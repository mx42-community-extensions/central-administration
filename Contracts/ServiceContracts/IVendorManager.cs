using CentralAdministration.Contracts.DataContracts;
using System;
using System.Threading.Tasks;

namespace CentralAdministration.Services
{
    public interface IVendorManager
    {
        Task<RegistrationResult> Register(Guid vendorId, string vendorCustomerReference);
    }
}