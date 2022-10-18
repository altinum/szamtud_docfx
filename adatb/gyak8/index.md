# A csoportosítás speciális lehetőségei
 [Összefoglaló videó](gyak08_x264.mp4)
 ## ROLLUP
 Az oszlopneveket és a NULL értéket kombinálva csoportosít, és  megjeleníti a  részösszegeket valamint végösszeget. Csoportosításkor a nem NULL oszlopok száma jobbról balra csökken
```sql
SELECT oszlopkifejezések, 
             aggregálás
FROM …
GROUP BY ROLLUP(oszlopkifejezések)
--Az oszlopkifejezések többnyire oszlopnevek listáját jelenti
```
Például:
```sql
SELECT oszlop1, oszlop2, oszlop3, SUM(oszlop4)
FROM …GROUP BY ROLLUP (oszlop1, oszlop2, oszlop3)
```
 esetén a következő csoportok jönnek létre:
 
|  |  ||
|--|--|--|
| oszlop1 | oszlop2 | oszlop3 | 
| oszlop1 | oszlop2 | NULL | 
| oszlop1 | NULL | NULL | 
| NULL | NULL | NULL |

## CUBE
Az oszlopneveket és a NULL értéket kombinálva csoportosít, és  megjeleníti a  részösszegeket valamint végösszeget. A csoportosításhoz minden lehetséges kombinációt felhasznál.

``` sql
SELECT oszlopkifejezések, 
             aggregálás
FROM …
GROUP BY CUBE(oszlopkifejezések)
```
Például:
```sql
SELECT oszlop1, oszlop2, oszlop3, SUM(oszlop4)
FROM …GROUP BY CUBE (oszlop1, oszlop2, oszlop3)
```
esetén a következő csoportok jönnek létre:

|  |  ||
|--|--|--|
| oszlop1 | oszlop2 | oszlop3 | 
| oszlop1 | oszlop2 | NULL | 
| oszlop1 | NULL | osszlop3 | 
| oszlop1 | NULL | NULL |
| NULL | oszlop2 | oszlop3 |
| NULL | oszlop2 | NULL |
| NULL | NULL | oszlop3 |
| NULL | NULL | NULL |

## GROUPING SETS
A GROUP BY parancs kiegészítve a GROUPING SETS taggal lehetővé teszi, hogy többféle csoportosítást is megadjunk.
A csoportosításokat leíró oszlopkifejezéseket egymás után, zárójelek között , vesszővel elválasztva kell megadni. A GROUPING SETS-ek az egyes csoportokra kiadott SELECT-ek UNION ALL-jainak alternatívái
``` sql
SELECT oszlop1, oszlop2, SUM(oszlop3)
FROM table
GROUP BY GROUPING SETS(( oszlop1, oszlop2), (oszlop1)
)
```
## A GROUPING és GROUPING _ID  függvények

- A GROUPING fv. értéke 1, ha az adott oszlopkifejezés szerint aggregálás (sum, min, max stb.) van, különben 0
- A GROUPING_ID fv. értéke a paraméterként megkapott oszlopkifejezések aggregációs szintjének száma.
>A szintszám számítása úgy történik, hogy az oszloplistához egy bináris kódot rendelünk. Ennek i-ik eleme 1, ha az i-ik oszlop szerint van aggregálás, különben 0. A szintszám a bináris szám értéke lesz tízes számrendszerben.  Pl: ha a csoport (oszlop1, oszlop2), és mindkettő szerint van aggregálás, akkor a szintszám binárisan 11, decimálisan 3.
- Használhatók a SELECT, a HAVING és az ORDER BY részekben, amennyiben a GROUP BY is specifikálva van
- Mindkét fv. legfontosabb alkalmazása, hogy megkülönböztessük a ROLLUP, CUBE és GROUPING SETS-ek által visszaadott NULL értékeket (részösszegek, végösszegek) a normál NULL értékektől
- Ha egy oszlop(kifejezés) szerint csoportosítunk, akkor a két fv. ugyanazt az értéket adja vissza

