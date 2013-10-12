using System;

namespace SystemDotDb.Infrastructure
{
    public interface ISystemTime
    {
        DateTime GetCurrentDate();

        TimeSpan SpanFromSeconds(int seconds);
    }
}