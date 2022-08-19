namespace GBCS.GB.Insts
{
    public class RET : Instruction
    {
        public RET(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            ushort jpAddress = _cpu.Mem.ReadU16(_cpu.Sp);
            Console.Write("{0,-14}", "RET $" + jpAddress.ToString("X"));
            _cpu.Sp += 2;
            _cpu.Pc = jpAddress;
            return (true, 16);
        }
    }
}