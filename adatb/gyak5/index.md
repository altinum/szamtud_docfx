# Halmazműveletek

[Összefoglaló videó](gyak05_prez_x264.mp4)

Az alábbiakban ismertetésre kerül halmazműveletek két vagy több lekérdezéssel végeznek műveleteket. 

 - Általános szabály, hogy a lekérdezéseknek azonos szerkezetűeknek kell lenniük (oszlopok száma, sorrendje, típusa azonos, illetve kompatibilis).
 - Az oszlopok neveinek nem kell megegyezniük. Ha a halmazműveletekben résztvevő lekérdezések oszlopnevei nem egyformák, abban az esetben az eredményhalmaz oszlopainak nevei az első lekérdezés oszlopnevei lesznek
 - Amennyiben a halmazműveletek eredményének sorait rendezni szeretnénk, akkor a rendezést (ORDER BY) mindig a legutolsó lekérdezés végén kell definiálni A rendezésnél alias nevek is használhatók.
 - A halmazműveletek helyett többnyire van más megoldási lehetőség is (Pl: összetett WHERE –feltétel, JOIN)
 - Több halmazművelet esetén a kiértékelési sorrend:
	1. Zárójelben lévő műveletek
	2. Metszet
	3. Különbség és Unió (balról jobbra)



## Unió
Két vagy több lekérdezés eredménysorait fűzi össze egyetlen eredményhalmazzá.
A lekérdezéseknek azonos szerkezetűeknek kell lenniük (oszlopok száma, sorrendje, típusa azonos, illetve kompatibilis)
```sql
SELECT oszlopnevek
FROM ….
UNION (ALL)
SELECT oszlopnevek
FROM …
```
## Metszet
Két vagy több lekérdezés eredményhalmazainak közös sorait adja meg.
```sql
SELECT oszlopnevek
FROM ……
INTERSECT
SELECT oszlopnevek
FROM …….
```
## Különbség
Két lekérdezés különbsége azokat a sorokat adja vissza, amelyek az első lekérdezés eredményhalmazában benne vannak, de a másodikéban nincsenek.
```sql
SELECT oszlopnevek
FROM ……
EXCEPT
SELECT oszlopnevek
FROM …….
```
## Feladatok
A feladatok a *tanulmanyi* adatbázishoz készültek.  Készen elérhető a tanszéki kiszolgálón az alábbi kapcsolati adatokkal:

|              | |
|-             |-|
|Szerver       |bit.uni-corvinus.hu
|Felhasználónév|hallgato
|Jelszó        |Password123
|Adatbázis     |tanulmanyi

(+/-)Hány kreditet érnek átlagosan azok a tantárgyak, amelyek nevében az 'ürge' szó szerepel?
a.	Az átlag nem egész szám, ezért tizedes törtként jelenjen meg!
b.	Ha lehet, az eredmény ne tartalmazzon felesleges 0-kat a tizedes jegyek között!
c.	ÖTLET: konvertáljuk a kredit értékét float típusúvá

[Megoldás](Gy05_01.mp4)

(+/-)Hány óra van összesen a 120-as teremben?

[Megoldás](Gy05_02.mp4)

(+/-)Listázzuk, hogy melyik tanárnak hány órája van napi bontásban!
a. A lista jelenítse meg a tanár és a nap azonosítóját, valamint az óraszámot!
b.	A listából hagyjuk el azokat a sorokat, ahol ez az óraszám kisebb, mint 3!

[Megoldás](Gy05_03.mp4)

(+/-)Hány órájuk van a tanároknak státuszonkénti bontásban?
a.	Jelenítsük meg a státusz kódját, nevét és az óraszámot!

[Megoldás](Gy05_04.mp4)

(+/-)Listázzuk az egyes oktatók kódját és nevét, valamint egy új oszlopban, hogy az adott oktató tantárgyfelelős-e!
a.	Rendezzük a listát név szerint!
b.	Egy oktató neve és azonosítója csak egyszer jelenjen meg!

[Megoldás](Gy05_05.mp4)

**A 6.-10 feladatokat halmazműveletek segítségével megoldandóak!**

(+/-)**Jelenítsük meg azon tanárok azonosítóját és nevét, akik hétfői vagy keddi napokon tanítanak!**

[Megoldás](Gy05_06.mp4)

(+/-)**Melyek azok a tantárgyak, amelyek esetén van óra a 8.00-kor kezdődő sávban, de nincs a 12.30-kor kezdődő sávban?**

[Megoldás](Gy05_07.mp4)

(+/-)**Listázzuk azokat a termeket, amelyekben oktat Kovács László és van olyan tanóra a teremben, ahol a tantárgy nevében nem szerepel az 'ürge' szó!**
a.	A termeknél elég a nevet megjeleníteni.

[Megoldás](Gy05_08.mp4)

(+/-)**Készítsünk listát arról, hogy melyik tanárnak hány órája van a (munka) hét elején (hétfőn), hét közben (kedd, szerda és csütörtök), illetve a hét végén (péntek)!**
a.	Jelenítsük meg a tanár azonosítóját, nevét, az időszakot (hét eleje - hét közben - hét vége), valamint az óraszámot!
b.	A három megjelölt időszakot külön kérdezzük le, majd fűzzük össze a lekérdezések eredményeit!
c.	Rendezzük a listát az oktató neve, azon belül időszak szerint!

[Megoldás](Gy05_09.mp4)

(+/-)**Melyik napokon nincs órája Pelikán Józsefnek?**

[Megoldás](Gy05_10.mp4)

(+/-)*Készítsünk listát az oktatók adatairól!*
a.	Az oktatók titulusa és neve összefűzve jelenjen meg, közöttük szóközzel!
b.	Ha valakinek nincs titulusa, akkor csak a neve jelenjen meg, szóköz nélkül!
c.	A listát rendezzük a beosztás kódja, azon belül a státusz kódja szerint növekvő sorrendbe!
d.	Az oszlopokat nevezzük el értelemszerűen!

[Megoldás](Gy05_11.mp4)

(+/-)*Készítsünk listát, amely megmutatja, hogy összesen hány tantárgy van kreditenkénti csoportosításban!*
a.	A listából hagyjuk ki azokat a tételeket, ahol ez a darabszám 1!
b.	A Folyami gáttan tantárgyat ne vegyük figyelembe!
c.	A listát rendezzük darabszám szerint csökkenő sorrendbe!
d.	Az oszlopokat nevezzük el értelemszerűen!

[Megoldás](Gy05_12.mp4)

(+/-)*Készítsünk listát az oktatók nevéről, a beosztásuk alapján elvárt és a tényleges óraszámukról!*
a.	Az oszlopok neve legyen 'Oktató neve', 'Elvárt óraszám' és 'Tényleges óraszám'
b.	Szűrjük a listát azokra az oktatókra, ahol az elvárt és a tényleges óraszám azonos

[Megoldás](Gy05_13.mp4)

(+/-)*Készítsünk listát, amely megmutatja, hogy mely tantárgyból nincs óra egyáltalán!*
a.	Csak a tantárgy neve jelenjen meg!

[Megoldás](Gy05_14.mp4)

(+/-)*Hány órájuk van az óraadóknak napi bontásban?*
a.	Csak a napok nevét és az óraszámot jelenítsük meg!
b.	Rendezzük a listát óraszám szerint növekvő sorrendbe!

[Megoldás](Gy05_15.mp4)
