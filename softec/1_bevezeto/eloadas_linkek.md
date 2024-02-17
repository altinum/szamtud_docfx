# Első hét

## Előadáshoz kapcsolódó anyagok

### Linkek

Természetes nyelvek népszerűsége: [This is the Language Each Country Wants to Learn the Most
](https://www.visualcapitalist.com/most-popular-languages-people-want-to-learn/)

Microsoft útmutató az Excel kerekítési hibáiról: [Floating-point arithmetic may give inaccurate result in Excel - Office | Microsoft Docs](https://docs.microsoft.com/en-us/office/troubleshoot/excel/floating-point-arithmetic-inaccurate-result)

Egyszerű C# kódok böngészőben is kipróbálhatók a Microsoft Docs oldalain: például a [Decimal Struct](https://docs.microsoft.com/en-us/dotnet/api/system.decimal?view=net-6.0#remarks) oldalon a `Run` gomb megnyomása után.

Könyv pdf fromátumban: [Reiter István: C# programozás lépésről lépésre](http://mapw.elte.hu/elek/Cshprogramozas.pdf)

Offtopic videó arról, hogy hogy nézett ki az Apollo földreszálló egységének számítógépe: [Light Years Ahead | The 1969 Apollo Guidance Computer](https://www.youtube.com/watch?v=B1J2RMorJXM) (4:47-től érdekes)

### Rövid összefoglaló az elemi változókról 

Ezeket érdemes megtanulni - a számtípusoknál legalább a nagyságrendeket.

| Típus     | Memóriaigény | Leírás                                                                          |
| --------- | ------------ | ------------------------------------------------------------------------------- |
| `byte`    | 1 byte       | Előjel nélküli 8 bites egész szám(0..255)                                       |
| `char`    | 2            | Egy Unicode karakter                                                            |
| `bool`    | 1            | Logikai típus, értéke igaz(1 vagy True)vagy hamis(0 vagy False)                 |
| `sbyte`   | 1            | Előjeles, 8 bites egész szám (-128..127)                                        |
| `short`   | 2            | Előjeles, 16 bites egész szám (-32768..32767)                                   |
| `ushort`  | 2            | Előjel nélküli, 16 bites egész szám(0..65535)                                   |
| `int`     | 4            | Előjeles, 32 bites egész szám (–2147483648.. 2147483647).                       |
| `uint`    | 4            | Előjel nélküli, 32 bites egész szám(0..4294967295)                              |
| `float`   | 4            | Egyszeres pontosságú lebegőpontos szám (kb. 7 decimális számjegy pontosság)     |
| `double`  | 8            | Kétszeres pontosságú lebegőpontos szám (kb. 15-16 decimális számjegy pontosság) |
| `decimal` | 16           | Fix pontosságú 28+1 jegyű szám                                                  |
| `long`    | 8            | Előjeles, 64 bites egész szám                                                   |
| `ulong`   | 8            | Előjel nélküli, 64 bites egész szám                                             |
| `string`  | N/A          | Unicode karakterek szekvenciája                                                 |
