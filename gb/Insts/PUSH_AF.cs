namespace GBCS.GB.Insts
{
    public class PUSH_AF : Instruction
    {
        public PUSH_AF(CPU cpu) : base(cpu)
        {
        }

        public override (bool, int) Run()
        {
            Console.Write("{0,-14}", "PUSH AF");
            _cpu.Stack.LogLn("PC: {3:X4} PUSH AF: {0:X2}{1:X2} from SP: {2:X4}", _cpu.RegA, _cpu.RegF, _cpu.Sp, _cpu.Pc);
            _cpu.Sp--;
            _cpu.StackHolder[_cpu.Sp] = _cpu.RegA;
            _cpu.Mem.Write(_cpu.Sp, _cpu.RegA);
            _cpu.Sp--;
            _cpu.StackHolder[_cpu.Sp] = _cpu.RegF;
            _cpu.Mem.Write(_cpu.Sp, _cpu.RegF);
            return (true, 16);
        }
    }
}