namespace GBCS.GB.Insts
{
    public class RM_LD_A_HLI : Instruction
    {
        public RM_LD_A_HLI(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "LD A, (HL+)");
            ushort hl = (ushort)((_cpu.RegH << 8) | (_cpu.RegL & 0xFF));
            _cpu.RegA = _cpu.Mem.Read(hl);
            hl++;
            _cpu.RegH = (byte)((hl & 0xFF00) >> 8);
            _cpu.RegL = (byte)(hl & 0xFF);
            return (true, 8);
        }
    }
}