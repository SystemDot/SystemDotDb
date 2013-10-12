using System;
using System.Collections.Generic;

namespace StoreStuff
{
    public class BigObject
    {
        public List<Thing> Things { get; set; }

        public BigObject()
        {
            Things = new List<Thing>();
        }

        public void AddThing(int id, string hello, DateTime now, string whatever, string otherThing, int otherId)
        {
            Things.Add(new Thing(id, hello, now, whatever, otherThing, otherId));
        }
    }
}