namespace GBCS.GB.Insts
{
    public class RM_LD_B_HL : Instruction
    {
        public RM_LD_B_HL(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            ushort hl = (ushort)((_cpu.RegH << 8) | (_cpu.RegL & 0xFF));
            Console.Write("{0,-14}", "LD B, ($" + hl.ToString("X") + ")");
            _cpu.RegB = _cpu.Mem.Read(hl);
            return (true, 8);
        }
    }
}