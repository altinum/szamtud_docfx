## Hitel költségének számítása

A feladat a nyelvi elemek bemutatására szolgál, nem pénzügyi oldalról közelíti a problémát.

``` csharp
private void btnOk_Click(object sender, EventArgs e)
{
    decimal hitelÖsszeg = decimal.Parse(tbHitelÖsszege.Text);
    decimal haviKamat = decimal.Parse(tbHaviKamat.Text);
    decimal haviTörlesztő = decimal.Parse(cbHaviTörlesztő.Text);

    decimal hátralék = hitelÖsszeg;
    decimal befizetés = 0;

    List<Sor> sorok = new List<Sor>();

    int hónap = 1;
    while (hátralék > 0)
    {        
        hátralék += haviKamat * (hátralék/100m);
        hátralék -= haviTörlesztő;
        befizetés += haviTörlesztő;
        hónap++;

        Sor újSor = new Sor();
        újSor.Hátralék = Math.Round(hátralék);
        újSor.Hónap = hónap;

        sorok.Add(újSor);
    }

    dataGridView1.DataSource = sorok;
}
```



``` csharp
class Sor
{
    public int Hónap { get; set; }
    public decimal Hátralék { get; set; }
       
}
```

## Megjegyzések a kódhoz

#### A `Sor` osztály

A `Sor` osztály felfogható egy olyan összetett típusnak mely képes két szám tárolására:

- egy `int` típusú `Hónap` nevű tulajdonságban tároljuk a hónap számát
- egy `decimal` típusú `Hátralék` nevű tulajdonságban tároljuk az adott hónapra vonatkozó hátralékot

#### A `Sor` osztály példányosítása

A `Sor` egy osztály. Az oszályokból példányokat hozunk létre -- ebben a példában minden héthez létrehozunk egy-egy példányt. A példány létrehozása a `new` kulcsszóval történik. Ezután kerülhet sor az `újSor` nevű példány tulajdonságainak beállítására.

``` csharp
Sor újSor = new Sor();
újSor.Hátralék = Math.Round(hátralék);
újSor.Hónap = hónap;
```

> [!IMPORTANT]
>
> Egy osztályból létrehozott példányt nevezünk **objektum**nak! A példában az `újSor` egy `Sor` típusú objektum.

#### Objektumokból álló listák

Listát mindenféléből lehet csinálni, de meg kell adni az elemtípust:

```c#
List<int> egészSzámok = new List<int>();
List<string> szavak = new List<string>();
```

A `List` is egy osztály, belőle is a `new` kulcsszóval hozunk létre példányokat.

Az igazán izgalmas az, amikor egy osztály szerepel az elemtípus helyén, mint a példában:

``` csharp
List<Sor> sorok = new List<Sor>();
```

Ezzel lényegében létrehoztunk a memóriában egy táblázatot, melynek sorai a hónapok számát és az adott hónaphoz tartozó hátralék értékét tartalmazák.

Ennek később, amikor adatbázistáblákat mozgatunk az SQL szerver és az alkalmazás között, lesz jelentősége!

## Feladatok

(+/-) Oldjátok meg, hogy az utolsó hónapban ne mehessen negatívba a hátralék!

(+/-) A hátralék mellett jelenítsétek meg a befizetések kummulált összegét. Ehhez új tuladjonságot kell felvenni a `Sor` osztályba.