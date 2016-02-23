using System;
using System.Collections.Generic;
using Jil;
using Newtonsoft.Json;
using Xunit;

namespace Benchmarks.Tests
{
    public class SerializationTests
    {
        private Person personToSerialize;

        public SerializationTests()
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

        [Fact]
        public void DeserializationTests()
        {
            var bondSerialized = BenchmarksHelper.SerializeBond(personToSerialize);
            var protobufSerialized = BenchmarksHelper.SerializeProtobuf(personToSerialize);
            var jsonNetSerialized = JsonConvert.SerializeObject(personToSerialize);
            var jsonJilSerialized = JSON.Serialize(personToSerialize);
            var bondDeserialized = BenchmarksHelper.DeserializeBond<Person>(bondSerialized);
            var protobufDeserialized = BenchmarksHelper.DeserializeProtobuf<Person>(protobufSerialized);
            var jsonNetDeserialized = JsonConvert.DeserializeObject<Person>(jsonNetSerialized);
            var jsonJilDeserialized = JSON.Deserialize<Person>(jsonJilSerialized);
            var jsonNetBuffersSerialized = BenchmarksHelper.SerializeJsonNetBuffers(personToSerialize);
            var jsonNetBuffersDeserialized = BenchmarksHelper.DeserializeJsonNetBuffers<Person>(jsonNetBuffersSerialized);
            Assert.Equal(personToSerialize, bondDeserialized);
            Assert.Equal(personToSerialize, protobufDeserialized);
            Assert.Equal(personToSerialize, jsonNetDeserialized);
            Assert.Equal(personToSerialize, jsonJilDeserialized);
            Assert.Equal(personToSerialize, jsonNetBuffersDeserialized);
        }
    }
}
