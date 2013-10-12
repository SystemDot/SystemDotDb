using System;

namespace StoreStuff
{
    public class Thing
    {
        public int Id { get; set; }
        public string Hello { get; set; }
        public DateTime Now { get; set; }
        public string Whatever { get; set; }
        public string OtherThing { get; set; }
        public int OtherId { get; set; }

        public Thing()
        {
        }

        public Thing(int id, string hello, DateTime now, string whatever, string otherThing, int otherId)
        {
            Id = id;
            Hello = hello;
            Now = now;
            Whatever = whatever;
            OtherThing = otherThing;
            OtherId = otherId;
        }
    }
}