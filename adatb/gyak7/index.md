# Beágyazott SQL lekérdezések
[Összefoglaló videó](gyak07_x264.mp4)
## Alapfogalmak
A beágyazott SQL lekérdezés (subuery) lekérdezés a lekérdezésen belül.
 - Rendszerint egy (külső) SELECT utasításon belüli (belső) SELECT  utasítást jelent (INSERT, DELETE és UPDATE utasításokba is beágyazható)    
 - Először a belső SELECT fut le, majd annak  eredményét megkapva a külső SELECT hajtódik végre. Korrelált allekérdezéseknél (lásd később) ez soronként történik. 
 - Egy külső SELECT-be több belső SELECT is beágyazható.
 
 Tipikus formája:
 ```sql
 Select <oszlopnév-lista> from <táblanév> 
 where (Select <oszlopnév-lista> from <táblanév>)
 ```
 pl: melyek azok a termékek, amelyeknek az átlagosnál nagyobb a listaára?
 ```sql
 select * from termek where listaar>(select avg(listaar) from termek)
 ```
 ### Korrelált és önálló allekérdezések
 Ha az allekérdezés hivatkozik a külső select valamely oszlopára, **korrelált** allekérdezésről beszélünk.
 ```sql
 select * from termek 
 where termek.listaar= (select max(listaar) from termek t2 where t2.kat_id=termek.kat_id)
  ```
  Ha nem, az allekérdezés **önálló**.
  ```sql
  select * from termek where listaar>(select avg(listaar) from termek)
  ```
  ## Csoportosítás eredmény szerint
Az allekérdezés visszaadhat egy értéket, ekkor **skalár** lekérdezésről beszélünk.
  ```sql
  select * from termek where listaar>(select avg(listaar) from termek)
  ```
Visszaadhat több értéket, akkor **multi-valued** lekérdezésről van szó:
  ```sql
  select * from termek where termekkod in (select termekkod from rendeles_tetel)
  ```
Visszaadhat **táblát** is, amely nem tananyag. Allekérdezést a from záradékban is használhatunk, ekkor táblát visszaadó allekérdezésről van szó.
## Allekérdezések használata 
### Hová kerülhet az allekérdezés?
Select záradékba:
 ```sql
select termekkod, 
(select count(*) from rendeles_tetel where termekkod=termek.termekkod) as [Eladott darabszám] 
from termek
```
From záradékba:
 ```sql
select * from  (select * from termek) as T
```
Where záradékba: 
  ```sql
  select * from termek where listaar>(select avg(listaar) from termek)
  ```
Having záradékba:
```sql
select * from rendeles_tetel where mennyiseg>(select avg(mennyiseg) from rendeles_tetel)
```
### Operátorok
#### ANY
Az ANY operátor igaz értéket ad vissza, ha az összehasonlítás eredménye az alkérdés legalább egy eredménysorára teljesül. Az alábbi lekérdezés a legolcsóbb terméken kívül mindegyiket visszaadja.
``` sql
SELECT *
FROM termek
WHERE listaar > ANY (select listaar from termek);
```
#### ALL
Az ALL operátor igaz értéket ad vissza, ha az összehasonlítás eredménye az alkérdés minden eredménysorára teljesül. Az alábbi lekérdezés a legdrágább termék(ek)et adja vissza:
```sql
SELECT *
FROM termek
WHERE listaar >= ALL (select listaar from termek);
```
#### IN
Az IN segítségével azt ellenőrízhetjük, a vizsgált érték eleme-e az eredményhalmaznak. Pl. melyek azok az ügyfelek, akik adtak már le rendelést?
```sql
select * from ugyfel where login in (select login from rendeles)
```
#### EXISTS
Az EXISTS operátor igaz értéket ad vissza, ha a beágyazott SELECT eredményhalmaza nem üres. Az előző feladat EXISTS operátorral:
``` sql
select * from ugyfel where exists (select * from rendeles where rendeles.login=ugyfel.login)
```
###  Mikor használjuk?
 - Ha szeretnénk összehasonlítani egy kifejezés értékét a beágyazott lekérdezés eredményével (legtöbbször <, >, = )
 - Ha szeretnénk eldönteni, hogy egy kifejezés eredménye benne van-e a beágyazott lekérdezés eredményhalmazában (IN)
 - Ha szeretnénk eldönteni, hogy a beágyazott lekérdezés eredményhalmaza üres-e (EXISTS)
