using System;
using SystemDot.Configuration;
using SystemDot.Db.Esent;
using SystemDot.Ioc;
using SystemDot.Db;
using SystemDot.Db.Configuration;

namespace StoreStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            Configure.SystemDot()
                .ResolveReferencesWith(new IocContainer())
                .UseDocumentDb().PersistToEsent()
                .Initialise();

            var id = new Guid("{3F17F2AB-C956-4BED-AE9F-C7092050FE56}");

            for (int i = 0; i < 1002; i++)
            {
                var bigObject = new BigObject();

                for (int k = 0; k < 1002; k++)
                    bigObject.AddThing(k, "Hello", DateTime.Now, "Whatever", "OtherThing", i);

                Console.WriteLine("Storing object {0}", i); 
                Db.Store(id, bigObject);
                Console.WriteLine("Stored object {0}", i);
            }

            Console.WriteLine("Getting last stored object"); 
            var lastOne = Db.GetById<BigObject>(id);
            Console.WriteLine("Got last stored object");
            Console.ReadLine();
        }
    }
}
