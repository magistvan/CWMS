using System;

namespace Project.Exceptions
{
    class RepositoryException : Exception
    {
        public RepositoryException(String message) : base(message) { }
    }
}
