using System;

namespace SystemDot.Db
{
    public class Db
    {
        static DocumentDb current;

        public static void Store(Guid id, object toStore)
        {
            current.Store(id, toStore);
        }

        public static T GetById<T>(Guid id)
        {
            return current.GetById<T>(id);
        }

        public static void Initialise(DocumentDb documentDb)
        {
            documentDb.Initialise();
            current = documentDb;

        }
    }
}