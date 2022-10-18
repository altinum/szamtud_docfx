# Adatdefiníció és adatmanipuláció SQL-ben
[Összefoglaló videó](gyak06_x264.mp4)
## Tábla szerkezetének létrehozása
Táblaszerkezetet a 
``` sql
CREATE TABLE táblanév 
(
   oszlopnév_1  típusnév_1,
   oszlopnév_2  típusnév_2,
   …   oszlopnév_n  típusnév_n
)
```
utasítással hozhatunk létre.  Például egy személy alapvető adatait tároló tábla szerkezetét a következő utasítással:
``` sql
CREATE TABLE személy
(
   azon            int,
   szülidő        date,
   lakcím         varchar(50),
   hazas_e      bit   
)
```
## Tábla szerkezetének módosítása
 A táblaszerkezet módosítására az ALTER TABLE utasítás szolgál, amelyet oszlopok hozzáadásához, módosításához és törléséhez követhet:
  - ADD
 - ALTER COLUMN
 - DROP COLUMN
 
 Érdemes megfigyelni, hogy a hozzáadáshoz az ADD kulcsszó önmagában áll, míg az ALTER és a DROP esetében a COLUMN kulcsszót is alkalmazni kell a helyes szintaxishoz.

### Oszlop(ok) hozzáadása
Oszlopot vagy oszlopokat utólag az alábbi utasítással adhatunk már meglévő táblához:
``` sql
ALTER TABLE táblanév ADD oszlopnév típus
```
Például  az alábbi utasítás a már létrehozott Személy táblához hozzáadja az anyja_neve oszlopot
``` sql
ALTER TABLE személy ADD anyja_neve varchar(100)
``` 
Egyidejűleg több oszlopot is a táblához adhatunk:
``` sql
ALTER TABLE személy ADD nev varchar(100), kedvencstilus varchar(50)
``` 
### Oszlopok módosítása
Oszlopot az ALTER COLUMN segítségével módosíthatunk, az alábbi szintaxissal:
``` sql
ALTER TABLE táblanév ALTER COLUMN oszlopnév típus
``` 
Például:
``` sql
ALTER TABLE személy ALTER COLUMN lakcím varchar(100)
``` 
Módosítás egyidejűleg csak egy oszlopot érinthet.
### Oszlopok törlése
Oszlopot a DROP COLUMN segítségével törölhetünk, az alábbi szintaxissal:
``` sql
ALTER TABLE táblanév DROP COLUMN oszlopnév
``` 
Például:
``` sql
ALTER TABLE személy DROP COLUMN anyja_neve
``` 
Oszlopokat szintén csak egyesével törölhetünk.
## Kényszerek
A kényszerek (CONSTRAINT) a lehetséges adatok halmazát leíró, korlátozó szabályok.  Kényszereket megadhatunk a tábla létrehozásakor és utólag is, illetve definiálhatóak az oszlop és a tábla szintjén is (lásd még az egyes típusú kényszereknél)
**Oszlopkényszerről**  beszélünk, ha a kényszert az adott oszlopdefiníció kiegészítéseként adjuk meg:
``` sql
oszlopnév típusnév CONSTRAINT constraint_név constraint_definíció
```
Például:
``` sql
CREATE TABLE személy
(
   azon            int,
   szülidő        date,
   lakcím         varchar(50),
   hazas_e      bit CONSTRAINT DEFHAZAS default 0 
   /*alapértelmezett 0 érték a hazas_e oszlop számára: 
   ha beszúráskor az oszlopnak nem adnak értéket, alapértelmezés szerint 0 lesz az értéke*/
)
```
A CONSTRAINT kulcsszó és a constraint név elhagyható elem, a szintaxis így is helyes:
``` sql
hazas_e      bit default 0 
```
**Táblakényszerről ** akkor, ha a tábladefiníció kiegészítéseként határozzuk meg a kényszert, a következő formában:
``` sql
CONSTRAINT constraint_név constraint_definíció 
```
Például:
``` sql
CREATE TABLE személy
(
   azon            int NOT NULL,
   szülidő        date NOT NULL,
   lakcím         varchar(50) NULL,
   foallasu_e   bit,
   CONSTRAINT SzulidoMultban CHECK (szülidő<=getdate())
   /* A születési időnek meg kell előznie az aktuális időpontot. 
   Ha a beszúrt vagy módosított sor értéke ennek nem tesz eleget, 
   a művelet nem lesz sikeres*/
)
```
DEFAULT és NULL/NOT NULL kényszert tábla létrehozásakor oszlopszinten kell definiálni, táblaszinten nem lehet.

