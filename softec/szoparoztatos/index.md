# Szópároztatós játék
A játék szövegfájlból olvas fel szópárokat, melyeket színes címkékben helyez el. A szövegfájl minden sorai párosával egy-egy összetartozó magyar és angol szót tartalmaznak. A játékos az egérrel tologathatja a szavakat a képernyőn. Ha a játokos egymás után kattint egy szópárra, mindkét szó eltűnik. A játék célja az összes szó eltűntetése. 

Melléklet: szavak.txt a  http://web.uni-corvinus.hu/~lmohacs/alfa/ oldalról

## Egérrel mozgatható címke készítése

1.	Származtass `Szó` nevű osztályt a `Button` osztályból!
2.	Az osztályt egészítsd ki konstruktorral!
3.	Az osztály szintjén vezess be egy `mozoge` nevű logikai változót `hamis` kezdőértékkel!
4.	Vezess be `ox` és `oy` nevű egész típusú változókat is az osztály szintjén!
5.	A konstruktorban rendelj esemény-kiszolgáló függvényt az egér lenyomásához, felengedéséhez illetve mozgatásához tartozó eseményekhez!
6.	Az egérgomb lenyomásakor az `ox`, és `oy` változók értékét állítsd be az egér aktuális koordinátáinak megfelelően! A `mozoge` változó értéke legyen igaz!
7.	Az egérgomb felengedésére `mozoge` változó kapjon hamis értéket!
8.	Ha az egér megmozdul, vizsgáld meg, a `mozoge` változó értékét! Ha igaz, állítsd be `Szó` koordinátáit értelemszerűen! Tipp: pl. `Left += e.X - ox`;
9.	Egészítsd ki az osztályt publikus `string` típusú `MásikSzó` nevű tulajdonsággal, melyben a szó jelentését tároljuk majd a másik nyelven. (A párok megtalálásánál lesz jelentősége.)
Szópárok felolvasása fájlból, és szétszórásuk az ablakban
10.	A `Form1` konstruktorában vagy `Load` eseményéhez tartozó eseménykiszolgálóban hozz létre egy példányt a `Random` osztályból!
11.	Hozz létre egy példányt a `StreamReader-ből` is, mely megnyitja a *szavak.txt* fájlt! 
12.	Nem előírt lépésszámú ciklussal olvasd végig a fájlt, mely felváltva tartalmaz angol és magyar szavakat, melyek szópárokat alkotnak:
13.	Minden cikluslépésben két sort olvass be a fájlból egy-egy `string` típusú változóba, és két `Szó` címkét pakolj véletlenszerű pozícióba az űrlapra. 
14.	Az egyik címkén a magyar, a másikon az angol szó jelenjen meg. A `Szó` típusú objektumok `MásikSzó` tulajdonsága kapja meg az éppen feldolgozott szópár másik tagját. 
15.	Az angol és a magyar szavakat tartalmazó címkéket különböztesd meg eltérő háttérszínnel!
 
## Párok megtalálása

16.	Bővítsd a `Form1` osztályt `Szó előző = new Szó();` referenciával, melyben az utoljára megkattintott szó referenciáját tárolod majd! (A `new..` azért szerencsés, hogy az első kattintásnál se legyen `null` az előző értéke.)
17.	A fájl feldolgozásáért felelős ciklusban rendelj közös eseménykiszolgálót az összes `Szó` típusú objektum `Click` eseményéhez. Az angol és a magyar jelentéshez tartozó `Szó` objektumok is közös eseménykiszolgálót kapjanak. 
18.	`Click` eseményéhez tartozó közös eseménykiszolgálóban vizsgáld, hogy az utoljára kattintott, előző nevű referencia által hivatkozott szó `MásikSzó` tulajdonságában tárolt érték megegyezik-e az éppen megkattintott szó feliratával! Ha igen, tüntesd el mindkettőt!
19.	A `Click` eseményéhez tartozó eseménykiszolgálóban ne felejtsd el beállítani a előző nevű referenciát az épp megkattintott szóra!


 

 
