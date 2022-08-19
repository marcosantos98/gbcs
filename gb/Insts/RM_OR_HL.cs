namespace GBCS.GB.Insts
{
    public class RM_OR_HL : Instruction
    {
        public RM_OR_HL(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "OR (HL)");
            ushort hl = (ushort)((_cpu.RegH << 8) | (_cpu.RegL & 0xFF));
            _cpu.RegA |= _cpu.Mem.Read(hl);
            _cpu.SetZeroFlag(_cpu.RegA == 0);
            _cpu.SetSubFlag(false);
            _cpu.SetHalfCarryFlag(false);
            _cpu.SetCarryFlag(false);
            return (true, 8);
        }
    }
}