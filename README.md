# SerializationBenchmarks
This is a small serialization benchmark using BenchmarkDotNet to benchmark Protobuf-net, MS Bond, Json.NET and JIL.

# Sample Results

```ini
BenchmarkDotNet-Dev=v0.9.1.0+
OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i5-5200U CPU @ 2.20GHz, ProcessorCount=4
Frequency=2143478 ticks, Resolution=466.5315 ns, Timer=TSC
HostCLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
JitModules=clrjit-v4.7.1507.0

Type=ProtobufVsBondVsJsonNetVsJilSerialization  Mode=Throughput  

```
               Method |    Median |    StdDev | Scaled |    Gen 0 | Gen 1 | Gen 2 | Memory Traffic/Op |
--------------------- |---------- |---------- |------- |--------- |------ |------ |------------------ |
        BondSerialize | 1.0878 us | 0.0536 us |   0.40 |   302.45 |     - |     - |           57.56 B |
 JsonJilSerialization | 1.3384 us | 0.0912 us |   0.49 | 1,709.01 |     - |     - |          320.45 B |
 JsonNetSerialization | 2.7340 us | 0.1916 us |   1.00 | 2,923.00 |     - |     - |          553.57 B |
    ProtobufSerialize | 1.4808 us | 0.0853 us |   0.54 |   520.69 |     - |     - |           98.76 B |
