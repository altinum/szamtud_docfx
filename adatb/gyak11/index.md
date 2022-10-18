# Összefoglalás
## A SELECT utasítás felépítése
Az SQL lekérdező utasítása, alapformája a következő:
``` sql
SELECT*…       -- oszlopok kiválasztása
FROM …         -- táblák kiválasztása
WHERE …        -- szűrőfeltétel megadása a sorokra
GROUP BY …     -- csoportosítás
HAVING …       -- szűrőfeltétel a csoportokra
ORDER BY…      -- sorbarendezés
```
**Kiegészítés:**  Az eredménysorok számát a TOP (n) [PERCENT] záradék megadásával befolyásolhatjuk:
pl: 
```sql
SELECT TOP 5 * FROM Szoba 
``` 
az első 5 szoba adatait jeleníti meg

## Kifejezések
Az egyszerű kifejezések konstansokat, változókat, oszlopneveket és függvényeket tartalmazhatnak, pl:
- 'Dr.'              (szöveges konstans)
- Nettóbér           (oszlopnév)
- YEAR('2010.01.011') (függvény, dátum konstans)

Az összetett kifejezések operátorokat is tartalmazhatnak, pl:
- 'Dr.' + Vezetéknév + Keresztnév (összefűzés)
- Nettóbér * 1.27                    (szorzás)

A kifejezések mindig egy értéket adnak vissza
### CASE
Többirányú elágazás megvalósítása, két formája van:
``` sql
CASE 
     WHEN feltétel1 THEN kifjezés1
     WHEN feltétel2 THEN kifejezés2
     …
	WHEN feltételn THEN kifejezésn
      [ELSE kifejezés]
END
```
``` sql
CASE kifejezés
     WHEN érték1 THEN kifjezés1
     WHEN érték2 THEN kifejezés2
     …
	WHEN értékn THEN kifejezésn
      [ELSE kifejezés]
END
```
### Konstansok és típusok
|    Konstans                       |    Típus                                                                       |    Példa                                                  |
|-----------------------------------|--------------------------------------------------------------------------------|-----------------------------------------------------------|
|    Szöveges   konstans            |    varchar(x)   (x:   a szöveg max.   hossza)                                  |    ’Budapest’                                             |
|    Unicode   szöveges konstans    |    nvarchar(x)   (x:   a szöveg max.   hossza)                                 |    N’Budapest’                                            |
|    Egész   konstans               |    int                                                                         |    25                                                     |
|    Bit   konstans                 |    bit                                                                         |    1                                                      |
|    Decimális   konstans           |    decimal(x,   y)   (x:   a számjegyek száma,    y: a tizedesjegyek száma)    |    12.45                                                  |
|    Dátum/Idő   konstans           |    date,      datetime,      time                                              |    ’2012.01.15’   ’2020.02.11   22:11:33’   ’06:12:10’    |

### Fontosabb függvények, operátorok
#### Függvények
|    Függvénytípus    |    Függvény                                                                             |
|---------------------|-----------------------------------------------------------------------------------------|
|    DÁTUM/IDŐ        |    GETDATE(),   DAY(d), MONTH(d), YEAR(d),       DATEADD(x, y, z), DATEDIFF(x, y, z)    |
|    KONVERZIÓS       |    CAST(x   AS y), CONVERT(x, y)                                                        |
|    MATEMATIKAI      |    POWER(x,   y), SQRT(x), ROUND(x, y), ABS(x)                                          |
|    SZÖVEG           |    LEN(x),   LEFT(x, y), RIGHT(x, y), LOWER(x), UPPER(x), CHARINDEX(x, y)               |
|    EGYÉB            |    ISNULL(x,   y), IIF(x, y, z)                                                         |
#### Operátorok
|    Operátor típus                 |    Operátor                 |    Megjegyzés                                                                                                                               |
|-----------------------------------|-----------------------------|---------------------------------------------------------------------------------------------------------------------------------------------|
|    Aritmetikai   operátorok       |    +,   -, *, /, %          |    %:   az egész osztás maradéka                                                                                                            |
|    Logikai   operátorok           |    NOT,   AND, OR           |                                                                                                                                             |
|    Összehasonlító   operátorok    |    <,   >, =, <>, >=, <=    |                                                                                                                                             |
|    Szöveg   operátorok            |    +,   %, _                |    +:   szövegek összefűzése   %:   helyettesítő operátor (egy vagy több karakter vagy üres)   _:   helyettesítő operátor (egy karakter)    |


## Összesítés (aggregálás)
- Az összesítő függvények értékek egy halmazán végeznek számítást, és egyetlen értéket adnak vissza.
- Alapesetben a halmaz a tábla összes sorát jelenti
- A számítás egy kifejezés kiértékelését jelenti
- Az összesítő függvények (kivéve: COUNT(*)) nem veszik figyelembe a NULL értékeket

