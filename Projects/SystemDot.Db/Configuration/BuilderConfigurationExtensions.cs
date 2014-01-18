using SystemDot.Configuration;
using SystemDot.Serialisation.Json.Configuration;

namespace SystemDot.Db.Configuration
{
    public static class BuilderConfigurationExtensions
    {
        public static DocumentDbBuilderConfiguration UseDocumentDb(this IBuilderConfiguration config)
        {
            config.RegisterBuildAction(c => c.RegisterJsonSerialisation());
            config.RegisterBuildAction(c => c.RegisterDocumentDb());
            config.RegisterBuildAction(c => Db.Initialise(c.ResolveDocumentDb()), BuildOrder.SystemOnlyLast);
            return new DocumentDbBuilderConfiguration(config);
        }
    }
}