using System;

namespace Ender.TimestampFormatter
{
    public interface ITimestampFormatter
    {
        string Format(DateTime timestamp);
    }
}