Fontosabb összesítő függvények és szerepük:
- SUM(): egy adott kifejezés értékeit összegét adja vissza
- AVG(): egy adott kifejezés értékeinek átlagát adja vissza
- MIN() és MAX(): egy adott kifejezés értékei közül a legkisebbet, illetve legnagyobbat adja vissza
- COUNT(): egy adott halmaz elemeinek számát adja vissza

## Csoportosítás
``` sql
SELECT…        -- oszlopok kiválasztása
FROM …         -- táblák kiválasztása
WHERE …        -- szűrőfeltétel megadása a sorokra
GROUP BY …     --  csoportosítás
HAVING …       -- szűrőfeltétel a csoportokra
ORDER BY…          -- sorbarendezés
```
A GROUP BY részben felsorolt mezők vagy kifejezések szerint csoportokat képezhetünk, és a SELECT részben alkalmazott számításokat ezekre a csoportokra alkalmazhatjuk. A HAVING részben a csoportokra adhatunk meg szűrőfeltételt.
Csoportosítás esetén a SELECT részben lévő oszlopoknak szerepelniük kell a GROUP BY felsorolásában, vagy egy összesítésben (mint az összesítő függvény paramétere)

## Táblák összekapcsolása – JOIN típusok
![1587964457825.png](../../images/1587964457825.png)
- (INNER) JOIN: Az A tábla idegen kulcsa megegyezik a B tábla kulcsával
- LEFT (OUTER) JOIN: Az INNER JOIN eredményéhez hozzá veszi az A tábla minden további sorát is
- RIGHT (OUTER) JOIN: Az INNER JOIN eredményéhez hozzá veszi az B tábla minden további sorát is
- FULL (OUTER) JOINT: Az INNER JOIN eredményéhez hozzá veszi az A és B tábla minden további sorait is 

Az OUTER szó használata nem kötelező
## Halmazműveletek
### Lekérdezések uniója SQL-ben:
``` sql
SELECT oszlopnevek
FROM ….
UNION (ALL)
SELECT oszlopnevek
FROM …
```
> UNION esetén az eredményhalmazban a duplikált (mindegyik lekérdezésben előforduló) sorok csak egyszer szerepelnek, UNION ALL esetén pedig annyiszor, ahányszor előfordulnak
### Lekérdezések metszete SQL-ben:
``` sql
SELECT oszlopnevek
FROM ……
INTERSECT
SELECT oszlopnevek
FROM …….
```
### Lekérdezések különbsége SQL-ben:
``` sql
SELECT oszlopnevek
FROM ……
EXCEPT
SELECT oszlopnevek
FROM ……
``` 
## Adatdefiníciós parancsok
### Tábla létrehozása 
``` sql
CREATE TABLE táblanév* 
(
 oszlopnév1  típusnév1 [oszlopkényszerek1],
 oszlopnév2  típusnév2 [oszlopkényszerek2],

   …    oszlopnévn  típusnévn [oszlopkényszerekn]
    [, táblakényszerek]
)
``` 
> Ha a táblanév # karakterrel kezdődik, akkor un. Ideiglenes tábla jön létre. Ez csak az adott kapcsolat (munkamenet, session) időtartalma alatt létezik. Ha a táblanév ## karakterekkel kezdődik, akkor több egyidejű kapcsolat esetén az ideiglenes tábla mindegyikben elérhető lesz.

### Oszlop hozzáadása, módosítása, törlése
``` sql
ALTER TABLE táblanév 
ADD oszlopnév típus
```
``` sql

ALTER TABLE táblanév
ALTER COLUMN 
oszlopnév típus
``` 
``` sql
ALTER TABLE táblanév
DROP COLUMN oszlopnév
``` 
### Kényszer törlése
``` sql
ALTER TABLE táblanév
DROP CONSTRAINT kényszernév
``` 
### Az egész tábla törlése
``` sql
DROP TABLE táblanév
``` 
> A tábla törlése a szerkezet meghagyásával
``` sql
TRUNCATE TABLE táblanév
``` 
## Kényszerek
A kényszerek a lehetséges adatok halmazát leíró, korlátozó szabályok.
A kényszerek (a NULL/NOT NULL és a Default kivételével) megadhatók oszlop, illetve tábla szinten is (oszlopkényszerek, táblakényszerek)
- Not Null Constraint: kötelező-e kitölteni az adott oszlopot?
- Check Constraint: teljesül-e az adott logikai feltétel?
- Default Constraint: mi legyen az adott oszlop alapértelmezett értéke?
- Unique Constraint: az adott oszlop vagy oszlopok értékei egyediek legyenek
- Primary Key Constraint: az adott oszlop vagy több oszlop együtt elsődleges kulcs legyen
- Foreign Key Constraint: az adott oszlop vagy több oszlop együtt idegen kulcs legyen

