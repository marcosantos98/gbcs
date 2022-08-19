using GBCS.GB;

using Raylib_cs;

namespace GBCS
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            //fixme 22/08/14: Check args before using them lol
            Cartidge cartridge = new(args[0]);

            Console.WriteLine("Cartridge Info:");
            Console.WriteLine("\tTitle: {0}", cartridge.Info.Title);
            Console.WriteLine("\tVersion: {0}", cartridge.Info.Version);
            Console.WriteLine("\tROM Size: {0} Kb", cartridge.Info.ROMSize);
            Console.WriteLine("\tRAM Size: {0}", cartridge.Info.RAMSize);
            Console.WriteLine("\tCartridge Type: {0}", cartridge.Info.CartidgeType);
            Console.WriteLine("\tChecksum: {0}", cartridge.Info.Checksum);
            Console.WriteLine("\tHasValidChecksum: {0}", cartridge.HasValidChecksum);

            CPU cpu = new();

            Buffer.BlockCopy(cartridge.ROM, 0, cpu.Mem.Memory, 0, 0x7FFF);

            Raylib.InitWindow(800, 400, "GBCS: " + cartridge.Info.Title);

            StringWriter writer = new();

            while (!Raylib.WindowShouldClose())
            {
                if (!cpu.Step())
                {
                    continue;
                }


                if (cpu.Mem.Read(0xFF02) == 0x81)
                {
                    char c = Convert.ToChar(cpu.Mem.Read(0xFF01));
                    if (c == '\n')
                    {
                        writer.Write("\n-");
                    }
                    else
                    {
                        writer.Write(c);
                    }

                    Console.WriteLine("Write: {0}", Convert.ToChar(cpu.Mem.Read(0xFF01)));
                    cpu.Mem.Write(0xFF02, 0x0);
                }

                Raylib.DrawText(writer.ToString(), 10, 10, 24, Color.BLACK);


                if (cpu.IsHalted)
                {
                    if (Raylib.IsKeyReleased(KeyboardKey.KEY_C))
                    {
                        cpu.IsHalted = false;
                        _ = cpu.Step();
                        cpu.IsHalted = true;
                    }
                    else if (Raylib.IsKeyReleased(KeyboardKey.KEY_B))
                    {
                        cpu.IsHalted = false;
                    }
                }

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.RAYWHITE);
                Raylib.EndDrawing();
            }


            Raylib.CloseWindow();
        }
    }
}