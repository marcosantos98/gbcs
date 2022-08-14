namespace GBCS.GB
{

    public class InstructionsHandlers
    {
        private static readonly IDictionary<InstructionType, Action<CPU>> Handlers = new Dictionary<InstructionType, Action<CPU>>();

        static InstructionsHandlers()
        {
            Handlers.Add(InstructionType.NOP, (cpu) => { });
            Handlers.Add(InstructionType.ADD, (cpu) =>
            {
                if (IsU16Register(cpu.Inst.RegTwo))
                {
                    throw new NotImplementedException("TODO: U16 Add");
                }
                byte a = (byte)cpu.GetRegister(cpu.Inst.RegOne);
                byte b = (byte)cpu.GetRegister(cpu.Inst.RegTwo);
                (byte, bool) result = OverflowAdd(a, b);
                cpu.Flags.Zero = result.Item1 == 0;
                cpu.Flags.Substract = false;
                cpu.Flags.Carry = result.Item2;
                cpu.Flags.HalfCarry = (a & 0xF) + (b & 0xF) > 0xF;
                cpu.SetRegister(RegisterType.A, result.Item1);
            });
            //fixme 22/08/14: Check flags and if is a PC Register.
            //fixme 22/08/14: Cycles
            Handlers.Add(InstructionType.JP, cpu => cpu.Pc = cpu.AddressData);
            //fixme 22/08/14: RETI
            Handlers.Add(InstructionType.EI, cpu => cpu.IMEEnabled = true);
            Handlers.Add(InstructionType.DI, cpu => cpu.IMEEnabled = false);
        }

        private static (byte, bool) OverflowAdd(byte a, byte b)
        {
            bool overflow = false;
            if (a + b > 0xFF)
            {
                overflow = true;
            }
            return ((byte)(a + b), overflow);
        }

        private static bool IsU16Register(RegisterType type)
        {
            return type is RegisterType.AF or RegisterType.BC or
            RegisterType.DE or RegisterType.HL or
            RegisterType.PC or RegisterType.SP;
        }

        public static Action<CPU> Get(InstructionType type)
        {
            return Handlers[type];
        }
    }
}