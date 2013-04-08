using System;
using System.Timers;
using Hik.NDist.Services;

namespace Hik.Sms
{
    public class SmsService: NDistService
    {
        private readonly Timer _timer;

        public SmsService()
        {
            _timer = new Timer(1500);
            _timer.Elapsed += _timer_Elapsed;
        }

        protected override void InstallService()
        {
            Console.WriteLine("Installed SmsService service!");
        }

        protected override void UninstallService()
        {
            Console.WriteLine("Uninstalled SmsService service!");
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
            Console.WriteLine("SmsService - tick!");
        }
    }
}
