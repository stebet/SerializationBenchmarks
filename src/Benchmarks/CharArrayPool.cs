using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Benchmarks
{
    class CharArrayPool : IArrayPool<char>
    {
        public static readonly CharArrayPool Instance = new CharArrayPool();

        public char[] Rent(int minimumLength) => ArrayPool<char>.Shared.Rent(minimumLength);

        public void Return(char[] array)
        {
            ArrayPool<char>.Shared.Return(array);
        }
    }
}
