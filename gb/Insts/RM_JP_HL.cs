namespace GBCS.GB.Insts
{
    public class JP_HL : Instruction
    {
        public JP_HL(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            ushort hl = (ushort)((_cpu.RegH << 8) | (_cpu.RegL & 0xFF));
            Console.Write("{0,-14}", "JP $" + hl.ToString("X"));
            _cpu.Pc = hl;
            return (true, 4);
        }
    }
}