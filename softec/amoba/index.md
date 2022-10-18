# Aknakereső

## Előadásra szánt videók

[1. videó](S1misc_1.m4v) -- Menüszalag használata

[2. videó](S1misc_2.m4v) -- Többablakos alkalmazások, a `Show()` és a `ShowDialog()` metódus közötti különbségek. 

[3. videó](S1misc_3.m4v) -- Párbeszédablakok visszatérési értéke, a `DialogResult`

[4. videó](S1misc_4.m4v) -- `MessageBox`

[5. videó](S1misc_5.m4v) -- Űrlap bezárásának megszakítása, a `Closing` esemény

[6. videó](S1misc_6.m4v) -- Az `OpenFileDialog`  használata

[7. videó](S1misc_7.m4v) -- Ikonok használata



## Képernyőbillentyűzet
Ez csak egy rávezető feladat a fájlkezeléshez és a közös eseménykiszolgálók kezeléséhez, nem kell leadni. A feladat egy billentyűzet felépítése a billentyűk elhelyezkedését leíró file alapján. 

[kbd_hun.txt](kbd_hun.txt) -- kiinduló állomány

A fájl billentyűk elhelyezkedését, méretét, és a rajtuk lévő feliratot tartalmazza. Olvasd fel a fájlt, és rakd ki gombokból a billentyűzetet!

[1. videó](S1kbdhun1.m4v)

[2. videó](S1kbdhun2.m4v)

## Aknakereső játék

#### A megoldás menete magyarázatokkal

[1. videó](S1mine_1.m4v) -- Bevezetés

[2. videó](S1mine_2.m4v) -- `Mező` osztály felépítése 

[3. videó](S1mine_3.m4v) -- Pályaépítés mezőkből

[4. videó](S1mine_4.m4v) -- Aknásítás

[5. videó](S1mine_5.m4v) -- Mezők felfedése

[6. videó](S1mine_6.m4v) -- Mezők rekurzív felfedése

[7. videó](S1mine_7.m4v) -- Nagy pálya `Panel`-ben

#### A Mező osztály
(+/-) Származtass osztályt `Mezo` néven a `Button` osztályból!

(+/-) Vegyél fel egy osztályszintű egész szám konstanst, legyen az értéke 25. A konstruktorban méretezze magát a mező a konstans szerint!

(+/-) A mezőnek a játékhoz két dolgot biztosan tudnia kell magáról: akna-e, és hogy a szomszédjában hány akna van. Vegyél fel ehhez a két adathoz osztályszintű mezőket!

(+/-) Mivel a mező mérete az osztályban szabályozható, így célszerű saját maga elhelyezését is rábízni. Ehhez alakítsd át a konstruktort, hogy fogadjon sor és oszlop pozíciót, majd a `Top` és `Left` tulajdonságokat állítsd be e szerint. Tárolt ezeket az értékeket későbbi felhasználásra osztályszintű változóként.

(+/-) A mező funkcionalitása a játékban a kattinthatóság: ha még nincs felfedve és rákattintunk, akkor, ha akna, vége a játéknak, ha nem, akkor megjeleníti a szomszédságában található aknák számát. Készíts tagfüggvényt, ami ellátja ezt a feladatot! 

``` csharp
class Mező : Button
{
    public static int méret = 25;
    public bool akna = false;
    public bool felfedve = false;
    public int szomszédszám = 0;
    public int sor, oszlop;

    public Mező(int sor, int oszlop)
    {
        this.sor = sor;
        this.oszlop = oszlop;
        this.Top = oszlop * Mező.méret;
        this.Left = sor * Mező.méret;
        this.Height = Mező.méret;
        this.Width = Mező.méret;
    }

    public void FelFed()
    {
        if (akna)
        {
            MessageBox.Show(":(");
        }
        else
        {
            this.FlatStyle = FlatStyle.Flat;
            if (szomszédszám > 0)
            {
                this.Text = szomszédszám.ToString();
            }
        }
        this.felfedve = true;
    }
}
```

