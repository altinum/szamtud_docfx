# Nézetek, tárolt eljárások, függvények
[Összefoglaló videó](gyak10_x264.mp4)
## Nézetek
A nézet egy elmentett, névvel ellátott lekérdezés.

- A nézetekből ugyanúgy lehet lekérdezni, mint táblákból
- A nézetek segítségével meghatározhatjuk a megjelenítendő adatok körét
- A nézetekhez adhatunk jogosultságokat az  alaptáblákhoz való jogosultságok nélkül is
- A DML-műveletek nem mindig megengedettek nézeteken keresztül
### A nézetek két fő típusa
- Virtuális: csak a lekérdezés tárolódik (csak ez tananyag)
- Materializált: az adatok is tárolásra kerülnek (indexed view)
### Létrehozás
``` sql
CREATE VIEW view_név  
[(oszlopnevek listája)]
[WITH view_attribútumok]
AS SELECT_utasítás
[WITH CHECK OPTION]*
```
- A szögletes zárójelbe tett részek opcionálisak
- A view_attribútumokkal nem foglalkozunk
- Az SQL Server 2016-tól a CREATE OR ALTER VIEW forma is használható
- WITH CHECK OPTION záradék az adatintegritást segíti. Bekapcsolásával csak olyan adatmódosítást végezhetünk a view-n keresztül, amely megfelel a SELECT-ben lévő feltételeknek
### Példa:
```sql
CREATE VIEW v_klimas_szobak
(Azonosító, Szobaszám, [Férőhelyek száma])
SELECT szoba_id, szoba_szama, ferohely
FROM szoba
WHERE KLIMAS=’i’

# A Nézet használata
SELECT * FROM v_klimas_szobak
```
## Tárolt eljárások
 A tárolt eljárás olyan adatbázis objektumként tárolt program, amely SQL- utasításokat is tartalmazhat.

A tárolt eljárások főbb jellemzői
- Input és output paramétereket, valamint különböző algoritmikus szerkezeteket is tartalmazhatnak (elágazás, ciklus)
- Az adatbázis szerveren tárolódnak
- Futtatásuk jogosultságokhoz köthető
### Tárolt eljárások létrehozása SQL-ben
``` sql
CREATE PROCEDURE
eljárás_név
[paraméterek listája]
[WITH eljárás_opciók]
AS
[BEGIN]
Utasítások
[END]
```
- A szögletes zárójelbe tett részek opcionálisak
- Az eljárás opciókkal nem foglalkozunk
- Az SQL Server 2016-tól a CREATE OR ALTER PROCEDURE forma is használható
### Példa
```sql
CREATE PROCEDURE vevo_foglalasok
@vevoid nvarchar(20)
AS
BEGIN
SELECT *
FROM Foglalas
WHERE UGYFEL_FK = @vevoid
END
# Futtatás
EXEC vevo_foglalasok 'laszlo2'
```
## Függvények
A (felhasználó által definiált) függvény olyan adatbázis objektum, amely végrehajt egy tevékenységet, majd annak eredményét visszaadja egy érték vagy egy tábla formájában
A függvények főbb jellemzői
- Input paramétereket, SQL-utasításokat, valamint különböző algoritmikus szerkezeteket is tartalmazhatnak (elágazás, ciklus)
- Az adatbázis szerveren tárolódnak
- Futtatásuk jogosultságokhoz köthető
- Felhasználhatók SQL-utasításokban, pl: SELECT utasításban
### Létrehozás
#### Skalárértékű
``` sql
CREATE FUNCTION fv_név
([paraméterek listája])
RETURNS adattípus_név
[WITH fv_opciók]
[AS]
BEGIN
Utasítások
RETURN skalár_kifejezés
END
```
#### Táblaértékű
``` sql
CREATE FUNCTION fv_név
([paraméterek listája])
RETURNS TABLE
[WITH fv_opciók]
[AS]
RETURN select_kifejezés
```

- A szögletes zárójelbe tett részek opcionálisak
- A fv. opciókkal nem foglalkozunk
 - Az SQL Server 2016-tól a CREATE OR ALTER FUNCTION forma is használható
