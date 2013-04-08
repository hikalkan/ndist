using System;

namespace Hik.NDist.Common
{
    /// <summary>
    /// Interface for modules those can be installed and uninstalled.
    /// </summary>
    public interface IInstallable
    {
        /// <summary>
        /// This event is raised when InstallStatus property has changed. 
        /// </summary>
        event EventHandler<InstallStatusChangedEventArgs> InstallStatusChanged;

        /// <summary>
        /// Used to get installation running status of the module.
        /// </summary>
        InstallStatus InstallStatus { get; }

        /// <summary>
        /// This method is called when this module needs to be installed.
        /// </summary>
        void Install();

        /// <summary>
        /// This method is called when this module needs to be uninstalled.
        /// </summary>
        void Uninstall();
    }
}