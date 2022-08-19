namespace GBCS.GB.Insts
{
    public class WM_LD_A16_A : Instruction
    {
        public WM_LD_A16_A(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            ushort address = _cpu.Mem.ReadU16(_cpu.Pc);
            Console.Write("{0,-14}", "LD ($" + address.ToString("X") + "), A");
            _cpu.Pc += 2;
            _cpu.Mem.Write(address, _cpu.RegA);
            return (true, 16);
        }
    }
}