# Csillagtérkép



A mai gyakorlaton egy csillagtérképet fogunk rajzolni. A csillagok adatai egy SQL adatbázisban vannak. Az adatok a [Hipparcos](https://www.cosmos.esa.int/web/hipparcos) katalógusból származnak, mely körülbelül 11800 égi objektum adatait tartalmazza. 

A gyakorlaton lehetőség nyílik nagyobb adathalmazzal is dolgozni, nemcsak néhány mintaadattal feltöltött oktatási célú táblákal. 

## Adatbázis kapcsolat

Hozzatok létere új projektet, és hozzátok létre az előző héten bemutatott módon az ORM oszályokat:

|                |                     |
| -------------- | ------------------- |
| Szerver        | bit.uni-corvinus.hu |
| Felhasználónév | hallgato            |
| Jelszó         | Password123         |
| Adatbázis      | hajos               |



> [!IMPORTANT] 
>
> A bit.uni-corvinus.hu SQL szerver csak VPN alól érhető el!



## Az adatokról

A `StarDatum` Táblából mindössze négymezőre lesz szükségünk: a csillagot azonosító `Hip` mezőre, az `X` és `Y` koordinátákra, illetve az égitest fényességét megadó magnitúdóra. Az `X` és `Y` koordináták egy adott időpillanatban Budapestről látható koordinátáit jelölik, sztereografikus projekcióval, száznyolcvan fokos látószöggel. Evvel a két mezővel került kiegészítésre az eredeti adatbázis. 

A (0,0) koordinátájú pont zenit, Az égi objektumok pedig egy egység sugarú körben helyezkednek el. A körvonal maga a horizont. Felfelé van észak. A körön kívül eső objektumokat nem kéne megjeleníteni, hiszen ezeket eltakarja a Föld.  A `ConstellationLine` táblának két oszolpa van: `star1` és `star2`. Ezeket a csillagokat kell egy-egy vonallal összekötni, ha a csillaglépeket is ki akarjuk rajzolni. 



## Csillagok letöltése az SQL szerverről



Első lépésben érdemes egy listát létrehozni. 

```csharp
 var stars = (from s in context.StarData select new {s.Hip, s.X, s.Y, s.Magnitude }).ToList();
```

Ha valakinek szimpatikusabb, lehet lambda kifejezéseket is használni:

```c#
var stars = context.StarData.Select(s => new { s.Hip, s.X, s.Y, s.Magnitude }).ToList();
```

A `new {s.Hip, s.X s.Y, s.Magnitude }` egy úgynevezett anonim típus, ilyen típusú elemekből álló lista lesz a `stars`. A `stars` már a gépünk memóriájában lakik, ha ebből csinálunk LINQ lekérdezéseket, már nem terheljük az SQL szervert. 

Ezt a listát kell majd bejárni egy `foreach`-el, és kirajzolni a csillagokat!

```c#
foreach (var s in stars)
{
	//Rajzolás
}
```



## GDI grafika

A rajzoláshoz a GDI grafikát fogjuk használni. Ez egyszerű vonalas ábrák rajzolására alkalmas, a játékfejlesztők nyilván nem ezt használják. Viszont cserébe egyszerű, adatvizualizációra kiválóan alkalmas.

A rajzolást érdemes egy gomb eseménykiszolgáló függvényből indítani.

```c#
Graphics g = this.CreateGraphics();

g.Clear(Color.White);

Color c = Color.Black;

Pen toll = new Pen(c, 1);
Brush brush = new SolidBrush(c);
```

A `Graphics g = this.CreateGraphics();` az űrlapon létrehoz egy felületet, amire lehet rajzolni. 

A `g.Clear(Color.White);` fehérrel törli az űrlapot, lehet szép mélykék színeket is használni.

Vonalas objektumok rajzolására létre kell hoznunk egy toll (`Pen`) objektumot kitöltött objektumok ecset (`Brush`) segítségével rajzolhatóak.

```
g.FillEllipse(brush, 10, 10, 10, 10);
g.DrawLine(toll, 10, 10, 10, 10);
```

 csillagokat érdemes kitöltött ellipszisből rajzolni!

> [!IMPORTANT]
>
> A koordinátákat `float` vagy `int` típusban kell megadni! ne felejtsd el konvertálni!



TIPP: a kirajzolásnál érdemes az ábrát eltolni az ablak közepére. Ha megfigyelitek, az adatbázisban a koordináták negatív és pozitív értékeket is felvehetnek. 

```csharp
float cx = ClientRectangle.Width / 2;
float cy = ClientRectangle.Height / 2;
```

Érdemes kísérletezni a nagyítás értékével. Aki nagyon szofisztikált szeretném megoldani a feladatot megnézi, hogy milyen tartományba esnek a koordináták, és az ablak méretéből kiszámolja az optimális nagyítást.

A **magnitúdó** a csillagászatban az égitestek fényességének mértékegysége. A magnitúdó latinul magnituto, magnitutis: nagyság. A magnitúdó skálája logaritmikus és faktora negatív: 5 magnitúdó különbség 100-szoros intenzitáskülönbséget, a kisebb érték nagyobb fényességet jelent! Tiszta, sötét égbolton a szabad szemmel még meglátható csillagok fényessége kb. 6m, a legfényesebbeké 0m. A feladat megoldásánál a 10m-nél halványabb égitesteket nem érdemes megjeleníteni hiszen ezeket szabad szemmel úgysem látjuk. 
Ha minden égitestet egyforma méretűre rajzolunk, nem lesz látványos az ábra. Lehet játszani a pixelek színével, illetve a fényesebb égitestek helyére rajzolhatunk egy korongot.

Ilyesmivel lehet kísérletezni:

```csharp
double size = 20 * Math.Pow(10, (star.Magnitude) / -2.5);
```

## Konstellációk

A`ConstellationLine ` tábla megadja, hogy melyik `Hip` számú csillagokat kell vonallal összekötni. Érdemes ezt a táblát is letölteni a memóriába egy listába, és ezután bejárni:

```csharp
var lines = context.ConstellationLines.ToList();

foreach (var line in lines)
{
  //...   
}
```

A `foreach` törzsében minden vonalhoz ki kell keresni a két csillagot, amit összeköt a vonal. Például így:

```csharp
var star1 = (from s in stars where s.Hip == line.Star1 select s).FirstOrDefault();
```

Érdemes odafigyelni a `.FirstOrDefault()`-ra a végén! A `from s in stars where s.Hip == line.Star1 select s` kifejezés egy gyüjteményt ad vissza, még akkor is, ha mi tudjuk, hogy csak egy eleme lesz -- vagy nem lesz eleme. A `FirstOrDefault()` a gyűjtemény első elemét adja vissza, vagy `null` értéket, ha a gyüjtemény üres. Innét már használhatjuk a `star1.X` kifejezést a vonalhúzásnál!