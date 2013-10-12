using System;

namespace SystemDotDb.Infrastructure.Ioc
{
    public interface IIocResolver
    {
        TPlugin Resolve<TPlugin>() where TPlugin : class;

        object Resolve(Type type);

        bool ComponentExists<TPlugin>();
    }
}