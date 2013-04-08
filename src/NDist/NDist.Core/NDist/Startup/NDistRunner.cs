using System;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.MicroKernel.Registration;
using Hik.NDist.Common;
using Hik.NDist.Config;

namespace Hik.NDist.Startup
{
    /// <summary>
    /// This class is the first class that is used to start/stop the system.
    /// </summary>
    internal class NDistRunner : IRunnable, IDisposable
    {
        private WindsorContainer _windsorContainer;

        public void Start()
        {
            _windsorContainer = new WindsorContainer();

            _windsorContainer.Register(
                Component.For<NDistConfig>().UsingFactoryMethod(() => new NDistConfigProcessor().Load()).LifestyleSingleton()
                );

            _windsorContainer.Install(FromAssembly.This());
            _windsorContainer.Resolve<NDistServer>().Start();
        }

        public void Stop()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (_windsorContainer != null)
            {
                _windsorContainer.Resolve<NDistServer>().Stop();
                _windsorContainer.Dispose();
                _windsorContainer = null;
            }
        }
    }
}