#### A Form kódja
##### Pályagenerátor
(+/-) A `Form` osztályának feladata, hogy kellő mennyiségben kipakoljon mezőket a játéktérre. Ehhez készíts egy pályagenerátor tagfüggvényt, amely két paramétert kap: vízszintes és függőleges játéktérméret. Két egymásba ágyazott ciklussal tegyél ki mezőket.

(+/-) A pályára rakott mezőket ne csak a formhoz add hozzá, hanem tárold egy kétdimenziós tömbben is az első lépésben készült tagfüggvény kiegészítésével. A tömb legyen osztályszintű változó, amit a pályagenerátor bemeneti paraméterei alapján hozol létre.

(+/-) Szintén tárold osztályszintű változóban a megadott függőleges és vízszintes méretet!

(+/-) Hívd meg a pályagenerátort 10,10 paraméterekkel a form konstruktorából. Elindítva az alkalmazást, már látszania kell a pályának.

##### Aknák kirakása
(+/-) Készíts tagfüggvényt, ami a már kirakott mezőkön véletlenszerűen helyez el aknákat. Hogy mennyi aknát rakjon ki, legyen bemeneti paraméter.

(+/-) A tagfüggvényben indíts ciklust, amely az átadott aknaszámnak megfelelő alkalommal fut le.

(+/-) A ciklusban generálj két véletlenszámot, melyek értéke 0 és a függőleges, illetve a vízszintes méret közé esik.

(+/-) A véletlenszám generátor példányosítását a ciklus előtt végezd el! (Mi a különbség?)

(+/-) Minden akna kirakásakor a szomszédos mezők szomszed értékét növeld eggyel!

(+/-) Futtatva a programot hibába ütközünk. A hiba oka, hogy a pálya peremére kerülő aknák esetén a szomszédok nem feltétlenül léteznek, ezt vizsgálni kell mielőtt a szomszed értéket növeljük. Ehhez egészítsd ki feltételekkel a megfelelő programrészt. Célszerű ehhez létrehoznod egy tagfüggvényt.

##### Felfedés

(+/-) Futtatva a programot ugyan nincs hiba, de nem is használható semmire az alkalmazás.

(+/-) A pályagenerátor függvényben rendelj közös esemény-kiszolgáló függvényt a kirakott mezőkhöz.

(+/-) Az esemény-kiszolgálóban hívd meg a Mezo felfed tagfüggvényét. Ha szükséges, módosítsd a tagfüggvény láthatóságát.

##### Szomszédok felfedése
Futtatva a programot most már van aknavizsgálat és a szomszédok értéke is kiíródik, de a "szigetszerű" felfedés még nem történik meg. A mezőszintű felfedés mellett a form1 osztálynak kell gondoskodnia erről.

(+/-) Készíts tagfüggvényt Felfedes néven a form1 osztályban is. Paraméterül kapja a sor és oszlop értéket. 

(+/-) A függvény, ha a kapott paraméterek szerinti mező szomszéd értéke 0, felfedi az összes szomszédos mezőt, ha azok nem aknák. A feladat leírásából is kitűnik, hogy ez egy rekurzív feladat. A rekurzió leállítási feltétele:
- Adott mező szomszédság értéke legyen 0
- Ne legyen akna
- Ne legyen még felfedve

(+/-) A függvény törzsén belül a paraméterek alapján vedd ki a mezőt a pálya tömbből, majd fogalmazz meg egy feltételt a fenti leállítási feltétel alapján. Ha a feltétel teljesül, és az adott mező pályán van, a függvény fedje fel a sor, oszlop által meghatározott mezőt, majd hívja meg saját magát a mező szomszédos mezőin végighaladva!

