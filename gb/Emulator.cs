namespace GB
{
    class Emulator {

        private CPU cpu = new CPU();

        public void Init() {
            Console.WriteLine("Initiliazing emulator...");
            Console.WriteLine("Reg AF: {0:X4}", cpu.GetU16Register(RegisterType.AF));
            cpu.SetU16Register(RegisterType.AF, 0x0609);
            Console.WriteLine("Reg A: {0:X2}", cpu.GetU8Register(RegisterType.A));
            Console.WriteLine("Reg F: {0:X2}", cpu.GetU8Register(RegisterType.F));
            Console.WriteLine("Reg AF: {0:X4}", cpu.GetU16Register(RegisterType.AF));

            cpu.SetFlags(0xF0);
            Console.WriteLine("Flags: {0}{1}{2}{3} Val: {4:X2}", cpu.flags.zero ? "Z" : "-", cpu.flags.substract ? "N" : "-", cpu.flags.halfCarry ? "H" : "-", cpu.flags.carry ? "C" : "-", cpu.FromFlags());
        }
    }
}