using System;
using Hik.NDist.Exceptions;

namespace Hik.NDist.Services.Controller
{
    public class NDistServiceNotFoundException : NDistException
    {
        public NDistServiceNotFoundException(string message = null, Exception innerException = null)
            : base(message, innerException)
        {

        }
    }
}