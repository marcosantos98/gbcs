namespace GBCS.GB.Insts
{
    public class PUSH_DE : Instruction
    {
        public PUSH_DE(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "PUSH DE");
            _cpu.Stack.LogLn("PC: {3:X4} PUSH DE: {0:X2}{1:X2} from SP: {2:X4}", _cpu.RegD, _cpu.RegE, _cpu.Sp, _cpu.Pc);
            _cpu.Sp--;
            _cpu.Mem.Write(_cpu.Sp, _cpu.RegD);
            _cpu.StackHolder[_cpu.Sp] = _cpu.RegD;
            _cpu.Sp--;
            _cpu.Mem.Write(_cpu.Sp, _cpu.RegE);
            _cpu.StackHolder[_cpu.Sp] = _cpu.RegE;
            return (true, 16);
        }
    }
}