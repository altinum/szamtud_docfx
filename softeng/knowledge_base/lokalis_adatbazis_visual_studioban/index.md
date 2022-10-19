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
   


◯ Az ORM létrehozásától kezdve a lokális adatbázist ugyanúgy kell használni, mint bármelyik szerveren található adatbázist.

Egy apró különbség, hogy mivel itt nincs authentikáció, ezért nincs olyan érzékeny adat, amit le kellene menteni a *ConnectionString*-be

[kep1]: service-based-db-1.png
[kep2]: service-based-db-2.png
[kep3]: local-connection-1.png
[kep4]: local-connection-2.png
[kep5]: local-connection-3.png
