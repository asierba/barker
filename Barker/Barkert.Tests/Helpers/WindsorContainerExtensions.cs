using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Barkert.Tests.Helpers
{
    public static class WindsorContainerExtensions
    {
        public static void OverrideRegister<T>(this WindsorContainer container, T instance)
            where T : class
        {
            var uniqueName = "Override for " + typeof(T) + Guid.NewGuid();
            container.Register(
                Component.For<T>()
                    .UsingFactoryMethod(x => instance)
                    .IsDefault()
                    .Named(uniqueName)
                );
        }
    }
}