A kényszerek utólag – a tábla szerkezetének definiálása után – is megadhatók:
``` sql
ALTER TABLE táblanév ADD CONSTRAINT constraint_név constraint_definíció
```
például: 
```
Alter table személy ADD CONSTRAINT defhazas DEFAULT 0 FOR hazas_e
```
A NULL/NOT NULL kényszert az alábbi módon adhatjuk meg utólag egy oszlopnak:
``` sql
ALTER TABLE táblanév ALTER COLUMN oszlopdefiníció NULL
ALTER TABLE táblanév ALTER COLUMN oszlopdefiníció NOT NULL
```
például
``` sql
Alter table személy ALTER COLUMN hazas_e bit NOT NULL
```
**Megjegyzés:** a Constraintek neve a táblákéhoz hasonlóan egyedi kell legyen

### A NULL/NOT NULL kényszer
A NULL/NOT NULL kényszer segítségével azt határozhatjuk meg, hogy egy adott oszlopban engedélyezzük-e a definiálatlan értéket. Alapértelmezés szerint a NULL érték engedélyezett.
Az alábbi példában az azon és a szülidő oszlopokban nem, a lakcím és a házas-e oszlopokban engedélyezett a NULL érték.
``` sql
CREATE TABLE személy
(
   azon         int NOT NULL,
   szülidő      date NOT NULL,
   lakcím      varchar(50) NULL,
   hazas_e    bit   NULL
)
```
A NULL/NOT NULL constraintet utólag az ALTER TABLE [tábla] ALTER COLUMN [oszlop] paranccsal adhatjuk a táblához:
``` sql
Alter table személy ALTER COLUMN hazas_e bit NOT NULL
```
### A PRIMARY KEY kényszer
A tábla elsődleges kulcsának meghatározása. Egytagú kulcsot meghatározhatunk oszlop- és táblakényszerként is, többtagút csak táblakényszerként.
``` sql
CREATE TABLE személy
(
   azon         int PRIMARY KEY,  --ilyenkor a NOT NULL-t nem kell megadni, a PK alapból NOT NULL
   szülidő      date NOT NULL,
   lakcím       varchar(50) NULL,
   hazas_e      bit   NULL,
)
```
vele ekvivalens az alábbi, az elsődleges kulcsot táblakényszerként megadó script:
``` sql
CREATE TABLE személy
(
   azon            int NOT NULL,
   szülidő        date NOT NULL,
   lakcím         varchar(50) NULL,
   hazas_e      bit   NULL,
   CONSTRAINT pk_személy       PRIMARY KEY (azon)
)
```
Ha két (vagy több) tagból áll az elsődleges kulcsunk, akkor azt az alábbi módon adhatjuk meg:
``` sql
CREATE TABLE személy
(
   azon            int NOT NULL,
   szülidő        date NOT NULL,
   lakcím         varchar(50) NULL,
   hazas_e      bit   NULL,
   CONSTRAINT pk_személy       PRIMARY KEY (azon, szülidő)
)
```
PRIMARY KEY kényszert a táblára utólagosan táblakényszerként tehetünk fel:
``` sql
alter table személy9 add constraint PK_Szemely PRIMARY key(azon)
``` 
### A UNIQUE kényszer
Nem csak elsődleges kulcsok esetében követelhetjük meg az egyediséget, hanem egyéb oszlopokra vagy oszlopkombinációkra is.
A UNIQUE  kényszer meghatározható oszlopszinten: 
``` sql
CREATE TABLE személy
(
   azon            int UNIQUE,
   szülidő         date NOT NULL,
   lakcím         varchar(50) NULL,
   hazas_e      bit   NULL,
)
``` 
és táblaszinten is:
``` sql
CREATE TABLE személy
(
   azon            int NOT NULL,
   szülidő        date NOT NULL,
   lakcím         varchar(50) NULL,
   hazas_e      bit   NULL,
   CONSTRAINT uk_személy       UNIQUE (azon)
)
``` 
A UNIQUE zárójelei között több oszlopot is felsorolhatunk.
UNIQUE kényszert utólagosan így tehetünk fel a táblára:
``` sql
alter table személy add constraint UK_Személy UNIQUE(azon)
``` 
### A FOREIGN KEY kényszer
A FOREIGN KEY kényszer segítségével idegen kulcsot definiálhatunk a táblánkban, amely egy másik  tábla elsődleges kulcsára mutat.
Formája:
Definiálható oszlop- és táblakényszerként is:
``` sql
CREATE TABLE személy
(
   azon            int NOT NULL,
   szülidő         date NOT NULL,
   lakcím         varchar(50) NULL,
   szamlakod int FOREIGN KEY REFERENCES szamla (kod)
   --oszlopnév típus FOREIGN KEY REFERENCES hivatkozott tábla (hivatkozott tábla oszlopa)
)

CREATE TABLE személy
(
   azon            int NOT NULL,
   szülidő        date NOT NULL,
   lakcím         varchar(50) NULL,
   szamlakod  int   NULL,
   CONSTRAINT fk_személy FOREIGN KEY (szamlakod) REFERENCES szamla (kod)
   --CONSTRAINT Constraint név FOREIGN KEY (oszlop neve) REFERENCES hivatkozott_tábla (hivatkozott tábla oszlopának neve)   
)
``` 
FOREIGN kényszer az előzőekhez hasonlóan ALTER TABLE ADD Constraint utasítással rakható fel a táblára.
###A DEFAULT kényszer
A DEFAULT kényszer segítségével egy oszlopra határozhatjuk meg, hogy milyen értéket kapjon abban az esetben, ha beszúráskor nem adják meg számára azt.
Csak oszlopkényszerként definiálható, hasonlóan a NULL/NOT NULL-hoz
``` sql
CREATE TABLE személy
(
   azon            int NOT NULL,
   szülidő         date NOT NULL,
   lakcím         varchar(50) NULL,
   foallasu_e  bit DEFAULT 1
)
```
Utólagosan az ALTER TABLE ADD CONSTRAINT utasítással rakható fel a táblára.
### A CHECK kényszer
A Check kényszer segítségével logikai feltételeket határozhatunk meg a táblába beszúrással vagy módosítással kerülő adatokra. Oszlop- és táblakényszerként is meghatározható:
``` sql
CREATE TABLE személy
(
   azon            int NOT NULL,
   szülidő         date NOT NULL,
   lakcím         varchar(50) NULL,
fizetés 		int CHECK (fizetés>0)
)
CREATE TABLE személy
(
   azon            int NOT NULL,
   szülidő        date NOT NULL,
   lakcím         varchar(50) NULL,
   fizetés         int,
   CONSTRAINT chk_személyCHECK (fizetés > 0)
)
``` 
Utólagosan az ALTER TABLE ADD CONSTRAINT utasítással rakható fel a táblára.

