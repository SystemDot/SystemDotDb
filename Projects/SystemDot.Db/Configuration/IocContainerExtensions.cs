using SystemDot.Ioc;

namespace SystemDot.Db.Configuration
{
    public static class IocContainerExtensions
    {
        internal static void RegisterDocumentDb(this IIocContainer container)
        {
            container.RegisterFromAssemblyOf<DocumentDb>();
        }

        internal static DocumentDb ResolveDocumentDb(this IIocContainer container)
        {
            return container.Resolve<DocumentDb>();
        }
    }
}