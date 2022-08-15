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
            Handlers.Add(InstructionType.JP, cpu => JumpTo(cpu, cpu.AddressData, false));
            Handlers.Add(InstructionType.CALL, cpu => JumpTo(cpu, cpu.AddressData, true));
            //fixme 22/08/14: RETI
            Handlers.Add(InstructionType.EI, cpu => cpu.IMEEnabled = true);
            Handlers.Add(InstructionType.DI, cpu => cpu.IMEEnabled = false);
            Handlers.Add(InstructionType.LD, cpu =>
            {
                if (cpu.PcIsMemDest)
                {
                    if (IsU16Register(cpu.Inst.RegTwo))
                    {
                        cpu.Mem.Write((ushort)(cpu.MemDest + 1), (byte)(cpu.AddressData & 0xFF));
                        cpu.Mem.Write(cpu.MemDest, (byte)((cpu.AddressData & 0xFF00) >> 8));
                    }
                    else
                    {
                        cpu.Mem.Write(cpu.MemDest, (byte)cpu.AddressData);
                    }
                }
                else
                {
                    cpu.SetRegister(cpu.Inst.RegOne, cpu.AddressData);
                }
            });
            Handlers.Add(InstructionType.LDH, cpu =>
            {
                if (cpu.Inst.RegOne == RegisterType.A)
                {
                    // Read IO Register to A
                    cpu.SetRegister(RegisterType.A, cpu.Mem.Read((ushort)(0xFF00 | cpu.AddressData)));
                }
                else
                {
                    // Write to IO Register from A
                    cpu.Mem.Write((ushort)(0xFF00 | cpu.AddressData), (byte)cpu.GetRegister(RegisterType.A));
                }
                //fixme 22/08/14: Cycles
            });
            Handlers.Add(InstructionType.JR, cpu => JumpTo(cpu, (ushort)(cpu.Pc + (cpu.AddressData & 0xFF)), false));
            Handlers.Add(InstructionType.RET, cpu =>
            {
                if (cpu.Inst.Cond != ConditionType.NONE)
                {
                    //fixme 22/08/15: Cycles
                }

                if (cpu.ValidateInstCondition())
                {
                    byte lo = cpu.Pop();
                    //fixme 22/08/15: Cycles
                    byte hi = cpu.Pop();
                    //fixme 22/08/15: Cycles

                    ushort n = (ushort)((hi << 8) | lo);
                    cpu.Pc = n;
                    //fixme 22/08/15: Cycles
                }
            });
            Handlers.Add(InstructionType.PUSH, cpu =>
            {
                byte hi = (byte)((cpu.GetRegister(cpu.Inst.RegOne) >> 8) & 0xFF);
                //fixme 22/08/15: Cycles
                cpu.Push(hi);

                byte lo = (byte)((cpu.GetRegister(cpu.Inst.RegOne) >> 8) & 0xFF);
                //fixme 22/08/15: Cycles
                cpu.Push(lo);

                //fixme 22/08/15: Cycles
            });
            Handlers.Add(InstructionType.POP, cpu =>
            {
                byte lo = cpu.Pop();
                //fixme 22/08/15: Cycles
                byte hi = cpu.Pop();
                //fixme 22/08/15: Cycles

                ushort n = (ushort)((hi << 8) | lo);
                cpu.SetRegister(cpu.Inst.RegOne, n);

                if (cpu.Inst.RegOne == RegisterType.AF)
                {
                    cpu.SetRegister(RegisterType.AF, (ushort)(n & 0xFFF0));
                }
            });
            Handlers.Add(InstructionType.INC, cpu =>
            {
                ushort val = (ushort)(cpu.GetRegister(cpu.Inst.RegOne) + 1);
                if (IsU16Register(cpu.Inst.RegOne))
                {
                    //fixme 22/08/15: cycles
                }

                if (cpu.Inst.RegOne == RegisterType.HL && cpu.Inst.Addr == AddressMode.MR)
                {
                    val = cpu.Mem.Read((byte)(cpu.GetRegister(RegisterType.HL) + 1));
                    val &= 0xFF;
                    cpu.Mem.Write(cpu.GetRegister(RegisterType.HL), (byte)val);
                }
                else
                {
                    cpu.SetRegister(cpu.Inst.RegOne, val);
                    val = cpu.GetRegister(cpu.Inst.RegOne);
                }
                if ((cpu.Opcode & 0x03) == 0x03)
                {
                    return;
                }

                cpu.Flags.Zero = val == 0;
                cpu.Flags.Substract = false;
                cpu.Flags.Carry = (val & 0x0F) == 0;
                cpu.Flags.HalfCarry = false;
            });
            Handlers.Add(InstructionType.DEC, cpu =>
            {
                ushort val = (ushort)(cpu.GetRegister(cpu.Inst.RegOne) - 1);
                if (IsU16Register(cpu.Inst.RegOne))
                {
                    //fixme 22/08/15: cycles
                }

                if (cpu.Inst.RegOne == RegisterType.HL && cpu.Inst.Addr == AddressMode.MR)
                {
                    val = cpu.Mem.Read((byte)(cpu.GetRegister(RegisterType.HL) - 1));
                    val &= 0xFF;
                    cpu.Mem.Write(cpu.GetRegister(RegisterType.HL), (byte)val);
                }
                else
                {
                    cpu.SetRegister(cpu.Inst.RegOne, val);
                    val = cpu.GetRegister(cpu.Inst.RegOne);
                }
                if ((cpu.Opcode & 0x0B) == 0x0B)
                {
                    return;
                }

                cpu.Flags.Zero = val == 0;
                cpu.Flags.Substract = true;
                cpu.Flags.Carry = (val & 0x0F) == 0x0F;
                cpu.Flags.HalfCarry = false;
            });
            Handlers.Add(InstructionType.CPL, cpu =>
            {
                cpu.SetRegister(RegisterType.A, (byte)~cpu.GetRegister(RegisterType.A));

                cpu.Flags.Zero = false;
                cpu.Flags.Substract = true;
                cpu.Flags.Carry = true;
                cpu.Flags.HalfCarry = false;
            });
        }

        private static void JumpTo(CPU cpu, ushort address, bool setPC)
        {
            if (cpu.ValidateInstCondition())
            {
                if (setPC)
                {
                    //fixme 22/08/14: Cycles
                    cpu.Push((byte)((cpu.Pc >> 8) & 0xFF));
                    cpu.Push((byte)(cpu.Pc & 0xFF));
                }

                cpu.Pc = address;
                //fixme 22/08/14: cycles
            }
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

        public static Action<CPU>? Get(InstructionType type)
        {
            return Handlers.ContainsKey(type) ? Handlers[type] : null;
        }
    }
}