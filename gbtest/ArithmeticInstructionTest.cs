using Xunit;
using GBCS.GB;

namespace GBCS.GBTest
{
    public class ArithmeticInstructionTest
    {

        [Theory]
        [InlineData(0x35, RegisterType.B, 0x34, 0x69)]
        [InlineData(0x0, RegisterType.C, 0x12, 0x0)]
        public void InstADD(byte aVal, RegisterType other, byte value, byte expected)
        {
            CPU cpu = new();
            cpu.SetRegister(RegisterType.A, aVal);
            cpu.SetRegister(other, value);
            cpu.Inst = Instructions.Get(0x80);
            InstructionsHandlers.Get(InstructionType.ADD).Invoke(cpu);
            Assert.Equal(expected, cpu.GetRegister(RegisterType.A));
        }
    }
}