# Példák
## ROLLUP
Készítsünk listát a raktáron lévő termékek összértékéről raktárkód, azon belül kategóriakód, majd mennyiségi egység szerinti bontásban! A lista jelenítse meg a részösszegeket és a végösszeget is! A listát szűrjük az 5-ös és 9-es azonosítójú kategóriára! A csoportosításnál a ROLLUP záradékot használjuk!
``` sql
SELECT RAKTAR_KOD, KAT_ID, MEGYS, 
       SUM(LISTAAR*KESZLET) AS 'Készlet értéke'
FROM Termek
WHERE kat_ID IN (5,9)
GROUP BY ROLLUP (RAKTAR_KOD, KAT_ID, MEGYS)
```
## CUBE
Készítsünk listát a raktáron lévő termékek összértékéről raktárkód, azon belül kategóriakód, majd mennyiségi egység szerinti bontásban! A lista jelenítse meg a részösszegeket és a végösszeget is! A listát szűrjük az 5-ös és 9-es azonosítójú kategóriára! A csoportosításnál a CUBE záradékot használjuk!
``` sql
SELECT RAKTAR_KOD, KAT_ID, MEGYS, 
       SUM(LISTAAR*KESZLET) AS 'Készlet értéke'
FROM Termek
WHERE kat_ID IN (5,9)
GROUP BY CUBE (RAKTAR_KOD, KAT_ID, MEGYS)
```
## GROUPING SETS
Készítsünk listát az egyes ügyfelek átlagos életkoráról az ügyfél neme, illetve az ügyfél születési éve szerint csoportosítva! A listát szűrjük azon ügyfelekre, akik neve D-vel vagy E-vel kezdődik!(Az életkor legyen a születési évtől a jelenlegi évig eltelt évek száma)
``` sql
SELECT szulev, nem, 
       AVG(YEAR(GETDATE())-SZULEV) AS 'Átlagos életkor'
FROM Ugyfel
WHERE NEV LIKE 'E%' OR NEV LIKE 'D%'
GROUP BY GROUPING SETS((SZULEV),(NEM))
```
## GROUPING(),  GROUPING_ID()
Listázzuk, hogy melyik évben hány db terméket rendeltek meg! A lista megfelelően jelölve jelenítse meg a rendelések teljes összegét is!
``` sql
SELECT  
 (
  CASE GROUPING(YEAR(REND_DATUM))   
  WHEN 0 THEN CAST(YEAR(REND_DATUM) AS nvarchar(4))
  WHEN 1 THEN 'Összesen' END
  ) 
  AS ÉV,  
  COUNT(*) AS 'DB'
FROM Rendeles
GROUP BY ROLLUP(YEAR(REND_DATUM))
```
Listázzuk, hogy naponta, azon belül fizetési mód szerint hány rendelés történt! A lista megfelelően jelölve jelenítse meg a részösszegeket és a végösszeget is!
``` sql
SELECT  IIF(GROUPING(REND_DATUM)=1,'Összesen',
        CAST(REND_DATUM AS nvarchar(10))) AS 'Rendelés dátuma',
 (  
  CASE GROUPING_ID(REND_DATUM, FIZ_MOD)   
   WHEN 0 THEN FIZ_MOD
   WHEN 1 THEN '**Fizetési módok összesen**'   
   WHEN 3 THEN 'Összesen'
  END)   as 'FIZ_MOD',    
   COUNT(*) as 'DB'
FROM Rendeles
GROUP BY ROLLUP(REND_DATUM, FIZ_MOD)
```

>A GROUPING SETS, GROUPING / GROUPING_ID fv. és a ROLLUP / CUBE együtt is használhatók
>```sql
>SELECT CASE WHEN GROUPING(szulev)=0 
  >      THEN CAST(SZULEV AS nvarchar(4))
  >      ELSE 'Minden év'
  >     END AS 'Születési év',
 >  CASE 
  >       WHEN GROUPING(nem)=1 THEN 'Minden nem'
  >       ELSE NEM
  >     END AS 'Nem', 
  >     AVG(YEAR(GETDATE())-SZULEV) 
  > AS 'Átlagos életkor'
>FROM Ugyfel
>WHERE NEV LIKE 'E%' OR NEV LIKE 'D%'
>GROUP BY GROUPING SETS(ROLLUP(SZULEV), CUBE(nem))
>```

# Feladatok

A feladatok a *webshop* adatbázishoz készültek.  Készen elérhető a tanszéki kiszolgálón az alábbi kapcsolati adatokkal:

|              | |
|-             |-|
|Szerver       |bit.uni-corvinus.hu
|Felhasználónév|hallgato
|Jelszó        |Password123
|Adatbázis     |webshop

(+/-)Melyek azok a termékek, amelyek neve az átlagosnál hosszabb?
a. Csak a termékek kódja és megnevezése jelenjen meg!
[Megoldás](Gy08_01.mp4)

