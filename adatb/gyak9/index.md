
# Partíciók, ablakok, analitikus függvények
[Összefoglaló videó (18 perc)](gyak09_x264.mp4)
## Partíciók
Azon rekordok csoportja, amelyeken az aggregálást el kell végezni. A GROUP BY egyfajta alternatíváinak is tekinthetjük őket.
Forma:
```sql
OVER(PARTITION BY kifejezés) 
--kiegészíthető rendezéssel:
OVER (PARTITION BY kifejezés  ORDER BY kifejezés)
```

>Példa: Jelenítsük meg a termékek kódja és listaára mellett a termékkategória átlagárát is!
``` sql
SELECT TERMEKKOD, LISTAAR,
       AVG(LISTAAR) OVER (PARTITION BY KAT_ID) AS 'Kategória átlagár'
FROM Termek
```
## Ablakok
Ablakokat a ROWS és a RANGE segítségével hozhatunk létre. Ezek az ablakot határozzák meg, használatukhoz az ORDER BY rész kötelező.
Forma:
```sql
OVER(PARTITION BY kifejezés ORDER BY kifejezés
ROWS | RANGE 
BETWEEN kezdőpont AND végpont)
/*A kifejezés - itt és az összes többi utasítás/függvény leírásban - 
a gyakorlatban többnyire oszlopnevet vagy oszlopnevek listáját jelenti*/
```
### ROWS
A ROWS az ablak méretét **fizikailag** adja meg  (legtöbbször az aktuális sort megelőző és/vagy követő sorok számát konkrétan megadja) 
Kezdőpont, végpont lehet: 
 - CURRENT ROW, 
- n PRECEDING, 
- n FOLLOWING.

Speciálisan: 
- UNBOUNDED PRECEDING (kezdőpont), 
- UNBOUNDED FOLLOWING (végpont)
(A partíció legelső, illetve legutolsó sorát jelenítik meg)

Formája:
``` sql
OVER(
PARTITION BY kifejezés 
ORDER BY kifejezés
ROWS BETWEEN kezdőpont AND végpont)
```
 
 >Példa: Listázzuk az egyes megrendelések dátumát, a termék kódját és mennyiségét, valamint a sorszám szerinti előző 5 megrendelés átlagos mennyiségét is!
``` sql
SELECT rt.TERMEKKOD, r.REND_DATUM,
 	   rt.MENNYISEG, AVG(rt.MENNYISEG) 
       OVER(PARTITION BY rt.TERMEKKOD 
       ORDER BY r.SORSZAM
       ROWS BETWEEN 5 PRECEDING AND 1 PRECEDING) 
       AS 'ELőző 5 rendelés mennyiség átlaga'
FROM Rendeles_tetel rt
     JOIN Rendeles r ON r.SORSZAM = rt.SORSZAM
```
### RANGE
A RANGE az ablak méretét **logikailag** adja meg: nem a sorok számát, hanem a legelső, legutolsó vagy az aktuális sort, mint az intervallum kezdő- vagy végpontját).
Kezdőpont, végpont lehet: 
- CURRENT ROW, 
- UNBOUNDED PRECEEDING (kezdőpont) 
- UNBOUNDED FOLLOWING (végpont)

Formája:
```sql
Formája: 
OVER(
PARTITION BY kifejezés 
ORDER BY kifejezés
RANGE BETWEEN kezdőpont AND végpont)
```
>Példa: Jelenítsük meg, hogy az egyes ügyfelek az adott rendelési dátumig bezárólag összesen hányszor rendeltek! Megjelenítendő a rendelés dátuma, az ügyfél login-ja és a rendelés darabszáma 
``` sql
SELECT DISTINCT REND_DATUM,[LOGIN],
       COUNT(*) OVER(PARTITION BY [LOGIN] ORDER BY REND_DATUM
       RANGE BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) 
       AS 'Eddigi rendeléseinek száma'
FROM Rendeles ORDER BY REND_DATUM, [LOGIN] 
```
## Analitikus függvények
### ROW_NUMBER()
A lekérdezés eredménysoraihoz sorszámokat rendel. Mindig **szigorúan monoton** növekvő számokat ad vissza! Több partíció esetén a sorszámozás minden partíciónál újra kezdődik. 

