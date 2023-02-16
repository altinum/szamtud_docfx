# Osztályok példányosítása

## Videók

[2a Speech](S2_2a_Speech-2.m4v)

[3a Timer Bemutatása](S2_3a_Timer_Bemutatasa-3.m4v)

[3b Sajat Osztály](S2_3b_Sajat_Osztaly-4.m4v)

[3c Egyszerű örökles](S2_3c_Egyszeru_Orokles-5.m4v)

[3d Származtatás](S2_3d_Szarmaztatas-6.m4v)

[3e Konstruktor](S2_3e_Konstruktor-7.m4v)

[3f Projekt Felépítése](S1_BEV_P1_7a2.m4v)

[3g Cs Fájl](S2_3g_csfile.m4v)

## Ellenőrző kérések a videókhoz

1. Mire való az űrlap konstruktorában az `InitializeComponent()` metódushívás?
2. Írd le azt a néhány kódsort, mely `Gomb` néven osztályt származtat a `Button` osztályból!
3. Mikor fut le egy osztály konstruktora?
4. Hogyan készítesz konstruktort egy osztályhoz?
5. Írd le azt a néhány kódsort, mely létrehozza a `Button` osztály egy példányát, majd elhelyezi az űrlapon!
6. Írd le azt a néhány kódsort, mely `SajátGomb` néven származtat egy osztályt a `Button` osztályból!
7. Írj példát `for` ciklusra!

Ezeket érdemes fejből tudni. 

## Heti feladatok 

