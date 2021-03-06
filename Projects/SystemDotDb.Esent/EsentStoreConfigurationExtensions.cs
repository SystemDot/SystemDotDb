using SystemDot.Configuration;
using SystemDotDb.Configuration;

namespace SystemDotDb.Esent
{
    public static class DocumentDbBuilderConfigurationExtensions
    {
        public static IBuilderConfiguration PersistToEsent(this DocumentDbBuilderConfiguration configuration)
        {
            configuration
                .GetBuilderConfiguration()
                .RegisterBuildAction(c => c.RegisterInstance<IDocumentStore, EsentDocumentStore>());

            return configuration.GetBuilderConfiguration();
        }
    }
}