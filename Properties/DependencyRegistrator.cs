using Matrix42.Hosting.Contracts;

namespace CentralAdministration.Properties
{
    public class DependencyRegistrator : DependencyRegistratorBase, IDependencyRegistrator
    {
        public void Register(IDependencyContainer container, IDependencyResolver resolver)
        {
            //Here be magic
        }
    }
}