Ezen a héten az első négy feladatot kell felépíteni egy közös Solution-ben, és feltölteni Moodle-be. Az 1. ZH-n feladatok az 1-4 feladatokhoz hasonlóan _step-by-step_ formában lesznek megfogalmazva. Az 5. és 6. feladatokat érdemes gyakorlásképpen megoldani pénteken, hogy ha esetleg elakadtok, legyen oktatói segítség. Pénteken a 2. 3. és 4. sávban  Mohácsi László is folyamatosan várja hívásaitokat [[Teams hívás link](https://teams.microsoft.com/l/call/0/0?users=laszlo.mohacsi@uni-corvinus.hu)]!

A jövő hétnél Moodle-ben van további információ ZH-val kapcsolatban. 


### 1. feladat 
# [feladat](#tab1/fel)

(+/-) Hozz létre KÓDBÓL `gomb` néven egy példányt a `Button` osztályból, és add hozzá az űrlap vezérlőinek listájához!

(+/-)  Állíts be méretet a gombnak!

(+/-)  Állítsd be a gomb `Left` és `Top` tulajdonságát úgy, hogy pont középre kerüljön az ablakban!

(+/-)  Rakj ki 10 gombot egymás mellé az űrlapra `for` ciklusból!

(+/-)  Egészítsd ki az előző feladatot úgy, hogy 10x10 gomb legye kint!

(+/-)  Csinálj szorzótáblát; jelenítsd meg a gombokon a számokat.

(+/-)  Származtass `VillogóGomb` néven osztályt a `Button` osztályból! (A kódot írhatod a `Form1` osztály alá.)

(+/-)  Hozz létre konstruktort a `VillogóGomb` osztályban! (ctor - tab - tab)

(+/-)  A konstruktorban rendelj eseménykiszolgálót a `MouseEnter` és a `MouseLeave` eseményekhez!  (+=  - tab - tab)

(+/-)  Az eseménykiszolgálókban állítsd be a gomb színét.

(+/-)  Cseréld le a szorzótábla gombjait `VillogóGomb`-ra!

(+/-)  :)
# [megoldás](#tab1/meg)
[1-3. pontok megoldása](S1_BEV_P1%201-3.m4v)
[5-6. pontok megoldása](S1_BEV_P1%205-6.m4v)
[7. pont megoldása](S1_BEV_P1%207a1.m4v)
[7. pont megoldása, kiegészítés](S1_BEV_P1%207a2.m4v)
[8-12. pontok megoldása](S1_BEV_P1%208-12.m4v)

```csharp
class VillogoGomb : Button
{
    public VillogoGomb()
    {
        BackColor = Color.Fuchsia;
        MouseEnter += VillogoGomb_MouseEnter;
        MouseLeave += VillogoGomb_MouseLeave;
    }

    private void VillogoGomb_MouseLeave(object sender, EventArgs e)
    {
        BackColor = SystemColors.ButtonFace;
    }

    private void VillogoGomb_MouseEnter(object sender, EventArgs e)
    {
        BackColor = Color.Yellow;
    }
}
```


### 2. feladat: színeződő gomb - önálló munka

(+/-)  Származtass osztályt a `Button` osztályból `SzíneződőGomb` néven!

(+/-)  Konstruktorbán a `SzíneződőGomb` méretezze át magát 20x20 pixelesre a `Button` osztálytól örökölt `Height` és `Width` tulajdonságának beállításával!

(+/-)  A `SzíneződőGomb` konstruktorában rendelj eseménykiszolgáló függvényt a kattintás (`Click`) eseményhez!

(+/-) Kattintásra a `SzíneződőGomb` színezze magát fukszia színűre.

### 3. feladat: számoló gomb - videó alapján
# [feladat](#tab2/fel)
(+/-) Származtass osztályt a `Button` osztályból `SzámolóGomb` néven!

(+/-) A `SzámolóGomb` osztályt bővítsd konstruktorral!

(+/-)  Konstruktorbán a `SzámolóGomb` méretezze át magát 20x20 pixelesre a `Button` osztálytól örökölt Height és Width tulajdonságának beállításával!

(+/-)  Bővítsd a `SzámolóGomb` osztályt `int` típusú „`szám`” nevű mezővel!

(+/-)  A `SzámolóGomb` konstruktorában rendelj eseménykiszolgáló függvényt a kattintás (`Click`) eseményhez!

(+/-)  Az előbb létrehozott eseménykiszolgáló függvényben növeld egyel a `szám` mező értékét, majd jelenítsd meg az új értéket a gomb felirataként (`Text` tulajdonság beállítása.)

(+/-)  Végül helyezz el az űrlapon 10x10 számológombot.

(+/-)  Módosítsd a `SzámolóGomb` osztályt úgy, hogy az 1-es értékről induljon a számolás!

(+/-)  Módosítsd a `SzámolóGomb` osztályt úgy, hogy az 5-ös szám után az 1-es jelenjen meg!

[1-7. pontok megoldása](S1_BEV_P3%201-7.m4v)
[változók érvenyessége](S1_BEV_P3%207lifecycle.m4v)
[8-9. pont megoldása](S1_BEV_P3%208-9.m4v)

# [megoldás](#tab2/meg)
A `SzámolóGomb` osztály:

```csharp
class SzámolóGomb : Button
{
    int szám;

    public SzámolóGomb()
    {            
        Width = 20;
        Height = 20;
        Click += SzámolóGomb_Click;
        szám = 1;
        Text = szám.ToString();
    }

    private void SzámolóGomb_Click(object sender, EventArgs e)
    {
        szám++;
        if (szám==6)
        {
            szám = 1;
        }
        Text = szám.ToString();
    }
}
```

A `Form1` osztály `Load` eseményéhez tartozó eseménykiszolgáló:

```csharp
private void Form1_Load(object sender, EventArgs e)
{
    for (int s = 0; s < 10; s++)
    {
        for (int o = 0; o < 10; o++)
        {
            SzámolóGomb számolóGomb = new SzámolóGomb();
            számolóGomb.Height = 20;
            számolóGomb.Width = 20;
            számolóGomb.Top = s * 20;
            számolóGomb.Left = o * 20;

            Controls.Add(számolóGomb);
        }
    }
}
```

### 4. feladat: gombok kirakása véletlenszerűen
# [feladat](#tab3/fel)
(+/-)  Szervezz `for` ciklust 100 iterációs lépéssel. Minden lépésben rakj ki egy gombot a képernyőn véletlenszerű, de az ablakba eső pozícióba.

(+/-)  A méret is legyen véletlen.

(+/-)  A szín is.

# [megoldás](#tab3/meg)
Gombok véletlenszerű kirajzolása

``` csharp
// A véletlenszámokhoz szükség van egy generátorra (RNG = Random Number Generator)
// AZ alábbi sor csak ezt hozza létre, tényleges véletlen számot még nem generál
// A konstruktoron kívül érdemes példányosítani, mert ebből csak 1-et akarunk létrehozni 
// (Bonyolultabb problémák esetén van értelme többet létrehozni, de ahhoz nagyon érteni kell a működésüket, egyszerűbb követni azt a szabályt, hogy ebből MINDIG csak 1 legyen)
Random rng = new Random();

public Form1()
{
    InitializeComponent();

    // Ciklus, ami létrehozza majd a gombokat
    for (int i = 0; i < 1000; i++)
    {
        // A tényleges randomszám generáláshoz a random generátor Next metódusát kell használnunk
        // Ennek két bemenő paramétere van, melyek megadják, hogy mely két érték között legyen a véletlenszám
        // Vigyázat a felső korlát exkluzív, tehát ezt az értéket már nem veheti fel a véletlenszám
        // Pl.: rng.Next(1, 10) esetén 1-től 9-ig bármelyik számot kaphatjuk eredményként, de a 10-et már nem
        // Az első paraméter elhagyható, ekkor a minimum 0 lesz és csak a maximumot kell megadni
        // Ha tört számra van szükség, akkor a NextDouble() metódus visszaad egy 0 és 1 közti tizedes törtet
        // Ezt felszorozva bármilyen két érték közti racionális számot elő lehet állítani

        // Az átláthatóság érdekében létrehozunk változókat a véletlen számok tárolására
        // Ezeknek a változóknak létrehozása kihagyható, az értékadásuk egyszerűen beírható oda, ahol később hivatkozunk rájuk

        // Aktuális gomb mérete
        // Ebben a példában a gomb szélessége és magassága véletlen szerűen 20 és 50 között van               
        int width = rng.Next(20, 51);
        int height = rng.Next(20, 51);

        // Aktuális gomb pozíciója
        // A pozíciók minimuma nulla, ezért használható a Next azon változata, ahol csak a maximum értéket kell megadni
        // A szélesség maximum értéke a Form szélessége, de ebből le kell vonni az aktuális gomb szélességét, különben előfordulhatna, hogy a gomb kilóg a Form-ról
        // A ClientSize.Width a Form belső méretét adja míg a sima Width a külső keretet is számba veszi ezért pontatlanabb
        int left = rng.Next(this.ClientSize.Width - width);
        int top = rng.Next(this.ClientSize.Height - height);

        // Aktuális gomb színe
        // A szín meghatározásához az RGB kódra van szükségünk
        // Ez három darab 0-255 közti számból áll
        int r = rng.Next(256);
        int g = rng.Next(256);
        int b = rng.Next(256);

        // A véletlen számok legenerálása után egyszerűen létrehozható a gomb
        Button gomb = new Button();
        gomb.Width = width;
        gomb.Height = height;
        gomb.Left = left;
        gomb.Top = top;
        gomb.BackColor = Color.FromArgb(r, g, b);
        this.Controls.Add(gomb);
    }
}
```


### 5. Gyakorló feladat: gombok kirakása háromszögben (ismétlés)

Rakd ki egy 10x10-es gombokból álló mátrix gombjait úgy, hogy csak a főátlóban lévők és a főátló alattiak jelenjenek meg!
>[!TIP]
>Itt azt érdemes vizsgálni egy feltételes elágazásban az belső ciklus törzsében, hogy az oszlop száma kisebb-e a sor számánál. 

### 6. Gyakorló feladat: gombok kirakása "karácsonyfában" (ismétlés)

(+/-) Helyezz el gombokat 10 sorban úgy, hogy minden sorban egyel több gomb legyen: az elsőbe egy, a másodikban kettő, a harmadikban három, stb. Tipp: a belső ciklus bennmaradási feltételében felhasználhatod a külső ciklus ciklusváltozójának értékét.

(+/-) Minden gomb legyen 20x20 pixel méretű.

(+/-) Told el a gombok `Left` tulajdonságon keresztül beállított vízszintes koordinátáját úgy, hogy a gombokból álló háromszög bal széle az ablak középvonalába essen. Tipp: az ablak szélességét a `Width` tulajdonságán keresztül tudod kiolvasni. Ha a gombok `Left` tulajdonságának beállításánál `Width/2` értéket hozzáadsz a korábban számított értékhez.

(+/-) Minden sorban egyre jobban húzd balra a koordinátákat úgy, hogy kijöjjön a karácsonyfa.
