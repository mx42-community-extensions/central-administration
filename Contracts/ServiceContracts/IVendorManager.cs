using CentralAdministration.Contracts.DataContracts;
using System;
using System.Threading.Tasks;

namespace CentralAdministration.Services
{
    public interface IVendorManager
    {
        Task<RegistrationResult> Register(Guid[] vendorIds, string vendorCustomerReference);
    }
}