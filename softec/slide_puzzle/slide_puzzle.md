## A játék

Az alábbi címen találtok egy szolgáltatást, melynek segítségével külön szoftver telepítése nélkül darabolhattok fel képeket: https://pinetools.com/split-image

Első lépésben választhatok egy szimpatikus képet és daraboljátok fel legalább 4x4 darabra!

Arra érdemes figyelni, hogy a kép szélessége illetve magassága osztható legyen a kívánt osztások számával. Akár Paint-ben is körbe lehet vágni a kiválasztott képet darabolás előtt.

A csempék között lesz egy kitüntetett, amelyen nem jelenik meg a kép. Ha bármelyik mellete lévő csempére kattintunk, a "megkantintott" csempének helyet kell cserélni ha a kitüntetett csempével. A kitüntetett csempére nem lehet kattintani. A helycsere gyakorlatilag a Top és a Left tulajdonságok értékeinek kicserélődését jelenti a kattintott csempe és a kitüntetett csempe között -- de erről majd később. 

## A csempe oszály

Először érdemes létrehozni egy `Csempe` osztályt, és ennek felhasználásával kirakni darabokból a képet egyenlőre úgy, hogy minden képdarab a helyén legyen. 

Érdemes a Csempe osztályt úgy megtervezni, hogy legyen neki egy teljesen kifejtett `Sor` és egy `Oszlop` tulajdonsága is, amelyeknek ha értékül beállítjuk a csempe rácsban elfoglalt pozícióját, a `Top` és `Left` tulajdonságokon keresztül méretének felhasználásával helyezi magát.  Így a csempék helycseréjét `Sor` és `Oszlop` tulajdonságaik cseréjén keresztül is megvalósíthatjuk.

``` csharp
private int _sor;

public int Sor
{
	get { return _sor; }
	set { 
		_sor = value;
		Top = Métert * Sor;
	}
}
```

Érdemes megjegyeztetni a csempével az eredeti sort, illetve eredeti oszlopot. A puzzle akkor van kirakva, ha az `EredetiSor` megegyezik a `Sor`-ral, és az `EredetiOszlop` megegyezik az `Oszlop`-pal az összes csempénél.  Ez megvalósítás szempontjából azt jelenti, hogy A kattintás hoz tartozó esemény kiszolgáló függvényben a helycsere után egy `foreach`-el meg kell vizsgálni hogy az összes csempénél teljesül-e ez a feltétel. Ha akár egyet is találunk ahol nem teljesül, a puzzle még nincs kirakva.

A kitüntetett csempére vonatkozó referenciát érdemes a `Form1`-ben osztályszinten létrehozni. Kitüntetett csempének a pálya kirakásakor bármelyik csempét választhatjuk: lehet mindig valamelyik sarok, vagy akár véletlenszerűen választott elem is. 

##  A csere

 A csempék ciklusból történő kirakásánál érdemes közös esemény kiszolgáló függvényt létrehozni az összes csempe kattintás eseményéhez. Csak akkor kerülhet sor a cserére, a kattintással kiválasztott csempe és a kitüntetett csempe egymás mellett vannak. Ha nem akarunk nagyon bonyolult feltételt írni az `if`-be,  használhatunk abszolút értéket.  Tipp: `Math.Abs()`

Ha a két oszlop különbségének abszolút értéke 1, és a sorok értéke egyezik, egymás mellett vannak, egy sorban. De az is jó hogy ha egymás alatt vannak egy oszlopban.

Ha egymás mellett vannak, sor kerülhet a helycserére! (`Sor` és `Oszlop` tulajdonságokban szereplő értékek cseréje.)

Helycsere után lehet ellenőrizni hogy sikerült-e már kirakni a játékot.

## Automatikus bekeverés

Miután működik a játéknak az a változata, amelyben a helyükön jelennek meg a csempék induláskor, és magunknak kell összekeverni, hogy aztán kirakhassuk, érdemes elgondolkozni azon hogy hogyan lehetne bekeverni a csempéket. Felmerül a kérdés, hogy minden tetszőlegesen összekevert konfiguráció megoldható-e.

Kérdezzük meg a ChatGPT-t: 

```
What are the solvable configurations for the sliding puzzle game?
```

Ennek megfelelően tegyetek javaslatot arra hogy hogyan lehetne bekeverni a csempéket!
