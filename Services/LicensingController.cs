using CentralAdministration.Contracts.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CentralAdministration.Services
{
    [RoutePrefix("api/CentralAdministration/Licensing")]
    public class LicensingController : ApiController
    {
        private readonly ILicensingService licensingService;

        public LicensingController(ILicensingService licensingService)
        {
            this.licensingService = licensingService;
        }
    }
}
