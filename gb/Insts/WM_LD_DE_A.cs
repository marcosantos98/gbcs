namespace GBCS.GB.Insts
{
    public class WM_LD_DE_A : Instruction
    {
        public WM_LD_DE_A(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "LD (DE), A");
            ushort address = (ushort)((_cpu.RegD << 8) | (_cpu.RegE & 0xFF));
            _cpu.Mem.Write(address, _cpu.RegA);
            return (true, 8);
        }
    }
}