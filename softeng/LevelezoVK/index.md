# Szoftvertechnológia II. levelező vizsgakurzus

A feladat ASP. NET illetve Forms felhasználói felület építése egy szabadon választott adatbázishoz, mely valós vagy kitalált problémára, vagy annak egy részére nyújt megoldást. Az adatbázis lehet saját készítésű, de használható  minta adatbázis is, mint az  [AdventureWorks.](https://learn.microsoft.com/en-us/sql/samples/adventureworks-install-configure?view=sql-server-ver16&tabs=ssms) Az adatbázissal szemben annyi a követelmény, hogy legalább négy táblából álljon, és tartalmazzon több-a-több kapcsolatot. 

A baloldali linkeken többféle megoldás is bemutatásra kerül az adatbázis hosztolására. Szükség esetén ebben is szívesen segítünk.

A feladat kötetlen, mivel minden adatbázis más, és más követelményeket támaszt az UI-vel szemben. A megvalósítás során alkalamzott megoldásokra az alábbi táblázat alapján kapható pont. 

> [!NOTE] 
>
> Javasoljuk, hogy tervezéssel kezdjétek a munkát! Egy lapra rajzoljátok le, hogy mit szeretnétek megvalósítani, és az [Árlap](#Árlap) alapján kiszámolni a pontértéket. Összehasonlításul: az 1b ZH az árlap alapján 

A jeleshez 40 pontot kell gyűjteni.

> [!IMPORTANT]
>
> A honlap folyamatosan bővül újabb segédanyagokkal. 
>
> Ha bármiben tudok segíteni, keressetek Teams-en!



## Árlap 

A pontszámok szorzat formájában kerültek megadásra, pl: `4x1p`. A **második** szám -- a példában `1p` -- azt jelenti, hogy hogy hány pontot ér az adott részfeladat, az **első** pedig az adja meg, hogy hány ismétlés kerül beszámításra. Így nem lehet egyetlen részfeladat ismételgetésével teljesíteni a követelményt. 

**Adatbázis**

- `1x15p` A saját tervezésű adatbázis 15 pontot ér! Annyi adattal kell csak feltölteni, hogy kipróbálható legyen működés közben.

##### User Interface 

- `1x2p` Az alkalmazásból a **kilépés csak megerősítő kérdés után** lehetséges. 
- `3x2p` Olyan alkalmazás **elrendezés, melyben gombok lenyomására UserControl-ok kerülnek elhelyezésre egy Panel vezérlőben**, teljesen kitöltve azt. Minden gombra jár a pont, amennyiben az funckuonlalitással rendelkező UserControl-t tölt be. 

- `3x1p` **Többablakos alkalmazás** legalább két felugró ablakkal. Minden Form-nak saját osztályon kell alapulnia, és funcionalitással kell rendelkeznie. Az ablakok nyílhatnak gombokkal vagy felső menüből is.

- `1x2p` **Anchorok alkalmazása**: az alkalmazás egészében meg van oldva, hogy az ablak átméretezésekor ki legyen használva a rendelkezésre álló terület.	

##### Tábla adatainak megjelenítése `ListBox`-ban. 

- `1x2p` Adatok  megjelenítése 
- `2x2p` Ha az adatok tetszőleges módszerrel, pl. `TextBox`-on keresztül szűrhetőek. 
- `1x2p` Ha a tábla adatforrása saját osztály. 

##### Tábla adatainak megjelenítése `DataGridView`-ban 

- `1x2p` Adatok  megjelenítése 
- `1x2p` Ha a tábla idegen kulcsot is tartalmaz, melynek megjelenítése `DataGridViewComboBoxColumn`-on keresztül történik. 
- `1x2p` Ha a tábla adatforrása saját osztály. 

##### Adatkötés `BindingSource` -on keresztül

- `1x2p` Működő  `BindingSource` 
- `3x1p` Egy `BindingSource`-ra egy gyűjemény megjelenítésére alkalmas vezérlő (ListÍBox, ComboBox, DataGridVIew) mellett más adatkötött vezérlő is van kötve, mint `TextBox`, `DateTimePicker`, `ComboBox` idegen kulcs értékének beállítására, stb.

##### Új rekord rögzítése 

A pontok összeadódnak. 

- `2x2p` master-detail reláció detail táblájába ÉS/VAGY több-a-több kapcsolatban álló táblák kapcsolótáblájába
- `1x2p` Ha csak az idegen kulcsok vannak felvéve
- `1x1p` Ha legalább egy nem kulcs mező, pl. _Mennyiség_ is fel van véve
- `1x2p` Ellenőrzéshez kötött adatfelvitel (egyszerű validáció pl: `String.IsNullOrEmpty()`)
- `1x2p` Felugró ablakon keresztül történik _Ok_ és _Mégse_ gombbal
- `1x2p` Ha az űrlap legördülő dobozon vagy listán keresztül beállítható idegen kulcsot is tartalmaz
- `2x1p` A kitöltési hiba `ErrorProvider`-en keresztül kerülnek köközlésre a felhasználóval, hibás kitöltés esetén nem enged rányomni az _Ok_ gombra
- `1x2p` `Regex` alapú validáció
- `1x1p` Hibás kitöltés esetén nem lehet megynomni az _Ok_ gombot. 

#####  Rekord törlése 

- `1x2p` Sikeres törlés
- `1x2p` Megerősítéshez kötött törlés

##### Diagram rajzolása, Excel munkafüzet generálása

- `1x5p` Tetszőleges diagram rajzolása
- `1x2p` A diagram adatforrása tetszőleges módszerrel szűrhető 
- `1x7p` Excel munkafüzet generálása kódból, adatbázistábla tartalmának megjelenítésével, legalább egy formázással

