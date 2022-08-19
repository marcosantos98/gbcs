namespace GBCS.GB.Insts
{
    public class XOR_C : Instruction
    {
        public XOR_C(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "XOR C");
            _cpu.RegA ^= _cpu.RegC;
            _cpu.SetZeroFlag(_cpu.RegA == 0);
            _cpu.SetSubFlag(false);
            _cpu.SetHalfCarryFlag(false);
            _cpu.SetCarryFlag(false);
            return (true, 4);
        }
    }
}