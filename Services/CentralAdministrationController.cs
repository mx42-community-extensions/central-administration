using CentralAdministration.Contracts.DataContracts;
using CentralAdministration.Contracts.DataContracts.ServiceContracts;
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

        public CentralAdministrationController(
            IExtensionRepository extensionRepository,
            IVendorManager vendorManager
            )
        {
            this.extensionRepository = extensionRepository;
            this.vendorManager = vendorManager;
        }

        [HttpGet]
        [Route("Extensions")]
        public Extension[] GetInstalledExtensions()
            => extensionRepository.GetInstalledExtensions();


        [HttpPost]
        [Route("Register")]
        [ServiceReturnType(typeof(RegistrationResult))]

        public async Task<RegistrationResult> Register(Guid[] vendorIds, string vendorCustomerReference)
            => await vendorManager.Register(vendorIds, vendorCustomerReference);
    }
}
