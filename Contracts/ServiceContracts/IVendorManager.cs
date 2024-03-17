using CentralAdministration.Contracts.DataContracts;
using System;

namespace CentralAdministration.Services
{
    public interface IVendorManager
    {
        RegistrationResult Register(Guid vendorId, string vendorCustomerReference);
    }
}