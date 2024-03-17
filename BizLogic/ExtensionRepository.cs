using CentralAdministration.Contracts.DataContracts;
using CentralAdministration.Contracts.DataContracts.ServiceContracts;
using CentralAdministration.Services;
using System;
using System.Collections.Generic;
using System.Data;
using update4u.SPS.DataLayer;

namespace CentralAdministration.BizLogic
{
    public class ExtensionRepository : IExtensionRepository
    {
        private readonly ILicensingService licensingService;

        public ExtensionRepository(ILicensingService licensingService)
        {
            this.licensingService = licensingService;
        }

        public Extension[] GetInstalledExtensions()
        {
            List<Extension> extensions = new List<Extension>();

            FragmentRequestBase fragmentRequest = new FragmentRequestBase(SPSDataEngineSchemaReader.ClassGetIDFromName("CAExtension"), ColumnSelectOption.All, null);
            fragmentRequest.IsSecured = update4u.SPS.DataLayer.Security.IsSecured.Unsecured;
            fragmentRequest.Where = "1=1";
            fragmentRequest.Load();

            foreach(DataRow row in fragmentRequest.DataSet.Tables[0].Rows)
            {
                Extension extension = new Extension();

                extension.Id = row.Field<Guid>("Id");
                extension.License = licensingService.GetLicense(row.Field<string>("License"));
                extension.Package = GetPackage(extension.Id);
                extensions.Add(extension);
            }

            return extensions.ToArray();
        }

        private Package GetPackage(Guid packageId)
        {
            FragmentRequestBase fragmentRequest = new FragmentRequestBase(SPSDataEngineSchemaReader.ClassGetIDFromName("PDRConfigurationPackageClassBase"), ColumnSelectOption.All, null);
            fragmentRequest.IsSecured = update4u.SPS.DataLayer.Security.IsSecured.Unsecured;
            fragmentRequest.Where = "PackageId = @PackageId";
            fragmentRequest.AsqlParameters.Add("@PackageId", packageId);
            fragmentRequest.Load();

            if (fragmentRequest.DataSet.Tables[0].Rows.Count != 1) return null;

            Package package = new Package();

            DataRow row = fragmentRequest.DataSet.Tables[0].Rows[0];
            package.UpdatedBy = row.Field<Guid>("UpdatedBy");
            package.Name = row.Field<string>("Name");
            package.InstalledDate = row.Field<DateTime>("InstalledDate");
            package.LastUpdatedDate = row.Field<DateTime>("LastUpdatedDate");
            package.Description = row.Field<string>("Description");
            return package;
        }
    }
}
