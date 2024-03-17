using CentralAdministration.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralAdministration.Contracts.DataContracts.ServiceContracts
{
    public interface IExtensionRepository
    {
        Extension[] GetInstalledExtensions();
    }
}
