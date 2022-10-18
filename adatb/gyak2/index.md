# 2. gyakorlat – Egyszerű, kifejezések, függvények

## Összefoglaló videó
[gyak02_1_x264.mp4](gyak02_1_x264.mp4)

## Előkészületek

Diakmunka adatbázis telepítése a Moodle oldalon található diakmunka.sql script segítségével
-- Vagy --
Ha technikai okokból a saját adatbázis nem érhető el, csatlakozás a tanszéki kiszolgálóra

|              | |
|-             |-|
|Szerver       |bit.uni-corvinus.hu
|Felhasználónév|hallgato
|Jelszó        |Password123
|Adatbázis     |diakmunka

Válasszuk ki a diakmunka adatbázist!


## Elmélet

### Kifejezések
A kifejezések mindig egy, azaz 1 értéket adnak vissza. Az **egyszerű** kifejezések változókat, oszlopneveket és függvényeket tartalmazhatnak. Az **összetett** kifejezések operátorokat is tartalmaznak.

#### Feltételes kifejezés: CASE
Az egyszerű CASE kifejezés összehasonlít egy kifejezést egyszerű kifejezések halmazával az eredmény meghatározásához.
```sql
CASE kifejezés  --a vizsgált kifejezés
WHEN érték_1 THEN kifejezés_1   --ha a kifejezés értéke érték_1, akkor az eredmény kifejezés_1
WHEN érték_2 THEN kifejezés_2   
…
WHEN érték_n THEN kifejezés_n
[ELSE kifejezés_e] END  --ha a kifejezés értéke egyik megadottal sem egyezik meg, az eredmény kifejezés_e
```

Az úgynevezett searched CASE kifejezés logikai kifejezések halmazát értékeli ki az eredmény meghatározásához.

```sql
CASE
WHEN feltétel_1 THEN kifejezés_1  --ha feltétel_1 igaz, akkor az eredmény kifejezés_1
WHEN feltétel_2 THEN kifejezés_2
…
WHEN feltétel_n THEN kifejezés_n
[ELSE kifejezés_e]  --ha egyik kifejezés sem igaz, az eredmény kifejezés_e
END
```
- Ha nincs megadva ELSE ág, az eredmény NULL (lásd később).
- NE felejtkezzünk el a záró END-ről, ami a kifejezés szerves része
- CASE kifejezést ugyanúgy nevezünk el, mint bármely más oszlopot, de használatos az egyenlőségjeles forma is:

```sql
--Adjunk meg három árkategóriát a DVD-k számára!
Select árkategória = CASE WHEN nettoar > 1500 THEN 'drága' WHEN nettoar < 500 THEN 'olcsó'  ELSE 'reális' END from dvd
Select CASE WHEN nettoar > 1500 THEN 'drága' WHEN nettoar < 500 THEN 'olcsó'  ELSE 'reális' END as árkategória from dvd
```

#### Konstansok
A konstansok olyan szimbólumok, amelyek valamilyen adat értékét ábrázolják. Az ábrázolás módja az adat típusától függ. Gyakoribb típusokat és ábrázolási formákat tartalmaz az alábbi táblázat.

|     Konstans                         |     Típus                                                                     |     Példa                                                    |
|--------------------------------------|-------------------------------------------------------------------------------|--------------------------------------------------------------|
|     Szöveges konstans                |     varchar(x)     (x: a szöveg max. hossza)                                  |     'Budapest'                                               |
|     Unicode szöveges     konstans    |     nvarchar(x)     (x: a szöveg   max. hossza)                               |     N'Budapest'                                              |
|     Egész konstans                   |     int                                                                       |     25                                                       |
|     Bit konstans                     |     bit                                                                       |     1                                                        |
|     Decimális konstans               |     decimal(x, y)     (x: a számjegyek száma,    y: a tizedesjegyek száma)    |     12.45                                                    |
|     Dátum/Idő konstans               |     date,    datetime,  time                                                  |     '2012.01.15' ,    '2020.02.11 22:11:33',     '06:12:10'    |

#### Operátorok
Az operátorok egy vagy több kifejezésen értelmezett szimbólumok („műveletek”)  A gyakoribb operátor típusok és operátorokat az alábbi táblázat foglalja össze.

