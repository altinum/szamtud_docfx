# Táblák összekapcsolása

Elméleti összefoglaló videó:
[gyak04-x264.mp4](gyak04-x264.mp4)
## Felvezető anyag: Egyen-összekapcsolás


Összekapcsolás segítségével több táblából kérdezhetünk le adatokat.
Tételezzük fel, hogy létezik az alábbi két tábla egy adatbázisban:

 
A `fiu` tábla tartalma:

ID|nev
----|------
1	|András
2	|Attila
3	|Albert

A `lany` tábla tartalma:

ID	|nev
----|------
1	|Bori
2	|Bea
3	|Barbara

Tekintsük az alábbi lekérdezést:
``` sql
SELECT fiu.nev, lany.nev FROM fiu, lany
```
A lekérdezés a két tábla direkt szorzatát képezi, azaz eredményül az összes létező fiu-lány párosítást kapjuk: 

fiu.nev|lany.nev
------|---------
András|	Bori
Attila|	Bori
Albert|	Bori
András|	Bea
Attila|	Bea
Albert|	Bea
András|	Barbara
Attila|	Barbara
Albert|	Barbara

> Ha több táblából kérdezünk le adatokat, a mezőnév elé írjuk ki a mezőhöz tartozó tábla nevét, pl. `fiu.nev`. Ha egy mezőnév a lekérdezésben szereplő táblák közül csak egyben fordul elő, a táblanév elhagyható. Az áttekinthetőség miatt mindenképpen érdemes megadni a táblanevet!

A következő példa kedvéért egészítsük ki a `fiu` táblát `feleseg` mezővel, ahol a fiú feleségének azonosítóját tároljuk, majd rendeljük hozzá a fiukhoz a lányokat.

A módosított `fiu` tábla tartalma:

ID	|nev	|feleseg
----|-------|-------
1	|András	|2
2	|Attila	|3
3	|Albert	|1

``` sql
SELECT fiu.nev, fiu.feleseg, lany.id, lany.nev FROM fiu, lany
```

A lekérdezés a következő eredményt adja:

fiuk.nev	|fiu.feleseg|lany. id	|lany.nev
------------|-------|---|-----------
András	    |2		|1	|Bori
Attila	    |3		|1	|Bori
Albert	    |1		|1	|Bori
András	    |2		|2	|Bea
Attila	    |3		|2	|Bea
Albert	    |1		|2	|Bea
András	    |2		|3	|Barbara
Attila	    |3		|3	|Barbara
Albert	    |1		|3	|Barbara

Ezek közül a sorok közül csak azok párok, ahol a `fiu.feleség` és a `lány.id` mező megegyeznek. Ha `WHERE` záradékban feltételként szabjuk a két mező azonosságát, csak a párokat adja eredményül a lekérdezés:
 ``` sql
SELECT fiu.nev, fiuk.feleseg, lany.id, lany.nev FROM fiu, lany 
WHERE fiu.feleseg = lany.id
```
fiu.nev|fiu.feleseg|lany .id|lany.nev
-|-|-|-
András|2|2|Bea
Attila|3|3|Barbara
Albert|1|1|Bori
A táblák kapcsolásához használt mezők ki is hagyhatók az eredményből, ha nincs szükségünk rá:

 ``` sql
SELECT fiu.nev, lany.nev FROM fiu, lany 
WHERE fiu.feleseg = lany.id
```
fiu.nev|lany.nev
-|-|
András|Bea
Attila|Barbara
Albert|Bori

> Fontos megjegyezni, hogy az eredményhalmazból kimaradnak azok a fiuk, akiknek nincs megadva a feleségük.

## Másodlagos táblanevek: aliasok

Az oszlopnevek táblanevekkel való minősítése meglehetősen sok időt vesz igénybe - főként,  ha a táblanevek hosszúak. A táblák neve helyett ilyenkor célszerűbb másodlagos táblaneveket használni. Ahogy az oszlop másodlagos neve más nevet ad az oszlopnak, a tábla másodlagos nevével is más néven hivatkozhatunk a táblára. Másodlagos táblanevek használatával
az SQL-kód sokkal rövidebbé tehető

