using SystemDotDb.Infrastructure.Ioc;

namespace SystemDotDb.Configuration
{
    public class DocumentDbConfiguration
    {
        public IIocContainer GetInternalIocContainer()
        {
            return IocContainerLocator.Locate();
        }

        public void Initialise()
        {
            GetInternalIocContainer().RegisterFromAssemblyOf<IIocContainer>();
            GetInternalIocContainer().RegisterFromAssemblyOf<DocumentDb>();

            GetInternalIocContainer().Resolve<IDocumentStore>().Initialise();
        }
    }
}