# GB# - WIP

Gameboy emulator written in C#;

# Using Retrio CPU Instructions Test ROMS:

- https://github.com/retrio/gb-test-roms/tree/master/cpu_instrs/individual

### Passing:

| Test                        | Passed             |
|:----------------------------|--------------------|
| 01 - Special                | :heavy_check_mark: |
| 02 - Interrupts             | Fails on EI        |
| 03 - Op sp, hl              | :x:                |
| 04 - Op r, imm              | :x:                |
| 05 - Op rp                  | :x:                |
| 06 - ld r, r                | :x:                |
| 07 - jr, jp, call, ret, rst | :x:                |
| 08 - misc instrs            | :x:                |
| 09 - op r, r                | :x:                |
| 10 - bit ops                | :x:                |
| 11 - op a, (hl)             | :x:                |