## Adatmanipulációs parancsok
Az adatmanipulációs parancsok segítségével  adatokat
 - szúrhatunk be (INSERT, INSERT SELECT, SELECT INTO)
 - törölhetünk (DELETE, TRUNCATE)
 - módosíthatunk (UPDATE)
### Beszúrás
#### INSERT
``` sql
INSERT INTO táblanév (oszlopnév lista) VALUES (értéklista)
INSERT INTO személy (szülidő, lakcím, fizetés) VALUES ('2001.05.02', 'Budapest, Váci út 3', 250000)
``` 
Az INTO  kulcsszó és az oszlopnév lista elhagyható, de ebben az esetben az összes oszlop számára meg kell adnunk értéket.
``` sql
INSERT személy values (1, '2001.05.02', 'Budapest, Váci út 3', 250000)
``` 
#### INSERT ... SELECT
Az INSERT parancsban nem csak a values segítségével adhatjuk meg a beszúrni kívánt értékeket, hanem írhatunk lekérdezést is, amelynek eredményét a táblába betöltjük.
``` sql
INSERT INTO személy (szülidő, lakcím, fizetés) SELECT szülidő, lakcím, fizetésFROM dolgozó
``` 
 Az INTO  kulcsszó és az oszlopnév lista elhagyható, de ebben az esetben az összes oszlop számára meg kell adnunk értéket.
