namespace GBCS.GB
{

    public class InstructionsHandlers
    {
        private static readonly IDictionary<InstructionType, Action<CPU>> Handlers = new Dictionary<InstructionType, Action<CPU>>();

        private enum CBRegType : byte
        {
            B,
            C,
            D,
            E,
            H,
            L,
            HL,
            A
        }

        static InstructionsHandlers()
        {
            Handlers.Add(InstructionType.NOP, cpu => { });
            Handlers.Add(InstructionType.HALT, cpu => cpu.WasHalted = true);
            Handlers.Add(InstructionType.ADD, cpu =>
            {
                int val = cpu.GetRegister(cpu.Inst.RegOne) + cpu.AddressData;

                if (IsU16Register(cpu.Inst.RegOne))
                {
                    //fixme 22/08/17: cycles
                }

                if (cpu.Inst.RegOne == RegisterType.SP)
                {
                    val = cpu.GetRegister(cpu.Inst.RegOne) + (sbyte)cpu.AddressData;
                }

                bool zero = (val & 0xFF) == 0;
                bool halfCarry = (cpu.GetRegister(cpu.Inst.RegOne) & 0xF) + (cpu.AddressData & 0xF) >= 0x10;
                bool carry = (cpu.GetRegister(cpu.Inst.RegOne) & 0xFF) + (cpu.AddressData & 0xFF) >= 0x100;

                if (IsU16Register(cpu.Inst.RegOne))
                {
                    zero = false;
                    halfCarry = (cpu.GetRegister(cpu.Inst.RegOne) & 0xFFF) + (cpu.AddressData & 0xFFF) >= 0x1000;
                    carry = cpu.GetRegister(cpu.Inst.RegOne) + cpu.AddressData >= 0x10000;
                }

                if (cpu.Inst.RegOne == RegisterType.SP)
                {
                    zero = false;
                    halfCarry = (cpu.GetRegister(cpu.Inst.RegOne) & 0xF) + (cpu.AddressData & 0xF) >= 0x10;
                    carry = (cpu.GetRegister(cpu.Inst.RegOne) & 0xFF) + (cpu.AddressData & 0xFF) > 0x100;
                }

                cpu.Flags.Zero = zero;
                cpu.Flags.Substract = false;
                cpu.Flags.HalfCarry = halfCarry;
                cpu.Flags.Carry = carry;

                cpu.SetRegister(cpu.Inst.RegOne, (ushort)(val & 0xFFFF));
            });
            Handlers.Add(InstructionType.ADC, cpu =>
            {
                ushort u = cpu.AddressData;
                ushort a = cpu.GetRegister(RegisterType.A);
                byte c = (byte)((cpu.FromFlags() >> 4) & 1);

                cpu.SetRegister(RegisterType.A, (ushort)((a + u + c) & 0xFF));

                cpu.Flags.Zero = cpu.GetRegister(RegisterType.A) == 0;
                cpu.Flags.Substract = false;
                cpu.Flags.HalfCarry = (a & 0xF) + (u & 0xF) + c > 0xF;
                cpu.Flags.Carry = a + u + c > 0xFF;

            });
            Handlers.Add(InstructionType.SUB, cpu =>
            {
                ushort val = (ushort)(cpu.GetRegister(cpu.Inst.RegOne) - cpu.AddressData);

                cpu.Flags.Zero = val == 0;
                cpu.Flags.Substract = true;
                cpu.Flags.HalfCarry = (cpu.GetRegister(cpu.Inst.RegOne) & 0xF) - (cpu.AddressData & 0xF) < 0;
                cpu.Flags.Carry = cpu.GetRegister(cpu.Inst.RegOne) - cpu.AddressData < 0;

                cpu.SetRegister(cpu.Inst.RegOne, val);
            });
            //fixme 22/08/14: Cycles
            Handlers.Add(InstructionType.JP, cpu => JumpTo(cpu, cpu.AddressData, false));
            Handlers.Add(InstructionType.CALL, cpu => JumpTo(cpu, cpu.AddressData, true));
            //fixme 22/08/14: RETI
            Handlers.Add(InstructionType.EI, cpu => cpu.EnableIME = true);
            Handlers.Add(InstructionType.DI, cpu => cpu.IMEEnabled = false);
            Handlers.Add(InstructionType.LD, cpu =>
            {
                if (cpu.PcIsMemDest)
                {
                    if (IsU16Register(cpu.Inst.RegTwo))
                    {
                        cpu.Mem.Write(cpu.MemDest, (byte)((cpu.AddressData >> 8) & 0xFF));
                        cpu.Mem.Write(cpu.MemDest, (byte)((cpu.AddressData) & 0xFF));
                    }
                    else
                    {
                        cpu.Mem.Write(cpu.MemDest, (byte)cpu.AddressData);
                    }

                    return;
                }
                cpu.SetRegister(cpu.Inst.RegOne, cpu.AddressData);

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
            Handlers.Add(InstructionType.JR, cpu =>
            {
                sbyte rel = (sbyte)(cpu.AddressData & 0xFF);
                ushort address = (ushort)(cpu.Pc + rel);
                JumpTo(cpu, address, false);
            });
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

                byte lo = (byte)(cpu.GetRegister(cpu.Inst.RegOne) & 0xFF);
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
            Handlers.Add(InstructionType.XOR, cpu =>
            {
                cpu.SetRegister(RegisterType.A, (byte)(cpu.GetRegister(RegisterType.A) ^ (cpu.AddressData & 0xFF)));

                cpu.Flags.Zero = cpu.GetRegister(RegisterType.A) == 0;
                cpu.Flags.Substract = false;
                cpu.Flags.Carry = false;
                cpu.Flags.HalfCarry = false;
            });
            Handlers.Add(InstructionType.AND, cpu =>
            {
                cpu.SetRegister(RegisterType.A, (byte)(cpu.GetRegister(RegisterType.A) & cpu.AddressData));

                cpu.Flags.Zero = cpu.GetRegister(RegisterType.A) == 0;
                cpu.Flags.Substract = false;
                cpu.Flags.Carry = true;
                cpu.Flags.HalfCarry = false;
            });
            Handlers.Add(InstructionType.OR, cpu =>
            {
                cpu.Registers[0x0] |= (byte)(cpu.AddressData & 0xFF);

                cpu.Flags.Zero = cpu.GetRegister(RegisterType.A) == 0;
                cpu.Flags.Substract = false;
                cpu.Flags.HalfCarry = false;
                cpu.Flags.Carry = false;
            });
            Handlers.Add(InstructionType.CP, cpu =>
            {
                short n = (short)(cpu.GetRegister(RegisterType.A) - cpu.AddressData);

                cpu.Flags.Zero = n == 0;
                cpu.Flags.Substract = true;
                cpu.Flags.HalfCarry = (cpu.GetRegister(RegisterType.A) & 0x0F) - (cpu.AddressData & 0x0F) < 0;
                cpu.Flags.Carry = n < 0;
            });
            Handlers.Add(InstructionType.RRA, cpu =>
            {
                byte carry = (byte)((cpu.FromFlags() >> 4) & 1);

                byte a = (byte)cpu.GetRegister(RegisterType.A);
                a >>= 1;
                a |= (byte)(carry << 7);
                cpu.SetRegister(RegisterType.A, a);

                cpu.Flags.Zero = false;
                cpu.Flags.Substract = false;
                cpu.Flags.HalfCarry = false;
                cpu.Flags.Carry = Convert.ToBoolean(cpu.GetRegister(RegisterType.A) & 1);
            });
            Handlers.Add(InstructionType.CB, cpu =>
            {
                byte op = (byte)cpu.AddressData;
                CBRegType reg = (CBRegType)Enum.GetValues(typeof(CBRegType)).GetValue(op & 0b111)!;
                byte bit = (byte)((op >> 3) & 0b111);
                byte bitOp = (byte)((op >> 6) & 0b11);
                byte regVal = GetWithCBRegType(cpu, reg);

                //fixme 22/08/15: Cycles

                if (reg == CBRegType.HL)
                {
                    //fixme 22/08/15: Cycles
                }
                byte cFlag = (byte)((cpu.FromFlags() >> 4) & 1);

                switch (bitOp)
                {
                    case 1:
                        {

                            //BIT
                            cpu.Flags.Zero = !Convert.ToBoolean(regVal & (1 << bit));
                            cpu.Flags.Substract = false;
                            cpu.Flags.HalfCarry = true;
                            cpu.Flags.Carry = false;
                            return;
                        }
                    case 2:
                        {
                            //RST
                            regVal &= (byte)~(1 << bit);
                            SetWithCBRegType(cpu, reg, regVal);
                            return;
                        }
                    case 3:
                        {
                            //SET
                            regVal |= (byte)(1 << bit);
                            SetWithCBRegType(cpu, reg, regVal);
                            return;
                        }

                    default:
                        break;
                }

                switch (bit)
                {
                    case 0:
                        {
                            //RLC
                            bool setC = false;
                            byte result = (byte)((regVal << 1) & 0xFF);

                            if ((regVal & (1 << 7)) != 0)
                            {
                                result |= 1;
                                setC = true;
                            }

                            SetWithCBRegType(cpu, reg, result);

                            cpu.Flags.Zero = result == 0;
                            cpu.Flags.Substract = false;
                            cpu.Flags.HalfCarry = false;
                            cpu.Flags.Carry = setC;
                            return;
                        }
                    case 1:
                        {
                            //RRC
                            byte old = regVal;
                            regVal >>= 1;
                            regVal |= (byte)(old << 7);

                            SetWithCBRegType(cpu, reg, regVal);

                            cpu.Flags.Zero = !Convert.ToBoolean(regVal);
                            cpu.Flags.Substract = false;
                            cpu.Flags.HalfCarry = false;
                            cpu.Flags.Carry = Convert.ToBoolean(old & 1);

                            return;
                        }
                    case 2:
                        {
                            //RL
                            byte old = regVal;
                            regVal <<= 1;
                            regVal |= cFlag;

                            SetWithCBRegType(cpu, reg, regVal);

                            cpu.Flags.Zero = !Convert.ToBoolean(regVal);
                            cpu.Flags.Substract = false;
                            cpu.Flags.HalfCarry = false;
                            cpu.Flags.Carry = !!Convert.ToBoolean(old & 0x80);
                            return;
                        }
                    case 3:
                        {
                            //RR
                            byte old = regVal;
                            regVal >>= 1;
                            regVal |= (byte)(cFlag << 7);

                            SetWithCBRegType(cpu, reg, regVal);

                            cpu.Flags.Zero = !Convert.ToBoolean(regVal);
                            cpu.Flags.Substract = false;
                            cpu.Flags.HalfCarry = false;
                            cpu.Flags.Carry = Convert.ToBoolean(old & 1);

                            return;
                        }
                    case 4:
                        {
                            //SLA
                            byte old = regVal;
                            regVal <<= 1;

                            SetWithCBRegType(cpu, reg, regVal);

                            cpu.Flags.Zero = !Convert.ToBoolean(regVal);
                            cpu.Flags.Substract = false;
                            cpu.Flags.HalfCarry = false;
                            cpu.Flags.Carry = !!Convert.ToBoolean(old & 0x80);

                            return;
                        }
                    case 5:
                        {
                            //SRA
                            byte u = (byte)((sbyte)regVal >> 1);
                            SetWithCBRegType(cpu, reg, u);

                            cpu.Flags.Zero = !Convert.ToBoolean(u);
                            cpu.Flags.Substract = false;
                            cpu.Flags.HalfCarry = false;
                            cpu.Flags.Carry = Convert.ToBoolean(regVal & 1);

                            return;
                        }
                    case 6:
                        {
                            //SWAP
                            regVal = (byte)(((regVal & 0xF0) >> 4) | ((regVal & 0xF) << 4));
                            SetWithCBRegType(cpu, reg, regVal);

                            cpu.Flags.Zero = Convert.ToBoolean(regVal);
                            cpu.Flags.Substract = false;
                            cpu.Flags.HalfCarry = false;
                            cpu.Flags.Carry = false;

                            return;
                        }
                    case 7:
                        {
                            //SRL
                            byte u = (byte)(regVal >> 1);
                            SetWithCBRegType(cpu, reg, u);

                            cpu.Flags.Zero = !Convert.ToBoolean(u);
                            cpu.Flags.Substract = false;
                            cpu.Flags.HalfCarry = false;
                            cpu.Flags.Carry = Convert.ToBoolean(regVal & 1);

                            return;
                        }

                    default:
                        break;
                }

                Console.WriteLine("ERROR: INVALID CB: {0:X2}", op);
                Environment.Exit(1);
            });
        }

        private static void JumpTo(CPU cpu, ushort address, bool setPC)
        {
            if (cpu.ValidateInstCondition())
            {
                if (setPC)
                {
                    //fixme 22/08/14: Cycles
                    cpu.PushU16(cpu.Pc);
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

        private static void SetWithCBRegType(CPU cpu, CBRegType registerType, byte value)
        {
            switch (registerType)
            {
                case CBRegType.A: cpu.SetRegister(RegisterType.A, (byte)(value & 0xFF)); break;
                case CBRegType.B: cpu.SetRegister(RegisterType.B, (byte)(value & 0xFF)); break;
                case CBRegType.C: cpu.SetRegister(RegisterType.C, (byte)(value & 0xFF)); break;
                case CBRegType.D: cpu.SetRegister(RegisterType.D, (byte)(value & 0xFF)); break;
                case CBRegType.E: cpu.SetRegister(RegisterType.E, (byte)(value & 0xFF)); break;
                case CBRegType.H: cpu.SetRegister(RegisterType.H, (byte)(value & 0xFF)); break;
                case CBRegType.L: cpu.SetRegister(RegisterType.L, (byte)(value & 0xFF)); break;
                case CBRegType.HL: cpu.Mem.Write(cpu.GetRegister(RegisterType.HL), value); break;
                default:
                    break;
            }
        }

        private static byte GetWithCBRegType(CPU cpu, CBRegType regType)
        {
            return regType switch
            {
                CBRegType.B => (byte)cpu.GetRegister(RegisterType.B),
                CBRegType.C => (byte)cpu.GetRegister(RegisterType.C),
                CBRegType.D => (byte)cpu.GetRegister(RegisterType.D),
                CBRegType.E => (byte)cpu.GetRegister(RegisterType.E),
                CBRegType.H => (byte)cpu.GetRegister(RegisterType.H),
                CBRegType.L => (byte)cpu.GetRegister(RegisterType.L),
                CBRegType.HL => cpu.Mem.Read(cpu.GetRegister(RegisterType.HL)),
                CBRegType.A => (byte)cpu.GetRegister(RegisterType.A),
                _ => throw new NotImplementedException()
            };
        }

        public static Action<CPU>? Get(InstructionType type)
        {
            return Handlers.ContainsKey(type) ? Handlers[type] : null;
        }


    }
}