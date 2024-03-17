using CentralAdministration.Contracts.DataContracts;
using CentralAdministration.Contracts.DataContracts.ServiceContracts;
using System;
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


        [HttpGet]
        [Route("Register")]
        public RegistrationResult Register(Guid vendorId, string vendorCustomerReference)
            => vendorManager.Register(vendorId, vendorCustomerReference);
    }
}
