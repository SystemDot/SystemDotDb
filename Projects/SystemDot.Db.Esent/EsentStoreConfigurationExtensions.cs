using SystemDot.Configuration;
using SystemDot.Db.Configuration;
using SystemDot.Files.Windows.Configuration;
using SystemDot.Serialisation.Json.Configuration;

namespace SystemDot.Db.Esent
{
    public static class DocumentDbBuilderConfigurationExtensions
    {
        public static IBuilderConfiguration PersistToEsent(this DocumentDbBuilderConfiguration configuration)
        {
            configuration
                .GetBuilderConfiguration()
                .RegisterBuildAction(c => c.RegisterFileSystem());

            configuration
                .GetBuilderConfiguration()
                .RegisterBuildAction(c => c.RegisterJsonSerialisation());
            
            configuration
                .GetBuilderConfiguration()
                .RegisterBuildAction(c => c.RegisterInstance<IDocumentStore, EsentDocumentStore>());

            return configuration.GetBuilderConfiguration();
        }
    }
}