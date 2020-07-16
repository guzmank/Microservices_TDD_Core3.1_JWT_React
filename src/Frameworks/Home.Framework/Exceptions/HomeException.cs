using System;
using System.Collections.Generic;
using System.Text;

namespace Home.Framework.Exceptions
{
    public abstract class HomeException : Exception
    {
        public HomeException(string message)
            : base(message)
        { }

        public abstract int ErrorCode { get; }
    }


}
