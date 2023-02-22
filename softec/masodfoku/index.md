# Első hét

## Előadáshoz kapcsolódó anyagok

### Linkek

Természetes nyelvek népszerűsége: [This is the Language Each Country Wants to Learn the Most
](https://www.visualcapitalist.com/most-popular-languages-people-want-to-learn/)

Microsoft útmutató az Excel kerekítési hibáiról: [Floating-point arithmetic may give inaccurate result in Excel - Office | Microsoft Docs](https://docs.microsoft.com/en-us/office/troubleshoot/excel/floating-point-arithmetic-inaccurate-result)

Egyszerű C# kódok böngészőben is kipróbálhatók a Microsoft Docs oldalain: például a [Decimal Struct](https://docs.microsoft.com/en-us/dotnet/api/system.decimal?view=net-6.0#remarks) oldalon a `Run` gomb megnyomása után.

Könyv pdf fromátumban: [Reiter István: C# programozás lépésről lépésre](http://mapw.elte.hu/elek/Cshprogramozas.pdf)

Offtopic videó arról, hogy hogy nézett ki az Apollo földreszálló egységének számítógépe: [Light Years Ahead | The 1969 Apollo Guidance Computer](https://www.youtube.com/watch?v=B1J2RMorJXM) (4:47-től érdekes)

## Videók az előadáshoz



(!Vid) "Learning by Doing" megközelítés
> [!Video https://storage.altinum.hu/szoft1/S1_BEV_03b_leadning_by_doing.m4v]

 Az alábbi videók segítsét nyújhatnak a ZH előtti ismétléshez.

(!Vid) Elemi változók
> [!Video https://storage.altinum.hu/szoft1/S1_BEV_valtozok_es_tipusok-1.m4v]

(!Vid) Változók viselkedése -1.rész
> [!Video https://storage.altinum.hu/szoft1/S1_BEV_7_valtozok1.m4v]

(!Vid) Változók viselkedése -2.rész
> [!Video https://storage.altinum.hu/szoft1/S1_BEV_7_valtozok2.mp4]



### Rövid összefoglaló az elemi változókról a videókhoz

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

## Összefoglaló és tippek a végére

A `Console.WriteLine()` a VisualStudio output ablakába ír. Ha nem találod, és ki akarod próbálni a példákat, próbáld így:  

```csharp
MessageBox.Show(_változónév_.ToString());
```
> [!TIP]
> A Visual Studio-n belül vannak beépített shortcutok a gyakran használt elemekre. Például cw+tab+tab=Console.WriteLine();

---

A különböző típusok közötti konverzió implicit (írásban nem jelölt) módon akkor működik csak, ha a céltípus értékkészlete tágabb, mint a forrás kifejezésé. Például  `int`  típusú változóba tehetek  `byte`  típusú értéket, vagy  `long`-ba  `int`-et. A  következő program helyes:

```csharp
byte a=1; 
int b=a;
```

---

Ha egy tágabb értékkészletű típusban szereplő értéket szeretnénk egy szűkebben tárolni, adatvesztés léphet fel, ezért a programban ki kell kényszeríteni a típuskonverziót:  

```csharp
int a=1; 
byte b=(byte)a;  
```

Ezt a kikényszerített típuskonverziót hívjuk  **cast**-olásnak.

---

Ha lebegőpontos (tört) típust castolok egésszé, a tizedesek levágásra kerülnek. Pl. a  

```csharp
double a=3.9; 
int b=(int)a;
```

futtatása után `b` változó értéke `3` lesz.

---

Kerekíteni a  `Math.Round()`  függvénnyel lehet.

---

Az egész típusok esetén nem számegyeneseben kell gondolkodni, hanem számkörökben. Az egész típusok körbefordulnak. Ha például egy  `byte`  típusú változó értékkészletének legnagyobb értékét veszi fel (pl. `byte b=255;`), és ezt még növeljük egyel (`b++;`), értéke az értékkészlet legkisebb értéke lesz (0). Ugyanez működik fordítva is. A `byte.MaxValue`  kifejezés megadja a byte típusban tárolható legnagyobb értéket. Ez működik minden elemi változótípusra.

---

A  `double`  felvehet  **végtelen**  és  **negatív végtelen**  értéket is. A  `double`  értéke lehet  **nem szám**  is: két végtelen hányadosa esetén például  **nem szám**  az eredmény.

---

Nagyon kell vigyázni: a C-alapú nyelvekben az `=` operátor értékadást jelöl. (Például `int a = 1;`) Feltétekben, ahol két érték közti ekvivalenciát vizsgálunk, a `==` operátort kell használni. 

```csharp
if (a==13) MessageBox.Show("Bad day");
```

## Gyakorlaton megoldandó feladatok

### Első projekt

(!Vid) Visual Studio első indítása
> [!Video https://storage.altinum.hu/szoft1/S1_BEV_02_first_start.m4v]

(!Vid) Új projekt létrehozása
> [!Video https://storage.altinum.hu/szoft1/S1_BEV_03a_add_new%20project.m4v]

(!Vid) Gomb elhelyezése űrlapon
> [!Video https://storage.altinum.hu/szoft1/S1_BEV_3c_ne_nyomj_meg.m4v]

### Másodfokú egyenlet megoldó program

A projekt felépítése az alábbi videókon követhető:

[1. lépés]()
> [!Video https://storage.altinum.hu/szoft1/S1_BEV_4a.m4v]

(!Vid) 2. lépés
> [!Video https://storage.altinum.hu/szoft1/S1_BEV_4b.m4v]

(!Vid) 3. lépés
> [!Video https://storage.altinum.hu/szoft1/S1_BEV_4c.m4v]

(!Vid) 4. lépés
> [!Video https://storage.altinum.hu/szoft1/S1_BEV_4d.m4v]

(!Vid) 5. lépés
> [!Video https://storage.altinum.hu/szoft1/S1_BEV_4e.m4v]

(!Vid) 6. lépés
> [!Video https://storage.altinum.hu/szoft1/S1_BEV_4f.mp4]

(!Vid) Try-catch: hibakezelés
> [!Video https://storage.altinum.hu/szoft1/S1_BEV_4g_try_catch.m4v]

(!Vid) TryParse hibakezelés (Kiegészítő anyag)
> [!Video https://storage.altinum.hu/szoft1/Kiegészítő anyag]

### Szorzótábla

(!Vid) Egy gomb kirakása
> [!Video https://storage.altinum.hu/szoft1/S1_BEV_5a_1gomb.m4v]

(!Vid) 10 gomb kirakása
> [!Video https://storage.altinum.hu/szoft1/S1_BEV_5b_100gomb.m4v]

(!Vid) 10x10 gomb kirakása szorzótáblába
> [!Video https://storage.altinum.hu/szoft1/S1_BEV_5c_szorzotabla.m4v]
