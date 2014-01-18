using SystemDot.Configuration;

namespace SystemDot.Db.Configuration
{
    public static class BuilderConfigurationExtensions
    {
        public static DocumentDbBuilderConfiguration UseDocumentDb(this IBuilderConfiguration config)
        {
            config.RegisterBuildAction(c => c.RegisterDocumentDb());
            config.RegisterBuildAction(c => Db.Initialise(c.ResolveDocumentDb()), BuildOrder.SystemOnlyLast);
            return new DocumentDbBuilderConfiguration(config);
        }
    }
}