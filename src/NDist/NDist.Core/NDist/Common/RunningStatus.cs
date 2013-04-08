namespace Hik.NDist.Common
{
    /// <summary>
    /// Represents states of an IRunnable module.
    /// </summary>
    public enum RunningStatus
    {
        /// <summary>
        /// Module is being started.
        /// </summary>
        Starting,

        /// <summary>
        /// Module is started (and running).
        /// </summary>
        Started,
        
        /// <summary>
        /// Module is being stopped.
        /// </summary>
        Stopping,

        /// <summary>
        /// Module is stopped (not running).
        /// </summary>
        Stopped
    }
}