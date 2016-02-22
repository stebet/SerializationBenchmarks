using System;
using System.Collections.Generic;
using System.Linq;
using Bond;
using ProtoBuf;

namespace Benchmarks
{
    [Schema]
    [ProtoContract]
    public partial class Person
    {
        [Id(0)]
        [ProtoMember(1)]
        public string FullName { get; set; }

        [Id(1), Type(typeof(long))]
        [ProtoMember(2)]
        public DateTime Birthday { get; set; }

        [Id(2)]
        [ProtoMember(3)]
        public Dictionary<string, string> Tags { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Person comparer = obj as Person;
            if (comparer == null)
            {
                return false;
            }

            return comparer.FullName == this.FullName &&
                   comparer.Birthday == this.Birthday &&
                   comparer.Tags.SequenceEqual(this.Tags);
        }
    }
}