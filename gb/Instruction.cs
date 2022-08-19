namespace GBCS.GB
{
    public abstract class Instruction
    {
        protected readonly CPU _cpu;
        protected Instruction(CPU cpu)
        {
            _cpu = cpu;
        }

        public abstract (bool, int) Run();
    }
}