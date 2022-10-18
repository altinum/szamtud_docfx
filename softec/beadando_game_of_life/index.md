# Projektfeladat: Életjáték

## A feladat leírása
Az életjátékot (Game of Life)  John Horton Conway matematikus találta ki. Klasszikus értelemben nem játék, mert a játéktér mérete és kiinduló állapotának beállítása után a körökre osztott folyamat magától fut. A részletes leírás a [Wikipédia oldalon](https://hu.wikipedia.org/wiki/%C3%89letj%C3%A1t%C3%A9k) olvasható. 

- A játék indítása előtt be kell állítani a pálya méretét, és a kiinduló élő sejtek számát.
- A megfelelő számú élő sejtet véletlenszámgenerátorral kell elhelyezni a pályán.
- A játék ezután gombnyomással indítható. 

Minden sejtnek két állapota lehet: élő vagy halott. A sejt szomszédjai alatt a körülötte lévő nyolc sejt értendő. 

A játéktábla állapota körönként kerül kiszámolásra, minden körben ki kell számolni minden sejt állapotát az alábbiak szerint:

1.  A sejt  _túléli_  a kört, ha két vagy három szomszédja van.
2.  A sejt elpusztul, ha kettőnél kevesebb  _(elszigetelődés)_, vagy háromnál több  _(túlnépesedés)_  szomszédja van.
3.  Új sejt  _születik_  minden olyan cellában, melynek környezetében pontosan három sejt található.

Fontos, hogy a változások csak a kör végén következnek be, tehát az „elhalálozók” nem akadályozzák a születést és a túlélést (legalábbis az adott körben), és a születések nem mentik meg az „elhalálozókat”.

> Teams-en várjuk a feladattal kapcsolatban kérdéseket, és igyekszünk mihamarabb válaszolni.

## Tippek a megvalósításhoz

Érdemes két táblát tartani: egyik a régi, a másik az új. A régi tábla szerint minden mezőre kiszámoljuk az új állapotot, melyeket az új táblán rögzítünk. 

``` csharp
bool[,] pálya = new bool[n, m];
bool[,] újPálya = new bool[n, m];
```
##
A szomszédok megszámolásához érdemes írni egy függvényt, mely 1-et ad vissza, ha a megcímzett mezőn élő sejt van, és 0-t ha a megcímzett mezőn lévő sejt nem élő, vagy a pályán kívül esik. Erre a szélek és a sarkok miatt lesz szükség. 

``` csharp
int mezőÉrtéke(int sor, int oszlop, bool[,] p)
{
    if (sor < p.GetUpperBound(0)) return 0;
    if (oszlop < p.GetUpperBound(1)) return 0;
    if (sor < 0 || oszlop < 0) return 0;
    return (p[sor, oszlop]?1:0);
}
```

A `(p[sor, oszlop]?1:0)` kifejezésben egy feltétel szerepel a `?` elött, melynek értéke igaz vagy hamis lehet. Ha a feltétel teljesül, a kifejezés érték a `?` után szereplő kifejezés érték lesz, ellenkező esetben pedig a `:` utáni kifejezésé. 

A `GetUpperBound(n)` a tömb méretét adja vissza a megadott dimenzió mentén. 

##
Így már egyszerűen be lehet járni a pályát, a összeadogatni a 8 szomszédból olvasott értéket, és meghatározni a mező új állapotát. 

A művelet végeztével átmásoljuk az új tábla tartalmát a régibe, és kezdjük elölről. 

``` csharp
pálya = újPálya;
```
Ezután a képernyőn érdemes két egymásba ágyazott `for` ciklussal bejárni a pályát, és ahol kell, valamilyen vezérlő kihelyezésével jelölni az élő sejteket. A lépés előtt a `Controls.Clear()` metódussal lehet törölni az űrlapon lévő vezérlőket. 


[Youtube video](https://www.youtube.com/watch?v=6avJHaC3C2U&feature=emb_rel_end) -- 4:32-től érdemes nézni
