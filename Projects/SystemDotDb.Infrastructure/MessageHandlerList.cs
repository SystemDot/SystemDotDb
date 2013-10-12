using System.Collections.Concurrent;

namespace SystemDotDb.Infrastructure
{
    public class MessageHandlerList : ConcurrentDictionary<object, object>
    {
    }
}