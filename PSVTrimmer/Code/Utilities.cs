using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;

namespace PSVTrimmer
{
    public partial class PSVTrimmer
    {
        public T ReadStructure<T>(MemoryMappedViewStream stream)
        {
            byte[] bytes = new byte[Marshal.SizeOf(typeof(T))];
            stream.Read(bytes, 0, Marshal.SizeOf(typeof(T)));

            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            T structure = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();

            return structure;
        }

        public void Log(string message)
        {
            lbLog.Items.Add(message);
        }
    }
}