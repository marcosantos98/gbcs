using Xunit;
using GBCS.GB;

namespace GBCS.GBTest
{
    public class JumpInstructionsTest
    {
        [Fact]
        public static void JumpInstruction()
        {
            CPU cpu = new()
            {
                AddressData = 0x69
            };
            InstructionsHandlers.Get(InstructionType.JP).Invoke(cpu);
            Assert.Equal(cpu.AddressData, cpu.Pc);
        }
    }
}