- A CLR-függvényekkel nem foglalkozunk
#### Példa
``` sql
CREATE FUNCTION csillagszam
(@szallas_id INT)
RETURNS INT
AS
BEGIN
DECLARE @db INT
SELECT @db=CSILLAGOK_SZAMA
FROM Szallashely
WHERE SZALLAS_ID=@szallas_id
RETURN @db
END
# Függvény alkalmazása
SELECT dbo.csillagszam(5)
```
## Függvények és tárolt eljárások összehasonlítása
A függvények sok tekintetben a tárolt eljárásokhoz hasonló tulajdonságokkal rendelkeznek, de van közöttük néhány fontos különbség.
| Függvények                                                              | Tárolt eljárások                         |   |
|-------------------------------------------------------------------------|------------------------------------------|---|
| Csak input paraméterek                                                  | Input és output paraméterek              |   |
| Tranzakciók nem használhatók                                            | Tranzakciók is használhatók              |   |
| A SELECT utasításban használhatók                                       | A SELECT utasításban nem használhatóak   |   |
| Kivételkezelés nem használható                                          | Kivételkezelés használható               |   |
| Nem hívhat meg tárolt eljárást                                          | Függvényhívás lehetséges                 |   |
| Mindig egy értéket adnak vissza (érték lehet egy skalár vagy egy tábla) | Visszaadhat nulla, egy vagy több értéket |   |

 **Megjegyzések**
-A nézetek definíciójában nem használható az ORDER BY záradék (kivéve, ha TOP záradék is definiálva van, ld. köv. gyakorlat)
- A nézetekben nem hivatkozhatunk ideiglenes táblákra (ld. köv. gyakorlat) 
-  Tárolt eljárásoknál az output paramétereket az OUT kulcsszóval jelölhetjük, pl: @i INT OUT
- A függvényekben sem paraméterként, sem visszaadott értékként nem szerepelhet a Timestamp típus
- Afüggvények egymásba is ágyazhatók
- Tárolt eljárásoknál és fv-eknél 
   -  Elágazások megvalósítása: IF feltétel utasítás[blokk] [ELSE utasítás[blokk]] 
    -  Ciklusok megvalósítása: WHILE feltétel utasítás[blokk]
# Feladatok
A feladatok a szallashely adatbázishoz készültek,  létrehozásához szükséges script elérhető itt:
[szallas.sql](szallas.sql)

(+/-)Készítsünk sorszámozott listát a szálláshelyek adatairól!
a.	A lista legyen a szálláshely típusa szerint, azon belül hely szerint, majd a neve szerint növekvően rendezve!
b.	A számozás típusonként kezdődjön újra!
[Megoldás](Gy10_1.mp4)

(+/-)Készítsünk lekérdezést, amely a foglalások adatait jeleníti meg!
a.	A lista tartalmazzon két új oszlopot, amelyek az adott ügyfél legrövidebb, illetve leghosszabb foglalásának hosszát (a foglalt napok számát) mutatják meg! 
b.	Az oszlopokat nevezzük el értelemszerűen!
[Megoldás](Gy10_2.mp4)

(+/-)Készítsük listát, amely megjeleníti az ügyfelek azonosítóját, nevét és a foglalásainak kezdő- és befejező dátumát, valamint azt, hogy a foglalás összesen hány főre történt!
a.	Egy új oszlopban jelenítsük meg azt is, hogy az ügyfél előző három foglalása összesen hány főre történt!
[Megoldás](Gy10_3.mp4)

(+/-)Készítsünk listát arról, hogy az egyes szálláshelyeken évente hány foglalás történt!
a.	A lista jelenítse meg a szálláshely azonosítóját, nevét, az évet, és a foglalások számát! 
b.	Egy új oszlopban jelenítsük meg a szálláshely eddigi éves foglalásainak számát is (az aktuálisat is beleértve). 
c.	Az évnél a METTOL dátumot vegyük figyelembe!
d.	A lista ne tartalmazzon duplikált sorokat!
[Megoldás](Gy10_4.mp4)

(+/-)Készítsük listát a szálláshelyekről! A lista tartalmazza a szálláshely azonosítóját, nevét, és a csillagok számát csillagszám szerint csökkenő, azon belül szállásnév szerint növekvő sorrendben! 
a.	Vegyünk fel két új oszlopot, amely a sorrend szerint előző szálláshely nevét, illetve azonosítóját is megjeleníti!
[Megoldás](Gy10_5.mp4)

(+/-)**Készítsünk nézetet NEPTUNKÓD_VSZOBA néven, amely megjeleníti a szobák adatai mellett a megfelelő szálláshely nevét, helyét és a csillagok számát is!**
a.	Az oszlopoknak nem szükséges külön nevet adni! 
b.	Teszteljük is a nézetet, pl: SELECT * FROM UJAENB_VSZOBA
[Megoldás](Gy10_6.mp4)

