# 1. gyakorlat 


## Előkészületek

Indítsuk el az SQL Server Management Studio programot, és a bejelentkezéshez adjuk meg a következő adatokat! \
(Ha nem az egyetemen vagyunk, akkor a kapcsolódáshoz VPN-re lehet szükség!)

| Server type  |  Database Engine |
|---|---|
| Server name  |  bit.uni-corvinus.hu |
| Authentication  | SQL Server authentication  |
|  User name |  hallgato |
|  Password | Password123  |


# A gyakorlati feladatsor tartalma:
+ 1/1 Egyszerű lekérdezések, konstansok, operátorok (a és b feladatsorok)
+ 1/2 Összesítés és csoportosítás
+ 1/3 Táblák összekapcsolása
+ 1/4 Halmazműveletek - kiegészítő anyag


## 1/1 Egyszerű lekérdezések, konstansok, operátorok, függvények

### 1/1/a A következő feladatok megoldásához a DVD adatbázisra (az egyetemi szerveren dvd_magyar) lesz szükség

(+/-) Listázzuk a `kolcsonzes` tábla következő oszlopait: ID, ki_datum, vissza_datum! 

a.	Az ID oszlop neve legyen Azonosító
b.	A ki_datum oszlop neve legyen Kölcsönzés_dátuma
c.	A vissza_datum oszlop neve legyen Visszahozatal_dátuma

[Megoldás](../gyak01/Gy1_5.mp4)

(+/-)	Melyek a 12-es azonosítójú kölcsönzések adatai? 

a.	Csak a ki, mit, és ki_datum oszlopok jelenjenek meg

[Megoldás](../gyak01/Gy1_7.mp4)

(+/-)	Melyek azok a kölcsönzések, amelyek 2005.01.01 és 2007.01.01 között történtek?

[Megoldás](../gyak01/Gy1_8.mp4)

(+/-)	Melyek azok a kölcsönzések, ahol a kölcsönző az 1-es, 2-es, vagy a 3-as azonosítójú tag? 

a.	A kölcsönző tag azonosítója ne legyen benne az oszlopok listájában

[Megoldás](../gyak01/Gy1_9.mp4)

(+/-)	Melyek azok a tagok, akiknek kedvenc stílusa a játék, és nevük a-ra végződik?

a.	Csak a tagok neve jelenjen meg, az oszlop neve Név legyen

[Megoldás](../gyak01/Gy1_10.mp4)

(+/-)	Melyek azok a tagok, akik nevében nincs b betű, de címükben van? 

[Megoldás](../gyak01/Gy1_11.mp4)

(+/-)	Melyek azok a tagok, akiknek kedvenc nyelve 1, 2 vagy 5-ös azonosítójú?

[Megoldás](../gyak01/Gy1_12.mp4)

(+/-)	Mennyi lenne a dvd-k nettó ára, ha 20%-kal csökkenne? 

a.	Csak a dvd-k címét és a csökkentett árat jelenítsük meg
b.	A csökkentett árat nevezzük el diszkont_ar-nak

[Megoldás](../gyak01/Gy1_15.mp4)

(+/-)	Melyek azok a kölcsönzések, ahol még nem hozták vissza a dvd-t? 

[Megoldás](../gyak01/Gy1_18.mp4)

### 1/1/b A következő feladatok megoldásához a diákmunka adatbázisra lesz szükség
(+/-) Listázzuk azon diákok nevét és születési idejét, akik 1984-ben vagy 1985-ben születtek!	

a.	A születési dátum csak az évet, hónapot és a napot tartalmazza! 
b.	A születési dátum oszlopát nevezzük el 'Születési idő'-nek!

[Megoldás](../gyak02/Gy2_1.mp4)

(+/-) Készítsünk lekérdezést, amely a tanulók nevét és az ebből képzett felhasználói nevét tartalmazza. 

a.	A felhasználói név álljon a név első kettő, illetve utolsó kettő betűjének összefűzéséből!
b.	A listát szűrjük azon tanulókra, akik teljes neve - szóközzel együtt - legalább 10 betűs!

[Megoldás](../gyak02/Gy2_2.mp4)

(+/-) Készítsünk listát a diákok adatairól, ahol a diákok neve úgy jelenik meg, hogy először a keresztnév, majd a vezetéknév, közöttük szóközzel! 	
a.	Ezen felül a születési idő három külön oszlopban jelenjen meg (év, hónap, nap). 
b.	Az oszlopokat nevezzük el értelemszerűen!

[Megoldás](../gyak02/Gy2_3.mp4)


(+/-) Készítsünk listát a munkák azonosítójáról és megnevezéséről! Egy új oszlopban azt is jelenítsük meg, hogy melyik munka hetente mennyit fizet! 
a.	Az oszlop neve legyen Heti bér, az értéket kerekítsük 1000 forintra! 
b.	A listát szűrjük azon rekordokra, ahol a kerekített heti bér 10000 Ft felett van!

[Megoldás](../gyak02/Gy2_5.mp4)