#### SELECT ... INTO
A SELECT INTO segítségével egy lekérdezés eredményét menthetjükel egy új táblába.
``` sql
Select * INTO házasok from személy where hazas_e=1
``` 
### TÖRLÉS
#### DELETE
Táblából sorokat a DELETE utasítással törölhetünk. A DELETE parancsot egy lekérdezéshez hasonlóan fogalmazhatjuk meg, például:
``` sql
DELETE FROM személy WHERE fizetés > 500000
```
#### TRUNCATE
Egy tábla minden sorát törölhetjük a TRUNCATE TABLE táblanév utasítással. 
``` sql
TRUNCATE TABLE személy
```
### MÓDOSÍTÁS
A tábla adatainak módosítása az UPDATE paranccsak lehetséges. Az UPDATE parancsot szintén egy lekérdezéshez hasonlóan fogalmazhatjuk meg:
``` sql
UPDATE személy SET fizetés = fizetés * 1.25 WHERE lakcím like ’Budapest%’
``` 
## Adatbázis-objektumok törlése
A korábbiakban ismertetett TRUNCATE paranccsal a tábla tartalmát törölhetjük teljes egészében.
Ha az egész táblát szeretnénk eltávolítani az adatbázisból, arra a DROP TABLE utasítás szolgál:
``` sql
DROP TABLE személy
```
Ha nem az egész táblát, csupán egy oszlopot szeretnénk törölni, akkor a következő utasításra lesz szükségünk:
``` sql
ALTER TABLE személy DROP COLUMN lakcím
```
Azonban, ha olyan oszlopot szeretnénk törölni, amelyre CONSTRAINT hivatkozik (kivéve NULL/NOT NULL), akkor előbb azt kell törölnünk, ellenkező esetben hibaüzenetet  kapunk:
``` sql
Server: Msg 5074, Level 16, State 1, Line 1
The object 'checkmultbanszuletett' is dependent on column 'szülidő'.
``` 
Constraintet az alábbi formában törölhetünk:
``` sql
Alter table személy drop constraint checkmultbanszuletett
```
Ha nem mi adtunk nevet a kényszernek, hanem az SQL szerverre bíztuk ezt (oszlopkényszereknél fordul elő), akkor például a hibaüzenetből könnyen kiolvasható.

## Feladatok

A feladatok a *tanulmanyi* adatbázishoz készültek.  Készen elérhető a tanszéki kiszolgálón az alábbi kapcsolati adatokkal:

|              | |
|-             |-|
|Szerver       |bit.uni-corvinus.hu
|Felhasználónév|hallgato
|Jelszó        |Password123
|Adatbázis     |tanulmanyi



(+/-)	Listázzuk az egyetemi tanárok titulusát, nevét és a státuszuk megnevezését!
a)	A listát rendezzük titulus szerint, azon belül név szerint növekvő sorrendbe!
[Megoldás](Gy0601.mp4)

(+/-)	Készítsünk lekérdezést, amely megjeleníti, hogy melyik beosztásban hány oktató van!
a)	Csak a beosztás nevét és az oktatók számát jelenítsük meg!
b)	Az oszlopok neve legyen 'Beosztás' és 'Létszám'
c)	Az Óraadókat hagyjuk ki a listából!
[Megoldás](Gy0602.mp4)

(+/-)	Készítsünk listát az egyes tantárgyak adatairól!
a)	A lista tartalmazzon egy új oszlopot 'Rövid név' néven, amely a tantárgy nevének első öt betűjét és utolsó három betűjét tartalmazza, közöttük három ponttal (...)!
b)	A rövid név csupa nagy betűvel jelenjen meg!
c)	A listát rendezzük a rövid név szerint növekvő sorrendbe!
[Megoldás](Gy0603.mp4)

(+/-)	Hány óra van összesen pénteki napokon?
a)	Csak az órák számát jelenítsük meg!
b)	Az oszlopot nevezzük el 'Pénteki óraszám'-nak
[Megoldás](Gy0604.mp4)

(+/-)	Készítsünk listát, amely megadja, hogy mely tantárgyakból nincs óra a 118-as teremben!
a)	Csak a tantárgyak azonosítóját és nevét jelenítsük meg!
b)	A lista ne tartalmazzon duplikált sorokat!
[Megoldás](Gy0605.mp4)

(+/-)	Készítsen új táblát, a tábla nevének eleje az Ön Neptun-kódja legyen, majd egy aláhúzásjel, végül TANKONYV, Pl: UJAENB_TANKONYV
a)	A tábla oszlopai legyenek: Tkod egész szám, Tcim szöveg(50), Tegysegar valós szám
b)	Adjuk meg a következő kényszereket is: Tkod elsődleges kulcs, Tegysegar > 0, a Tcim és a Tegysegar legyenek kötelezően kitöltendő mezők
[Megoldás](Gy0606.mp4)

