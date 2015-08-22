using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Barker.Infrastructure
{
    public class IocContainerSetup : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .Pick()
                .WithService.DefaultInterfaces()
                .LifestyleTransient());
        }
    }
}