# 3. gyakorlat - Aggregált függvények és csoportok képzése

Összefoglaló videó:

[gyak03-osszefoglalo_x264.mp4](gyak03-osszefoglalo_x264.mp4)

A skaláris függvények mindig egy rekordon belül, a rekord mezőivel végeznek műveleteket.  Az összesítő függvények értékek egy halmazán végeznek számítást, és egyetlen értéket adnak vissza. Alapesetben, azaz, ha egyéb megkötéseket nem teszünk, a halmaz a tábla összes sorát jelenti. 

Az összesítő függvények (kivéve: COUNT(*)) nem veszik figyelembe a NULL értékeket.  Azaz, ha adott egy ilyen tábla:

| Kod| Nev| Ertek   |
|-----|------------|------|
| 1   | ABC        | 100  |
| 2   | DEF        | NULL |
| 3   | GHI        | 20   |

``` sql
SELECT COUNT(Ertek) FROM tabla  --eredménye 2
SELECT COUNT(*) FROM tabla -- eredménye 3
SELECT AVG(ertek) FROM tabla --eredménye 60
```
de:
```sql
SELECT AVG(isnull(ertek,0)) from tabla  --eredménye 40
```
Példák aggregált függvényekre: `MAX`, `MIN`, `COUNT`, `SUM`, `STDEV`, `VAR`

A `MIN` és a `MAX` bármely adattípusra használhatók, a `SUM` és az `AVG` függvényeket csak numerikus adatokkal használjuk. Egész oszlopra végzik el a műveletet, egy értéket adnak vissza.

Példák:

``` sql
SELECT
	MAX(nettoar) AS legdrágább,
	MIN(nettoar) AS legolcsóbb,
	AVG(nettoar) AS átlagár,
	SUM(nettoar) AS összeg,
	COUNT(nettoar) AS db,
	STDEV(nettoar) AS szórás,
	VAR(nettoar) AS variancia

FROM dvd
```
``` sql
SELECT MAX(cim) AS [abc első filmje], MIN(cim) AS [abc utolsó filmje] FROM dvd;
```
Szöveg típusú mezők esetén a `MIN` és a `MAX` az abc-ben elfoglalt helyre vonatkozik. 

``` sql
SELECT COUNT(*) FROM dvd;
```
A `dvd` tábla rekordjainak számát adja vissza.

``` sql
SELECT COUNT(stilus) FROM dvd;
```
Megadja, hogy hány rekordban van kitöltve a `stilus` mező a `dvd` táblában. 

## Csoportok képzése - A GROUP BY záradék

A `GROUP BY` záradék segítségével mező vagy kifejezés szerint csoportokat képezhetünk. Ha csoportokat alkotunk, és azután használjuk az aggregált függvényeket, akkor már nem az egész táblázatra vonatkoznak, hanem a csoportokra. (Minden csoportra külön értéket adnak vissza.)

A `GROUP BY` záradékban minden oszlopnévnek kell szerepelnie, ami a `SELECT` után előfordul. Ez alól csak az aggregált függvények paramétereiként szereplő mezőnevek képeznek kivételt.

``` sql
SELECT stilus
FROM dvd
GROUP BY stilus
```
Csoportokat képezünk stílus szerint, és a `SELECT` kulcsszó után meg is jelenítjük a csoportjainkat. Azok a filmek is külön csoportba kerülnek, ahol a `stilus` mező nincs kitöltve. Ezek szerint annyi csoportunk lesz, ahány különböző stílus fordul elő a `dvd` táblában. 
``` sql
SELECT stilus, nyelv
FROM dvd
GROUP BY stilus, nyelv
```
Itt azok a rekordok kerülnek egy csoportba, melyeknél a `stilus` és a `nyelv` megegyezik. (Pl. az összes angol nyelvű horror film egy csoportba kerül.)
``` sql
SELECT stilus, COUNT(stilus) AS db
FROM dvd
GROUP BY stilus
```
Csoportokat képezünk stílus alapján, majd megszámoljuk, hogy hány helyen van kitöltve a stilus mező egy csoporton belül.
> Megjegyzés: Ilyenkor pl. a címet már nem tehetném be a `SELECT` után. Tehát a `SELECT` után csak azok a feliratok szerepelhetnek, amik szerepelnek a `GROUP BY` részeként is.
> ``` sql
>SELECT stilus, cim, COUNT(stilus) AS db 
> FROM dvd
>GROUP BY stilus
>```
>Ez így nem helyes, mert a `SELECT` után csak olyan állhat, ami a `GROUP BY` után is van.

## A HAVING záradék

A `HAVING` záradék a csoportképzés utáni táblázatokra tesz rá egy feltételt.  A `WHERE` csoportképzés előtt használatos, míg a `HAVING` segítségével a már elkészült csoportokra fogalmazható meg feltétel!

