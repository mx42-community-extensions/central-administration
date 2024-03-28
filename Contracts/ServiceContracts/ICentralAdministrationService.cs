using CentralAdministration.Contracts.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralAdministration.Contracts.ServiceContracts
{
    public interface ICentralAdministrationService
    {
        void SaveRegistrationDetails(RegistrationDetail registrationDetail);
    }
}
