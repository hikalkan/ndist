using System.IO;
using Hik.NDist.Config;
using System;
using Hik.NDist.Services.Config;

namespace Hik.NDist.Services
{
    /// <summary>
    /// This class is used to host a service in NDist system.
    /// </summary>
    public class NDistServiceHost : INDistServiceHost
    {
        #region Public properties

        public string RootPath { get; private set; }

        public NDistService Service { get; private set; }

        public ServiceEntry ServiceEntry { get; private set; }

        public NDistServiceConfig ServiceConfig { get; private set; }

        #endregion

        #region Private fields

        private readonly NDistConfig _config;

        private AppDomain _appDomain;

        #endregion

        #region Constructor

        public NDistServiceHost(NDistConfig config, ServiceEntry serviceConfig)
        {
            _config = config;
            ServiceEntry = serviceConfig;
            RootPath = Path.Combine(_config.GetSetting("DefaultServicePath").Value, serviceConfig.Name);
        }

        #endregion

        #region Public methods

        public void Load()
        {
            _appDomain = AppDomain.CreateDomain(ServiceEntry.Name + "ServiceDomain", null, RootPath, null, false);
            ServiceConfig = new NDistServiceConfigReader(Path.Combine(RootPath, "NDistServiceConfig.xml")).Read();
            Service = (NDistService)_appDomain.CreateInstanceAndUnwrap(ServiceConfig.Service.AssemblyName, ServiceConfig.Service.TypeName);
        }

        public void Unload()
        {
            AppDomain.Unload(_appDomain);
        }

        #endregion
    }
}