``` sql
SELECT  stílus, COUNT(cím) AS Címek FROM dvd GROUP BY stílus HAVING  COUNT(cim)>30; 
```
Csak azokat a stílusokat jeleníti meg, melyeknél több mint 30 címet számoltunk. 
``` sql
SELECT Kategóriakód, Sum(Raktáron)FROM Termékek GROUP BY Kategóriakód HAVING Sum(Raktáron) > 100
```
## Rendezés - Az ORDER BY záradék

Az ORDER BY záradék lekérdezés eredményét sorba rendezi a megadott szempontok alapján.
A rendezésnél megadhatjuk az egyes oszlopok nevét. Aaz AS kulcsszó után megadott név is használható, azaz a két alábbi lekérdezés azonos eredményt ad:
``` sql
select id, cim, nettoar*1.27 as bruttoar from DVD
order by nettoar*1.27

select id, cim, nettoar*1.27 as bruttoar from DVD
order by bruttoar
```
Növekvő rendezés esetén az ASC, csökkenő rendezés esetén a DESC kulcsszót használhatjuk a rendezés irányának megadására  Alapértelmezett a növekvő rendezés, ilyenkor az ASC kulcsszó is elhagyható. DVD-k bruttoar szerinti csökkenő sorrendben:
``` sql
select id, cim, nettoar*1.27 as bruttoar from DVD
order by bruttoar DESC
```
Rendezni lehetséges az aggregálás eredménye szerint is:
``` sql
select stilus, count(*) from dvd 
group by stilus
order by count(*) desc
```
>Ha egy lekérdezésben csoportosítást is használunk, akkor az ORDER BY utáni felsorolásban lévő oszlopoknak benne kell lenniük a GROUP BY listában vagy egy összesítésben, azaz az alábbi lekérdezés **nem** helyes:
>``` sql
>select stilus, count(*) from dvd 
>group by stilus
>order by nettoar desc
>```


## Záradékok sorrendje

`SELECT` -> `FROM` -> `WHERE` -> `GROUP BY` -> `HAVING` -> `ORDER BY`

A záradékok sorrendje a gépi adatfeldolgozás sorrendjét követi:
- `FROM`: kiválasztjuk, melyik táblá(k)ból szeretnénk dolgozni
- `WHERE`: kiszűrjük, hogy melyik sorokkal szeretnénk dolgozni
- `GROUP BY`: a szűrés után megmaradt sorok alapján csoportokat képezünk
- `HAVING`: a csoportosítás után kapott táblára is szabhatunk szűrőfeltételt
- `ORDER BY`: csak a legvégén érdemes sorba rakni az eredményt

``` sql
SELECT stilus, COUNT(stilus) AS db
FROM dvd
WHERE nettoar<5000
GROUP BY stilus
HAVING COUNT(stilus)>2
ORDER BY stilus
```

## Feladatok

A feladatokat a *dvd_magyar* adatbázishoz készültek.  Készen elérhető a tanszéki kiszolgálón az alábbi kapcsolati adatokkal:

|              | |
|-             |-|
|Szerver       |bit.uni-corvinus.hu
|Felhasználónév|hallgato
|Jelszó        |Password123
|Adatbázis     |dvd_magyar

(+/-) 1.	Jelenítsük meg, hogy összesen hány db történelem stílusú dvd van a dvd táblában! 

a.	Az oszlop neve legyen 'DB'! 
b.	Csak olyan dvd-ket vegyünk figyelembe, amelyeknek van címe!

[Megoldás](Gy3_1.mp4)

(+/-) 2. Készítsünk lekérdezést, amely listázza, hogy mely napokon hány db kölcsönzés történt! 

a.   Az oszlopok neve legyen 'Dátum' és 'Kölcsönzések száma'
b.   A listát rendezzük a kölcsönzés dátuma szerint csökkenő sorrendbe!

[Megoldás](Gy3_2.mp4)

**(+/-) 3. Mennyi a dvd-k átlagos ára stílusonkénti bontásban?**

a.   Csak azokat a stílusokat vegyük figyelembe, ahol az átlagos ár 4500 Ft feletti!
b.   Az oszlopokat nevezzük el értelemszerűen!
c.   A listát rendezzük átlagos ár szerint csökkenő sorrendbe!

[Megoldás](Gy3_3.mp4)

(+/-) 4. Összesen mennyi a raktárkészlet teljes nettó értéke? 
a.   Az oszlop neve legyen 'Pontos érték'
b.   Egy másik oszlopban jelenítsük meg az előző értéket millió Ft-ra kerekítve, az oszlop neve legyen 'Kerekíett érték millió Ft-ban'

[Megoldás](Gy3_4.mp4)

(+/-) 5. Készítsünk listát, amely a kölcsönzések darabszámát listázza éves, azon belül havi bontásban! 
a.   Az oszlopokat nevezzük el értelemszerűen!
b.   Rendezzük a listát Év szerint növekvő sorrendbe!

[Megoldás](Gy3_5.mp4)

