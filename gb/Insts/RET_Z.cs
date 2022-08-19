namespace GBCS.GB.Insts
{
    public class RET_Z : Instruction
    {
        public RET_Z(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            if (_cpu.GetFlags().zero)
            {
                ushort jpAddress = _cpu.Mem.ReadU16(_cpu.Sp);
                Console.Write("{0,-14}", "RET Z $" + jpAddress.ToString("X"));
                _cpu.Sp += 2;
                _cpu.Pc = jpAddress;
                return (true, 20);
            }
            Console.Write("{0,-14}", "RET $" + _cpu.Pc.ToString("X"));
            return (true, 8);
        }
    }
}