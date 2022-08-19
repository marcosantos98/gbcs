namespace GBCS.GB.Insts
{
    public class INC_DE : Instruction
    {
        public INC_DE(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "INC DE");

            ushort de = (ushort)((_cpu.RegD << 8) | (_cpu.RegE & 0xFF));
            de++;

            _cpu.RegD = (byte)((de >> 8) & 0xFF);
            _cpu.RegE = (byte)(de & 0xFF);

            return (true, 8);
        }
    }
}