Formája:
```sql
ROW_NUMBER()
OVER (
PARTITION BY kifejezés
ORDER BY kifejezés)
```
>Példa: Készítsünk sorszámozott listát nemenként az ügyfelekről! A sorszámozás szempontja az ügyfél email-címe legyen!
```sql
SELECT ROW_NUMBER() OVER(PARTITION BY nem ORDER BY email) AS 'Nemenkénti sorszám', *
FROM Ugyfel
```
### RANK()
Megadja, hogy az adott rekord hányadik a partícióban az adott rendezettség szerint. Mindig  **monoton** növekvő számokat ad vissza!
- Az azonos értékű sorok ugyanazt a sorszámot kapják. 
- A következő sorszám az aktuálisnál annyival lesz nagyobb, ahány azonos értékű sor van.

Formája:
```sql
RANK()
OVER (
PARTITION BY kifejezés
ORDER BY kifejezés)
```
>Példa:Listázzuk a termékek kódját, megnevezését, kategória kódját, készlet mennyiségét és azt, hogy a termék a készlet alapján hányadik a kategóriájában
```sql
SELECT TERMEKKOD, MEGNEVEZES, KAT_ID, KESZLET,
       RANK() OVER (PARTITION BY KAT_ID 
	    ORDER BY KESZLET DESC)
   AS 'Készlet szerinti helyezés kategóriájában'
FROM Termek
```
### DENSE_RANK()
Megadja, hogy az adott rekord hányadik a partícióban az adott rendezettség szerint.  A DENSE_RANK() mindig **monoton növekvő** számokat ad vissza.
- Az azonos értékű sorok ugyanazt a sorszámot kapják
- A következő sorszám az aktuálisnál eggyel nagyobb lesz

Formája:
``` sql
ROW_NUMBER()
OVER (PARTITION BY kifejezés
ORDER BY kifejezés)
```

> Példa: Az előző példa DENSE_RANK() függvénnyel
```sql
SELECT TERMEKKOD, MEGNEVEZES, KAT_ID, KESZLET,
       DENSE_RANK() OVER (PARTITION BY KAT_ID 
	    ORDER BY KESZLET DESC)
    AS 'Készlet szerinti helyezés kategóriájában'
FROM Termek
```
### LAG()
Megadja egy adott sorhoz képest x-sorral korábbi oszlop értékét partíciónként egy adott rendezési szempont  szerint. 
- A default érték akkor jelenik meg, ha nincs x sorral korábbi elem
- Ha x és default érték elmarad, akkor 1 sorral ugrik vissza

Formája:
```sql
LAG(kifejezés, x, default érték) 
OVER (PARTITION BY kifejezés ORDER BY kifejezés)
```
> Példa: Listázzuk minden rendelési tétel sorszámát, a termék kódját és mennyiségét, valamint az adott termék előző rendelésének mennyiségét!
```sql
SELECT SORSZAM, TERMEKKOD, MENNYISEG,
       LAG(MENNYISEG,1,0) OVER(PARTITION BY TERMEKKOD ORDER BY SORSZAM)
       AS 'Előző rendelési mennyiség'
FROM Rendeles_tetel
```
### LEAD()
Megadja egy adott sorhoz képest x-sorral későbbi oszlop értékét partíciónként egy adott rendezési szempont  szerint. Ha x és default érték elmarad, akkor 1 sort lép előre.
Formája:
```sql
LEAD(kifejezés, x, default) 
OVER (PARTITION BY kifejezés ORDER BY kifejezés)
```
>Példa: Listázzuk minden rendelési tétel sorszámát, a termék kódját és mennyiségét, valamint az adott termék kettővel későbbi rendelésének mennyiségét!
```sql
SELECT SORSZAM, TERMEKKOD, MENNYISEG,
       LEAD(MENNYISEG,2,0) OVER(PARTITION BY TERMEKKOD ORDER BY SORSZAM)
   AS 'Két rendeléssel későbbi rendelési mennyiség'
FROM Rendeles_tetel
```
### FIRST_VALUE()
Megadja egy adott sorrendben lévő csoport(partíció) legelső elemét.
Formája:
```sql
FIRST_VALUE(kifejezés) 
OVER (ORDER BY kifejezés
PARTITION BY kifejezés)
```
>Példa: Listázzuk az egyes ügyfelek adatait és első rendelésük dátumát! A lista ne tartalmazzon duplikált sorokat!
```sql
SELECT DISTINCT u.*, 
 	   FIRST_VALUE(r.REND_DATUM) 
       OVER (Partition BY u.LOGIN ORDER BY r.REND_DATUM) 
   		AS 'Első rendelés'
FROM Ugyfel u JOIN Rendeles r 
	 ON u.LOGIN = r.LOGIN
```
### LAST_VALUE()
Megadja egy adott sorrendben lévő csoport(partíció) legutolsó elemét.
>A LAST_VALUE esetén vigyázni kell, mivel futtatáskor a partíció legutolsó eleme alapértelmezés szerint az aktuális sor! Megoldás lehet a RANGE vagy helyette fordított sorrend és FIRST_VALUE()

