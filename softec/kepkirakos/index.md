# Képkirakós játék
## Kiinduló állományok és megoldás
 | | |
|-|-|
|[lo.zip](lo.zip) | Kiinduló képek|
[Pascel_es_lo.docx](Pascel_es_lo.docx)|Előadás handout

## A megoldás menete videón

(!Vid) 1. Vonszolható gomb kíserlet
> [!Video https://storage.altinum.hu/szoft1/S1lo1-1.m4v]

(!Vid) 2. Képek kezelése, 
> [!Video https://storage.altinum.hu/szoft1/S1lo2-2.m4v]

(!Vid) 3. 5x5 kiskép kirakása
> [!Video https://storage.altinum.hu/szoft1/S1lo3-3.m4v]

(!Vid) 4. Mozgatás
> [!Video https://storage.altinum.hu/szoft1/S1lo4-4.m4v]

(!Vid) 5. Keverés
> [!Video https://storage.altinum.hu/szoft1/S1lo5-5.m4v]

### Ellenőrző kérdések az előadáshoz

(!Hint) 1.  Hány közvetlen őse lehet C#-ban egy osztálynak? [!Egyszerre csak egy osztálytól tud közvetlenül örökölni. A több osztályból való öröklés funkcióinak egy része interfészekkel van megoldva.]
(!Hint) 2.  Hol lehet átírni, hogy melyik űrlappal induljon az alkalmazás? [!A Program.cs Main függvényében.]
3.  Írd le azt a kódrésztelet, amit 10x10 gombot kirak az űrlapra!
4.  Sorolj fel 5-öt a Form osztály tulajdonságai közül!
5.  Sorolj fel 2-öt a Form osztály metódusai közül!
6.  Sorolj fel 5-öt a Form osztály eseményai közül!
7.  Melyik osztálytól ötököl a Példa osztály?  `class Példa {...}`
9.  Mikor következnek be az alábbi események pl. egy gomb esetén?  
    - MouseUp  
    - MouseDown  
    - MouseMove  
    - MouseEnter  
    - MouseLeave  
    
10.  Példaként adott az alábbi esemény-kiszolgáló függvény. Milyen információt hordoz az  _e_  paraméter?
``` csharp
void b_MouseDown(object sender, MouseEventArgs e)  
{  
...  
}
```

## A feladatmegoldás lépései gyakorlatra

### Első fázis – új osztály származtatása

(+/-)  Származtass osztályt a `PictureBox` osztályból `Képkocka` néven!

(+/-)  Az új `Képkocka` osztályt bővítsd konstruktorral!

(+/-) A konstruktorban a `Képkocka` osztály színezze magát fukszia színűre, valamint állítsa be saját szélességét és magasságát 76 pixelre!

(+/-) Fordítsd le az alkalmazást. Pl. futtasd és állítsd le. Fordítás után a Toolbox-on meg kell jelennie a `Képkocka` vezérlőnek, melyet a többihez hasonlóan tervező nézetben is elhelyezhetsz a űrlapon. Próbáld ki!

### Második fázis – mozgatható gomb

(+/-) A `Képkocka` konstruktorában rendelj esemélykiszolgáló függvényeket a `MouseDown`, a `MouseUp` és a `MouseMove` eseményekhez! (Ezeket a `Képkocka` osztály a `PictureBox` osztálytól örökölte.)

(+/-) A `Képkocka` osztályt bővítsd egy `ox` és egy `oy` nevű `int` típusú változóval! Ebben tároljuk majd azt a koordinátát, ahol az egér a gomb lenyomásakor tartózkodott a gombon belül.

(+/-) A Képkocka osztályt bővítsd egy `mozoge` nevű `bool` típusú változóval, melynek kezdőértéke `false`!

(+/-) A `MouseDown` eseményhez tartozó eseménykiszolgálóban állítsd be `ox` és `oy` értékét `e.X` illetve `e.Y` érékére, és állítsd a `mozoge` változó értékét igazra!

(+/-) A `MouseUp` eseményhez tartozó eseménykiszolgálóban nincs más teendő, mint a `mozoge` változó értékét hamisra állítani.

(+/-) A `MouseMove` eseményhez tartozó eseménykiszolgálóban csak akkor csinálunk valamit, ha a `mozoge` változó értéke igaz. Hozd létre a feltételes szerkezetet! (`if..`)

(+/-) Ha a fenti feltétel teljesül, tolja el (`+=`) a Képkocka az `X` koordinátáját (`Left` tulajdonság) `e.X-ox` képponttal, valamint az `Y` koordinátáját (Top tulajdonság) `e.Y-oy` képponttal!

(+/-) Próbáld ki, mit csináltál: az előző fázis végén tervezőben kihelyezett gombnak most vonszolhatónak kéne lennie.

### Harmadik fázis – lovas kirakós

(+/-) Először rakj ki 5x5 Képkockát egymástól 76 pixeles távolságra! (Két egymásba ágyazott ciklus a `Form1` konstruktorában.)

(+/-) Vezess be egy `int` típusú, `sorszám` nevű változót a ciklusok előtt `0` kezdőértékkel!

(+/-) A `sorszám` változó értékét a belső ciklus törzsének utolsó lépéseként növeld egyel! Így, amikor kiraksz egy Képkockát, rendelkezésedre áll egy változó, melyből tudod, hogy épp hányadik képkockát rakod ki.

(+/-) Töltsd le a `lo.zip` állományt, és csomagold ki egy mappába. A mappában lévő képetek másold be az projekten belül lévő `bin/debug` mappába, ide hozza majd létre a fordító a futtatható .exe állományt. Ha az alkalmazásban nem adsz elérési utat egy fájlnévhez, alapértelmezésben az .exe mellett keresi.

17.  Töltsd be a `Képkocka` `Load` metódusa segítségével a megfelelő lódarabot! A `Load` metódus paramétereként használható egy relatív hivatkozás a fájlra, mint pl. `kk.Load("./kepek/lo_1.jpg");`. Az URL-ben a `\` és a `/` karakterek egyaránt használhatóak. 

### Negyedik fázis – képkockák összekeverése

(+/-)  Építsd be az alkalmazásba a keverő funkciót az alábbi kódrészlet alapján!

``` csharp
public partial class Form1 : Form
{
    public Form1()
    {
      ....                 
    }

    int[] tömb = new int[25];

    void Kever()
    {
        int n = 25;
        for (int i = 0; i < n; i++)
        {
            tömb[i] = i+1;
        }
        Random rnd = new Random();
        for (int i = 0; i < n; i++)
        {
            int egyik = rnd.Next(n);
            int másik = rnd.Next(n);
            int köztes = tömb[egyik];
            tömb[egyik] = tömb[másik];
            tömb[másik] = köztes;
        }
    }
}
```


``` csharp
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        Kever();
        int sorszám = 0;
        for (int sor = 0; sor < 5; sor++)
            for (int oszlop = 0; oszlop < 5; oszlop++)
            {
                Kepkocka k = new Kepkocka($"lo_{tömb[sorszám]}.jpg", sor, oszlop);               
                this.Controls.Add(k);
                sorszám++;
            }                      
    }
    ...
}

```


