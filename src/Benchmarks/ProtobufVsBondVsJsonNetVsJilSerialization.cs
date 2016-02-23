using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnostics;
using Jil;
using Newtonsoft.Json;

namespace Benchmarks
{
    [Config(typeof(Config))]
    public class ProtobufVsBondVsJsonNetVsJilSerialization
    {
        Person personToSerialize;

        private class Config : ManualConfig
        {
            public Config()
            {
                Add(new GCDiagnoser());
            }
        }

        [Setup]
        public void Setup()
        {
            personToSerialize = new Person()
            {
                FullName = "Stefán Jökull Sigurðarson",
                Birthday = new DateTime(1979, 11, 23),
                Tags = new Dictionary<string, string>
                {
                    { "Interest1", "Judo" },
                    { "Interest2", "Music" }
                }
            };
        }

        [Benchmark]
        public void ProtobufSerialize()
        {
            BenchmarksHelper.SerializeProtobuf(personToSerialize);
        }

        [Benchmark]
        public void BondSerialize()
        {
            BenchmarksHelper.SerializeBond(personToSerialize);
        }

        [Benchmark(Baseline = true)]
        public void JsonNetSerialization()
        {
            JsonConvert.SerializeObject(personToSerialize);
        }

        [Benchmark]
        public void JsonNetSerializationWithBuffers()
        {
            BenchmarksHelper.SerializeJsonNetBuffers(personToSerialize);
        }

        [Benchmark]
        public void JsonJilSerialization()
        {
            JSON.Serialize(personToSerialize);
        }
    }
}
