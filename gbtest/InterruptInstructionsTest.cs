using Xunit;
using GBCS.GB;

namespace GBCS.GBTest
{
    public class InterruptInstructionsTest
    {
        [Fact]
        public static void DisableInterrupts()
        {
            CPU cpu = new()
            {
                IMEEnabled = true
            };
            Assert.True(cpu.IMEEnabled);
            InstructionsHandlers.Get(InstructionType.DI).Invoke(cpu);
            Assert.False(cpu.IMEEnabled);
        }

        [Fact]
        public static void EnableInterrupts()
        {
            CPU cpu = new()
            {
                IMEEnabled = false
            };
            Assert.False(cpu.IMEEnabled);
            InstructionsHandlers.Get(InstructionType.EI).Invoke(cpu);
            Assert.True(cpu.IMEEnabled);
        }
    }
}