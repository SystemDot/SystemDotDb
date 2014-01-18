using SystemDot.Configuration;

namespace SystemDot.Db.Configuration
{
    public class DocumentDbBuilderConfiguration
    {
        readonly IBuilderConfiguration config;

        public DocumentDbBuilderConfiguration(IBuilderConfiguration config)
        {
            this.config = config;
        }

        public IBuilderConfiguration GetBuilderConfiguration()
        {
            return config;
        }
    }
}