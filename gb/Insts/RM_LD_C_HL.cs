namespace GBCS.GB.Insts
{
    public class RM_LD_C_HL : Instruction
    {
        public RM_LD_C_HL(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            ushort hl = (ushort)((_cpu.RegH << 8) | (_cpu.RegL & 0xFF));
            Console.Write("{0,-14}", "LD C, ($" + hl.ToString("X") + ")");
            _cpu.RegC = _cpu.Mem.Read(hl);
            return (true, 8);
        }
    }
}