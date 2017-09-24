using System;
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

        public void WriteStructure<T>(T structure, MemoryMappedViewStream stream)
        {
            int size = Marshal.SizeOf(structure);
            byte[] byteData = new byte[size];

            IntPtr objectPointer = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(structure, objectPointer, true);
            Marshal.Copy(objectPointer, byteData, 0, size);
            Marshal.FreeHGlobal(objectPointer);

            stream.Write(byteData, 0, size);
        }

        public void Log(string message)
        {
            lbLog.Items.Add(message);
        }
    }
}