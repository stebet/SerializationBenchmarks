using System;

namespace Benchmarks
{
    public static class BondTypeAliasConverter
    {
        public static long Convert(DateTime value, long unused) => value.Ticks;
        public static DateTime Convert(long value, DateTime unused) => new DateTime(value);
    }
}