(+/-) A diákok számára differenciált béremelést terveznek: a középiskolások esetében 33%, egyéb esetben 17% mértékben. Készítsünk listát, amely tartalmazza a munkák azonosítóját, az állás nevét, az eredeti óradíjat és a tervezett emelt óradíjat.

a.	Az oszlopoknak adjuk nevet értelemszerűen!
b.	Az emelt óradíj összegét kerekítsük egészre! (Az esetlegesen megjelenő 0 tizedesjegyekkel ne foglalkozzunk)

[Megoldás](../gyak02/Gy2_7.mp4)


(+/-) A diákok számára próbaidőt írnak elő, amely a munka kezdetétől számítva 3 hónapig tart.    Jelenítsük meg a munka tábla adatait egy új oszloppal kiegészítve, amelyik a próbaidő    végének dátumát mutatja!  

a.	Az oszlop neve Próbaidő vége legyen! 
b.	A lista ne tartalmazza azokat a munkákat, ahol a diákok azonosítója nincs megadva!

[Megoldás](../gyak02/Gy2_9.mp4)

(+/-) Készítsünk listát a diákok adatairól, amely egy új oszlopban azt is tartalmazza, hogy melyik diák
jelenleg (a mai nap) hány éves! Egy másik új oszlop jelenítse meg, hogy a diák 35 év alatti-e (Igen vagy Nem).

a.	Az oszlopokat nevezzük el értelemszerűen!
b.	A diákok neve két külön oszlopban jelenjen meg: vezetéknév és keresztnév, a vezetéknév csupa nagybetűs, a keresztnév csupa kisbetűs legyen!
c.	A listából hagyjuk ki a Péter keresztnevű diákokat!

[Megoldás](../gyak02/Gy2_11.mp4)

## 1/2 Összesítés és csoportosítás
###  A következő feladatok megoldásához a dvd (dvd_magyar) adatbázisra lesz szükség

(+/-) Jelenítsük meg, hogy összesen hány db történelem stílusú dvd van a dvd táblában! 

a.	Az oszlop neve legyen 'DB'! 
b.	Csak olyan dvd-ket vegyünk figyelembe, amelyeknek van címe!

[Megoldás](../gyak03/Gy3_1.mp4)


(+/-) Mennyi a dvd-k átlagos ára stílusonkénti bontásban?

a.   Csak azokat a stílusokat vegyük figyelembe, ahol az átlagos ár 4500 Ft feletti!
b.   Az oszlopokat nevezzük el értelemszerűen!
c.   A listát rendezzük átlagos ár szerint csökkenő sorrendbe!

[Megoldás](../gyak03/Gy3_3.mp4)


(+/-) Készítsünk listát, amely a kölcsönzések darabszámát listázza éves, azon belül havi bontásban! 
a.   Az oszlopokat nevezzük el értelemszerűen!
b.   Rendezzük a listát Év szerint növekvő sorrendbe!

[Megoldás](../gyak03/Gy3_5.mp4)

(+/-) Listázzuk nyelvenkénti, azon belül stílusonkénti bontásban, hogy mennyi a dvd-k legkisebb és legnagyobb ára! a.   Az oszlopok neve legyen 'Nyelv', 'Stílus', 'MinÁr' és 'MaxÁr'!

b.   A listából hagyjuk ki azokat a sorokat, ahol a nyelv vagy a stílus nincs megadva!
c.   Szintén hagyjuk ki azokat a csoportokat, ahol a csoport elemszáma 3-nál kisebb!

[Megoldás](../gyak03/Gy3_6.mp4)

(+/-) A kölcsönzéseket két csoportra oszthatjuk aszerint, hogy visszahozták-e már a dvd-t. Ez alapján készítsünk listát, amely megadja a kölcsönzés alatt lévő, illetve a már visszahozott dvd-k számát!

a.   Az oszlopok neve legyen 'Állapot' és 'DB'
b.   A listát rendezzük DB szerint növekvő sorrendbe!

[Megoldás](../gyak03/Gy3_7.mp4)

(+/-) Hány darab különböző című dvd van stílusonként? 
a.    Az oszlopok neve legyen 'Stílus' és 'Különböző című dvd-k száma'
b.    Csak azokat a dvd-ket számoljuk bele, amelyek stílusnevében a 'játék' szó benne van.

[Megoldás](../gyak03/Gy3_8.mp4)


(+/-) A kölcsönző tulajdonosa elhatározza, hogy ezentúl kerekebb árakat alkalmaz. Ezért minden dvd árát 1000 Ft-ra kerekíti. Készítsünk lekérdezést, amely megmutatja, hogy melyik 1000 Ft-ra kerekített ár szerint, azon belül stílus szerint hány db dvd összesen raktáron! 
a.   Csak olyan csoportokat listázzunk, ahol a raktárkészlet legalább 30!
b.   A listát rendezzük kerekített ár szerint, azon belül raktárkészlet szerint növekvő sorrendbe!

[Megoldás](../gyak03/Gy3_12.mp4)