Formája:
```sql
LAST_VALUE(kifejezés) 
OVER (ORDER BY kifejezés
PARTITION BY kifejezés)
```
>Példa: Listázzuk az ügyfelek adatai és azt, hogy melyik ügyfél utoljára milyen módon legelőször, illetve legutoljára! A lista ne tartalmazzon duplikált sorokat!
```sql
 SELECT DISTINCT u.*, FIRST_VALUE(r.FIZ_MOD) 
       OVER (Partition BY u.LOGIN ORDER BY r.SORSZAM) 
   		AS 'Fizetési mód legelső rendeléskor',
   		LAST_VALUE(r.FIZ_MOD) 
       OVER (Partition BY u.LOGIN ORDER BY r.SORSZAM 
       RANGE BETWEEN UNBOUNDED PRECEDING AND UNBOUNDED FOLLOWING) 
       AS 'Fizetési mód legutolsó rendeléskor'
FROM Ugyfel u
JOIN Rendeles r ON u.LOGIN = r.LOGIN
```
### NTILE()
A partíció elemeit adott számú osztályba sorolja a megadott sorrend alapján.
Formája:
```sql
NTILE(osztályok száma) 
OVER (ORDER BY kifejezés
PARTITION BY kifejezés)
```
Példa: Soroljuk be a termékeket kategóriájukban a listaáruk alapján 5 osztályba!
```sql
SELECT *, 
      NTILE(5) OVER(PARTITION BY KAT_ID 
      ORDER BY LISTAAR) 
      AS 'Osztály'
FROM Termek
```
### Megjegyzések
- Az analitikus függvények segítségével sok feladat egyszerűbben megoldható, mint „hagyományos” módon, viszont ilyenkor a lekérdezés többnyire lassúbb lesz
- Bizonyos feladatok a RANGE és a ROWS segítségével is megoldhatók, viszont duplikált sorok esetén a RANGE és a ROWS különböző eredményt adhat
- Egy lekérdezésben több ablak-függvény is szerepelhet
- Ha ROWS/RANGE esetén a végpont elhagyható, ez esetben alapértelmezés szerint a CURRENT ROW lesz
- Ha a PARTITION BY kimarad, akkor csak egy csoport lesz, amely minden rekordot tartalmaz

# Feladatok

A feladatok a *webshop* adatbázishoz készültek.  Készen elérhető a tanszéki kiszolgálón az alábbi kapcsolati adatokkal:

|              | |
|-             |-|
|Szerver       |bit.uni-corvinus.hu
|Felhasználónév|hallgato
|Jelszó        |Password123
|Adatbázis     |webshop

(+/-) Készítsünk listát arról, hogy melyik ügyfél (LOGIN) hányszor rendelt összesen. 
a.	A lista tartalmazza a végösszeget is. 
b.	 A listát rendezzük a rendelések száma szerint növekvő sorrendbe!
[Megoldás](Gy09_01.mp4)

(+/-) Átlagosan hány termék van készleten kategóriánként (KAT_ID), raktáranként (RAKTAR_KOD), illetve mennyiségi egységenként? (szempontonként külön-külön) 
a.	Az átlagot kerekítsük egészre!
[Megoldás](Gy09_02.mp4)

(+/-) Készítsünk listát a megrendelt termékek legkisebb és legnagyobb egységáráról szállítási dátum, azon belül szállítási mód szerinti bontásban! 
a.	A lista csak a 2015 májusi szállításokat tartalmazza! 
b.	Jelenítsük meg a részösszegeket és a végösszeget is!
[Megoldás](Gy09_03.mp4)

(+/-) Készítsünk csoportot a termékek listaára alapján a következők szerint: Az "olcsó" termékek legyenek azok, amelyek listaára 3000 alatt van. A "drága" termékek legyenek az 5000 felettiek, a többi legyen "közepes".
a.	Listázzuk az egyes csoportokat, és a csoportokba tartozó termékek darabszámát! 
b.	A lista jelenítse meg a végösszeget is!
[Megoldás](Gy09_04.mp4)

(+/-) Listázzuk a rendelési tételek számát raktáranként éves bontásban!
a.	A listában a raktár neve, az év és a darabszám jelenjen meg! 
b.	A lista jelenítse meg a részösszegeket és a végösszeget is! 
c.	A végösszeget megfelelően jelöljük!
d.	Az oszlopokat nevezzük el értelemszerűen!
[Megoldás](Gy09_05.mp4)