|     Típus                        |     Operátorok             |     Megjegyzés                                                                                                                                 |
|----------------------------------|----------------------------|------------------------------------------------------------------------------------------------------------------------------------------------|
|     Aritmetikai operátorok       |     +, -, *, /, %          |     %: az egész osztás maradéka                                                                                                                |
|     Logikai operátorok           |     NOT, AND, OR           |                                                                                                                                                |
|     Összehasonlító operátorok    |     <, >, =, <>, >=, <=    |                                                                                                                                                |
|     Szöveg operátorok            |     +                |     szövegek összefűzése   |
|     Szöveg operátorok (LIKE)           |     %, _           |%: helyettesítő operátor (egy vagy több  karakter vagy üres)<br />_: helyettesítő operátor (egy karakter)  |                                                                                                                 

#### Függvények
A paramétereken végzett műveletek eredményét adják vissza egy vagy több érték formájában. Számos **beépített függvény** létezik, illetve **felhasználó általi létrehozás** is lehetséges (user function).

A beépített függvények típusait foglalja össze az alábbi táblázat:

| Típus                 | Példa                        |
|-----------------------|------------------------------|
| Aggregáló függvények  | SUM(), MIN(), MAX()          |
| Analitikus függvények | LAG(), LEAD(), FIRST_VALUE() |
| Rangsor függvények    | RANK(), NTILE()              |
| Rowset függvények     | OPENROWSET()                 |
| Skalár függvények     | YEAR(), LEFT(), ROUND()      |
| Egyéb függvények      | ISNULL()                     |

Az aggregáló, analitikus, rangsor és rowset függvényekkel később foglalkozunk.

###### Fontosabb matematikai függvények

|     Függvény       |     Kötelező paraméterek                                                                              |     Funkció                                    |
|--------------------|-------------------------------------------------------------------------------------------------------|------------------------------------------------|
|     POWER(x, y)    |     x: a hatványalap  y: a kitevő     (mindkettő numerikus   kifejezés)                               |     Hatványozás adott kitevőre                 |
|     SQRT(x)        |     x: numerikus   kifejezés                                                                          |     A szám négyzetgyökének     számítása       |
|     ROUND(x, y)    |     x:   a kerekítendő valós szám  y: a kerekítés pontossága     (mindkettő numerikus   kifejezés)    |     Adott pontosságú kerekítés                 |
|     ABS()          |     x: numerikus kifejezés                                                                            |     Az adott szám  abszolútértékét adja meg    |

**Példák**
```sql
SELECT POWER(3, 5)
SELECT SQRT(2020)
SELECT ABS(-210.3)
SELECT ROUND(32.332, 1)
SELECT ROUND(322, -2)
SELECT ROUND(232.2, 0)
```

##### Fontosabb dátum/Idő függvények

|     Függvény                       |     Kötelező paraméterek                                                                                                              |     Funkció                                                                              |
|------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------|
|     GETDATE()                      |     --                                                                                                                                |     Az aktuális rendszeridőt adja   vissza                                               |
|     DAY(d)    MONTH(d)  YEAR(d)    |     d: dátum kifejezés                                                                                                                |     Az adott dátumhoz tartozó nap, hónap  sorszámát, illetve az évszámot adja  vissza    |
|     DATEADD(x, y, z)               |     x: a hozzáadandó  dátumegység (day, week,    month, year stb.)     y: a hozzáadandó egységek    száma     z: dátum   kifejezés    |     Adott dátumhoz   ad hozzá adott számú     napot, hetet, hónapot stb.                 |
|     DATEDIFF(x, y, z)              |     x: dátumegység neve     y: start dátum, z: vég dátum                                                                              |     A két dátum   között lévő dátumegységek     számát adja meg                          |

**Példák**
```sql
SELECT GETDATE()
SELECT MONTH(GETDATE())
SELECT DATEADD(year, -1, GETDATE())
SELECT DATEDIFF(day, ’2019.01.01’, GETDATE())
```

##### Fontosabb szöveg függvények

|     Függvény                     |     Kötelező paraméterek                                     |     Funkció                                                                                                                               |
|----------------------------------|--------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------|
|     LEN(x)                       |     x: szöveg (string)                                       |     A szöveg hosszát adja meg  karakterekben                                                                                              |
|     LEFT(x,   y)  RIGHT(x, y)    |     x:   szöveg (string)  y: egész kifejezés                 |     Az adott   szövegből balról, illetve  jobbról levág adott számú karaktert                                                             |
|     LOWER(x)  UPPER(x)           |     x: szöveg                                                |     A szöveget csupa kis-, illetve    nagybetűssé alakítja                                                                                |
|     CHARINDEX(x, y)              |     x: a keresett szöveg  y: a szöveg, amelyben  keresünk    |     A keresett szöveg első  előfordulásának pozícióját adja meg.  Ha a keresett szöveg nem található,    0 lesz   a visszaadott érték.    |