``` sql
SELECT f.nev, l.nev FROM fiu AS f, lany AS l;
```

# Mintafeladat: társkereső

Készítsd el egy társkereső iroda nyilvántartását! A keretsztori a következő: az irodát emelt díjas vonalon keresztül hívhatják a magányűzésre vágyó ifjak és leányzók. A jelentkezők bediktálják saját adataikat, majd megadják az ideális partnerrel szemben támasztott követelményeket. Az operátor a fent említett adatokat adatbázisban rögzíti, majd gombnyomásra lekérdezheti az adatbázis alapján megfelelő párosításokat. 

Nyilvántartandó adatok:

- Név
- Életkor
- e-mail
- csillagjegy
- Ideális partner minimális életkora
- Ideális partner maximális életkora

> Tipp: érdemes a fiukat és a lányokat külön táblában rögzíteni, mert így a későbbiekben más paramétereket tudunk a fiukról és a lányokról nyilvántartani, valamint többtáblás lekérdezéssel könnyű az összeillő párokat leszűrni:
> ``` sql
> SELECT fiuk.nev, lanyok.nev FROM fiuk, lanyok WHERE …
> ```

`Fiu` tábla tartalma:
ID|nev	|email|	kor|p_kor_min|	p_kor_max
-|-|-|-|-|-
1	|András	||	25|	20	|25      |
2	|Attila	||	30|	25	|32      |

`Lány` tábla tartalma:
ID|nev	email	|kor|	P_kor_min|	p_kor_max
-|-|-|-|-|-
3|Bori		||100	|10|	30|
4|Barbara	||22|20|	26|

``` sql
SELECT
f.nev, l.nev FROM fiuk AS f, lanyok AS l 
WHERE
f.kor BETWEEN l.p_kor_min AND l.p_kor_max
AND
l.kor BETWEEN f.p_kor_min AND f.p_kor_max;
``` 

A lekérdezés a fenti táblákra eredményül egy párt ad:

f.nev|l.nev
-----|------
András|Barbara


Ha ezekkel megvagyunk, bővíthetjük az adatbázist: testmagasság, legmagasabb iskolai végzettség, stb.

TIPP: a legmagasabb iskolai végzettséget érdemes számmal jelölni, mert így értelmezhetők a `<=`, `>=` relációk. 

Extra feladat: Egészítsétek ki a rendszert úgy, hogy figyelembe vegye a zodiákus jegyek összeférhetetlenségeit is!

Tudományos szakirodalom egybehangzó véleménye: az azonos elemhez tartozó zodiákus jegyek harmóniában vannak egymással (120 fok).

Mindegyik kategóriába három csillagjegy tartozik:
Tüzes: Kos, Oroszlán, Nyilas.
Vizes: Rák, Skorpió, Halak.
Levegős: Ikrek, Mérleg, Vízöntő.
Földies: Bika, Szűz, Bak.

# Mintafeladat: tábla összekapcsolása saját magával

Oldjuk meg az előző társkeresős problémát úgy, hogy a fiukat és a lányokat egy táblában tároljuk!

Tételezzünk fel egy ‘tag’ táblát, mely az eddigi mezőkön felül tartalmaz egy ‘neme’ mezőt, melynek értéke lehet F vagy L.

Bizonyos esetben a táblát saját magával kell összekapcsolnunk. Ahhoz, hogy a táblában szereplőknek párt találjunk, a táblát önmagával kell összekapcsolni. Ebben az eljárásban kétszer használjuk fel ugyanazt a táblát.

``` sql
SELECT f.*, l.* FROM tag AS f, tag AS l WHERE f.neme<>l.neme …
```

# Mintafeladat: tanulmányi adatbázis


Feladat: készíts lekérdezést a TAO adatbázis teremfoglalásairól a tanár, az óra neve, a nap, a sáv és a terem feltüntetésével!

Todo: ADATB. ELÉRHETŐSÉGE

