using System.Collections.Generic;
using System.Linq;
using Hik.Collections;
using Hik.Communication.ScsServices.Service;
using System;
using Hik.NDist.Exceptions;
using Hik.NDist.Management.Objects;
using Hik.NDist.Services;
using Hik.NDist.Services.Controller;
using System.Threading.Tasks;

namespace Hik.NDist.Management
{
    internal class NDistManagementService : ScsService, INDistManagementService
    {
        #region Private fields

        private readonly INDistServiceController _serviceController;

        private readonly ThreadSafeSortedList<long, ConnectedClient> _clients;

        #endregion

        #region Constructor

        public NDistManagementService(INDistServiceController serviceController)
        {
            _serviceController = serviceController;
            _serviceController.ServiceRunningStatusChanged += ServiceController_ServiceRunningStatusChanged;

            _clients = new ThreadSafeSortedList<long, ConnectedClient>();
        }

        #endregion

        #region INDistManagementService implementation

        public void Register()
        {
            var client = CurrentClient;

            lock (_clients)
            {
                if (_clients.ContainsKey(client.ClientId))
                {
                    throw new NDistException("Client has already registered. Register method must be called only once.");
                }

                var monitor = new ConnectedClient(client);
                monitor.Client.Disconnected += Client_Disconnected;

                _clients[client.ClientId] = monitor;
            }

            Console.WriteLine("Registered a new client: " + client.ClientId);
        }

        public List<ServiceInfo> GetAllServices()
        {
            Console.WriteLine("GetAllServices for client: " + CurrentClient.ClientId);
            return _serviceController.GetServiceList().Select(
                service => new ServiceInfo
                               {
                                   Name = service.ServiceEntry.Name,
                                   RunningStatus = service.Service.RunningStatus
                               }
                ).ToList();
        }

        public void StopService(string serviceName)
        {
            _serviceController.StopService(serviceName);
        }

        public void StartService(string serviceName)
        {
            _serviceController.StartService(serviceName);
        }

        #endregion

        #region Private methods

        private void ServiceController_ServiceRunningStatusChanged(object sender, ServiceRunningStatusChangedEventArgs e)
        {
            Task.Factory.StartNew(
                () =>
                    {
                        foreach (var client in _clients.GetAllItems())
                        {
                            try
                            {
                                client.Proxy.OnServiceRunningStatusChanged(
                                    new ServiceInfo
                                        {
                                            Name = e.ServiceHost.ServiceEntry.Name,
                                            RunningStatus = e.ServiceHost.Service.RunningStatus
                                        }
                                    );
                            }
                            catch
                            {
                                //TODO: log warning
                            }
                        }
                    });
        }

        private void Client_Disconnected(object sender, EventArgs e)
        {
            var client = (IScsServiceClient)sender;

            lock (_clients)
            {
                if (_clients.ContainsKey(client.ClientId))
                {
                    _clients.Remove(client.ClientId);
                }
            }

            Console.WriteLine("Disconnected a client: " + client.ClientId);
        }

        #endregion

        #region Nested classes

        private class ConnectedClient
        {
            public IScsServiceClient Client { get; private set; }

            public INDistManagementServiceClient Proxy { get; private set; }

            public ConnectedClient(IScsServiceClient client)
            {
                Client = client;
                Proxy = client.GetClientProxy<INDistManagementServiceClient>();
            }
        }

        #endregion
    }
}