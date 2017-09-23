﻿using System.IO;
using System.IO.MemoryMappedFiles;

namespace PSVTrimmer
{
    public partial class PSVTrimmer
    {
        public readonly uint BLOCK_SIZE = 512;

        public bool ValidateHeader(MemoryMappedFile file, string filepath)
        {
            // Assume the whole useful part of the header is in one block - likely is for v1
            using (MemoryMappedViewStream header = file.CreateViewStream(0, BLOCK_SIZE))
            {
                psv_file_header_base basicHeaderStruct = ReadStructure<psv_file_header_base>(header);

                // Check the magic and version - only v1 is defined so far
                if (basicHeaderStruct.magic != PSV_MAGIC || basicHeaderStruct.version != PSV_VERSION_V1)
                {
                    Log("Could not parse PSV v1 header.");
                    return false;
                }

                header.Position = 0;

                psv_file_header_v1 headerStruct = ReadStructure<psv_file_header_v1>(header);

                // If it's already trimmed, abort
                if ((headerStruct.flags & FLAG_TRIMMED) == FLAG_TRIMMED)
                {
                    Log("Image is already trimmed.");
                    return false;
                }

                var fileInfo = new FileInfo(filepath);

                // Validate the file size - offset sector implicitly equals the number of header blocks
                if (((headerStruct.image_offset_sector * BLOCK_SIZE) + headerStruct.image_size) != (ulong)fileInfo.Length)
                {
                    Log("Image size is invalid.");
                    return false;
                }

                Log("Parsed PSV v1 header - image is valid.");
                return true;
            }
        }

        public void Trim(string filepath)
        {
            var file = MemoryMappedFile.CreateFromFile(filepath);

            if (!ValidateHeader(file, filepath))
            {
                return;
            }
        }
    }
}