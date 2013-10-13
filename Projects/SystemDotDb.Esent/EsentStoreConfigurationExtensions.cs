using SystemDotDb.Configuration;
using SystemDotDb.Infrastructure.Ioc;

namespace SystemDotDb.Esent
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