using System.Collections.Generic;
using System.Text;
using SystemDotDb.Infrastructure;
using SystemDotDb.Infrastructure.Files;
using Microsoft.Isam.Esent.Interop;

namespace SystemDotDb.Esent
{
    public class EsentDocumentStore : Disposable, IDocumentStore
    {
        const string DatabaseName = "Document";
        const string FilesFolder = "DocumentDb";
        
        readonly IFileSystem fileSystem;
        
        Instance instance;

        public EsentDocumentStore(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
        }

        public void Initialise()
        {
            instance = new Instance(string.Empty);

            instance.Parameters.MaxVerPages = 1024;
            instance.Parameters.LogFileDirectory = FilesFolder;
            instance.Parameters.TempDirectory = FilesFolder;
            instance.Parameters.SystemDirectory = FilesFolder;
            instance.Parameters.CreatePathIfNotExist = true;

            instance.Init();

            using (var session = new Session(this.instance))
                if (!fileSystem.FileExists(GetDatabaseFileName())) 
                    CreateDatabaseAndTables(session, GetDatabaseFileName());            
        }
        
        string GetDatabaseFileName()
        {
            return DatabaseName;
        }

        static void CreateDatabaseAndTables(Session session, string databaseName)
        {
            CreateTables(Esent.CreateDatabase(session, databaseName), session);
        }

        static void CreateTables(JET_DBID dbId, JET_SESID session)
        {
            using (var transaction = new Transaction(session))
            {
                JET_TABLEID tableId = Esent.CreateTable(dbId, session, DocumentStoreTable.Name);

                Esent.AddColumn(session, tableId, DocumentStoreTable.IdColumn, JET_coltyp.Text, JET_CP.Unicode);
                Esent.AddColumn(session, tableId, DocumentStoreTable.VersionColumn, JET_coltyp.Long, JET_CP.None, ColumndefGrbit.ColumnAutoincrement);
                Esent.AddColumn(session, tableId, DocumentStoreTable.BodyColumn, JET_coltyp.LongText, JET_CP.Unicode);
                
                string keyDescription = string.Format("+{0}\0+{1}\0\0", DocumentStoreTable.IdColumn, DocumentStoreTable.VersionColumn);
                Esent.CreateIndex(session, tableId, DocumentStoreTable.Index, keyDescription);
                
                Esent.CloseTable(session, tableId);

                transaction.Commit(CommitTransactionGrbit.None);
            }
        }

        public void StoreDocumentBody(string id, byte[] body)
        {
            using (var session = new Session(instance))
            {
                StoreDocumentBody(session, id, body);
            }
        }

        void StoreDocumentBody(Session session, string changeRootId, byte[] body)
        {
            JET_DBID dbId = Esent.OpenDatabase(session, GetDatabaseFileName());

            using (var table = new Table(session, dbId, DocumentStoreTable.Name, OpenTableGrbit.None))
            {
                var columns = Esent.GetColumns(session, table);

                using (var transaction = new Transaction(session))
                {
                    StoreDocumentBody(session, table, columns, changeRootId, body);
                    transaction.Commit(CommitTransactionGrbit.None);
                }
            }
        }

        void StoreDocumentBody(Session session, Table table, IDictionary<string, JET_COLUMNID> columns, string id, byte[] body)
        {
            using (var update = new Update(session, table, JET_prep.Insert))
            {
                Esent.SetColumn(session, table, columns[DocumentStoreTable.IdColumn], id, Encoding.Unicode);
                Esent.SetColumn(session, table, columns[DocumentStoreTable.BodyColumn], body);
                
                update.Save();
            }
        }

        public byte[] GetDocumentBody(string id)
        {                    
            using (var session = new Session(instance))
            {
                JET_DBID dbId = Esent.OpenDatabase(session, GetDatabaseFileName());

                using (var table = new Table(session, dbId, DocumentStoreTable.Name, OpenTableGrbit.None))
                    return GetDocumentBody(id, session, table);                
            }
        }

        byte[] GetDocumentBody(string id, Session session, Table table)
        {
            IDictionary<string, JET_COLUMNID> columns = Esent.GetColumns(session, table);

            Esent.UseIndex(session, table, DocumentStoreTable.Index);
            
            Esent.SetFirstSearchKey(session, table, id, Encoding.Unicode);
            Esent.SetSearchKey(session, table, int.MaxValue);

            if(!Esent.TrySearchForLessThanKey(session, table))
                return new byte[0];

            //Esent.TryMoveNext(session, table);

            return Esent.RetrieveBytesFromColumn(session, table, columns[DocumentStoreTable.BodyColumn]);
        }

        protected override void DisposeOfManagedResources()
        {
            instance.Dispose();
            base.DisposeOfManagedResources();
        }
    }
}