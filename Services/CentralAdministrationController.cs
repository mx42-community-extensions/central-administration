using CentralAdministration.Contracts.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CentralAdministration.Services
{
    [RoutePrefix("api/CentralAdministration")]
    public class CentralAdministrationController : ApiController
    {
        private readonly ICentralAdministrationService centralAdministrationService;

        public CentralAdministrationController(ICentralAdministrationService centralAdministrationService)
        {
            this.centralAdministrationService = centralAdministrationService;
        }
    }
}
