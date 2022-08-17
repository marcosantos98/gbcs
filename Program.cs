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

            ushort breakAt = 0x0000;

            if (args.Length == 2)
            {
                breakAt = ushort.Parse(args[1], System.Globalization.NumberStyles.HexNumber);
            }

            while (true)
            {
                if (!cpu.Step())
                {
                    cpu.Stack.ToFile();
                    break;
                }
                if (breakAt != 0x0000)
                {
                    if (cpu.Pc == breakAt)
                    {
                        Console.WriteLine("> Break at: {0:X4}", breakAt);
                        _ = cpu.Step();
                        Console.WriteLine("> Inst: {0}, {1}, {2}, {3}, {4}", cpu.Inst.Type, cpu.Inst.Addr, cpu.Inst.RegOne, cpu.Inst.RegTwo, cpu.Inst.Cond);
                        Console.WriteLine("> AddressData: {0:X4}", cpu.AddressData);
                        cpu.Stack.ToFile();
                        break;
                    }
                }
            }
        }
    }
}


