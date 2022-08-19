namespace GBCS.GB.Insts
{
    public class JP_NZ_A16 : Instruction
    {
        public JP_NZ_A16(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            if (!_cpu.GetFlags().zero)
            {
                ushort jpAddress = _cpu.Mem.ReadU16(_cpu.Pc);
                Console.Write("{0,-14}", "JP NZ, $" + jpAddress.ToString("X"));
                _cpu.Pc = jpAddress;
                return (true, 16);
            }
            _cpu.Pc += 2;
            Console.Write("{0,-14}", "JP $" + _cpu.Pc.ToString("X"));
            return (true, 12);
        }
    }
}