(+/-)	Készítsen új táblát, az Oktatok tábla lemásolásával NEPTUNKOD_TANAR néven, pl: UJAENB_TANAR!
a)	Használja a SELECT ... INTO ... FROM szerkezetet!
[Megoldás](Gy0607.mp4)

(+/-)	Adja hozzá a következő kényszereket a 7. feladatban létrehozott táblához:
a)	Az oktato_id oszlopra állítsa be, hogy kötelezően kitöltendő legyen
b)	Az oktato_id legyen elsődleges kulcs, a titulus alapértelmezett értéke legyen üres string
c)	Az oktato neve egyedi legyen! A beosztás kódja csak 1 és 7 közötti egész szám lehessen!
d)	A feladatot több lépésben is megoldhatja!
[Megoldás](Gy0608.mp4)

(+/-)	Hozzon létre új táblát NEPTUN_TANAR_TK néven, pl: UJAENB_TANAR_TK, amely a tanár által használt tankönyveket fogja tárolni! 
a)	A tábla szerkezete a következő legyen: ttkkod egész szám elsődleges kulcs, tkod egész szám - a tanár kódja, ttkod egész szám a tankönyv kódja
b)	A tkod legyen idegen kulcs a NEPTUN_TANAR tábla oktato_id mezőjéhez, a ttkod pedig a NEPTUN_TANKONYV tábla tkod mezőjéhez kötve!
[Megoldás](Gy0609.mp4)

(+/-)	Adjunk hozzá új oszlopot a NEPTUN_TANKONYV táblához: akkreditalt_e bit, és a NEPTUN_TANAR táblához: vegzettseg szoveg(2)!
a)	Az akkreditalt_e alapértelmezett értéke 0 legyen!
b)	A vegzettseg csak a következő értékeket vehesse fel: E, F, K, 8 és N (Egyetem, Főiskola, Középiskola, 8 általános és nincs), alapértelmezett értéke legyen 'E'
[Megoldás](Gy0610.mp4)

(+/-)	Töltsük fel a NEPTUN_TANKONYV táblát a következő adatokkal:
a)	1, 'Matematika alapjai', 2400
b)	2, 'Bevezetés a fizikába', 3500
c)	3, 'Differenciálegyenletek', 5000
d)	4, 'Gazdasági ismeretek I.',4000
e)	5, 'Statisztika', 3800
[Megoldás](Gy0611.mp4)

(+/-)	Szúrjuk be a NEPTUN_TANAR_TK táblába a következő sorokat:
a)	1, 2, 3
b)	2, 1, 2
c)	3, 3, 2
d)	4, 5, 4
[Megoldás](Gy0612.mp4)

(+/-)	Töröljük az Óraadó beosztású tanárokat a NEPTUN_TANAR táblából!
a)	Segítség: mivel a törlés során két táblát kell összekapcsolni, ezért ilyenkor a DELETE után meg kell adni a törlésben érintett tábla nevét is, azaz DELETE NEPTUN_TANAR FROM ...
[Megoldás](Gy0613.mp4)

(+/-)	Állítsuk vissza az előző feladatban kitörölt tanárokat a NEPTUN_TANAR Táblába az Oktatok tábla adatait felhasználva!
a)	Használjuk az INSERT INTO... SELECT szerkezetet! Vegyük figyelembe, hogy az Oktatok táblának nincs vegzettseg oszlopa!
[Megoldás](Gy0614.mp4)

(+/-)	Módosítsuk a NEPTUN_TANKONYV táblában a tankönyvek egységárát úgy, hogy mindegyik 20%-kal több legyen!
a)	Ugyanitt módosítsuk az akkreditalt_e értékét úgy, hogy a meglévő ellentett értéke legyen, (azaz ha 1 volt, akkor 0, ha 0 volt, akkor 1 legyen)
[Megoldás](Gy0615.mp4)

(+/-)	Plusz feladat: Töröljük ki az általunk létrehozott NEPTUN_TANAR, NEPTUN_TANAR_TK és NEPTUN_TANKONYV táblákat!
[Megoldás](Gy0616.mp4)
