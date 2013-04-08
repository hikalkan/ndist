using System;

namespace Hik.NDist.Exceptions
{
    public class NDistException : Exception
    {
        public NDistException(string message = null, Exception innerException = null)
            : base(message, innerException)
        {

        }
    }
}
