namespace GBCS.GB.Insts
{
    public class RM_DEC_HL : Instruction
    {
        public RM_DEC_HL(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "DEC (HL)");
            ushort hl = (ushort)((_cpu.RegH << 8) | (_cpu.RegL & 0xFF));

            byte val = (byte)(_cpu.Mem.Read(hl) - 1);
            _cpu.Mem.Write(hl, val);

            _cpu.SetZeroFlag(val == 0);
            _cpu.SetSubFlag(true);
            _cpu.SetHalfCarryFlag(((val + 1) & 0xF0) != (val & 0xF0));

            return (true, 12);
        }
    }
}