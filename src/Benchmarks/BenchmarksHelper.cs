using System;
using System.Buffers;
using System.IO;
using Bond;
using Bond.IO.Unsafe;
using Bond.Protocols;
using ProtoBuf;

namespace Benchmarks
{
    public static class BenchmarksHelper
    {
        private static ArrayPool<byte> bytePool = ArrayPool<byte>.Shared;

        public static byte[] SerializeBond<T>(T value)
        {
            byte[] buffer = bytePool.Rent(128);
            var outputBuffer = new OutputBuffer(buffer);
            var compactWriter = new CompactBinaryWriter<OutputBuffer>(outputBuffer);
            Serialize.To(compactWriter, value);
            var result = new byte[outputBuffer.Data.Count];
            Buffer.BlockCopy(buffer, outputBuffer.Data.Offset, result, 0, result.Length);
            bytePool.Return(buffer);
            return result;
        }

        public static byte[] SerializeProtobuf<T>(T value)
        {
            byte[] buffer = bytePool.Rent(128);
            using (var stream = new MemoryStream(buffer))
            {
                Serializer.Serialize(stream, value);
                var result = new byte[stream.Position];
                Buffer.BlockCopy(buffer, 0, result, 0, result.Length);
                bytePool.Return(buffer);
                return result;
            }
        }

        public static T DeserializeBond<T>(byte[] value)
        {
            var inputBuffer = new InputBuffer(value);
            var compactReader = new CompactBinaryReader<InputBuffer>(inputBuffer);
            return Deserialize<T>.From(compactReader);
        }

        public static T DeserializeProtobuf<T>(byte[] value)
        {
            using (var valueBytes = new MemoryStream(value))
            {
                return Serializer.Deserialize<T>(valueBytes);
            }
        }
    }
}
