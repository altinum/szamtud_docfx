# Projektfeladat: Hajós oktató

## A feladat leírása

A kedvtelési célú hajóvezetői vizsga hatósági vizsgakérdései (vitorlázáselmélet, kisgéphajó-elmélet, hajózási szabályzat) a Közlekedési Hatóság honlapjáról voltak letölthetők: [2018_11_22_Hajozasi_szabalyzat.zip](2018_11_22_Hajozasi_szabalyzat.zip). A tömörített állomány egy Excel táblában tartalmazta a vizsgán előforduló összes kérdést és a válaszlehetőségeket. Vannak olyan kérdések, amelyekhez kép is tartozik.

A feladat olyan alkalmazás készítése C# nyelven, mely begyakoroltatja a kérdéssort a vizsgára készülőkkel.
- Első lépésként olyan formátumú csv fájlt kell exportálni Excelből, amit C# kódból fel tudsz dolgozni.
- Ezután létre kell hozni egy vizsgakérdés tematikájú osztályt, de itt kép is tartozhat a kérdéshez a kérdés szövege és a válaszlehetőségek mellett. Az osztály tartalmazzon egy publikus változót, mely tárolja, hogy egymás után hányszor válaszolták meg jól a kérdést. 
- A fájl alapján fel kell építeni a kérdéseket tartalmazó listát (például: `List<Kerdes> x`). 
- A képernyőn mindig egy kérdés legyen látható, a képek miatt nem lenne célszerű egymás alá tenni őket. 

Ha az 1400 kérdésből mindig véletlenszerűen választunk, nem lesz hatékony a tanulás. A program tartalmazzon egy listát, melyben az éppen gyakoroltatott 7 kérdés van. A program indításakor az első 7 kérdés kerüljön ide. Az éppen gyakoroltatott kérdések közül kerüljön mindig véletlenszerűen egy a képernyőre. Ha a tanuló egymás után háromszor helyesen válaszol egy kérdésre, a kérdés kerüljön ki a gyakoroltatott kérdések listájáról, és helyébe a teljes listáról kerüljön be a következő kérdés. 

> Teams-en várjuk a feladattal kapcsolatban kérdéseket, és igyekszünk mihamarabb válaszolni.


## Tippek a megvalósításhoz

### Excel állomány feldolgozása

Az elején feltűnhet, hogy az Excelben csak színekkel vannak jelölve a jó válaszok, és ebből így nehéz lesz olyan csv-t csinálni, ami a helyes válasz sorszámát is tartalmazza. Az alábbi kis VBA programmal segítettek a problémán, de a letölthető ZIP tartalmaz egy olyan változatot is az Excel-fájlból, amelyben már külön oszlopokban szerepelnek a színkódok alapján képzett betűk. 

``` vba
Sub Gomb1_Click()
    sorok = ActiveSheet.UsedRange.Rows.Count
    For i = 1 To sorok
	    Cells(i, 12) = Cells(i, 3).Font.ColorIndex
    Next
End Sub
```

### Listák kezelése

Az alábbi listákat, referenciát, illetve változót érdemes létrehozni a fő űrlap szintjén:

``` csharp
//Ebbe a referenciába kerül az a kérdés, amelyik éppen a képernyőn van
Kerdes aktuálisKérdés;

//Ide kerül a fájl alapján a teljes kérdéslista
List<Kerdes> összesKérdés = new List<Kerdes>();

//Ebbe a listába kerül az éppen gyakoroltaott 7 kérdés
List<Kerdes> gyakoroltatottKérdések = new List<Kerdes>();

//Ez a változó tartalmazza azt, hogy ha háromszor jó választ adott a felhasználó egy kérdésre, akkor
//hányas számú kérdés jön be az összesKérdés listából a helyére
int követketőKérdés = 8;
```

