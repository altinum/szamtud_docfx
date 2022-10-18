# Honnét lesz SQL szerverem?
Mindenkiben felmerülhet a kérdés, hogy az egyetem elvégzése után hogyan építhető fel az a szoftveres környezet, amelyben megtanult technológiák a gyakorlatban, üzleti környezetben is használhatók. Ez a dokumentum ebben nyújt segítséget.

A félév tananyagához kapcsolódó MS-SQL szerver üzemeltetésére az alábbi lehetőségek kínálkoznak:

1. Vállalati / egyetemi MS-SQL szerver
2. Azure infrastruktúrában futó SQL szerver
3. MS-SQL Express vagy Developer Edition
4. MySQL 
5. Lokális adatbázis-fájl használata

## Vállalati / egyetemi MS-SQL szerver

Az [SQL Server Downloads](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) oldalról letölthető az **SQL Server 2019 on-premises** változat, melyben az *on-premises* kifejezés azt jeleni, hogy vállalat a saját infrastruktúrájában üzemelteti a szervert. A legtöbb vállalt IT Policy-jába nem fér bele, hogy az üzleti szempontból kritikus adatok a vállalat IT infrastruktúráján kívül kerüljenek tárolásra. A kevésbé kritikus szolgáltatások mögött lévő adatbázisok viszont egyre gyakrabban költöznek a felhőbe.

Az MS-SQL szerver telepítéséhez a Windows szerver változatára van szükség, melynek licencköltségeivel szintén számolni kell. 

## Azure infrastruktúrában futó SQL szerver

A másik lehetőség MS-SQL szerver és adatbázis Azure infrastruktúrában történő bérlése. 

Az **Azure for students** előfizetés keretében minden hallgató kap egy 100 dolláros keretet, melyet Azure szolgáltatások egy korlátozott körére költhet el. SQL adatbázisból illetve MS-SQL szerverből nem áll rendelkezésre ingyenes, korlátozott kapacitású változat. Gyakorláshoz és tanuláshoz érdemes a legkisebb elérhető szerver kapacitást választani, és ha nincs szükség a szerverre, az [Azure portál](https://portal.azure.com)on keresztül leállítani. A szerver használatért idő alapon kell fizetni.

Sajnos az *Azure for students* előfizetés csak egyetemi e-mail címről aktiválható. A szabályozás megváltozott, régebben csak egyszer, egy éves időtartamra járt a keret, a tanulmányok teljes ideje alatt. Ha valaki valamilyen okból nem tud  *Azure for students* előfizetést regisztrálni, vagy nem diák, két lehetősége marad: 
- Regisztrálahat újabb 12 hónapra egy **Azure free account**ot [itt](https://azure.microsoft.com/en-us/free/sql-database/search/?&ef_id=EAIaIQobChMImN_Wha3H5wIVDIuyCh1zvAwsEAAYASAAEgImifD_BwE:G:s&OCID=AID2000597_SEM_QLQnZjIQ&MarinID=QLQnZjIQ_364688946710_azure%20database%20pricing_e_c__75854089146_kwd-326879019023&lnkd=Google_Azure_Brand&dclid=CM_JhIitx-cCFYu_dwodnyoAcw)).
- Bárki regisztrálhat **Pay-as-you-go** előfizetést. Ebben az esetben már meg kell adni bankkártya számot, melyet a Microsoft az érvényesség ellenőrzése végett megterhel néhány dollárral, melyet később visszautal. Itt már nagyon kell vigyázni, mert az igénybe vett szolgáltatásokat könyörtelenül kiszámlázzák. Viszont kis odafigyeléssel a költségek alacsonyan tarthatók. 

Érdemes vetni egy pillantást az [Azure Pricing Calculator](https://azure.microsoft.com/en-us/pricing/calculator/) oldalra. Ha kiválasztjuk az *Azure SQL Database* opciót, alapértelmezett beállításokkal az oldal írásának pillanatában kijött egy **368 USD**-s havi költség. Ha a *COMPUTE TIER* opciót *Provisoned*-ről *Serverless*-re állítjuk, a költség visszazuhan **4,2 USD**-re! A különbség annyi, hogy nem foglaljuk le a felajánlott 2 CPU magot magunknak teljesen, egész hónapra. 


## MS-SQL Express / Develper Edition

A Microsoft SQL Servernek van egy **Express** kiadásra is, mely többek között a kezelhető adatbázis méretében és az egyidejűleg csatlakozott felhasználók számában is korlátozott. A korlátozás azért elég megengedő, egy kisvállalkozás könyvelése és raktárkészlet nyilvántartása gond nélkül kezelhető az expressz változattal is. változat telepítéséhez nincsen szükség szerver Windowsra, egy sima Professional változat is megteszi.

A Microsoft SQL Server **Developer** kiadása a teljes változatéval azonos funkcionalitással bír, viszont a licenc feltételei szerint csak fejlesztésre használható, éles környezetben nem.

[SQL Server Downloads](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)  

## MySQL, Oracle, stb.

Az Entity Framework Core dokunetációjának részét képező [Database Providers](https://docs.microsoft.com/en-us/ef/core/ providers/?tabs=dotnet-core-cli) oldal  felsorolja azokat az adatbázisszervereket,  melyekhez létezik kapcsolódást biztosító Microsoft vagy third party _provider_.  A listában szerepel a MySQL, az Oracle és a PostgreSQL is.  Így ezek is használhatók a fejlesztés során.

## Lokális adatbázis-fájl használata

Egy adatbázis-szerver üzemeltetése erőforrás-igényes feladat.  A C# projekten belül létrehozható lokális adatbázis egyértelmű hátránya, hogy nem igazán tudja egyszerre több felhasználó elérni az adatbázisban tárolt adatokat. Viszont nincs szükség internet elérésre és/vagy szerver üzemeltetésére a használatához. Lokális adatbázis használata *produciton*, azaz éles környezetben nem javasolt, fejlesztéshez és prototípus készítéshez viszont kiváló eszköz. 

A lokális adatbázis létrehozásának lépései külön dokumentumban mutatjuk be! A lényeg az, hogy egy `Service based database` objektum adható a projekthez  a *Solution Explorer*-ben jobb egérgombra megjelenő menüben az *Add new item* menüpontra kattintva. Ezután létrejön egy .mdf kiterjesztésű állomány, adatbázis állomány, mely a projektből használható. 
