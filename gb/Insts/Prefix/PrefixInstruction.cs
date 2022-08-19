namespace GBCS.GB.Insts.Prefix
{
    public abstract class PrefixInstruction
    {
        protected readonly CPU _cpu;
        protected PrefixInstruction(CPU cpu)
        {
            _cpu = cpu;
        }

        public abstract (bool, int) Run();

        public abstract string Name();
    }
}