using Hik.NDist.Config;
using Hik.NDist.Services.Config;

namespace Hik.NDist.Services
{
    /// <summary>
    /// Defines interface to host a service in NDist system.
    /// </summary>
    public interface INDistServiceHost
    {
        /// <summary>
        /// Root path for the service files.
        /// </summary>
        string RootPath { get; }

        /// <summary>
        /// Reference to the service.
        /// </summary>
        NDistService Service { get; }

        ServiceEntry ServiceEntry { get; }

        NDistServiceConfig ServiceConfig { get; }

        /// <summary>
        /// Loads the service.
        /// </summary>
        void Load();

        /// <summary>
        /// Unloads the service.
        /// </summary>
        void Unload();
    }
}