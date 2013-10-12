namespace SystemDotDb
{
    public interface IDocumentStore
    {
        void Initialise();
        void StoreDocumentBody(string id, byte[] body);
        byte[] GetDocumentBody(string id);
    }
}