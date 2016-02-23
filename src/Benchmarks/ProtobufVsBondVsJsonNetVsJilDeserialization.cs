using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnostics;
using Jil;
using Newtonsoft.Json;

namespace Benchmarks
{
    [Config(typeof(Config))]
    public class ProtobufVsBondVsJsonNetVsJilDeserialization
    {
        Person personToSerialize;
        byte[] personProtobuf;
        byte[] personBond;
        string personJsonNet;
        string personJsonJil;
        string personJsonNetBuffers;


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

            personBond = BenchmarksHelper.SerializeBond(personToSerialize);
            personProtobuf = BenchmarksHelper.SerializeProtobuf(personToSerialize);
            personJsonNet = JsonConvert.SerializeObject(personToSerialize);
            personJsonJil = Jil.JSON.Serialize(personToSerialize);
            personJsonNetBuffers = BenchmarksHelper.SerializeJsonNetBuffers(personToSerialize);
        }

        [Benchmark]
        public void ProtobufDeserialize()
        {
            BenchmarksHelper.DeserializeProtobuf<Person>(personProtobuf);
        }

        [Benchmark]
        public void BondDeserialize()
        {
            BenchmarksHelper.DeserializeBond<Person>(personBond);
        }

        [Benchmark(Baseline = true)]
        public void JsonNetDeserialization()
        {
            JsonConvert.DeserializeObject<Person>(personJsonNet);
        }

        [Benchmark]
        public void JsonJilDeserialization()
        {
            JSON.Deserialize<Person>(personJsonJil);
        }

        [Benchmark]
        public void JsonNetWithBuffersDeserialization()
        {
            BenchmarksHelper.DeserializeJsonNetBuffers<Person>(personJsonNetBuffers);
        }
    }
}
