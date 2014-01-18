using System;
using SystemDot.Core;
using SystemDot.Serialisation;

namespace SystemDot.Db
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

        public void Initialise()
        {
            store.Initialise();
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