(+/-) **Készítsünk listát az ügyfelek adatairól név szerinti sorrendben.**
a.	Minden sorban jelenjen meg a sorrend szerint előző, illetve következő ügyfél neve is. 
b.	Ha nincs előző vagy következő ügyfél, akkor a 'Nincs' jelenjen meg!
[Megoldás](Gy09_06.mp4)

(+/-) **Készítsünk lekérdezést, amely megmutatja, hogy melyik termékkategóriába hány termék tartozik. A lista a kategória nevét és a darabszámot jelenítse meg.**
a.	A lista ne tartalmazzon duplikált sorokat. 
b.	A feladatot partíciók segítségével oldjuk meg!
[Megoldás](Gy09_07.mp4)

(+/-) **Készítsünk listát a rendelési tételekről. Az egyes rendelési tételeket termékenként soroljuk be 4 osztályba a rendelés mennyisége alapján. Jelenítsük meg ezt az információt is egy új oszlopban, az oszlop neve legyen 'Mennyiségi kategória'.** 
a.	A lista csak a 100 Ft feletti egységárú rendelési tételeket vegye figyelembe!
[Megoldás](Gy09_08.mp4)

(+/-) **Listázzuk a termékek kódját, megnevezését, kategóriájának nevét, és listaárát.** 
a.	A listát egészítsük ki két új oszloppal, amelyek a kategória legolcsóbb, illetve legdrágább termékének árát tartalmazzák. 
b.	A két új oszlop létrehozásánál partíciókkal dolgozzunk!
[Megoldás](Gy09_09.mp4)

(+/-) **Készítsünk listát a rendelésekről. A lista legyen rendezve ügyfelenként (LOGIN), azon belül a rendelés dátuma szerint. A listához készítsünk sorszámozást is. A sorszám a következő formában jelenjen meg: sorszám_év_login. Pl: 1_2015_adam1** 
a.	A számozás login-onként, azon belül rendelési évenként kezdődjön újra. 
b.	A sorszám oszlop neve legyen Azonosító.
[Megoldás](Gy09_10.mp4)

(+/-) Készítsünk listát a termékek adatairól listaár szerint növekvő sorrendben! A lista jelenítse meg két új oszlopban a sorrend szerint előző, illetve következő termék listaárát is a termék saját kategóriájában és raktárában! 
a.	Ahol nincs előző vagy következő érték, ott 0 jelenjen meg! 
b.	Az oszlopokat nevezzük el értelemszerűen!
[Megoldás](Gy09_11.mp4)

(+/-) Listázzuk a termékek kódját, nevét és listaárát listaár szerinti sorrendben! 
a.	Vegyünk fel egy új oszlopot Mozgóátlag néven, amely minden esetben az aktuális termék, az előző, és a következő termék átlagárát tartalmazza! 
b.	A mozgóátlagot kerekítsük két tizedesre!
[Megoldás](Gy09_12.mp4)

(+/-) Készítsünk listát, amely a rendelések sorszámát és a rendelés értékét tartalmazza. A listát egészítsük ki egy új oszloppal, amely minden rendelés esetén addigi rendelések összegét tartalmazza (az aktuálisat is beleértve)! 
a.	A listát rendezzük sorszám szerint növekvő sorrendbe. 
b.	A lista ne tartalmazzon duplikált sorokat! 
c.	Nevezzük el az oszlopokat értelemszerűen!
[Megoldás](Gy09_13.mp4)

(+/-) Készítsünk listát a termékek kódjáról, nevéről, kategória azonosítójáról, raktár azonosítójáról és listaáráról, valamint a termék adott szempontok szerinti rangsorokban elfoglalt helyezéseiről. (Szempontonként külön oszlopban, a helyezéseknél növekvő sorrendet feltételezve). A szempontok a következők legyenek: listaár, kategória szerinti listaár, és raktárkód szerinti listaár.
a.	Az oszlopokat nevezzük el értelemszerűen. 
b.	A helyezések egyenlőség esetén "sűrűn" kövessék egymást. 
c.	A lista legyen rendezett kategória azonosító, azon belül listaár szerint!
[Megoldás](Gy09_14.mp4)

(+/-) Készítsünk listát a rendelési tételekről, amely minden sor esetén göngyölítve tartalmazza az ügyfél adott rendelési tételig meglévő rendelési tételeinek összértékét! 
a.	Az új oszlop neve legyen Eddigi rendelési tételek összértéke! 
b.	Az ügyfél neve is jelenjen meg!
[Megoldás](Gy09_15.mp4)
