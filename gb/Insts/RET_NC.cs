namespace GBCS.GB.Insts
{
    public class RET_NC : Instruction
    {
        public RET_NC(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            if (!_cpu.GetFlags().carry)
            {
                ushort jpAddress = _cpu.Mem.ReadU16(_cpu.Sp);
                Console.Write("{0,-14}", "RET NC $" + jpAddress.ToString("X"));
                _cpu.Sp += 2;
                _cpu.Pc = jpAddress;
                return (true, 20);
            }
            Console.Write("{0,-14}", "RET $" + _cpu.Pc.ToString("X"));
            return (true, 8);
        }
    }
}