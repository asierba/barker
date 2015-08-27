using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Barkert.Tests
{
    public static class WindsorContainerExtensions
    {
        public static void OverrideRegister<T>(this WindsorContainer container, T instance)
            where T : class
        {
            container.Register(
                Component.For<T>()
                    .UsingFactoryMethod(x => instance)
                    .IsDefault()
                    .Named("Override for " + typeof(T))
                );
        }
    }
}