**Példák**
```sql
SELECT LEN('Budapest')
SELECT LEFT('Kiss Béla',4)
SELECT LOWER('Nagy Laci')
SELECT UPPER('Nagy Laci')
SELECT CHARINDEX('al', ' Dalma')
```

##### Konverziós függvények

A konverziós függvények használatára gyakran lehet szükség, például egy szöveg számmal való össszefűzésénél a számérték szöveggé konvertálása elengedhetetlen.

|     Függvény         |     Kötelező paraméterek           |     Funkció                                |
|----------------------|------------------------------------|--------------------------------------------|
|     CAST(x AS y)     |     x: kifejezés<br />    y: típusnév    |     Az x kifejezést y típusúra alakítja    |
|     CONVERT(x, y, [, s])    |     x:   típusnév<br />  y: kifejezés <br /> s: formátumkód    |     Az y kifejezést x típusúra alakítja, a formátum opcionális    |

A CAST szabványos, ezért gyakrabban használt. 
A CONVERT függvény rendelkezik egy opcionális paraméterrel, amellyel formátumot is lehet beállítani, amely szükséges lehet például lebegőpontos számok, dátumok kívánt formátumának beállításához. A CONVERT a gyakorlati feladatokban nem fordul elő.

**Példák**
```sql
--Fűzzük össze a dvd-k nevét és ID-ját egy szóközzel megszakítva!
select cim + ' ' + cast(ID as varchar) from dvd
--Írjuk ki az aktuális rendszeridőt ÉÉÉÉ.HH.NN formátumban!
--select CONVERT(VARCHAR, getdate(), 102)

--További példák
SELECT CIM + ' ' + CAST(ID AS VARCHAR) FROM DVD
SELECT CAST(GETDATE() AS DATE)
SELECT CAST('14.55' AS DECIMAL(5,2))
SELECT CONVERT(INT, 5.32)
SELECT CONVERT(VARCHAR(10), GETDATE(), 111)
```



##### A NULL érték, az IS NULL, az IS NOT NULL és az ISNULL()
Amennyiben egy adott oszlop definíciója lehetővé teszi (erről később), előfordulhat, hogy bizonyos, vagy akár az összes sorban nincsen megadott érték, ezt jelzi az eredményhalmazban a NULL. Az érték hiánya nem összekeverendő az üres értékkel, és kezelése is speciális.

NULL értékre való egyezőséget nem egyenlőségjellel, hanem az IS NULL szerkezettel vizsgálunk, ellentettje az IS NOT NULL.
```sql
--Listázzuk, mely DVD-k esetében nincs megadva stílus! A stílus hiányát az oszlop kitöltetlensége jelzi.
select * from DVD where stilus IS NULL  //a STILUS=NULL feltétel üres eredményhalmazra vezet, próbáljuk ki!
--Listázzuk, mely DVD-k esetében van megadva stílus! A stílus hiányát az oszlop kitöltetlensége jelzi.
select * from DVD where stilus IS NOT NULL  //a STILUS<>NULL feltétel üres eredményhalmazra vezet, próbáljuk ki!
```

Az ISNULL függvény segítségével a NULL értékeket helyettesíthetjük vegy értékkel. 
Ezzel egyrészt már végezhetünk egyenlőségvizsgálatot:
```sql
/*Listázzuk, mely DVD-k esetében nincs megadva stílus! 
A stílus hiányát az oszlop kitöltetlensége vagy üres karakterlánccal való kitöltöttége jelzi.*/
select * from DVD where ISNULL(stilus,'')=''
```
Másrészt  elkerülhetjük, hogy az eredményalmazban NULL értékek jelenjenek meg
```sql
/*Listázzuk a címmel rendelkező DVD-kt stílusukkal együtt. 
Ha nincs megadva stílus, "<nincs megadva>" szöveg szerepeljen!*/
select cim, isnull(stilus, '<nincs megadva>') as stilus from dvd 
--a függvényhívás okán a második oszlop neve az eredményhalmazban nem lesz megadva, ezért el is nevezzük
where cim is not null  -- használhatnánk az isnull(cim, '')='' formát is
```

