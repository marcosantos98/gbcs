namespace GBCS.GB.Insts
{
    public class RM_LD_A_A16 : Instruction
    {
        public RM_LD_A_A16(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            ushort address = _cpu.Mem.ReadU16(_cpu.Pc);
            Console.Write("{0,-14}", "LD A, ($" + address.ToString("X") + ")");
            _cpu.Pc += 2;
            _cpu.RegA = _cpu.Mem.Read(address);
            return (true, 16);
        }
    }
}