## Adatmanipulációs parancsok
### Új sor beszúrása
``` sql
INSERT INTO táblanév 
(
   oszlopnév lista
)
VALUES
(
  értéklista
)
````
> Ha egy SELECT eredménysorait egy új táblába szeretnénk menteni, akkor használhatjuk a
> SELECT oszlopnév lista INTO táblanév FROM … parancsot is.
### Sorok törlése
``` sql
DELETE FROM táblanév 
WHERE feltétel
``` 
### Értékek módosítása
``` sql
UPDATE táblanév 
SET   oszlop1 = érték1,
        oszlop2 = érték2,
        ….
WHERE feltétel
``` 
## Beágyazott lekérdezések
``` sql
SELECT select_list  
FROM table  
WHERE expr operator  
(SELECT select_list FROM table)
``` 
``` sql
SELECT ProductID, Name, ListPrice  
FROM production.Product  
WHERE ListPrice > (SELECT AVG(ListPrice)  FROM Production.Product) --subquery 
```
Tipikus használat
- Ha szeretnénk összehasonlítani egy kifejezés értékét a beágyazott lekérdezés eredményével (legtöbbször <, >, = )
- Ha szeretnénk eldönteni, hogy egy kifejezés eredménye benne van-e a beágyazott lekérdezés eredményhalmazában (IN)- 
- Ha szeretnénk eldönteni, hogy a beágyazott lekérdezés eredményhalmaza üres-e (EXISTS)

## Részösszegek
Az oszlopneveket és a NULL értéket kombinálva csoportosít, és  megjeleníti a  részösszegeket valamint végösszeget. ROLLUP esetén a nem NULL oszlopok száma jobbról balra csökken, CUBE esetén a csoportosítás minden lehetséges kombinációt tartalmaz
``` sql
SELECT oszlopkifejezések*, 
             aggregálás
FROM …
GROUP BY ROLLUP(oszlopkifejezések*)
``` 
``` sql
SELECT oszlopkifejezések, 
             aggregálás
