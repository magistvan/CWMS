using System;

namespace Project.Exceptions
{
    class ControllerException : Exception
    {
        public ControllerException(String message) : base(message) { }
    }
}
