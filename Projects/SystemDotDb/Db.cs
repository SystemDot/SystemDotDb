using System;
using SystemDotDb.Infrastructure.Ioc;

namespace SystemDotDb
{
    public class Db
    {
        public static void Store(Guid id, object toStore)
        {
            GetDocumentDb().Store(id, toStore);
        }

        public static T GetById<T>(Guid id)
        {
            return GetDocumentDb().GetById<T>(id);
        }

        static DocumentDb GetDocumentDb()
        {
            return IocContainerLocator.Locate().Resolve<DocumentDb>();
        }
    }
}