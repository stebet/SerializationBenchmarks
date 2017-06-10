|# SerializationBenchmarks
This is a small serialization benchmark using BenchmarkDotNet to benchmark Protobuf-net, MS Bond, Json.NET and JIL.

# Sample Serialization Results
```ini
BenchmarkDotNet-Dev=v0.9.1.0+
OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i5-5200U CPU @ 2.20GHz, ProcessorCount=4
Frequency=2143472 ticks, Resolution=466.5328 ns, Timer=TSC
HostCLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
JitModules=clrjit-v4.7.1507.0

Type=ProtobufVsBondVsJsonNetVsJilSerialization  Mode=Throughput  

```
|                         Method |    Median |    StdDev | Scaled |    Gen 0 | Gen 1 | Gen 2 | Memory Traffic/Op |
|-------------------------------:|----------:|----------:|-------:|---------:|------:|------:|------------------:|
|                  BondSerialize | 1.1578 us | 0.0921 us |   0.43 |   215.06 |     - |     - |           60.43 B |
|           JsonJilSerialization | 1.3678 us | 0.1129 us |   0.51 | 1,232.94 |     - |     - |          345.11 B |
|JsonNetSerializationWithBuffers | 3.0340 us | 0.1503 us |   1.13 | 1,915.00 |     - |     - |          539.05 B |
|           JsonNetSerialization | 2.6832 us | 0.0854 us |   1.00 | 2,120.25 |     - |     - |          593.48 B |
|              ProtobufSerialize | 1.5135 us | 0.0098 us |   0.56 |   397.50 |     - |     - |          111.33 B |

# Sample Deserialization Results
```ini
BenchmarkDotNet-Dev=v0.9.1.0+
OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i5-5200U CPU @ 2.20GHz, ProcessorCount=4
Frequency=2143472 ticks, Resolution=466.5328 ns, Timer=TSC
HostCLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
JitModules=clrjit-v4.7.1507.0

Type=ProtobufVsBondVsJsonNetVsJilDeserialization  Mode=Throughput  

```
|                           Method |        Median |      StdDev | Scaled |    Gen 0 | Gen 1 | Gen 2 | Memory Traffic/Op |
|---------------------------------:|--------------:|------------:|-------:|---------:|------:|------:|------------------:|
|                  BondDeserialize |   881.9879 ns |  27.1019 ns |   0.23 |   326.71 |     - |     - |          168.66 B |
|           JsonJilDeserialization | 1,372.2051 ns | 229.4886 ns |   0.36 |   256.91 |     - |     - |          134.03 B |
|           JsonNetDeserialization | 3,828.1784 ns | 164.9656 ns |   1.00 | 2,018.00 |     - |     - |        1,137.34 B |
|JsonNetWithBuffersDeserialization | 3,943.1226 ns | 410.8149 ns |   1.03 |   558.58 |     - |     - |          288.85 B |
|              ProtobufDeserialize | 2,024.1598 ns | 117.1558 ns |   0.53 |   306.97 |     - |     - |          158.26 B |