(+/-) 6. Listázzuk nyelvenkénti, azon belül stílusonkénti bontásban, hogy mennyi a dvd-k legkisebb és legnagyobb ára! a.   Az oszlopok neve legyen 'Nyelv', 'Stílus', 'MinÁr' és 'MaxÁr'!

b.   A listából hagyjuk ki azokat a sorokat, ahol a nyelv vagy a stílus nincs megadva!
c.   Szintén hagyjuk ki azokat a csoportokat, ahol a csoport elemszáma 3-nál kisebb!

[Megoldás](Gy3_6.mp4)

**(+/-) 7. A kölcsönzéseket két csoportra oszthatjuk aszerint, hogy visszahozták-e már a dvd-t. Ez alapján készítsünk listát, amely megadja a kölcsönzés alatt lévő, illetve a már visszahozott dvd-k számát!**

a.   Az oszlopok neve legyen 'Állapot' és 'DB'
b.   A listát rendezzük DB szerint növekvő sorrendbe!

[Megoldás](Gy3_7.mp4)

(+/-) 8. Hány darab különböző című dvd van stílusonként? 
a.    Az oszlopok neve legyen 'Stílus' és 'Különböző című dvd-k száma'
b.    Csak azokat a dvd-ket számoljuk bele, amelyek stílusnevében a 'játék' szó benne van.

[Megoldás](Gy3_8.mp4)

**(+/-) 9. A DVD-ket katalógusba szeretnénk rendezni, ezért készítsünk listát, amely a cím első betűje alapján, majd a stílus alapján, utána a nyelv alapján, végül a nettó ár alapján rendezi sorba a dvd-k listáját.**
a.   A lista jelenítse meg az összes oszlopot. 
b.   Azokra dvd-kre, ahol a cím nincs megadva, ott 'Ismeretlen cím'   szerepeljen, ahol pedig a stílus nincs megadva, ott 'Ismeretlen stílus'.

[Megoldás](Gy3_9.mp4)

(+/-) 10. Készítsünk listát, amely a csoportokat hoz létre aszerint, hogy a mai naptól számítva hány nap telt el a kölcsönzés kezdete óta. A lista jelenítse meg csoportonkénti bontásban a kikölcsönzött dvd-k számát! 
a.   Az oszlopokat nevezzük el értelemszerűen! 
b.   A listát rendezzük az eltelt napok száma szerint csökkenő sorrendbe!

[Megoldás](Gy3_10.mp4)

(+/-) 11. Egy nyelvtanuló kíváncsi, hogy vajon átlagosan drágábbak-e azok a dvd-k, amelyek nevében az 'angol' szó benne van azoknál, amelyeknél nincs. Ezért készítsünk lekérdezést, amely segítségével erre a kérdésre választ adhatunk! 
a.   Az átlagos ár 10 Ft-ra kerekítve jelenjen meg!

[Megoldás](Gy3_11.mp4)

**(+/-) 12. A kölcsönző tulajdonosa elhatározza, hogy ezentúl kerekebb árakat alkalmaz. Ezért minden dvd árát 1000 Ft-ra kerekíti. Készítsünk lekérdezést, amely megmutatja, hogy melyik 1000 Ft-ra kerekített ár szerint, azon belül stílus szerint hány db dvd összesen raktáron! **
a.   Csak olyan csoportokat listázzunk, ahol a raktárkészlet legalább 30!
b.   A listát rendezzük kerekített ár szerint, azon belül raktárkészlet szerint növekvő sorrendbe!**

[Megoldás](Gy3_12.mp4)

(+/-) 13. Készítsünk listát, amely nyelvenként, azon belül stílusonként, azon belül a raktár készlet mennyisége szerint jeleníti meg a dvd-k darabszámát, minimális és maximális árát! 
a.   Csak azokat a csoportokat jelenítsük meg, ahol a maximális ár legalább 1000 forinttal haladja meg a minimális árat!

[Megoldás](Gy3_13.mp4)

(+/-) 14. Több dvd esetén a stílus nevében zárójelbe téve szerepel egy szó, pl. játék (repülős). Ez alapján létrehozható egy 'Alstílus' nevű oszlop, amely a zárójelben lévő szót tartalmazza a zárójellel együtt. Azoknál a stílusoknál, ahol nincs zárójel, ott az oszlop értéke legyen üres szöveg.   Készítsünk lekérdezést, amely stílusonként, azon belül alstílusonként listázza a raktáron lévő  dvd-k darabszámát. 

a.   A stílus nevéből vegyük ki a zárójeles kifejezést!

[Megoldás](Gy3_14.mp4)

**(+/-) 15. A dvd-ket csoportosíthatjuk aszerint, hogy milyen hosszú a címük. Amelyiknél a cím hosszúsága 10 karakter alatt van, az legyen Rövid, 10-20-ig Átlagos, 20 felett Hosszú. Hány Rövid, Átlagos, illetve Hosszú dvd-van összesen raktáron?**

a.    Az oszlopok neve legyen 'Cím hosszúság' és 'Darabszám'

[Megoldás](Gy3_15.mp4)
