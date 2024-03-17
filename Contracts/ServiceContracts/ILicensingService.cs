using CentralAdministration.Contracts.DataContracts;
using System;

namespace CentralAdministration.Services
{
    public interface ILicensingService
    {
        License GetLicense(Guid extensionId);
        License GetLicense(string license);

        bool IsLicensed(Guid extensionId);
    }
}