namespace Hik.NDist.Common
{
    /// <summary>
    /// Interface for modules those can be started and stopped.
    /// (Probably runs in it's own thread or perform periodic tasks).
    /// </summary>
    public interface IRunnable
    {
        /// <summary>
        /// Starts the module.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the module.
        /// </summary>
        void Stop();
    }
}