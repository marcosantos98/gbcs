namespace GBCS.GB.Insts
{
    public class ADC_A_D8 : Instruction
    {
        public ADC_A_D8(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            byte val = _cpu.Mem.Read(_cpu.Pc++);
            Console.Write("{0,-14}", "ADC $" + val.ToString("X"));
            byte carry = (byte)(_cpu.GetFlags().carry ? 1 : 0);
            byte newValue = (byte)(_cpu.RegA + (byte)(val + (carry & 0xFF)));
            _cpu.SetZeroFlag(newValue == 0);
            _cpu.SetSubFlag(false);
            _cpu.SetHalfCarryFlag((_cpu.RegA & 0xF) + (val & 0xF) > 0xF);
            _cpu.SetCarryFlag(val + _cpu.RegA + carry >= 0xFF);
            _cpu.RegA = newValue;
            return (true, 8);
        }
    }
}