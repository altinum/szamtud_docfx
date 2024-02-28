# Projektfeladat:  Kígyós játék almákkal
## A feladat leírása

A gyakorlaton felépített kígyós játék folytatása a feladat az alábbiak szerint:

- Bizonyos lépésszámonként gyorsuljon a játék, de ne kerüljön negatív érték az időzítőbe. (Itt ez a hibatűrés.)
- A kígyóelemek periodikusan ismétlődő színűek legyenek!
- A kígyó hossza ne automatikusan nőjön, hanem bizonyos lépésszámonként jelenjenek meg véletlenszerűen almák vagy hasonló elemek, melyeket meg lehet enni, és ezektől hosszabbodjon a hüllő. 
- Az almákhoz hasonlóan mérgek is jelenjenek meg, melyek megölik vagy rövidítik az állatot. (Szabadon választható.)
- Az eltelt idő és a lépésszám megjelenítendő.

Extra: legyen két kígyó!

> Teams-en várjuk a feladattal kapcsolatban kérdéseket, és igyekszünk mihamarabb válaszolni.

## Tippek a megvalósításhoz

### Kígyóelemek és almák vegyesen

Ha kígyóelemek és almák vegyesen kerülnek az űrlapra, már nem működik az a megközelítés, hogy minden lépésben hozzáadunk egy új kígyóelemet a `Controls` gyűjteményhez, majd kivesszük a `Controls` gyűjtemény 
0. elemét, mert az almáknak is a  gyűjtemény részét kell képezniük. Szükség lesz egy külön listára, melyben a kígyó elemeit tartjuk:

``` csharp
List<Kigyoelem> kígyóelemek = new List<Kigyoelem>();
```

Az "előremozdulásnál" a lista alapján meghatározzuk a levágandó farokelemre mutató referenciát, majd eltávolítjuk mind a kígyóelemeket tartalmazó listából, mind a `Controls` listából. 

``` csharp
 Kigyoelem levágandóFarok = kígyóelemek[0];
 Controls.Remove(levágandóFarok);
 kígyóelemek.Remove(levágandóFarok);
```

### Objektumok típusának megállapítása

Az alábbi kódrészlet az űrlapon szereplő vezérlők közül a gombokat fuksziára színezi, a címkéket nem fuksziára. Ez a megoldás felhasználható annak eldöntésére, hogy kígyóelemnek vagy almának ütköztünk. 

``` csharp
//Bejárjuk egy iterációval az űrlap összes vezérlőjét, azaz a Controls gyűjteményt
foreach (var elem in Controls)
{
    //Az épp vizsgált elem Button?
    if (elem is Button)
    {
        //Ha igen, cast-oljuk Buttonná, és színezzük
        Button b = (Button)elem;
        b.BackColor = Color.Fuchsia;
    }


    //Az épp vizsgált elem Label?
    if (elem is Label)
    {
        //Ha igen, cast-oljuk Labellé, és színezzük
        Label l = (Label)elem;
        b.BackColor = Color.Blue;
    }
}
```
