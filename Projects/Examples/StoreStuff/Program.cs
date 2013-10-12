using System;
using SystemDot.Esent;
using SystemDotDb;
using SystemDotDb.Configuration;

namespace StoreStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            Configure.DocumentDb()
                .UsingEsentPersistence()
                .Initialise();

            var id = new Guid("{3F17F2AB-C956-4BED-AE9F-C7092050FE56}");

            var bigObject = new BigObject();

            for (int i = 0; i < 1002; i++)
                bigObject.AddThing(i, "Hello", DateTime.Now, "Whatever", "OtherThing", i);

            Db.Store(id, bigObject);

            var biggy = Db.GetById<BigObject>(id);
        }
    }
}
