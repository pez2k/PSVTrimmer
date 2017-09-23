using System.Runtime.InteropServices;

namespace PSVTrimmer
{
    public partial class PSVTrimmer
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct digital_header_t
        {
            public uint type; // 0x1 indicates header for digital content
            public uint flags; // 1 == game, 2 == DLC, etc (not yet specified)
            public ulong license_size; // size of RIF that follows
            public byte[] rif; // rif file
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct compression_header_t
        {
            public uint type; // 0x2 indicates header for compression
            public uint compression_algorithm; // not yet specified
            public ulong uncompressed_size;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct opt_header_t
        {
            public uint type;
            public digital_header_t digital;
            public compression_header_t compression;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct psv_file_header_base
        {
            public uint magic;
            public uint version;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct psv_file_header_v1
        {
            public uint magic;               // 'PSV\0'
            public uint version;             // 0x00 = first version
            public uint flags;               // see below
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x10)]
            public byte[] key1;           // for klicensee decryption
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x10)]
            public byte[] key2;           // for klicensee decryption
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x14)]
            public byte[] signature;      // same as in RIF
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x20)]
            public byte[] hash;           // optional consistency check. sha256 over complete data (including any trimmed bytes) if cart dump, sha256 over the pkg if digital dump.
            public ulong image_size;          // if trimmed, this will be actual size
            public ulong image_offset_sector; // image (dump/pkg) offset in multiple of 512 bytes. must be > 0 if an actual image exists. == 0 if no image is included.
            public opt_header_t[] headers;       // optional additional headers as defined by the flags
        }

        public uint PSV_MAGIC = 0x00565350; // 'PSV\0'

        public uint PSV_VERSION_V1 = 1;

        public uint FLAG_TRIMMED = (1 << 0);  // if set, the file is trimmed and 'image_size' is the actual size
        public uint FLAG_DIGITAL = (1 << 1);  // if set, RIF is present and an encrypted PKG file follows
        public uint FLAG_COMPRESSED = (1 << 2);  // undefined if set with `FLAG_TRIMMED` or `FLAG_DIGITAL`. if set, the data must start with a compression header (not currently defined)
        //public uint FLAG_LICENSE_ONLY = (FLAG_TRIMMED | FLAG_DIGITAL); // if set, the actual PKG is NOT stored and only RIF is present. 'image_size' will be size of actual package.
    }
}