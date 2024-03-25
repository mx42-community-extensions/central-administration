using CentralAdministration.Contracts.DataContracts;
using CentralAdministration.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using update4u.SPS.DataLayer;

namespace CentralAdministration.BizLogic
{
    public class VendorManager : IVendorManager, IDisposable
    {
        private static readonly Vendor[] vendors =
        {
            new Vendor (Guid.Parse("b78d9fa5-26fe-4ebd-9c3a-ae2e7f084d53"),"Labtagon GmbH","Labtagon"),
            new Vendor (Guid.Parse("a0ff55a3-9c8f-4b3c-9395-a76454804a3f"),"Innomea GmbH","Innomea")
        };

        private HttpClient client = new HttpClient();

        public RegistrationResult Register(Guid[] vendorIds, string vendorCustomerReference)
        {
            RegistrationDetails reigstrationDetails = GetRegistrationDetails();
            string body = JsonConvert.SerializeObject(reigstrationDetails);
            StringContent content = new StringContent(body, Encoding.UTF8, "application/json");
            ///
            foreach (Guid vendorid in vendorIds)
            {
                Vendor vendor = GetVendor(vendorid);
                Uri url = vendor.GetRegistrationUrl();
                client.PostAsync(url.ToString(), content);
            }
            throw new NotImplementedException();
        }

        private RegistrationDetails GetRegistrationDetails()
        {
            FragmentRequestBase fragmentRequest = new FragmentRequestBase(SPSDataEngineSchemaReader.ClassGetIDFromName("CAExtensionClassCentralAdministration"), ColumnSelectOption.All, null);
            fragmentRequest.IsSecured = update4u.SPS.DataLayer.Security.IsSecured.Unsecured;
            fragmentRequest.Where = "1=1";
            fragmentRequest.Load();
            if (fragmentRequest.DataSet.Tables[0].Rows.Count != 1) return null;
            RegistrationDetails registrationDetails = new RegistrationDetails();

            DataRow row = fragmentRequest.DataSet.Tables[0].Rows[0];
            registrationDetails.ContactPhone = row.Field<string>("ContactPhone");
            registrationDetails.ContactEmail = row.Field<string>("ContactEmail");
            registrationDetails.CompanyName = row.Field<string>("CompanyName");
            registrationDetails.ContactPhone = row.Field<string>("ContactPhone");
            registrationDetails.M42CustomerNumber = row.Field<string>("M42CustomerNumber");
            return registrationDetails;

        }

        public Vendor GetVendor(Guid vendorId)
        {
            return vendors.FirstOrDefault(v => v.Id == vendorId);
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
