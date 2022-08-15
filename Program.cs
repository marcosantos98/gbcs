using GBCS.GB;

namespace GBCS
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //fixme 22/08/14: Check args before using them lol
            Cartidge cartidge = new(args[0]);

            Console.WriteLine("Cartridge Info:");
            Console.WriteLine("\tTitle: {0}", cartidge.Info.Title);
            Console.WriteLine("\tVersion: {0}", cartidge.Info.Version);
            Console.WriteLine("\tROM Size: {0} Kb", cartidge.Info.ROMSize);
            Console.WriteLine("\tRAM Size: {0}", cartidge.Info.RAMSize);
            Console.WriteLine("\tCartridge Type: {0}", cartidge.Info.CartidgeType);
            Console.WriteLine("\tChecksum: {0}", cartidge.Info.Checksum);
            Console.WriteLine("\tHasValidChecksum: {0}", cartidge.HasValidChecksum);

            CPU cpu = new();

            Buffer.BlockCopy(cartidge.ROM, 0, cpu.Mem.Memory, 0, 0x7FFF);

            while (!cpu.WasHalted)
            {
                if (!cpu.Step())
                {
                    break;
                }
            }
        }
    }
}


