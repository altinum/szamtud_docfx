# 1. gyakorlat – Egyszerű, egytáblás lekérdezések

## Előkészületek

- A gyakorlatvezető Azure-előfizetésének használata
-- VAGY --
- DVD adatbázis telepítése a dvd.sql script segítségével saját, Azure-ban létrehozott adatbázisba

A gyakorlathoz tartozó adatbázis az egyetemen kívülről csak VPN-en keresztül érhető el. 

|              | |
|-             |-|
|Szerver       |bit.uni-corvinus.hu
|Felhasználónév|hallgato
|Jelszó        |Password123
|Adatbázis     |dvd_magyar

**Adatbázis elérése Visual Studio-ból**

A Visual Studio rendelkezik egy *Server Explorer* panellel, mely egy olyan segédeszköz, mellyel projekttől függetlenül lehet SQL adatbázisokhoz csatlakozni. A panel a *View* menüből a *Server Exprlorer* menüpont kiválasztása után jelenik meg. (Nem összekeverendő az *SQL Server Object Explorer*rel.)

◯ A panelen a kis ikonra kattintval lehet csatlakozni egy új adatbázishoz.


◯ A megjelenő lehetőségek közül az **SQL Server**t kell választani. 

◯ A felugró ablakban meg kell adni az adatbázis eléréséhet szükséges adatokat a fenti táblázat szerint.
- Fontos, hogy az **Windows Authentication** helyett az **SQL Server Authentication**-t válaszd! A **Windows Authentication** Windows-ba történő bejelentkezéshez használt *credential*-öket használja az SQL szerver felé is, míg az  **SQL Server Authentication** az SQL szerverben felvett *login* és *jelszó* alapján végzi el az autentikációt.  
- Érdemes odafigyelni arra, hogy a szerver domain (sql.2rpi. hu) neve és a port (7000) `,` karakterrel vannak elválasztva, nem az URL-ben megszokott `:` használatos az elválasztásra. 

![](../../images/vs_sql_connect2.png)

◯ A megjelenő fában a **Tables**-t kinyitva láthatóvá válnak az adatbázis táblái, jobb egérgombbal kattintva bármelyik táblára a **New Query**  menüpont hozza elő azt a panelt, melyben az SQL mondatok futtathatók. (Teljesen mindegy, melyik táblán kattintasz, ugyanaz a lekérdezésszerkesztő panel jelenik meg.)

## ADATOK LEKÉRDEZÉSE – SELECT UTASÍTÁS 

### LEKÉRDEZÉSEK OSZLOPAINAK MEGVÁLTOZTATÁSA 
**Legegyszerűbb példa**

``` sql
SELECT 1+1
```
A `SELECT` kulcsszó után tetszőleges algebrai kifejezés megadható, a lekérdezés a kifejezés eredményét adja vissza. Ez nem egy tipikus felhasználási mód, de  a teljesség kedvéért érdemes megemlíteni.  

**A megjelenítendő oszlopok kiválasztása**
``` sql
SELECT * FROM dvd;
```
``` sql
SELECT cim, stilus FROM dvd;
```
A `SELECT` utasításrész után a megjelenítendő oszlopok nevei kerülnek egymástól vesszővel elválasztva, a * az összes oszlopot jelenti. A `FROM` utasításrész után adhatjuk meg a tábla nevét, melyből kérdezni akarunk. 

**Oszlopfejléc feliratának megváltoztatása**

``` sql
SELECT szam AS [Nyilvántartási szám], cim AS Filmcím FROM Dvd;
```

Ha egy elnevezés több szóból áll, szögletes zárójelbe kell tenni, különben az SQL szerver a második szót ismeretlen kifejezésnek értelmezi. Természetesen egyszavas oszlopnév körül is szerepeltethető szögletes zárójel. Ugyanez vonatkozik a mezőnevekre. A betűközzel tagolt mezőnevek használata nem javasolt, de nem tilos. A betűközzel tagolt mezőneveket mindenképpen szögletes zárójelbe kell tenni. 

