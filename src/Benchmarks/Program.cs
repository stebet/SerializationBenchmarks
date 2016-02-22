using BenchmarkDotNet.Running;

namespace Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var switcher = new BenchmarkSwitcher(new[] { typeof(ProtobufVsBondVsJsonNetVsJilSerialization), typeof(ProtobufVsBondVsJsonNetVsJilDeserialization) });
            switcher.Run(args);
        }
    }
}