### Korlátozások
Az ANSI SQL több korlátozást is megfogalmaz az allekérdezésekkel kapcsolatban, többségüket tapasztalhatjuk MSSQL-ben is:
- Mindig zárójelbe kell tenni
- Összehasonlítás esetén mindig a reláció jobb oldalán áll
- Nem lehet benne ORDER BY (leszámítva a TOP, FOR XML, OFFSET esetét), INTO
- Ha van benne GROUP BY, akkor nem lehet benne DISTINCT
- Ha csak egy értéket ad vissza, akkor nem lehet benne GROUP BY és HAVING sem 
- A visszaadott érték(ek)nek (join) kompatibilisnek kell lennie a külső SELECT WHERE feltételével
- Bizonyos adattípusok nem használhatók (ntext, text, image)
### Megjegyzések
- A beágyazott lekérdezések helyett többnyire más megoldást is használhatunk (pl: JOIN)
- A beágyazott lekérdezések átláthatóbbá teszik a kódot, viszont performacia szempontjából nem a legjobbak
- Ugyanaz a feladat sokszor többféle operátor használatával is megoldható (pl: IN, EXISTS). 
- Nagyobb rekordszám esetén performancia szempontjából legtöbbször az EXISTS a legjobb választás
- Az IN és az EXISTS operátorok tagadhatók is (NOT IN, NOT EXISTS)
- A beágyazott lekérdezések  egymásba is ágyazhatók
## Példák
### Önálló alkérdés - összehasonlítás
Melyek azok a rendelési tételek, amelyek rendelési mennyisége az átlagos rendelési mennyiségnél nagyobb?
``` sql
SELECT * FROM rendeles_tetel
WHERE mennyiseg > (SELECT AVG(mennyiseg) FROM rendeles_tetel)
```
### Önálló alkérdés – összehasonlítás + ANY, ALL
Melyek azok a termékek, amelyek nem a legolcsóbbak (listaáruk nem a legkisebb)
``` sql
SELECT megnevezes
FROM Termek
WHERE listaar > ANY
(
 SELECT listaar
 FROM Termek
)
```
Melyek a legdrágább termékek?
``` sql
SELECT megnevezes
FROM Termek
WHERE listaar >= ALL
(
 SELECT listaar
 FROM Termek
)
```
### Önálló alkérdés - IN
Melyek azok az ügyfelek, akik már adtak le rendelést?
``` sql
SELECT Nev
 FROM Ugyfel 
WHERE [login] IN 
(
SELECT DISTINCT [login] 
FROM rendeles
)
```
### Korrelált alkérdés - Összehasonlítás
Melyek azok a termékek, amelyek listaára kategóriájukban a legmagasabb?
``` sql
SELECT t.termekkod, t.MEGNEVEZES
FROM Termek t
WHERE t.LISTAAR = 
(
 SELECT max(t2.LISTAAR)
 FROM Termek t2
 WHERE t.KAT_ID = t2.KAT_ID
)
```
### Korrelált alkérdés – Összehasonlítás + ANY, ALL
Melyek azok az a termékek, amelyek saját raktárukban a legolcsóbbak?
``` sql
SELECT t.TERMEKKOD, t.megnevezes
FROM Termek t
WHERE t.listaar <= ALL
(
 SELECT t2.listaar
 FROM Termek t2
 WHERE t.RAKTAR_KOD = t2.RAKTAR_KOD
)
```
### Korrelált alkérdés - IN
``` sql
SELECT u.NEV
FROM Ugyfel u
WHERE 'Esküvői meghívó' IN
(
  SELECT t.megnevezes
  FROM Rendeles r        JOIN Rendeles_Tetel rt ON r.SORSZAM = rt.SORSZAM
       JOIN Termek t ON rt.TERMEKKOD = t.TERMEKKOD
  WHERE u.LOGIN = r.LOGIN
)
```
### Korrelált alkérdés - EXISTS
Melyek azok a termékek, amelyekből legalább egyszer rendeltek már 50 darabnál többet? 
``` sql
SELECT t.megnevezes
from Termek t
where EXISTS
(
  SELECT *
  FROM Rendeles_tetel rt 
  WHERE rt.TERMEKKOD = t.TERMEKKOD 
        AND rt.MENNYISEG > 50
)
```
### Alkérdés - HAVING
Melyek azok az ügyfelek, amelyek 2017-ben többször rendeltek, mint 2016-ban? Elég az ügyfelek azonosítóját (LOGIN) megjeleníteni!
``` sql
SELECT u.LOGIN
FROM Rendeles r JOIN Ugyfel u ON r.LOGIN = u.LOGIN
WHERE YEAR(rend_datum)=2017 
GROUP BY u.login
HAVING COUNT(*)>
(
  SELECT COUNT(*)
  FROM Rendeles r2 JOIN Ugyfel u2 ON r2.LOGIN = u2.LOGIN
  WHERE YEAR(rend_datum)=2016 AND u2.LOGIN = u.LOGIN
)
```

# Feladatok
## Előkészületek
• Csatlakozás a tanszéki kiszolgálóra
A gyakorlathoz tartozó adatbázis az egyetemen kívülről csak VPN-en keresztül érhető el. 

|              | |
|-             |-|
|Szerver       |bit.uni-corvinus.hu
|Felhasználónév|hallgato
|Jelszó        |Password123
|Adatbázis     |webshop


