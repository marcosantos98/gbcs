
namespace GBCS.GB
{
    public class Instruction
    {
        public InstructionType Type;
        public AddressMode Addr;
        public RegisterType RegOne;
        public RegisterType RegTwo;
        public ConditionType Cond;
        public byte Param;

        public Instruction(InstructionType type, AddressMode addr, RegisterType regOne, RegisterType regTwo, ConditionType cond, byte param)
        {
            Type = type;
            Addr = addr;
            RegOne = regOne;
            RegTwo = regTwo;
            Cond = cond;
            Param = param;
        }
    }
}