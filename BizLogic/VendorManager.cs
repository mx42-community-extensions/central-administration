using CentralAdministration.Contracts.DataContracts;
using CentralAdministration.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralAdministration.BizLogic
{
    public class VendorManager : IVendorManager
    {
        private static readonly Vendor[] vendors =
        {
            new Vendor (Guid.Parse("b78d9fa5-26fe-4ebd-9c3a-ae2e7f084d53"),"Labtagon GmbH","Labtagon"),
            new Vendor (Guid.Parse("a0ff55a3-9c8f-4b3c-9395-a76454804a3f"),"Innomea GmbH","Innomea")
        };

        public RegistrationResult Register(Guid vendorId, string vendorCustomerReference)
        {
            throw new NotImplementedException();
        }

        public Vendor GetVendor(Guid vendorId)
        {
            return vendors.FirstOrDefault(v => v.Id == vendorId);
        }
    }
}