``` sql
SELECT 
Oktatók.Név, Tantárgyak.Tantárgynév, Sávok.Időpont, Napok.Nap, Termek.Terem, Órák.Ókód
FROM 
oktatók, tantárgyak, termek, sávok, napok, órák
WHERE 
oktatók.okód=órák.tanár 
AND
tantárgyak.tkód=órák.tantárgy
AND
Órák.terem=Termek.tkód
AND
órák.nap=napok.nkód
AND
sávok.Skód=órák.sáv;
```

Feladat: készíts lekérdezést az ütköző teremfoglalásokról!

``` sql
SELECT 
a.*,b.*
FROM órák a, órák b
WHERE
a.ókód<>b.ókód
AND
a.nap=b.nap
AND
a.sáv=b.sáv
AND
a.terem=b.terem;
```

 

# Táblák összekapcsolása JOIN művelettel

Mintafeladat: Készítsünk lekérdezést a tanulmányi adatbázis orak táblájából, mely tárgy szerinti ABC sorrendbe rendezi a rekordokat.

``` sql
SELECT  *  FROM Orak ORDER BY orak.targy
``` 
Eredmény: A sorba rendezés nem sikerült, mert az `orak` táblában a `targy` mezőben idegen kulcsok vannak. 


Megoldás: Feladatot egy olyan lekérdezéssel lehet megoldani, melyben mindkét tábla szerepel. Az előzőek alapján:

``` sql
SELECT  *  FROM orak, targy
WHERE orak.targy = targyak.tkód
``` 

A fenti megoldással ekvivalens eredményt ad a következő lekérdezés:

``` sql
SELECT * FROM orak INNER JOIN targy ON orak.targy=targyak.tkód
``` 

Az INNER JOIN használatára nézzünk egy másik példát! Listázzuk a dvd adatbázisból a filmek címeit és a nyelvüket, nyelv, majd cím szerinti abc sorrendben!

``` sql
SELECT  * FROM nyelvek INNER JOIN dvd ON nyelvek.nyelv_id = dvd.nyelv
ORDER BY nyelvek.nyelv, dvd.cim
``` 

A fenti lekérdezésből hiányoznak 
- azok a DVD-k, melyek melyeknél nincs kitöltve a `nyelv` mező, valamint
- azok a nyelvek, amilyen nyelvű DVD nincs a `dvd` táblában. 

JOIN-ok típusai:
-	INNER JOIN
-	LEFT JOIN
-	RIGHT JOIN (helyettesíthető left joinnal, ha a táblák nevét felcseréljük)
-	FULL JOIN


## Feladatok
A feladatok a *tanulmanyi* adatbázishoz készültek.  Készen elérhető a tanszéki kiszolgálón az alábbi kapcsolati adatokkal:

|              | |
|-             |-|
|Szerver       |bit.uni-corvinus.hu
|Felhasználónév|hallgato
|Jelszó        |Password123
|Adatbázis     |tanulmanyi

(+/-)1.	Jelenítsük meg az oktatók azonosítóját, titulusát és nevét! 
a.	A név két külön oszlopban jelenjen meg (vezetéknév és keresztnév– feltételezzük, hogy pontosan egy szóköz választja el őket). 
b.	A lista ne tartalmazza azokat a sorokat, ahol a titulus nincs megadva!

[Megoldás](Gy4_1.mp4)

(+/-)2.	Készítsünk listát arról, hogy melyik teremben hány óra van! 
a.	Jelenítsük meg a termek azonosítóit és a teremben tartott órák számát!
b.	Az oszlopokat nevezzük el értelemszerűen!
c.	Szűrjünk azokra a termekre, ahol az órák száma legalább 3!

[Megoldás](Gy4_2.mp4)

(+/-)3.	Készítsünk lekérdezést, amely megadja, hogy minimálian és maximálisan hány kreditet ér egy tantárgy!
a.	Az oszlopokat nevezzük el értelemszerűen!
b.	Ne vegyük figyelembe azokat a tantárgyakat, amelyek nevében az „alapjai” szó szerepel, vagy a tantárgy neve 10 karakternél rövidebb!

[Megoldás](Gy4_3.mp4)