**Példák**
```sql
SELECT ISNULL(nettóár, 0)
SELECT ISNULL(vezetéknév, ' ')
```

##### Az IIF függvény
Az IIF függvény segítségével egyszerűsített elágazást fogalmazhatunk meg. Formája: `IIF(x,y,z)` ahol `x` logikai kifejezés, `y` az eredmény ha igaz, `z` ha  hamis.
```sql
/*Listázzuk a kolcsonzesek tábla tartalmát! Egy külön oszlopban jelenítsük meg, 
hogy az adott kölcsönzés esetében visszahozták-e már a kazettát (igen/nem)!*/
SELECT *, iif(vissza_datum is not null, 'igen', 'nem') as [visszahozta?] from kolcsonzesek

/*Vizsgáljuk meg, hogy egy tábla mobilszam oszlopában a megadott karakterlánc 9 karakter hosszú-e. 
Jelenítsük meg a vizsgálat eredményét egy oszlopban (OK/Nem OK).*/
SELECT IIF(LEN(mobilszam)=9, 'OK', 'Nem OK ') from tábla
```

Fontos megjegyezni, hogy az `IIF()` függvény nem minden SQL implementációban érhető el.



##  FELADATOK 
(+/-) Listázzuk azon diákok nevét és születési idejét, akik 1984-ben vagy 1985-ben születtek!	

a.	A születési dátum csak az évet, hónapot és a napot tartalmazza! 
b.	A születési dátum oszlopát nevezzük el 'Születési idő'-nek!

[Megoldás](Gy2_1.mp4)

(+/-) Készítsünk lekérdezést, amely a tanulók nevét és az ebből képzett felhasználói nevét tartalmazza. 

a.	A felhasználói név álljon a név első kettő, illetve utolsó kettő betűjének összefűzéséből!
b.	A listát szűrjük azon tanulókra, akik teljes neve - szóközzel együtt - legalább 10 betűs!

[Megoldás](Gy2_2.mp4)

(+/-) Készítsünk listát a diákok adatairól, ahol a diákok neve úgy jelenik meg, hogy először a keresztnév, majd a vezetéknév, közöttük szóközzel! 	
a.	Ezen felül a születési idő három külön oszlopban jelenjen meg (év, hónap, nap). 
b.	Az oszlopokat nevezzük el értelemszerűen!

[Megoldás](Gy2_3.mp4)

(+/-) Készítsünk listát a munkaadókról, amely a munkahely azonosítója mellett egy másik oszlopban a település nevét jeleníti meg, majd kettősponttal és szóközzel elválasztva a munkaadó nevét, pl: Cseprűfalva: Bicaj Futárszolgálat. 

a.	Az oszlop neve legyen 'Munkahely'. 
b.	Ne jelenjenek meg azok a munkaadók, akiknek a nevében a 'Kávé' szó benne van!

[Megoldás](Gy2_4.mp4)

(+/-) Készítsünk listát a munkák azonosítójáról és megnevezéséről! Egy új oszlopban azt is jelenítsük meg, hogy melyik munka hetente mennyit fizet! 
a.	Az oszlop neve legyen Heti bér, az értéket kerekítsük 1000 forintra! 
b.	A listát szűrjük azon rekordokra, ahol a kerekített heti bér 10000 Ft felett van!

[Megoldás](Gy2_5.mp4)

(+/-) Készítsünk lekérdezést, amely listázza azon munkaadók nevét, akik Szombati településen vannak! 

a.	A munkaadó neve csupa nagybetűvel jelenjen meg!
b.	Egy új oszlopban jelenítsük meg a munkaadó nevének második részét 'Cégforma' néven!

[Megoldás](Gy2_6.mp4)

(+/-) A diákok számára differenciált béremelést terveznek: a középiskolások esetében 33%, egyéb esetben 17% mértékben. Készítsünk listát, amely tartalmazza a munkák azonosítóját, az állás nevét, az eredeti óradíjat és a tervezett emelt óradíjat.

a.	Az oszlopoknak adjuk nevet értelemszerűen!
b.	Az emelt óradíj összegét kerekítsük egészre! (Az esetlegesen megjelenő 0 tizedesjegyekkel ne foglalkozzunk)