(+/-) **Készítsünk tárolt eljárást NEPTUNKÓD_SPUgyfelenkentiFoglalasok néve, amely ügyfelenkénti bontásban megjeleníti, hogy hány foglalás történt!**
a.	Elég az ügyfél kódjával dolgozni!
b.	Teszteljük le a tárolt eljárás működését, pl: EXEC UJAENB_SPUgyfelenkentiFoglalasok
[Megoldás](Gy10_7.mp4)

**(+/-)Készítsen tárolt eljárást NEPTUNKÓD_SPUgyfelFoglalasok, amely a paraméterként megkapott ügyfél azonosítóhoz tartozó foglalások adatait listázza!**
a.	Teszteljük a tárolt eljárás működését, pl: EXEC UJAENB_SPUgyfelFoglalasok 'laszlo2'
[Megoldás](Gy10_8.mp4)

**(+/-)Készítsen skalár értékű függvényt NEPTUNKÓD_UDFFerohely néven, amely visszaadja, hogy a paraméterként megkapott foglalás azonosítóhoz hány férőhelyes szoba tartozik!**
a.	Teszteljük is a függvény működését, pl: SELECT dbo.UJAENB_UDFFerohely(600)
[Megoldás](Gy10_9.mp4)

**(+/-)Készítsen tábla értékű függvényt NEPTUNKÓD_UDFFoglalasnelkuliek néven, amely azon ügyfelek adatait listázza, akik még nem foglaltak egyszer sem az adott évben adott hónapjában! A függvény paraméterként kapja meg a foglalás évét és hónapját! (Itt is a METTOL dátummal dolgozzunk)**
a.	Teszteljük is a függvény működését, 
pl: SELECT * FROM dbo.UJAENB_UDFFoglalasnelkuliek(2016, 10)**
[Megoldás](Gy10_10.mp4)

(+/-)Készítsünk nézetet NEPTUNKÓD_VFoglalasreszletek néven, amely a következő adatokat jeleníti meg: foglalás azonosítója, az ügyfél neve, a szálláshely neve és helye, a foglalás kezdete és vége, és a szoba száma. 
a.	Az oszlopokat nevezzük el értelemszerűen!
b.	Teszteljük a nézet működését, pl: SELECT * FROM UJAENB_VFoglalasreszletek
[Megoldás](Gy10_11.mp4)

(+/-)Készítsen skalár függvényt NEPTUNKÓD_UDFAtlagosFoglalasszam néven, amely a paraméterként megkapott szállásazonosítóhoz megadja a napi foglalások átlagos számát (valós szám)! A napnál a METTOL dátumot használjuk! 
a.	Ha az adott szálláson nem volt foglalás, akkor 0 jelenjen meg!
b.	Teszteljük a fv. működését, pl: SELECT dbo.UJAENB_UDFAtlagosFoglalasszam(1)
[Megoldás](Gy10_12.mp4)

(+/-)Készítsen tábla értékű függvényt NEPTUNKÓD_UDFJougyfelek néven, amely listázza azon ügyfelek azonosítóját és nevét, akik az átlagosnál többször foglaltak a paraméterként megadott időszakban (az átlag is az adott időszakra vonatkozzon) 
a.	Az időszak kezdetét és végét a METTŐL dátumhoz viszonyítsuk! 
b.	Az átlagnál egész számokkal dolgozzunk! 
c.	Teszteljük a függvény működését, 
pl: SELECT * FROM dbo.UJAENB_UDFJougyfelek('2016.01.01','2016.10.20')
[Megoldás](Gy10_13.mp4)

(+/-)Készítsünk tárolt eljárást NEPTUNKÓD_SPRangsor néven, amely rangsorolja a szálláshelyeket a foglalások száma alapján (a legtöbb foglalás legyen a rangsorban az első). A listában a szállás azonosítója, neve és a rangsor szerinti helyezés jelenjen meg - holtverseny esetén ugrással (ne sűrűn)!
a.	Teszteljük a tárolt eljárást, pl: EXEC UJAENB_SPRangsor
[Megoldás](Gy10_14.mp4)

(+/-)Töröljük le a létrehozott nézeteket, tárolt eljárásokat és függvényeket!