(+/-)4.	Melyek azok a sávok, amelyek délután (12:00 után) vannak?
a.	Jelenítsük meg az adott sávok minden adatát!
ÖTLET: az időpontot alakítsuk át óra:perc formára, majd konvertáljuk át time típusra

[Megoldás](Gy4_4.mp4)

(+/-)5.	A tapasztalat alapján a tanársegédeknek 8, az óraadóknak 10 órájuk van egy héten. A többiek annyi órát tartanak, amennyi az elvárt óraszámuk. Készítsünk lekérdezést, amely minden beosztáshoz megjeleníti, hogy hetente hány túlóra tartozik hozzá!
a.	A lekérdezés csak a beosztások nevét és a heti túlórák számát jelenítse meg! 

[Megoldás](Gy4_5.mp4)

(+/-)**6.	Készítsünk listát arról, hogy melyik óra melyik teremben van!**
a.	Jelenítsük meg az óra azonosítóját és a terem nevét!
b.	A listát szűrjük a 3 karakter hosszú, [100;199] zárt intervallumba eső termekre!
Feltesszük, hogy a 3 karakter hosszú terem nevek csak számjegyeket tartalmaznak.

[Megoldás](Gy4_6.mp4)

(+/-)**7.	Hány óra van összesen az egyes napokon?**
a.	Jelenítsük meg a napok nevét és az órák számát az adott napon!
b.	Az oszlopokat nevezzük el értelemszerűen!
c.	A listát rendezzük óraszám szerint növekvő sorrendbe!

[Megoldás](Gy4_7.mp4)

(+/-)**8.	Melyek azok az oktatók, akiknek nincs órájuk?**
a.	Csak az oktatók neve jelenjen meg!
b.	ÖTLET: használjunk LEFT JOIN-t, és szűrjünk azokra a rekordokra, ahol NULL érték van a JOIN utáni feltétel jobb oldalán!

[Megoldás](Gy4_8.mp4)

(+/-)**9.	Készítsünk lekérdezést, amely részletesen megjeleníti az egyes órák fontosabb adatait, azaz**
a.	Az órák azonosítóit, a tanár nevét, a tantárgy nevét, a terem nevét és a kezdési időpontot!
b.	Az oszlopokat nevezzük el értelemszerűen!

[Megoldás](Gy4_9.mp4)

(+/-)**10.	Készítsünk listát arról, hogy melyik oktatónak hány órája van az Órák táblában!**
a.	A lista jelenítse meg az oktatók nevét, és az órák számát!
b.	Az oszlopokat nevezzük el értelemszerűen!
c.	A listából hagyjuk ki az óraadókat!

[Megoldás](Gy4_10.mp4)

(+/-)11.	Készítsünk listát, amely tartalmazza az egyes órák azonosítóit, és az órán oktatott tantárgy felelősének nevét!
a.	Rendezzük a listát a tantárgyfelelős neve szerint csökkenő sorrendbe!

[Megoldás](Gy4_11.mp4)

(+/-)12.	Van-e olyan tantárgy, amelyből nincs óra? 
a.	Jelentsük meg a tantárgy nevét és a tantárgyfelelős nevét!

[Megoldás](Gy4_12.mp4)

(+/-)13.	Készítsünk listát, amely megjeleníti, hogy az Orak táblában lévő órák közül hányat tart Dr., illetve nem Dr. titulusú tanár!
a.	Az oszlopokat nevezzük el értelemszerűen!

[Megoldás](Gy4_13.mp4)

(+/-)14.	Készítsünk listát arról, hogy beosztásonként hány óra szerepel az Orak táblában!
a.	Jelenítsük meg a beosztások nevét és az órák számát!
b.	A listát szűrjük azokra a beosztásokra, ahol ez az óraszám 10 feletti!

[Megoldás](Gy4_14.mp4)

(+/-)15.	Melyek azok az órák, amelyek kezdési időpontja olyan sávba esik, amely a mostani időpont (óra:perc) után van?
a.	Listázzuk az órák azonosítóit, valamint az órakezdés napját és időpontját!
b.	A listát rendezzük az időpont szerint növekvő sorrendbe!

[Megoldás](Gy4_15.mp4)
