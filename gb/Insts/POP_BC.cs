namespace GBCS.GB.Insts
{
    public class POP_BC : Instruction
    {
        public POP_BC(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "POP BC");
            ushort spAddress = _cpu.Mem.ReadU16(_cpu.Sp);
            _cpu.Sp += 2;
            _cpu.RegB = (byte)((spAddress >> 8) & 0xFF);
            _cpu.RegC = (byte)(spAddress & 0xFF);
            _cpu.Stack.LogLn("PC: {3:X4} POP BC: {0:X2}{1:X2} from SP: {2:X4}", _cpu.RegB, _cpu.RegC, _cpu.Sp - 2, _cpu.Pc);
            return (true, 12);
        }
    }
}