namespace GBCS.GB.Insts
{
    public class RM_LDH_A_A8 : Instruction
    {
        public RM_LDH_A_A8(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            byte ioOffset = _cpu.Mem.Read(_cpu.Pc++);
            Console.Write("{0,-14}", "LDH A, ($FF" + ioOffset.ToString("X") + ")");
            _cpu.RegA = _cpu.Mem.Read((ushort)(0xFF00 | ioOffset));
            return (true, 12);
        }
    }
}