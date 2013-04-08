using System;
using Hik.NDist.Common;
using Hik.NDist.Helpers;

namespace Hik.NDist.Services
{
    /// <summary>
    /// Base class for services that can be used in NDist system.
    /// </summary>
    public abstract class NDistService : MarshalByRefObject, IRunnable, IInstallable
    {
        #region Public events

        public event EventHandler<InstallStatusChangedEventArgs> InstallStatusChanged;

        public event EventHandler<RunningStatusChangedEventArgs> RunningStatusChanged;

        #endregion

        #region Public properties

        public InstallStatus InstallStatus
        {
            get { return _installStatus; }
            private set
            {
                _installStatus = value;
                OnInstallStatusChanged();
            }
        }
        private InstallStatus _installStatus;
        
        public RunningStatus RunningStatus
        {
            get { return _runningStatus; }
            private set
            {
                _runningStatus = value;
                OnRunningStatusChanged();
            }
        }
        private RunningStatus _runningStatus;

        #endregion

        #region Constructor

        protected NDistService()
        {
            RunningStatus = RunningStatus.Stopped;
        }

        #endregion

        #region Public methods

        public void Start()
        {
            RunningStatus = RunningStatus.Starting;

            StartService();

            RunningStatus = RunningStatus.Started;
        }

        public void Stop()
        {
            RunningStatus = RunningStatus.Stopping;

            StopService();

            RunningStatus = RunningStatus.Stopped;
        }

        public void Install()
        {
            InstallStatus = InstallStatus.Installing;

            InstallService();

            InstallStatus = InstallStatus.Installed;
        }

        public void Uninstall()
        {
            InstallStatus = InstallStatus.Uninstalling;

            UninstallService();

            InstallStatus = InstallStatus.Uninstalled;
        }

        #endregion

        #region Protected methods

        #region Virtual methods

        protected virtual void InstallService() { }

        protected virtual void UninstallService() { }

        #endregion

        #region Abstract methods

        protected abstract void StartService();

        protected abstract void StopService();

        #endregion

        #region Event raise methods

        protected virtual void OnRunningStatusChanged()
        {
            EventHelper.Invoke(RunningStatusChanged, this, new RunningStatusChangedEventArgs());
        }

        protected virtual void OnInstallStatusChanged()
        {
            EventHelper.Invoke(InstallStatusChanged, this, new InstallStatusChangedEventArgs());
        }

        #endregion

        #endregion
    }
}