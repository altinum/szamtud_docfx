# Lokális adatbázis
Egy adatbázis-szerver üzemeltetése erőforrás igényes és költséges feladat. A lokális adatbázis egyértelmű hátránya, hogy nem igazán tudja egyszerre több felhasználó elérni az adatokat. Viszont nincs szükség internet elérésre és/vagy szerver üzemeltetésére a használatához. Lokális adatbázis használata *production*, azaz éles környezetben nem javasolt, fejlesztéshez és prototípus készítéshez viszont kiváló eszköz.


## Lokális adatbázis létrehozásának lépései egy Visual Studio projektben
◯ Adj egy `Service based database` objektumot a projekthez, az objektum neve lesz az adatbázis neve! (A képen látható ablak a *Solution Explorer*-ben jobb egérgombra megjelenő menüben az *Add new item* menüpontra kattintva jelenik meg.)

![kep1]

Ez két új fájlt fog létrehozni a Solution Explorerben:

* A .mdf kiterjesztésű maga az adatbázis
* Az .ldf kiterjesztésű az adatbázishoz kapcsolódó log fájl. (Ez  utóbbit büntetlenül lehet törölni is, legfeljebb újra létrejön.)

![kep2]
   
   
◯ A Server Explorer-ben csatlakozz a létrejött adatbázishoz

Új Connection felvétele esetén most nem a szerver, hanem a `Microsoft SQL Server Database File` opciót kell kiválasztani!

   ![kep3]
   ![kep4]
   Előfordulhat, hogy az mdf-et csak akkor engedi kiválasztani a VS, ha be van zárva az azt tartalmazó projekt!
   A Windows Authentication opció maradjon kiválasztva.
   
   ![kep5]
   
Ezt a VS automatikusan elvégzi a `Service based database` létrehozásakor, de ha egy másik gépen újra nyitod a projektedet, akkor már kézzel kell majd megcsinálni.
   
◯ Mindkét(!!!) létrejövő fájl `Copy to Output Directory` tulajdonságát állítsd át `Copy if newer`-re
    
>    **Magyarázat:**
     A projekt mappában található fájlok nem feltétlenül kerülnek be a végleges programba. *Build*-eléskor a Visual Studio lefordítja a programot és egy futtatható .exe kiterjesztésű állományt hoz létre belőle a bin/Debug mappába. A projekthez tartozó fájlok (pl.: képek) csak akkor másolódnak be ebbe a mappába, ha a fenti propery megfelelően van beállítva.
    A lokális adatbázis fájlok beállítása azonban alapértelmezetten `Copy always`. Ha futtatjuk a programunkat és módosítunk az adatbázis tartalmán, akkor annak tartalma elmentődik a `bin/Debug` mappában levő adatbázis fájlba. Viszont, ha újból futtatjuk a programot Visual Studio-ból, akkor az eredeti adatbázis fájl átmásolódik és felülírja a `bin/Debug`-ban levőt. Ezért úgy tűnik majd, hogy nem módosultak az adataink. (Ez a jelenség nem áll fenn, ha az *exe* fájl közvetlen futtatásával próbáljuk ki a programot.)
    Ha tehát módosul az eredeti adatbázis fájl a projekt mappában (pl.: új rekordot veszünk fel Server Explorer-ben vagy módosítjuk egy tábla mezőit), akkor az aktuális állapot felül fogja írni a bin/Debug tartalmát. Előfordulhat azonban, hogy kényelmesebb a programunkon keresztül felvenni az új rekordokat az adatbázisba.
    Ebben az esetben a következő a teendő:
	1. Indítsd el a programot (mindegy, hogy VS-ből vagy az exe-vel) és vedd fel az új rekordokat az adatbázisba
    2. Zárd be a programot, de ne indítsd el újra, mert elveszhetnek a felvett adatok
    3. Zárd be az egész projektet amiben dolgozol
    4. Keresd meg az mdf és az ldf kiterjesztésű fájlokat a bin/Debug mappában
    5. Másold be ezt a két fájlt a projekt mappába, és írd felül az ott levő változataikat
    6. A projektet újra nyitva a Server Explorer-ben jobb klikk egy érintett táblán, és a `Show Table Data` opcióval meg tudod nézni, hogy valóban bekerültek-e a módosítások az eredeti adatbázisba is

◯ Az ORM létrehozásától kezdve a lokális adatbázist ugyanúgy kell használni, mint bármelyik szerveren található adatbázist.

Egy apró különbség, hogy mivel itt nincs authentikáció, ezért nincs olyan érzékeny adat, amit le kellene menteni a *ConnectionString*-be

[kep1]: service-based-db-1.png
[kep2]: service-based-db-2.png
[kep3]: local-connection-1.png
[kep4]: local-connection-2.png
[kep5]: local-connection-3.png