Válasszuk ki a webshop adatbázist!
-- Vagy --
•	Webshop adatbázis telepítése a webshop.sql script segítségével. Figyelem, nagy méretű állomány, lefuttatása néhány percet is igénybe vehet.

***A 3,4,5,16 feladatokhoz mindenképpen saját (Azure vagy telepített) SQL szerverre van szükség, mivel adatdefiníciós és -manipulációs parancsok futtatása a tanszéki kiszolgálón nem megengedett.***

## Feladatsor
(+/-) Melyek azok a rendelések, ahol a rendelés postai úton történt, és a megrendelés és a szállítás dátuma között több, mint egy hét telt el?
a.	Csak a rendelések sorszámait listázzuk!
[Megoldás](Gy07_01.mp4)

(+/-) Listázzuk veronika4 azonosítójú (LOGIN) felhasználó összes rendelését!
a.	Csak a rendelés sorszámát, dátumát, a termékkódot és a mennyiséget jelenítsük meg!
[Megoldás](Gy07_02.mp4)

(+/-) Egy spórolós ügyfél saját árlistát szeretne készíteni, amelyet egy külön táblában tárol. 
Ebben a megvásárolni kívánt termékek kódját és a más webshopokban elérhető legalacsonyabb árát tárolja. Első lépésként létrehoz egy táblát NEPTUNKOD_ARLISTA néven, amelynek szerkezete a következő: 
(
  ID egész szám,
  TERMEKKOD szöveg(255),
  MIN_LISTAAR valós szám
)
Az ID legyen elsődleges kulcs, a LISTAAR csak 0 és 50000 között lehet.
a.	Hozzuk létre az új táblát és a megadott kényszereket!
[Megoldás](Gy07_03.mp4)

(+/-) Töltsük fel manuálisan a NEPTUNKOD_ARLISTA táblát a következő adatokkal:
a.	 1, '01100070T', 80
b.	 2, '02040403T', 1200
c.	 3, '03080031T', 100
d.	 4, '07040047T', 35
[Megoldás](Gy07_04.mp4)

(+/-) Listázzuk a NEPTUNKOD_ARLISTA tábla sorait! A lista tartalmazzon két új oszlopot is. 
a.	Az első a Termek táblában található listaár legyen ugyanerre a termékre 'Webshop_listaár' néven!
b.	A második 'Megéri_e' néven egy bit típusú oszlop legyen. Ennek értéke 1, ha a listaár kisebb, vagy egyenlő, mint a Termek táblában található listaár, 0 ha magasabb.
[Megoldás](Gy07_05.mp4)

(+/-)  **Listázzuk azon termékeket, amelyekből az átlagosnál kevesebb van raktáron!**
a.	Csak a termék kódja és megnevezése jelenjen meg!
[Megoldás](Gy07_06.mp4)

(+/-) ** Listázzuk azon ügyfeleket, akik még nem fizettek bankkártyával!**
a.	Csak az ügyfelek neve jelenjen meg!
[Megoldás](Gy07_07.mp4)

(+/-) **Mennyibe kerül a második legnagyobb listaárú termék?**
[Megoldás](Gy07_08.mp4)

(+/-) **Melyik raktár(ak)ban van az a termék, amelyből a legnagyobb készlet van?**
a.	 Csak a raktár(ak) neve jelenjen meg!
[Megoldás](Gy07_09.mp4)

(+/-) **Melyek azok a termékek, amelyek listaára nagyobb, mint bármelyik olyan terméké, amelynek nevében az Ajándék szó szerepel?**
a.	A termékek kódját és nevét is jelenítsük meg!
[Megoldás](Gy07_10.mp4)

(+/-) Melyik hónapokban adtak le az ügyfelek több rendelést, mint januárban?
a.	Elég a hónapok sorszámait megjeleníteni.
b.	A listát rendezzük a hónapok száma szerint növekvő sorrendbe!
[Megoldás](Gy07_11.mp4)

(+/-) Melyek azok a termékek, amelyek listaára az átlagostól max. 20%-kal tér el?
a.	A termék kódját és nevét is jelenítsük meg!
[Megoldás](Gy07_12.mp4)

(+/-) Készítsünk listát (sorszámonként) az egyes rendelések teljes összegéről!
a.	Szűrjünk azon tételekre, ahol ez az érték nagyobb, mint Viktor Éva rendeléseinek teljes összege! 
b.	 A teljes összeg oszlopot nevezzük el értelemszerűen!
[Megoldás](Gy07_13.mp4)

(+/-) Listázzuk azokat a termékkategóriákat, amelyből 2017 januárban nem történt rendelés! 
a.	Elég a kategóriák nevét megjeleníteni!
[Megoldás](Gy07_14.mp4)

(+/-) Listázzuk azon rendelési tételeket, amelynek értéke nagyobb, mint a legdrágább termék listaára azon termékek közül, amelyek szülő kategóriája a ruha!
[Megoldás](Gy07_15.mp4)

(+/-) Plusz feladat: töröljük a NEPTUN_LISTAAR táblát