**Számított oszlopértékek**

Magyar billentyűzetet használóknál gyakori hiba, hogy a numerikus billentyűzeten az SQL-ben használt tizedes pont helyett vesszőt ütnek. Az SQL a vesszőt felsorolások tagolására használja. Az aritmetikai műveletek közül használható a `+` `-` `*` `/` , hatványozás a `^` operátorral történik. 

``` sql
SELECT cim,nettoar AS [nettó ár], nettoar*1.25 AS [bruttó ár] FROM Dvd;
```
``` sql
SELECT cim,nettoar * (1+(1.27/100)) AS [bruttó ár] FROM Dvd;
```
``` sql
SELECT nev + ', ' + cim AS [Kölcsönző] FROM tagok;
```
Az `+` operátorral fűzhetünk össze szövegrészleteket illetve több értéket egy oszlopba.

**A kiválasztott sorok számának korlátozása, a WHERE záradék**

A kívánt sorokat a `WHERE` záradék használatával választhatjuk ki. A `WHERE` záradék a `FROM` záradékot követi.
Feltételek szöveg és feljegyzés típusú mezőkre

``` sql
SELECT  cim, stilus FROM dvd WHERE stilus='számítástechnika';
```
Karakterláncok
-	A lekérdezésben szereplő karakterláncokat aposztrófok (') közé foglaljuk.
-	A karakterláncokban a kis- és nagybetűk különbözőnek számíthatnak. 

**A LIKE operátor**

Előfordulhat, hogy nem ismerjük pontosan a keresendő értéket, illetve egy szövegben szereplő szövegrészletre keresünk. A mezőnév='valami' módszerrel csak teljes szövegegyezésre tudunk feltételt szabni. 

A 'LIKE' operátorral kiválaszthatjuk azokat a sorokat, amelyekben szereplő értékek megfelelnek egy karaktermintának.  A karaktermintának való megfelelést ellenőrző műveletet helyettesítő karakteres keresésnek is nevezzük. A behelyettesítéshez használt szimbólumok:

`_`  	- Egyetlen karaktert jelképez
`%` 	- Nulla vagy több tetszőleges karakter sorozatát jelképezi

``` sql
SELECT  cim, stilus FROM dvd WHERE Cim LIKE 'A%';
```
A fenti példa az A betűvel kezdődő címeket listázza ki. 
``` sql
SELECT  cim, stilus FROM dvd WHERE Cim LIKE '_z%';
```
A fenti példa azokat a sorokat adja eredményül, ahol a cím második karaktere z.
``` sql
SELECT  cim, stilus FROM dvd WHERE Cim LIKE '%kutya%';
```
Eredményül azokat a filmeket kapjuk, melyek címében szerepel a ‘kutya’ szó – előtte és utána tetszőleges karaktersorozattal. 

>A szövegműveletek az adatbázis alapértelmezett beállításai szerint nem tesznek különbséget a kis- és nagybetűk közözött. Az adatbázis létrehozásánál a **collation** beállítás adja meg, hogy legyen-e különbség a kis- és nagybetűk között, illetve mely nyelv szabályai szerint történjen a szövegek sorba rendezése. Pl. magyarban ...,o ,ó ,ö ,ő ,p, ...  vagy ...,s, sz, t, ...

**Az ESCAPE opció (nagyon haladóknak)**

Előfordulhat, hogy a `LIKE` operátorral  éppen`%` vagy `_` jelet szeretnénk kerestetni. Az `ESCAPE` opció után kijelölhetünk egy ún. escape karaktert. Az escape karakter után következő karaktert a LIKE hagyományos karakterként és nem vezérlőkarakterként értelmezi. 
``` sql
SELECT  cim, stilus FROM dvd WHERE Cim LIKE '%\_%' ESCAPE '\';
```
A fenti példa azon címeket listázza, melyekben szerepel az _ karakter. Magát az escape karaktert az escape karakter dupla leütésével érhetjük el: 

``` sql
…Cim LIKE ‘C:\\%’ ESCAPE ‘\’;
```
**Feltételek számot vagy pénznemet tartalmazó mezőkre**

A következő aritmetikai operátorokat használhatjuk: `<`, `>`, `=`, `<=`, `>=`, `<>`
``` sql
SELECT * FROM dvd WHERE nettoar>=3000
```
**Feltételek dátumot tartalmazó mezőkre**

Az SQL szerver többféle dátumtípust kezel. A minta adatbázisban szereplő `date` adattípus nem tartalmaz időadatot. 
A `getdate()` függvény mindig az aznapi dátumot adja vissza. Ha kivonunk belőle egy dátum típusú értéket, megkapjuk az eltelt időt:
``` sql
SELECT getdate()-ki_datum AS [Mióta kölcsönözve] FROM kolcsonzes
```
Az eredmény azonban nehezen olvasható, mert szintén dátumformátumban van, az 1900. január 1 óta eltelt napok számának megfelelően. Az eredményt alávethetjük típuskonverziónak, vagy használhatjuk a DATEDIFF függvényt. Ezekről később lesz szó.
Az SQL kifejezésekben szereplő dátumokat ' jelek közé kell tenni, és célszerű angol dátumformátumban megadni. 
``` sql
SELECT * FROM kolcsonzes WHERE ki_datum>='02/19/2000'
```
**Feltételek logikai típusú mezőkre**

A Microsoft SQL Server nem rendelkezik valódi (TRUE, FALSE) logikai adattípussal, erre a `bit`  (0,1) értékkészletű típus használatos.
-	igaz  	1
-	hamis 	0

Listázzuk a korhatáros filmeket:
``` sql
SELECT * FROM dvd WHERE korhatár=1
```
Listázzuk a nem korhatáros filmeket:
``` sql
SELECT * FROM dvd WHERE korhatár=0
```
**Kitöltetlen mezők keresése - `IS NULL` operátor**

Az `IS NULL` operátor `NULL` értékeket keres. A `NULL` érték olyan értéket jelöl, amely nem érhető  el, nem ismert, nincs megadva vagy nem értelmezhető. 
``` sql
SELECT  cim, stilus FROM dvd WHERE stilus IS NULL;
```
Eredményül azokat a sorokat kapjuk, akol a stílus mező nincs kitöltve. 

**Összetett feltételek - Logikai operátorok**

Az SQL nyelv három logikai operátor használatát támogatja: `AND`, `OR` és `NOT`

``` sql
SELECT cim, stilus FROM dvd WHERE stilus='számítástechnika' OR stilus='ismeretterjesztő';
```
``` sql
SELECT cim, stilus FROM dvd WHERE NOT stilus='számítástechnika';
```
A `WHERE` záradékban szereplő összetett feltételek rekordonként kerülnek kiértékelésre. Az SQL szerver végigmegy a `FROM` záradékban szereplő táblán, és rekordonként eldönti, hogy az adott rekord megfelel-e a `WHERE` záradékban megadott feltételeknek. 

**A teljesség kedvéért**
 
Az `AND` operátor igazságtáblázata
 ||TRUE|FALSE|NULL
-|-|-|-
TRUE|TRUE|FALSE|NULL
FALSE|FALSE|FALSE|FALSE
NULL|NULL|FALSE|NULL

 
Az `OR` operátor igazságtáblázata

 ||TRUE|FALSE|NULL
-|-|-|-
TRUE|TRUE|TRUE|TRUE
FALSE|TRUE|FALSE|NULL
NULL|TRUE|NULL|NULL

A `NOT` operátor igazságtáblázata

|TRUE|FALSE|NULL
-|-|-|-
|FALSE|TRUE|NULL
 

Vigyázzunk az `AND` művelet magasabb rendű, mint az `OR`! Vegyük példának a következő lekérdezést:
``` sql
SELECT * FROM magyarok WHERE 
Neme='lany' AND tulajdonsag='szép' OR tulajdonsag='Okos'
```
A lekérdezés eredményül nem a szép és okos lányokat adja eredményül, mert az AND magasabb rendű művelet, mint az OR. A feltételt következő rekordok elégítik ki:
- szép lányok
- nemtől függetlenül mindenki, aki okoks

A kívánt eredményt (szép és okos) megfelelő zárójelezéssel érhetjük el:
``` sql
SELECT * FROM magyarok WHERE 
Neme='lany' AND (tulajdonsag='szép' OR tulajdonsag='Okos')
```

**A BETWEEN .. AND**

A `BETWEEN` művelet használatával értéktartomány alapján szabhatunk feltételt.  A tartományt alsó és felső határértékével adhatjuk meg. A `BETWEEN` operátorral megadott határértékek beletartoznak a tartományba – zárt intervallumról beszélünk. Először az alsó határértéket kell megadnunk.

```sql
SELECT cim, nettoar FROM dvd WHERE nettoar BETWEEN 1000 AND 5000;
```
Használata kiváltható egy összetett lekérdezéssel:
```sql
SELECT cim, nettoar FROM dvd WHERE nettoar>=1000 AND nettoar<=5000;
```
**Az IN operáror**

```sql
SELECT cim, stilus  FROM dvd WHERE stilus IN ('ismeretterjesztő', 'számítástechnika');
```
A `WHERE` záradékban lévő feltétel azoknál a rekordoknál teljesül, ahol a stílus mező értéke szerepel az IN utáni felsorolásban. 

Még két példa:
```sql
SELECT  cim, stilus FROM dvd WHERE stílus='számítástechnika' OR stílus='ismeretterjesztő' 
```
```sql
SELECT  cim, stilus FROM dvd WHERE NOT (stílus='számítástechnika' OR stílus='ismeretterjesztő')
```
**A DISTINCT predikátum**

A `DISTINCT` kihagyja eredményül kapott táblából az ismétlődő sorokat. A dvd táblában például több filmnek lehet azonos a stílusa. Ha a ‘rajzfilm’ két rekord stílus mezőjében szerepel, akkor a következő SQL-utasítás csak az egyik rekordot adja vissza: 

```sql
SELECT DISTINCT stilus FROM dvd;
```

A DISTINCT predikátumot használó lekérdezés eredménye nem frissíthető.


## Gyakorló feladatok
### Mezők listázása
(+/-) Mennyi 6*8?

[Megoldás](Gy1_1.mp4)

(+/-) Listázd az összes mezőt a `dvd` táblából 

[Megoldás](Gy1_2.mp4)

(+/-) Listázd a `cim` mező tartalmát a `dvd` táblából! 

[Megoldás](Gy1_3.mp4)

(+/-) Listázd a `cim` és a  `stilus` mező tartalmát a `dvd` táblából! 

[Megoldás](Gy1_4.mp4) 

(+/-) Listázzuk a `kolcsonzes` tábla következő oszlopait: ID, ki_datum, vissza_datum! 

a.	Az ID oszlop neve legyen Azonosító
b.	A ki_datum oszlop neve legyen Kölcsönzés_dátuma
c.	A vissza_datum oszlop neve legyen Visszahozatal_dátuma

[Megoldás](Gy1_5.mp4)

(+/-) Listázd az 4000 forintnál drágább filmeket! (A táblázatban az árak forintban szerepelnek.) 

a. Listázd az 5000 forintnál olcsóbb filmeket! 
b. Listázd az 5000 forintnál olcsóbb, de 4000 forintnál drágább filmeket! 

[Megoldás](Gy1_6.mp4)

(+/-)	Melyek a 12-es azonosítójú kölcsönzések adatai? 

a.	Csak a ki, mit, és ki_datum oszlopok jelenjenek meg

[Megoldás](Gy1_7.mp4)

(+/-)	**Melyek azok a kölcsönzések, amelyek 2005.01.01 és 2007.01.01 között történtek?** 

[Megoldás](Gy1_8.mp4)

(+/-)	Melyek azok a kölcsönzések, ahol a kölcsönző az 1-es, 2-es, vagy a 3-as azonosítójú tag? 

a.	A kölcsönző tag azonosítója ne legyen benne az oszlopok listájában

[Megoldás](Gy1_9.mp4)

(+/-)	**Melyek azok a tagok, akiknek kedvenc stílusa a játék, és nevük a-ra végződik?**

a.	Csak a tagok neve jelenjen meg, az oszlop neve Név legyen

[Megoldás](Gy1_10.mp4)

(+/-)	Melyek azok a tagok, akik nevében nincs b betű, de címükben van? 

[Megoldás](Gy1_11.mp4)

(+/-)	**Melyek azok a tagok, akiknek kedvenc nyelve 1, 2 vagy 5-ös azonosítójú?** 

[Megoldás](Gy1_12.mp4)

(+/-)	Melyek azok a dvd-k, amelyek nem magyar nyelvűek? 

Megjegyzés: itt most két lekérdezés kell, először meg kell keresni a magyar nyelv kódját, majd leszűrni a dvd táblát. Később majd meg tudjuk oldani egyben is. 

[Megoldás](Gy1_13.mp4)

(+/-)	**Listázzuk egy oszlopban a tagok nevét, címét és kedvenc stílusát összefűzve!** 

a.	A nevet, címet és a stílust kötőjellel válasszuk el
b.	A kötőjelek előtt és után legyen 1-1 szóköz
c.	Az oszlop neve legyen TAG
d.	Kinga keresztnevű tagok ne legyenek benne a listában

[Megoldás](Gy1_14.mp4)

(+/-)	Mennyi lenne a dvd-k nettó ára, ha 20%-kal csökkenne? 

a.	Csak a dvd-k címét és a csökkentett árat jelenítsük meg
b.	A csökkentett árat nevezzük el diszkont_ar-nak

	[Megoldás](Gy1_15.mp4)

(+/-)	**Vannak-e bizonyos ellentmondások a kolcsonzesek táblában? (ugyanazon tag ugyanazt a konyvet ugyanazon nap többször is kivette)?** 

a.	Listázzuk a szükséges oszlopokat
b.	Adjuk ki ugyanazt a lekérdezést DISTINCT kulcsszóval is
c.	Hasonlítsuk össze a 2 eredményhalmazt, egyformák-e?

[Megoldás](Gy1_16.mp4)

(+/-)	Van-e olyan dvd, amely orosz nyelvű?

[Megoldás](Gy1_17.mp4)

a.	Először keresse meg a nyelvek táblában az orosz nyelv azonosítóját
b.	Majd szűrje le az adott nyelv azonosítójú dvd-ket

(+/-)	Melyek azok a kölcsönzések, ahol még nem hozták vissza a dvd-t? 

[Megoldás](Gy1_18.mp4)

(+/-) Melyek azok a kölcsönzések, ahol a dvd-t már visszahozták, vagy nem hozták vissza, és a 3-as vagy 4-es azonosítójú tag vette ki? 

Megjegyzés: a logikai *AND* magasabb rendű művelet, mint az *OR*. Erre érdemes odafigyelni a zárójelezésnél!

[Megoldás](Gy1_19.mp4)

(+/-) Listázd a filmeket cím abc szerinti sorrendben! 

[Megoldás](Gy1_20.mp4)

(+/-) Az előző lekérdezést bővíts úgy, hogy a film címe mellett a stílus is szerepeljen zárójelben. Az oszlopot nevezd is el. 

[Megoldás](Gy1_21.mp4)

(+/-) Listázd azokat a filmeket, melyek címében szerepel az „angol” vagy a „példatár” szavak valamelyike! 

[Megoldás](Gy1_22.mp4)

(+/-) Listázd a filmek címét úgy, hogy a cím után, vele egy mezőben, zárójelek között szerepeljen az ára áfával! 

[Megoldás](Gy1_23.mp4)
