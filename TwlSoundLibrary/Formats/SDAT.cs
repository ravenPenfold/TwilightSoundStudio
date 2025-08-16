namespace TwlSoundLibrary.Formats
{
    /// <summary>
    /// Handler for Sound Data Archives (*.sdat)
    /// </summary>
    public class SDAT
    {
        // Variables - Public
        public SdatStructure MainHeader;
        private List<byte[]> Files;
        public List<SeqInfo> Sequences;
        public List<BankInfo> Banks;

        public void ExtractSdat(string output)
        {
            string path = "";
            // Start with Sequences
            Console.WriteLine("Exporting " + Sequences.Count + " Sequences...\n");
            path = output + "\\Sequences";
            Directory.CreateDirectory(path);
            foreach (var seq in Sequences)
            {
                File.WriteAllBytes(path + "\\" + seq.Name + ".sseq", Files[(int)seq.FileId]);
                Console.WriteLine("Exported sequence #" + seq.EntryId + " " + seq.Name);
            }

            // Next up - Banks
            Console.WriteLine("Exporting " + Banks.Count + " Banks...\n");
            path = output + "\\Banks";
            Directory.CreateDirectory(path);
            foreach (var bnk in Banks)
            {
                File.WriteAllBytes(path + "\\" + bnk.Name + ".sbnk", Files[(int)bnk.FileId]);
                Console.WriteLine("Exported sequence #" + bnk.EntryId + " " + bnk.Name);
            }
        }

        private void LoadBankInfo(BinaryReader r)
        {
            uint[] EntryOffsets = new uint[0];
            uint[] NameOffsets = new uint[0];
            uint NoEntries = 0;
            uint ActualEntryCount = 0;
            Banks = new List<BankInfo>();
            // Read INFO Block
            r.BaseStream.Seek(MainHeader.InfoChunk.Offset, MainHeader.InfoChunk.SeekOrigin);
            if (IS.CheckFormat(r.ReadBytes(4), "INFO"))
            {
                uint ChunkSize = r.ReadUInt32();
                uint[] RecordOffsets = new uint[8];
                for (int i = 0; i < 8; i++)
                {
                    RecordOffsets[i] = r.ReadUInt32() + MainHeader.InfoChunk.Offset;
                }
                r.BaseStream.Seek(RecordOffsets[(int)FileTypes.Bank], SeekOrigin.Begin);

                // Read Info Offsets
                Console.Write("Reading Bank Info Offsets... | ");
                NoEntries = r.ReadUInt32();
                EntryOffsets = new uint[NoEntries];
                for (uint i = 0; i < NoEntries; i++)
                {
                    uint offset = r.ReadUInt32();
                    if (offset != 0)
                    {
                        ActualEntryCount++;
                        EntryOffsets[i] = offset + MainHeader.InfoChunk.Offset;
                    }
                    else
                    {
                        EntryOffsets[i] = offset;
                    }

                }
                Console.WriteLine("Successfully read " + NoEntries + " entries!");
            }
            else
            {
                Console.WriteLine("Invalid INFO block. Runtime terminated.");
                Environment.Exit(-3);
            }

            // Read SYMB Block (if exists)
            if (MainHeader.ChunkCount != 3)
            {
                r.BaseStream.Seek(MainHeader.SymbChunk.Offset, MainHeader.SymbChunk.SeekOrigin);
                if (IS.CheckFormat(r.ReadBytes(4), "SYMB"))
                {
                    uint ChunkSize = r.ReadUInt32();
                    uint[] RecordOffsets = new uint[8];
                    for (int i = 0; i < 8; i++)
                    {
                        RecordOffsets[i] = r.ReadUInt32() + MainHeader.SymbChunk.Offset;
                    }
                    r.BaseStream.Seek(RecordOffsets[(int)FileTypes.Bank], SeekOrigin.Begin);
                    NoEntries = r.ReadUInt32();
                    NameOffsets = new uint[NoEntries];
                    for (uint i = 0; i < NoEntries; i++)
                    {
                        uint offset = r.ReadUInt32();
                        if (offset != 0)
                        {
                            NameOffsets[i] = offset + MainHeader.SymbChunk.Offset;
                        }
                        else
                        {
                            NameOffsets[i] = 0;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid SYMB Chunk. Runtime terminated!");
                    Environment.Exit(-4);
                }
            }
            else
            {
                NameOffsets = new uint[NoEntries];
                for (uint i = 0; i < NoEntries; i++)
                {
                    NameOffsets[i] = 0;
                }
            }
            // Read and Get Info
            Console.Write("Reading " + ActualEntryCount + " entries | ");
            for (uint i = 0; i < NoEntries; i++)
            {
                if (EntryOffsets[i] != 0)
                {
                    BankInfo info = new BankInfo(i);
                    r.BaseStream.Seek(EntryOffsets[i], SeekOrigin.Begin);
                    info.Name = "Sequence_" + i;
                    info.FileId = r.ReadUInt32();
                    for(int j = 0; j < 4; j++)
                    {
                        info.WaveAssoc[j] = r.ReadUInt16();
                    }

                    if (NameOffsets[i] != 0)
                    {
                        r.BaseStream.Seek(NameOffsets[i], SeekOrigin.Begin);
                        info.Name = "";
                        while (true)
                        {
                            byte b = r.ReadByte();
                            if (b != 0x00)
                            {
                                info.Name += (char)b;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    Banks.Add(info);
                }
            }
            Console.WriteLine(" Successfully read all bank entries!");
        }

        private void LoadSequenceInfo(BinaryReader r)
        {
            uint[] EntryOffsets = new uint[0];
            uint[] NameOffsets = new uint[0];
            uint NoEntries = 0;
            uint ActualEntryCount = 0;
            Sequences = new List<SeqInfo>();
            // Read INFO Block
            r.BaseStream.Seek(MainHeader.InfoChunk.Offset, MainHeader.InfoChunk.SeekOrigin);
            if (IS.CheckFormat(r.ReadBytes(4), "INFO"))
            {
                uint ChunkSize = r.ReadUInt32();
                uint[] RecordOffsets = new uint[8];
                for (int i = 0; i < 8; i++)
                {
                    RecordOffsets[i] = r.ReadUInt32() + MainHeader.InfoChunk.Offset;
                }
                r.BaseStream.Seek(RecordOffsets[(int)FileTypes.Seq], SeekOrigin.Begin);

                // Read Info Offsets
                Console.Write("Reading Sequence Info Offsets... | ");
                NoEntries = r.ReadUInt32();
                EntryOffsets = new uint[NoEntries];
                for (uint i = 0; i < NoEntries; i++)
                {
                    uint offset = r.ReadUInt32();
                    if (offset != 0)
                    {
                        ActualEntryCount++;
                        EntryOffsets[i] = offset + MainHeader.InfoChunk.Offset;
                    }
                    else
                    {
                        EntryOffsets[i] = offset;
                    }

                }
                Console.WriteLine("Successfully read " + NoEntries + " entries!");
            }
            else
            {
                Console.WriteLine("Invalid INFO block. Runtime terminated.");
                Environment.Exit(-3);
            }

            // Read SYMB Block (if exists)
            if (MainHeader.ChunkCount != 3)
            {
                r.BaseStream.Seek(MainHeader.SymbChunk.Offset, MainHeader.SymbChunk.SeekOrigin);
                if (IS.CheckFormat(r.ReadBytes(4), "SYMB"))
                {
                    uint ChunkSize = r.ReadUInt32();
                    uint[] RecordOffsets = new uint[8];
                    for (int i = 0; i < 8; i++)
                    {
                        RecordOffsets[i] = r.ReadUInt32() + MainHeader.SymbChunk.Offset;
                    }
                    r.BaseStream.Seek(RecordOffsets[(int)FileTypes.Seq], SeekOrigin.Begin);
                    NoEntries = r.ReadUInt32();
                    NameOffsets = new uint[NoEntries];
                    for (uint i = 0; i < NoEntries; i++)
                    {
                        uint offset = r.ReadUInt32();
                        if (offset != 0)
                        {
                            NameOffsets[i] = offset + MainHeader.SymbChunk.Offset;
                        }
                        else
                        {
                            NameOffsets[i] = 0;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid SYMB Chunk. Runtime terminated!");
                    Environment.Exit(-4);
                }
            }
            else
            {
                NameOffsets = new uint[NoEntries];
                for (uint i = 0; i < NoEntries; i++)
                {
                    NameOffsets[i] = 0;
                }
            }

            // Read and Get Info
            Console.Write("Reading " + ActualEntryCount + " entries | ");
            for (uint i = 0; i < NoEntries; i++)
            {
                if (EntryOffsets[i] != 0)
                {
                    SeqInfo info = new SeqInfo(i);
                    r.BaseStream.Seek(EntryOffsets[i], SeekOrigin.Begin);
                    info.Name = "Sequence_" + i;
                    info.FileId = r.ReadUInt32();
                    info.BankAssoc = r.ReadUInt16();
                    info.Volume = r.ReadByte();
                    info.ChannelPrio = r.ReadByte();
                    info.PlayerPrio = r.ReadByte();
                    info.PlayerAssoc = r.ReadByte();

                    if (NameOffsets[i] != 0)
                    {
                        r.BaseStream.Seek(NameOffsets[i], SeekOrigin.Begin);
                        info.Name = "";
                        while (true)
                        {
                            byte b = r.ReadByte();
                            if (b != 0x00)
                            {
                                info.Name += (char)b;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    Sequences.Add(info);
                }
            }
            Console.WriteLine(" Successfully read all sequence entries!");
        }

        public byte[] GetFile(int FileId)
        {
            return Files[FileId];
        }

        public void ReplaceFile(int FileId, byte[] Data)
        {
            Files[FileId] = Data;
        }

        public void ReplaceFile(int FileId, MemoryStream Data)
        {
            Files[FileId] = Data.ToArray();
        }

        private void LoadFiles(BinaryReader r)
        {
            Files = new List<byte[]>();
            r.BaseStream.Seek(MainHeader.FatChunk.Offset, MainHeader.FatChunk.SeekOrigin);
            if (IS.CheckFormat(r.ReadBytes(4), "FAT "))
            {
                uint ChunkSize = r.ReadUInt32();
                uint NoFiles = r.ReadUInt32();
                List<FatEntry> FileAllocs = new List<FatEntry>();

                // Get Offsets
                for (uint i = 0; i < NoFiles; i++)
                {
                    FileAllocs.Add(new FatEntry(r.ReadUInt32(), r.ReadUInt32()));
                    r.ReadBytes(8);     // Skips over 8 bytes
                }

                // Get Files
                Console.Write("Reading files... | ");
                foreach (FatEntry entry in FileAllocs)
                {
                    r.BaseStream.Seek(entry.Offset, entry.SeekOrigin);
                    Files.Add(r.ReadBytes((int)entry.Size));
                }
                Console.WriteLine("Successfully read " + NoFiles + " files!");
            }
            else
            {
                Console.WriteLine("Invalid FAT chunk. Runtime terminated");
                Environment.Exit(-2);
            }
        }

        // Constructor
        /// <param name="stm">Stream to SDAT file</param>
        public SDAT(Stream stm)
        {
            using (BinaryReader r = new BinaryReader(stm))
            {
                if (IS.CheckFormat(r.ReadBytes(4), "SDAT"))
                {
                    // Read Main Fileheader
                    MainHeader = new SdatStructure();
                    r.ReadUInt32();                             // Skip over MagicID
                    MainHeader.Length = r.ReadUInt32();
                    MainHeader.SdatHeaderSize = r.ReadUInt16();
                    MainHeader.ChunkCount = r.ReadUInt16();

                    MainHeader.SymbChunk = new FatEntry(r.ReadUInt32(), r.ReadUInt32());
                    MainHeader.InfoChunk = new FatEntry(r.ReadUInt32(), r.ReadUInt32());
                    MainHeader.FatChunk = new FatEntry(r.ReadUInt32(), r.ReadUInt32());
                    MainHeader.FileChunk = new FatEntry(r.ReadUInt32(), r.ReadUInt32());

                    // Load Files
                    LoadFiles(r);

                    // Load SequenceInfo
                    LoadSequenceInfo(r);

                    // Load BankInfo
                    LoadBankInfo(r);
                }
                else
                {
                    Console.WriteLine("Invalid Sound Archive");
                    Environment.Exit(-1);
                }
            }
        }
    }

    public enum FileTypes : int
    {
        Seq,
        Seqarc,
        Bank,
        WaveArc,
        SeqPlayer,
        Group,
        StrmPlayer,
        Strm
    }

    public struct SdatStructure
    {
        /// <summary>
        /// File Size in Bytes
        /// </summary>
        public uint Length;
        /// <summary>
        /// Main Header size in Bytes
        /// </summary>
        public ushort SdatHeaderSize;
        /// <summary>
        /// Number of chunks in file. 3 if SYMB is omitted
        /// </summary>
        public ushort ChunkCount;
        public FatEntry SymbChunk;
        public FatEntry InfoChunk;
        public FatEntry FatChunk;
        public FatEntry FileChunk;
    }

    public struct FatEntry
    {
        public uint Offset;
        public uint Size;
        public readonly SeekOrigin SeekOrigin;

        public FatEntry(uint offset, uint size)
        {
            Offset = offset;
            Size = size;
            SeekOrigin = SeekOrigin.Begin;
        }
    }

    // Info Structs
    public struct SeqInfo
    {
        public uint EntryId;
        public string Name;
        public uint FileId;
        public ushort BankAssoc;
        public byte Volume;
        public byte ChannelPrio;
        public byte PlayerPrio;
        public byte PlayerAssoc;

        public SeqInfo(uint id)
        {
            EntryId = id;
        }
    }

    public struct BankInfo
    {
        public uint EntryId;
        public string Name;
        public uint FileId;
        public ushort[] WaveAssoc;

        public BankInfo(uint id)
        {
            EntryId = id;
            WaveAssoc = new ushort[4];
        }
    }
}
