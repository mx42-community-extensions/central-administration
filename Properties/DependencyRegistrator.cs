using CentralAdministration.Contracts.ServiceContracts;
using CentralAdministration.Services;
using Matrix42.Hosting.Contracts;

namespace CentralAdministration.Properties
{
    public class DependencyRegistrator : DependencyRegistratorBase, IDependencyRegistrator
    {
        public void Register(IDependencyContainer container, IDependencyResolver resolver)
        {
            container.RegisterSingletonType<ILicensingService, LicensingService>();
            container.RegisterSingletonType<ICentralAdministrationService, CentralAdministrationService>();
        }
    }
}