(+/-) A dvd-ket csoportosíthatjuk aszerint, hogy milyen hosszú a címük. Amelyiknél a cím hosszúsága 10 karakter alatt van, az legyen Rövid, 10-20-ig Átlagos, 20 felett Hosszú. Hány Rövid, Átlagos, illetve Hosszú dvd-van összesen raktáron?

a.    Az oszlopok neve legyen 'Cím hosszúság' és 'Darabszám'

[Megoldás](../gyak03/Gy3_15.mp4)

## 1/3 Táblák összekapcsolása
###  A következő feladatok megoldásához a Tanulmányi adatbázisra lesz szükség


(+/-) Készítsünk listát arról, hogy melyik óra melyik teremben van!
a.	Jelenítsük meg az óra azonosítóját és a terem nevét!
b.	A listát szűrjük a 3 karakter hosszú, [100;199] zárt intervallumba eső termekre!
Feltesszük, hogy a 3 karakter hosszú terem nevek csak számjegyeket tartalmaznak.

[Megoldás](../gyak4/Gy4_6.mp4)

(+/-) Hány óra van összesen az egyes napokon?
a.	Jelenítsük meg a napok nevét és az órák számát az adott napon!
b.	Az oszlopokat nevezzük el értelemszerűen!
c.	A listát rendezzük óraszám szerint növekvő sorrendbe!

[Megoldás](../gyak4/Gy4_7.mp4)

(+/-) Melyek azok az oktatók, akiknek nincs órájuk?
a.	Csak az oktatók neve jelenjen meg!
b.	ÖTLET: használjunk LEFT JOIN-t, és szűrjünk azokra a rekordokra, ahol NULL érték van a JOIN utáni feltétel jobb oldalán!

[Megoldás](../gyak4/Gy4_8.mp4)

(+/-) 9.	Készítsünk lekérdezést, amely részletesen megjeleníti az egyes órák fontosabb adatait, azaz
a.	Az órák azonosítóit, a tanár nevét, a tantárgy nevét, a terem nevét és a kezdési időpontot!
b.	Az oszlopokat nevezzük el értelemszerűen!

[Megoldás](../gyak4/Gy4_9.mp4)

(+/-) Készítsünk listát arról, hogy melyik oktatónak hány órája van az Órák táblában!
a.	A lista jelenítse meg az oktatók nevét, és az órák számát!
b.	Az oszlopokat nevezzük el értelemszerűen!
c.	A listából hagyjuk ki az óraadókat!

[Megoldás](../gyak4/Gy4_10.mp4)

(+/-)  Készítsünk listát, amely tartalmazza az egyes órák azonosítóit, és az órán oktatott tantárgy felelősének nevét!
a.	Rendezzük a listát a tantárgyfelelős neve szerint csökkenő sorrendbe!

[Megoldás](../gyak4/Gy4_11.mp4)


(+/-) Készítsünk listát, amely megjeleníti, hogy az Orak táblában lévő órák közül hányat tart Dr., illetve nem Dr. titulusú tanár!
a.	Az oszlopokat nevezzük el értelemszerűen!

[Megoldás](../gyak4/Gy4_13.mp4)

(+/-) Készítsünk listát arról, hogy beosztásonként hány óra szerepel az Orak táblában!
a.	Jelenítsük meg a beosztások nevét és az órák számát!
b.	A listát szűrjük azokra a beosztásokra, ahol ez az óraszám 10 feletti!

[Megoldás](../gyak4/Gy4_14.mp4)

## 1/4 Halmazműveletek - kiegészítő anyag

### 1/4 A következő feladatok megoldásához a Tanulmányi adatbázisra lesz szükség

A következő feladatokat halmazműveletek segítségével oldjuk meg!

(+/-) Jelenítsük meg azon tanárok azonosítóját és nevét, akik hétfői vagy keddi napokon tanítanak!

[Megoldás](../gyak5/Gy05_06.mp4)

(+/-) Melyek azok a tantárgyak, amelyek esetén van óra a 8.00-kor kezdődő sávban, de nincs a 12.30-kor kezdődő sávban?

[Megoldás](../gyak5/Gy05_07.mp4)

(+/-) Listázzuk azokat a termeket, amelyekben oktat Kovács László és van olyan tanóra a teremben, ahol a tantárgy nevében nem szerepel az 'ürge' szó!
a.	A termeknél elég a nevet megjeleníteni.

[Megoldás](../gyak5/Gy05_08.mp4)

(+/-) Készítsünk listát arról, hogy melyik tanárnak hány órája van a (munka) hét elején (hétfőn), hét közben (kedd, szerda és csütörtök), illetve a hét végén (péntek)!
a.	Jelenítsük meg a tanár azonosítóját, nevét, az időszakot (hét eleje - hét közben - hét vége), valamint az óraszámot!
b.	A három megjelölt időszakot külön kérdezzük le, majd fűzzük össze a lekérdezések eredményeit!
c.	Rendezzük a listát az oktató neve, azon belül időszak szerint!

[Megoldás](../gyak5/Gy05_09.mp4)

(+/-) Melyik napokon nincs órája Pelikán Józsefnek?

[Megoldás](../gyak5/Gy05_10.mp4)












