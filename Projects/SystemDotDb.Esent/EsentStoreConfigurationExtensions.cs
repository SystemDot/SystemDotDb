using SystemDotDb;
using SystemDotDb.Configuration;
using SystemDotDb.Infrastructure.Ioc;

namespace SystemDot.Esent
{
    public static class EsentStoreConfigurationExtensions
    {
        public static DocumentDbConfiguration UsingEsentPersistence(this DocumentDbConfiguration configuration)
        {
            IIocContainer container = configuration.GetInternalIocContainer();

            container.RegisterInstance<IDocumentStore, EsentDocumentStore>();

            return configuration;
        }
    }
}