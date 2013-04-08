using System;
using System.Timers;
using Hik.NDist.Services;

namespace Hik.DiskChecker
{
    public class DiskCheckerService : NDistService
    {
        private readonly Timer _timer;

        public DiskCheckerService()
        {
            _timer = new Timer(1000);
            _timer.Elapsed += _timer_Elapsed;
        }

        protected override void InstallService()
        {
            Console.WriteLine("Installed DiskCheckerService service!");
        }

        protected override void UninstallService()
        {
            Console.WriteLine("Uninstalled DiskCheckerService service!");
        }

        protected override void StartService()
        {
            _timer.Start();
        }

        protected override void StopService()
        {
            _timer.Stop();
        }

        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("DiskCheckerServiceBase - tick!");
        }
    }
}