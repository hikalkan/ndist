namespace Hik.NDist.Common
{
    /// <summary>
    /// Represents states of an IInstallable module.
    /// </summary>
    public enum InstallStatus
    {
        /// <summary>
        /// Module is being installed.
        /// </summary>
        Installing,

        /// <summary>
        /// Module is installed.
        /// </summary>
        Installed,
        
        /// <summary>
        /// Module is being uninstalled
        /// </summary>
        Uninstalling,

        /// <summary>
        /// Module is uninstalled.
        /// </summary>
        Uninstalled
    }
}