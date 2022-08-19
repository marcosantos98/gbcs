namespace GBCS.GB.Insts
{
    public class RM_LD_D_HL : Instruction
    {
        public RM_LD_D_HL(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            ushort hl = (ushort)((_cpu.RegH << 8) | (_cpu.RegL & 0xFF));
            Console.Write("{0,-14}", "LD D, ($" + hl.ToString("X") + ")");
            _cpu.RegD = _cpu.Mem.Read(hl);
            return (true, 8);
        }
    }
}