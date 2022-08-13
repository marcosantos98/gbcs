namespace GBCS.GB
{
    public class IBuilder
    {

        private InstructionType _instructionType = InstructionType.NONE;
        private AddressMode _addressMode = AddressMode.IMP;
        private RegisterType _registerTypeOne = RegisterType.NONE;
        private RegisterType _registerTypeTwo = RegisterType.NONE;
        private ConditionType _conditionType = ConditionType.NONE;
        private byte _parameter;

        public static IBuilder Type(InstructionType type)
        {
            IBuilder builder = new()
            {
                _instructionType = type
            };
            return builder;
        }

        public IBuilder Addr(AddressMode addr)
        {
            _addressMode = addr;
            return this;
        }

        public IBuilder One(RegisterType one)
        {
            _registerTypeOne = one;
            return this;
        }

        public IBuilder Two(RegisterType two)
        {
            _registerTypeTwo = two;
            return this;
        }

        public IBuilder Cond(ConditionType cond)
        {
            _conditionType = cond;
            return this;
        }

        public IBuilder Param(byte cond)
        {
            _parameter = cond;
            return this;
        }

        public Instruction Ret()
        {
            return new Instruction(
                    _instructionType,
                    _addressMode,
                    _registerTypeOne,
                    _registerTypeTwo,
                    _conditionType,
                    _parameter
            );
        }
    }
}