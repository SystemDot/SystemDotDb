using System;

namespace SystemDotDb.Infrastructure.Ioc
{
    public class TypeNotRegisteredException : Exception
    {
        public TypeNotRegisteredException(string message) : base(message)
        {
        }
    }
}