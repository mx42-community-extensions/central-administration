using CentralAdministration.Contracts.DataContracts;
using CentralAdministration.Services;
using System;

namespace CentralAdministration.BizLogic
{
    public class LicensingService : ILicensingService
    {
        public License GetLicense(Guid extensionId)
        {
            return new License();
        }

        public License GetLicense(string license)
        {
            return new License();
        }

        public bool IsLicensed(Guid extensionId)
        {
            return false;
        }
    }
}