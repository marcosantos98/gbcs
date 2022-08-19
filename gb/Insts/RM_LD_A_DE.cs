namespace GBCS.GB.Insts
{
    public class RM_LD_A_DE : Instruction
    {
        public RM_LD_A_DE(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            ushort de = (ushort)((_cpu.RegD << 8) | (_cpu.RegE & 0xFF));
            Console.Write("{0,-14}", "LD A, ($" + de.ToString("X") + ")");
            _cpu.RegA = _cpu.Mem.Read(de);
            return (true, 8);
        }
    }
}