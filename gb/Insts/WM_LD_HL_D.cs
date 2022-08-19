namespace GBCS.GB.Insts
{
    public class WM_LD_HL_D : Instruction
    {
        public WM_LD_HL_D(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            ushort address = (ushort)((_cpu.RegH << 8) | (_cpu.RegL & 0xFF));
            Console.Write("{0,-14}", "LD ($" + address.ToString("X") + "), D");
            _cpu.Mem.Write(address, _cpu.RegD);
            return (true, 8);
        }
    }
}