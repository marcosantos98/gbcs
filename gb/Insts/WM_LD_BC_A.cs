namespace GBCS.GB.Insts
{
    public class WM_LD_BC_A : Instruction
    {
        public WM_LD_BC_A(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "LD (BC), A");
            ushort address = (ushort)((_cpu.RegB << 8) | (_cpu.RegC & 0xFF));
            _cpu.Mem.Write(address, _cpu.RegA);
            return (true, 8);
        }
    }
}