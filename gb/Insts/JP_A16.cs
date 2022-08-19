namespace GBCS.GB.Insts
{
    public class JP_A16 : Instruction
    {
        public JP_A16(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            ushort jpAddress = _cpu.Mem.ReadU16(_cpu.Pc);
            Console.Write("{0,-14}", "JP $" + jpAddress.ToString("X"));
            _cpu.Pc = jpAddress;
            return (true, 16);
        }
    }
}