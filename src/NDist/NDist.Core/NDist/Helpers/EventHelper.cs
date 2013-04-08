using System;

namespace Hik.NDist.Helpers
{
    public static class EventHelper
    {
        public static void Invoke<TEventArgs>(EventHandler<TEventArgs> handler, object source, TEventArgs eventArgs) 
            where TEventArgs : EventArgs
        {
            if (handler != null)
            {
                handler(source, eventArgs);
            }
        }
    }
}