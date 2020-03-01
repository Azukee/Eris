using System;

namespace ErisLib.Server
{
    public class CustomBuffer : IDisposable
    {
        public int Idx = 0;
        public byte[] Buffer;
        private const int BufferSize = 4;
        
        public CustomBuffer()
        {
            Buffer = new byte[BufferSize];
        }

        public void ResizeBuffer(int size)
        {
            if (size > short.MaxValue)
                throw new Exception();

            byte[] previousBytes = Buffer;
            Buffer = new byte[size];
            previousBytes.CopyTo(Buffer, 0);
        }
        
        public void Clear()
        {
            Buffer = new byte[BufferSize];
            Idx = 0;
        }
        
        public int Remaining => Buffer.Length - Idx;
        public void Walk(int count) => Idx += count;
        public void Dispose() => Buffer = null;
    }
}