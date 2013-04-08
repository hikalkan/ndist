using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Hik.NDist.Management;
using Hik.NDist.Services;
using Hik.NDist.Services.Controller;

namespace Hik.NDist.Dependency.Installers
{
    public class NDistMainInstaller : IWindsorInstaller
    {
        public virtual void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<INDistServiceController>().ImplementedBy<NDistServiceController>().LifestyleSingleton(),
                Component.For<INDistManagementService>().ImplementedBy<NDistManagementService>().LifestyleSingleton(),
                Component.For<INDistManagementServicesRunner>().ImplementedBy<NDistManagementServicesRunner>().LifestyleSingleton(),
                Component.For<NDistServer>().LifestyleSingleton()
                );
        }
    }
}