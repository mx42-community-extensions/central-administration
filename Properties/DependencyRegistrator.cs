using CentralAdministration.BizLogic;
using CentralAdministration.BizLogic.EntityBehaviour;
using CentralAdministration.Contracts.DataContracts.ServiceContracts;
using CentralAdministration.Services;
using Matrix42.Hosting.Contracts;
using Matrix42.Persistence.Contracts;

namespace CentralAdministration.Properties
{
    public class DependencyRegistrator : DependencyRegistratorBase, IDependencyRegistrator
    {
        public void Register(IDependencyContainer container, IDependencyResolver resolver)
        {
            container.RegisterSingletonType<ILicensingService, LicensingService>();
            container.RegisterSingletonType<IVendorManager, VendorManager>();
            container.RegisterSingletonType<IExtensionRepository, ExtensionRepository>();
            resolver.Get<IEntityBehaviorProvider>().Register(new CentralAdministrationRegistrationBehaviour(resolver), "CAExtensionTypeCentralAdministration");
        }
    }
}
