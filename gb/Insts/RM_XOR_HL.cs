namespace GBCS.GB.Insts
{
    public class RM_XOR_HL : Instruction
    {
        public RM_XOR_HL(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "XOR (HL)");
            ushort hl = (ushort)((_cpu.RegH << 8) | (_cpu.RegL & 0xFF));
            _cpu.RegA ^= _cpu.Mem.Read(hl);
            _cpu.SetZeroFlag(_cpu.RegA == 0);
            _cpu.SetSubFlag(false);
            _cpu.SetHalfCarryFlag(false);
            _cpu.SetCarryFlag(false);
            return (true, 8);
        }
    }
}