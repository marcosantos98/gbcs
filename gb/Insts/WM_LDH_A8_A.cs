namespace GBCS.GB.Insts
{
    public class WM_LDH_A8_A : Instruction
    {
        public WM_LDH_A8_A(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            byte ioOffset = _cpu.Mem.Read(_cpu.Pc++);
            Console.Write("{0,-14}", "LDH ($FF" + ioOffset.ToString("X") + "), A");
            _cpu.Mem.Write((ushort)(0xFF00 + ioOffset), _cpu.RegA);
            return (true, 12);
        }
    }
}