[Megoldás](Gy2_7.mp4)

(+/-) Egy másik terv szerint a 4 órában dolgozó diákok egységesen 100 Ft, az 5 órában dolgozók 150 Ft, a többiek 200 Ft emelést kapnak óránként.

a.	A listából maradjanak ki a takarítók! (ők már korábban kaptak emelést).
b.	Jelenítsük meg a munkák azonosítóját, az állás nevét, óraszámát, és az óradíj emelés előtti és utáni összegét!
c.	Az oszlopoknak adjunk nevet értelemszerűen!

[Megoldás](Gy2_8.mp4)

(+/-) A diákok számára próbaidőt írnak elő, amely a munka kezdetétől számítva 3 hónapig tart.    Jelenítsük meg a munka tábla adatait egy új oszloppal kiegészítve, amelyik a próbaidő    végének dátumát mutatja!  

a.	Az oszlop neve Próbaidő vége legyen! 
b.	A lista ne tartalmazza azokat a munkákat, ahol a diákok azonosítója nincs megadva!

[Megoldás](Gy2_9.mp4)

(+/-) Egy vezetői döntés szerint a munkák kezdetét mindig az adott hónap elsejétől kell számítani.Készítsünk lekérdezést, amely megjeleníti a munka tábla munkaId, allas és datum oszlopait, valamint egy új oszlopot 'Kezdő dátum' néven. Ez mindig azt a napot jelenítse meg, amikor a munka megkezdhető.

a.	A döntés nem vonatkozik azokra, akik napi keresete 1500 Ft alatt van, őket   hagyjuk ki a listából!
b.	ÖTLET: az időszámítás kezdő dátumához (aminek értéke 0) adjunk hozzá annyi hónapot, amely a datum oszlop értékéig eltelt
c.	ÖTLET2: vágjuk le a dátum végéről a napot, majd tegyük hozzá az elsejét, utána konvertáljuk át dátummá

[Megoldás](Gy2_10.mp4)

(+/-) Készítsünk listát a diákok adatairól, amely egy új oszlopban azt is tartalmazza, hogy melyik diák
jelenleg (a mai nap) hány éves! Egy másik új oszlop jelenítse meg, hogy a diák 35 év alatti-e (Igen vagy Nem).

a.	Az oszlopokat nevezzük el értelemszerűen!
b.	A diákok neve két külön oszlopban jelenjen meg: vezetéknév és keresztnév, a vezetéknév csupa nagybetűs, a keresztnév csupa kisbetűs legyen!
c.	A listából hagyjuk ki a Péter keresztnevű diákokat!

[Megoldás](Gy2_11.mp4)

(+/-) Készítsünk listát a munkák azonosítójáról, megnevezéséről és az óraszámáról! Egy új oszlopban jelenítsük meg, hogy a munka kezdő dátuma tavaszra, nyárra, őszre, vagy télre esik-e! 

a.	Az oszlop neve legyen 'Idény'. 
b.	A listából hagyjuk ki azokat, ahol a munka azonosítója páratlan szám! (kettővel osztva 1 maradékot ad)

[Megoldás](Gy2_12.mp4)

(+/-) Készítsünk listát a munkák azonosítóiról és a megnevezésükről! A megnevezés allas-óraszám formában jelenjen meg, pl: eladó-4. 

a.	Jelenítsük meg a dátumot is, de csak a évet és a hónapot, pl: 2003-07! 
b.	Ennek az oszlopnak 'Kezdés hónapja' legyen a neve! A listát szűrjük a nyári hónapokra!

[Megoldás](Gy2_13.mp4)

(+/-) Készítsünk listát a diákok adatairól, amely a Nev oszlop helyén a diák monogramját jeleníti meg (keresztnév, illetve vezetéknév első betűje összefűzve). 
a.	A listát szűrjük 1983.01.01 és 1987.06.01 között született diákokra!

[Megoldás](Gy2_14.mp4)

(+/-) A diákok a munkakezdés évének utolsó napján bónuszt kapnak, amennyiben az adott évben legalább 6 hónapot dolgoznak. 

a.	Jelenítsük meg, hogy az egyes munkák adatait, egy új oszlopban az éves bónusz napját is 'Bónusz dátum' néven! 
b.	A lista csak a bónuszra jogosultak adatait tartalmazza!

[Megoldás](Gy2_15.mp4)
