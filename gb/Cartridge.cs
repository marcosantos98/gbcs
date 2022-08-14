namespace GBCS.GB
{
    public class Cartidge
    {

        public struct CartridgeInfo
        {
            public byte[] Title;
            public byte SgbFlag;
            public byte OldLicense;
            public ushort NewLicense;
            public byte CartidgeType;
            public byte ROMSize;
            public byte RAMSize;
            public byte Version;
            public ushort Checksum;
        }

        public byte[] ROM;
        public readonly CartridgeInfo Info;
        public bool HasValidChecksum;
        public byte CalculatedChecksum;

        public Cartidge(string romPath)
        {
            ROM = File.ReadAllBytes(romPath);
            //fixme 22/08/13: Check for errors;

            //Fill info
            Info.Title = new byte[0x143 - 0x134];
            Buffer.BlockCopy(ROM, 0x134, Info.Title, 0, 0x143 - 0x134);
            Info.SgbFlag = ROM[0x146];
            Info.OldLicense = ROM[0x14B];
            Info.NewLicense = (ushort)((ROM[0x144] & (0xFF << 8)) | (ROM[0x145] & 0xFF));
            Info.CartidgeType = 32;
            Info.ROMSize = (byte)(32 * (1 << ROM[0x148]));
            Info.RAMSize = ROM[0x149];
            Info.Version = ROM[0x14C];
            Info.Checksum = ROM[0x14D];

            byte checksum = 0;
            for (ushort address = 0x134; address <= 0x14C; address++)
            {
                checksum = (byte)(checksum - ROM[address] - 1);
            }

            CalculatedChecksum = (byte)(checksum & 0xFF);
            HasValidChecksum = Info.Checksum == (checksum & 0xFF);
        }


    }

}