namespace GBCS.GB.Insts
{
    public class ADD_HL_HL : Instruction
    {
        public ADD_HL_HL(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "ADD HL, HL");
            ushort hl = (ushort)((_cpu.RegH << 8) | (_cpu.RegL & 0xFF));
            ushort val = (ushort)(hl + hl);

            _cpu.RegH = (byte)((val >> 8) & 0xFF);
            _cpu.RegL = (byte)(val & 0xFF);

            _cpu.SetSubFlag(false);
            _cpu.SetHalfCarryFlag((hl & 0xFFF) + (val & 0xFFF) > 0xFFF);
            _cpu.SetCarryFlag(val > 0xFFFF);

            return (true, 8);
        }
    }
}