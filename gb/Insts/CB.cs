using GBCS.GB.Insts.Prefix;

namespace GBCS.GB.Insts
{
    public class CB : Instruction
    {
        private readonly IDictionary<byte, PrefixInstruction> _cbs = new Dictionary<byte, PrefixInstruction>();

        public CB(CPU cpu) : base(cpu)
        {
            _cbs[0x19] = new RR_C(cpu);
            _cbs[0x1A] = new RR_D(cpu);
            _cbs[0x1F] = new RR_A(cpu);
            _cbs[0x37] = new SWAP_A(cpu);
            _cbs[0x38] = new SRL_B(cpu);
        }

        public override (bool, int) Run()
        {
            byte op = _cpu.Mem.Read(_cpu.Pc++);
            PrefixInstruction cb = _cbs.ContainsKey(op) ? _cbs[op] : throw new NotImplementedException("Prefix not implemented! " + op.ToString("X"));
            Console.Write("{0,-14}", "CB $" + op.ToString("X") + " (" + cb.Name() + ")");
            return cb.Run();
        }
    }
}