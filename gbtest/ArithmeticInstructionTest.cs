using Xunit;
using GB;
using GB.Types;

namespace GBTest
{
    public class ArithmeticInstructionTest
    {
        private CPU cpu = new CPU();

        [Theory]
        [InlineData(0x35, RegisterType.B, 0x34, 0x69)]
        [InlineData(0x0, RegisterType.C, 0x12, 0x0)]
        public void InstADD(byte aVal, RegisterType other, byte value, byte expected)
        {
            var cpu = new CPU();
            cpu.SetU8Register(RegisterType.A, aVal);
            cpu.SetU8Register(other, value);
            cpu.inst = Instructions.instructions[0x80];
            InstructionsHandlers.handlers[InstructionType.ADD].Invoke(cpu);
            Assert.Equal(expected, cpu.GetU8Register(RegisterType.A));
        }
    }
}
