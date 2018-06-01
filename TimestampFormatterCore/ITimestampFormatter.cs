using System;

namespace Ender.TimestampFormatterCore
{
    public interface ITimestampFormatter
    {
        string Format(DateTime timestamp);
    }
}