FROM …
GROUP BY CUBE(oszlopkifejezések)
``` 
## GROUPING SETS 
A GROUP BY parancs kiegészítve a GROUPING SETS taggal lehetővé teszi, hogy többféle csoportosítást is megadjunk.
A csoportosításokat leíró oszlopkifejezéseket egymás után, zárójelek között , vesszővel elválasztva kell megadni.

Pl: 
``` sql
SELECT oszlop1, oszlop2, SUM(oszlop3)
FROM table
GROUP BY GROUPING SETS(( oszlop1, oszlop2), (oszlop1)
)
``` 
## Ablakok, partíciók, analitikus függvények
Formája: 
``` sql
Függvény()*
OVER(
[PARTITION BY kifejezés] 
[ORDER BY kifejezés]
[ROWS | RANGE BETWEEN kezdőpont AND végpont])
``` 
A függvény lehet 
- Aggregáló függvény (SUM, AVG, MIN, MAX, COUNT)
- Analitikus függvény (LAG, LEAD, FIRST_VALUE, LAST_VALUE)
- Ranking függvény (RANK, DENS_RANK, NTILE, ROW_NUMBER)

## Nézetek, tárolt eljárások, függvények
``` sql
CREATE VIEW view_név
[(oszlopnevek listája)] [WITH view_attribútumok]
AS SELECT_utasítás
[WITH CHECK OPTION]*
``` 
``` sql
CREATE PROCEDURE eljárás_név
[paraméterek listája][WITH eljárás_opciók]
AS 
[BEGIN]
Utasítások
[END]
``` 
``` sql
CREATE FUNCTION fv_név
([paraméterek listája])RETURNS adattípus_név
[WITH fv_opciók]
[AS]
BEGIN
Utasítások
RETURN skalár_kifejezés
END
``` 
``` sql
CREATE FUNCTION fv_név
([paraméterek listája])RETURNS TABLE
[WITH fv_opciók]
[AS] 
RETURN select_kifejezés
``` 
# Hogyan tovább? – Az SQL tudás bővítése
- A tanult témakörök elmélyítése (pl: függvények esetén opcionális paraméterek kipróbálása és/vagy újabb függvények megismerése)
- Ismerkedés újabb témákkal (pl: dinamikus SQL, triggerek, rekurzió stb.)
- Más relációs adatbázis rendszerek megismerése(elsősorban Oracle, DB2, MySQL)
- Tapasztalat szerzés a gyakorlatban (Junior szint: 1-3 év, Medior szint: 3-5 év, Senior szint: >5 év)
# Feladatok
A feladatok a szallashely adatbázishoz készültek,  létrehozásához szükséges script elérhető itt:
[szallas.sql](szallas.sql)

(+/-)	Készítsen tárolt eljárást NEPTUNKÓD_SPFEROHELYEK néven, amely paraméterként kap egy egész számot, és listázza azon szobák adatait, ahol a férőhelyek száma (pótággyal együtt!) megegyezik a paraméter értékével!
a)	Teszteljük a tárolt eljárás működését, pl: EXEC UJAENB_FEROHELYEK 4
[Megoldás](gy11_01.mp4)

(+/-)	Készítsen függvényt NEPTUNKÓD_UDFFoglalasszam néven, amely a paraméterként megadott ügyfél azonosítót felhasználva visszaadja, hogy az adott ügyfél eddig hányszor foglalt! 
a)	Teszteljük a fv. működését, pl: SELECT dbo.UJAENB_UDFFoglalasszam('kata')
[Megoldás](gy11_02.mp4)

(+/-)	Készítsen nézetet NEPTUNKÓD_VVendeghazSzobak néven, amely azon szobák adatait jeleníti meg, amelyek vendégházban vannak! 
a)	Egy új oszlopban jelenjen meg a szálláshely neve és zárójelben a helye is, pl: Gold Hotel (Budapest)!
b)	Teszteljük a nézet működését, pl: SELECT * FROM UJAENB_VVendeghazSzobak
[Megoldás](gy11_03.mp4)

(+/-)	Készítsen nézetet NEPTUNKÓD_VHaviFoglalasszam néven, amely évenkénti, azon belül havi bontásban listázza a foglalások számát! 
a)	A foglalás dátumánál a METTOL oszlop értékét vegyük alapul! 
b)	Az oszlopokat nevezzük el értelemszerűen! 
c)	Teszteljük a nézet működését, pl: SELECT * FROM UJAENB_VHaviFoglalaszszam
[Megoldás](gy11_04.mp4)

(+/-)	Készítsen tárolt eljárást NEPTUNKÓD_SPPotagyasUGyfelek néven, amely azon vendégek adatait listázza, akik MINDIG pótágyas foglalást adtak le! 
a)	Az eredménylista ne tartalmazzon duplikált sorokat! 
b)	Teszteljük a tárolt eljárás működését, pl: EXEC UJAENB_SPPotagyasUgyfelek
[Megoldás](gy11_05.mp4)

(+/-)	**Készítsen lekérdezést, amely listázza a foglalások azonosítóját, a foglalások időtartamát napokban, valamint a felnőttek és gyermekek számát!** 
a)	A listát szűrjük azokra az ügyfelekre, akik azonosítója 'a' vagy 'b' betűvel kezdődik! 
b)	Az oszlopokat nevezzük el értelemszerűen!

(+/-)	**Készítsen lekérdezést, amely típusonként, azon belül csillagok száma szerinti bontásban megjeleníti a szálláshelyek számát!** 
a)	A listát szűrjük azokra a rekordokra, ahol a szálláshelyek száma 4-nél kisebb! 
b)	A listából hagyjuk ki a budapesti szálláshelyeket!

(+/-)	**Listázzuk a foglalások adatait! A gyermekkel érkezők külön ajándékot kapnak.** 
a)	Ezért egy új oszlopban jelenítsük meg, hogy az adott foglaláshoz jár-e ajándék (Igen-Nem). 
b)	A listát szűrjük a 3 csillagos szállásokra!

(+/-)	**Melyek azok a vendégek, akiknek már volt gyermekes és gyermek nélküli foglalásuk is?** 
a)	Csak az ügyfelek azonosítója és neve jelenjen meg! 
b)	Az oszlopok neve legyen 'Azonosító' és 'Ügyfél' 
c)	A listát rendezzük név szerint növekvő sorrendbe!

(+/-)	**Melyek azok a szálláshelyek, ahol a legtöbb főre foglaltak?** 
a)	Csak a szálláshelyek azonosítója, neve és helye jelenjen meg! 
b)	A lista ne tartalmazzon ismétlődő sorokat!

(+/-)	**Készítsünk lekérdezést, amely a szállás helye szerint, azon belül a foglalás éve szerint megjeleníti, hogy hány foglalás történt! (A foglalás időpontjánál a METTOL dátummal számoljunk).** 
a)	A lista jelenítse meg a részösszegeket és a végösszeget is! 
b)	A végösszeget jelöljük megfelelően! 
c)	Az oszlopokat nevezzük el értelemszerűen!

(+/-)	Listázzuk a szálláshelyek adatait a rögzítési idejének sorrendjében! 
a)	Egy-egy új oszlopban jelenjen meg az eddig rögzített szálláshelyek minimális és maximális csillagszáma is (az aktuálisat is beleértve) a szálláshely helyén belül!
