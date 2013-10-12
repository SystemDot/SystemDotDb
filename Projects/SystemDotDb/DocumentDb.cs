using System;
using SystemDotDb.Infrastructure;
using SystemDotDb.Infrastructure.Serialisation;

namespace SystemDotDb
{
    public class DocumentDb
    {
        readonly IDocumentStore store;
        readonly ISerialiser serialiser;

        public DocumentDb(IDocumentStore store, ISerialiser serialiser)
        {
            this.store = store;
            this.serialiser = serialiser;
        }

        public void Store(Guid id, object toStore)
        {
            store.StoreDocumentBody(id.ToString(), serialiser.Serialise(toStore));
        }

        public T GetById<T>(Guid id)
        {
            return serialiser.Deserialise(store.GetDocumentBody(id.ToString())).As<T>();
        }
    }
}