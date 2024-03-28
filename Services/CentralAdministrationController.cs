using CentralAdministration.Contracts.DataContracts;
using CentralAdministration.Contracts.DataContracts.ServiceContracts;
using CentralAdministration.Contracts.ServiceContracts;
using Matrix42.Services.Description.Contracts;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace CentralAdministration.Services
{
    [RoutePrefix("api/CentralAdministration")]
    public class CentralAdministrationController : ApiController
    {
        private readonly IExtensionRepository extensionRepository;
        private readonly IVendorManager vendorManager;
        private readonly ICentralAdministrationService centralAdministrationService;

        public CentralAdministrationController(
            IExtensionRepository extensionRepository,
            IVendorManager vendorManager,
            ICentralAdministrationService  centralAdministrationService
            )
        {
            this.extensionRepository = extensionRepository;
            this.vendorManager = vendorManager;
            this.centralAdministrationService = centralAdministrationService;
        }

        [HttpGet]
        [Route("Extensions")]
        public Extension[] GetInstalledExtensions()
            => extensionRepository.GetInstalledExtensions();


        [HttpPost]
        [Route("Register")]
        [ServiceReturnType(typeof(RegistrationResult))]

        public async Task<RegistrationResult> Register(Guid vendorId, string vendorCustomerReference)
            => await vendorManager.Register(vendorId, vendorCustomerReference);


        [HttpPost]
        [Route("SaveRegistrationDetails")]
       

        public void SaveRegistrationDetails(RegistrationDetail registrationDetail)
         =>  centralAdministrationService.SaveRegistrationDetails(registrationDetail);
    }
}