``` csharp
public partial class Form1 : Form
{
    Mező[,] pálya;
    int szélesség;
    int magasság;

    public Form1()
    {
        InitializeComponent();
        PályaGenerátor(10, 10);
        AknaPakoló(10);
    }

    void AknaPakoló(int aknaszám)
    {
        Random rnd = new Random();
        for (int i = 0; i < aknaszám; i++)
        {
            int sor = rnd.Next(magasság);
            int oszlop = rnd.Next(szélesség);
            pálya[sor, oszlop].akna = true;
            if (PályánVanE(sor - 1, oszlop - 1)) pálya[sor - 1, oszlop - 1].szomszédszám++;
            if (PályánVanE(sor - 1, oszlop + 1)) pálya[sor - 1, oszlop + 1].szomszédszám++;
            if (PályánVanE(sor + 1, oszlop - 1)) pálya[sor + 1, oszlop - 1].szomszédszám++;
            if (PályánVanE(sor + 1, oszlop + 1)) pálya[sor + 1, oszlop + 1].szomszédszám++;
            if (PályánVanE(sor - 0, oszlop + 1)) pálya[sor - 0, oszlop + 1].szomszédszám++;
            if (PályánVanE(sor - 0, oszlop - 1)) pálya[sor - 0, oszlop - 1].szomszédszám++;
            if (PályánVanE(sor + 1, oszlop - 0)) pálya[sor + 1, oszlop - 0].szomszédszám++;
            if (PályánVanE(sor - 1, oszlop - 0)) pálya[sor - 1, oszlop - 0].szomszédszám++;
        }
    }

    bool PályánVanE(int sor, int oszlop)
    {
        if ((sor < 0) || (oszlop < 0)) return false;
        if ((sor >= magasság) || (oszlop >= szélesség)) return false;
        return true;
    }

    void PályaGenerátor(int szélesség, int magasság)
    {
        this.szélesség = szélesség;
        this.magasság = magasság;

        pálya = new Mező[szélesség, magasság];
        for (int s = 0; s < magasság; s++)
        {
            for (int o = 0; o < szélesség; o++)
            {
                Mező m = new Mező(s,o);
                this.Controls.Add(m);
                pálya[s, o] = m;
                m.Click += new EventHandler(m_Click);
            }    
        }
    }

    void m_Click(object sender, EventArgs e)
    {
        Mező m = (Mező)sender;
        felfedés(m.sor, m.oszlop);
        m.FelFed();
    }

    void felfedés(int sor, int oszlop)
    {
        Mező mező = pálya[sor, oszlop];
        if (mező.szomszédszám == 0 && !mező.akna && !mező.felfedve)
        {
            mező.FelFed();
            if (PályánVanE(sor - 1, oszlop - 1)) felfedés(sor - 1, oszlop - 1);
            if (PályánVanE(sor - 1, oszlop + 1)) felfedés(sor - 1, oszlop + 1);
            if (PályánVanE(sor + 1, oszlop - 1)) felfedés(sor + 1, oszlop - 1);
            if (PályánVanE(sor + 1, oszlop + 1)) felfedés(sor + 1, oszlop + 1);
            if (PályánVanE(sor - 0, oszlop + 1)) felfedés(sor - 0, oszlop + 1);
            if (PályánVanE(sor - 0, oszlop - 1)) felfedés(sor - 0, oszlop - 1);
            if (PályánVanE(sor + 1, oszlop - 0)) felfedés(sor + 1, oszlop - 0);
            if (PályánVanE(sor - 1, oszlop - 0)) felfedés(sor - 1, oszlop - 0);
        }
    }
}
```

#### További gyakorlási lehetőségek 

(+/-) Nyerésvizsgálat: Ha már csak "akna" nem felfedett mezők maradtak a pályán, a játékot megnyerted. Oldd meg, hogy kattintáskor történjen nyerésvizsgálat!

(+/-) Újraindítás: Játék elveszítésekor vagy megnyerésekor készüljön új pálya és induljon újra a játék!

(+/-) Jobb kattintással lehessen megjelölni az aknának sejtett mezőket!
