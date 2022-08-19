namespace GBCS.GB.Insts
{
    public class INC_BC : Instruction
    {
        public INC_BC(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "INC BC");

            ushort bc = (ushort)((_cpu.RegB << 8) | (_cpu.RegC & 0xFF));
            bc++;

            _cpu.RegB = (byte)((bc >> 8) & 0xFF);
            _cpu.RegC = (byte)(bc & 0xFF);

            return (true, 8);
        }
    }
}