(+/-)Melyek azok a termékek, amelyekből ugyanannyi van készleten, mint dvd-ből?
a. Csak a termékek kódja és megnevezése jelenjen meg!
b. A Dvd ne szerepeljen a listában!
[Megoldás](Gy08_02.mp4)

(+/-)Melyek azok a raktárak, amelyekben nincs olyan termék, amelynek nevében a matrica szó benne van? 
a. A listában a raktárak minden adata jelenjen meg!
[Megoldás](Gy08_03.mp4)

(+/-)Mely nap(ok)on történt a legkevesebb megrendelés?
[Megoldás](Gy08_04.mp4)

(+/-)Listázzuk azon termékek adatait, amelyek listaára saját raktárukban a legkisebb!
[Megoldás](Gy08_05.mp4)

(+/-)Készítsünk listát arról, hogy ügyfelenként (LOGIN), azon belül szállítási módonként hány megrendelés történt! 
a.  A lista tartalmazza a részösszegeket és a végösszeget is!
b. Használjuk a ROLLUP záradékot!
[Megoldás](Gy08_06.mp4)

(+/-)Készítsünk listát a termékek számáról a következő csoportosítási szempontok szerint: kategória azonosító, raktárkód, raktárkód+mennyiségi egység! 
a. A listát szűrjük azokra a csoportokra, ahol a termékek száma legalább 6!
[Megoldás](Gy08_07.mp4)

(+/-)Készítsünk listát az egyes termékkategóriákban lévő termékek számáról!
a.  Elég megjeleníteni a kategóriák azonosítóit és a darabszámokat!
b.  A lista megfelelően jelölve tartalmazza a végösszeget is! 
c. Az oszlopokat nevezzük el értelemszerűen! 
d. A listát rendezzük a darabszám szerint növekvő sorrendbe!
[Megoldás](Gy08_08.mp4)

(+/-)Készítsünk listát az ügyfelek számáról születési év szerint, azon belül nem szerinti bontásban!
a. A lista megfelelően jelölve tartalmazza a részösszegeket és a végösszeget is! 
b. Az oszlopoknak adjunk nevet értelemszerűen!
[Megoldás](Gy08_09.mp4)

(+/-)Készítsünk listát a termékek számáról a felvitel hónapja, azon belül napja szerint csoportosítva. 
a. A lista csak a részösszegeket és a végösszeget tartalmazza! 
b. Az oszlopoknak adjunk megfelelő nevet! 
c. Ötlet: HAVING + GROUPING_ID fv együttes használata
[Megoldás](Gy08_10.mp4)

(+/-)Készítsünk listát éves bontásban norbert2 azonosítójú ügyfél rendeléseinek értékéről! 
a. A lista megfelelően jelölve tartalmazza a végösszeget is! 
b. Az oszlopokat nevezzük el értelemszerűen!
[Megoldás](Gy08_11.mp4)

(+/-)Készítsünk listát szállítási dátumonként, azon belül szállítási módonként az egyes rendelések összmennyiségéről! 
a. Csak azokat a termékeket vegyük figyelembe, amelyek mennyiségi egysége db! 
b. A listát szűrjük úgy, hogy az csak a részösszeg sorokat és a végösszeget tartalmazza! 
[Megoldás](Gy08_12.mp4)

(+/-)Készítsünk listát a termékek átlagos listaárairól! 
a. A lista legyen csoportosítva a következő szempontok alapján: kategórianév, kategórianév + raktárnév 
b. A lista tartalmazzon végösszeget (az átlagos árat minden termékre) is!
c. Az átlagos értéke max. két tizedesjeggyel legyen megjelenítve!
[Megoldás](Gy08_13.mp4)

(+/-)Hány olyan ügyfél van, aki még nem rendelt semmit? 
a. Csoportosítsuk őket nem szerint, azon belül életkor szerint! 
b. A lista tartalmazza a részösszegeket és a végösszeget is!
[Megoldás](Gy08_14.mp4)

(+/-)Készítsünk listát arról, hogy évente hányszor rendelték meg azokat a termékeket, amelyek kategóriájukban a legdrágábbak! 
a. A lista jelenítse meg az évet, a termék nevét és a rendelés számát! 
b. Jelenjenek meg a részösszegek és a végösszeg is!
[Megoldás](Gy08_15.mp4)
