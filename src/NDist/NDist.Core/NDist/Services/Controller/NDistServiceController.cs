using System;
using System.Collections.Generic;
using System.Linq;
using Hik.Collections;
using Hik.NDist.Common;
using Hik.NDist.Config;
using Hik.NDist.Helpers;

namespace Hik.NDist.Services.Controller
{
    internal class NDistServiceController : INDistServiceController
    {
        private readonly NDistConfig _config;

        #region Public events

        public event EventHandler<ServiceRunningStatusChangedEventArgs> ServiceRunningStatusChanged;

        #endregion

        #region Private fields

        private readonly ControlledServiceList _controlledServices;

        #endregion

        #region Constructor

        public NDistServiceController(NDistConfig config)
        {
            _config = config;
            _controlledServices = new ControlledServiceList();
        }

        #endregion

        #region Public methods

        public INDistServiceHost GetService(string name)
        {
            return _controlledServices.Get(name).Host;
        }

        public INDistServiceHost GetServiceOrNull(string name)
        {
            var service = _controlledServices.GetOrNull(name);
            return service == null ? null : service.Host;
        }

        public void StartService(string serviceName)
        {
            _controlledServices.Get(serviceName).Host.Service.Start();
        }

        public void StopService(string serviceName)
        {
            _controlledServices.Get(serviceName).Host.Service.Stop();
        }

        public List<NDistServiceHost> GetServiceList()
        {
            return _controlledServices.GetAllItems().Select(cs => cs.Host).ToList();
        }

        public void Start()
        {
            var serviceHosts = _config.Services.Select(service => new NDistServiceHost(_config, service)).ToList();
            foreach (var serviceHost in serviceHosts)
            {
                _controlledServices[serviceHost.ServiceEntry.Name] = new ControlledService(this, serviceHost);
            }

            foreach (var controlledService in _controlledServices.GetAllItems())
            {
                controlledService.Host.Load();
                controlledService.Initialize();
                controlledService.Host.Service.Start();
            }
        }

        public void Stop()
        {
            foreach (var controlledService in _controlledServices.GetAllItems())
            {
                controlledService.Host.Service.Stop();
                controlledService.Host.Unload();
            }
        }

        #endregion

        #region Protected/Private methods

        protected virtual void OnServiceRunningStatusChanged(INDistServiceHost serviceHost)
        {
            EventHelper.Invoke(ServiceRunningStatusChanged, this, new ServiceRunningStatusChangedEventArgs(serviceHost));
        }

        #endregion

        #region Nested classes

        #region class ControlledServiceList

        private class ControlledServiceList : ThreadSafeSortedList<string, ControlledService>
        {
            public ControlledService Get(string name)
            {
                if (!ContainsKey(name))
                {
                    throw new NDistServiceNotFoundException("Can not found service: " + name);
                }

                return this[name];
            }

            public ControlledService GetOrNull(string name)
            {
                if (!ContainsKey(name))
                {
                    return null;
                }

                return this[name];
            }
        }

        #endregion

        #region class ControlledService

        private class ControlledService : MarshalByRefObject
        {
            public NDistServiceHost Host { get; private set; }

            private readonly NDistServiceController _controller;

            public ControlledService(NDistServiceController controller, NDistServiceHost host)
            {
                _controller = controller;
                Host = host;
            }

            public void Initialize()
            {
                Host.Service.RunningStatusChanged += Service_RunningStatusChanged;
            }

            private void Service_RunningStatusChanged(object sender, RunningStatusChangedEventArgs e)
            {
                _controller.OnServiceRunningStatusChanged(Host);
            }
        }

        #endregion

        #endregion
    }
}