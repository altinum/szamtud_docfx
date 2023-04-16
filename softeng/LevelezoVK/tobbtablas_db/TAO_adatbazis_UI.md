# 4. gyakorlati feladatsor: Többtáblás adatbázis



### Adatbázis feltöltése adatokkal

(+/-) Töltsd fel a táblákat néhány mintaadattal! Figyelj, hogy az idegen kulcsokban csak létező adatok szerepeljenek! (Jobbklikk a kész táblára, majd: *Edit top 200 rows*)

A következő feladatokban megvalósítandó alkalmazás az előbb létrehozott adatbázisra épül. Ha szeretnéd, hogy az adatbázisodban több adat legyen a teszteléshez, vagy csak bizonytalan vagy a felépítésével kapcsolatban, akkor választhatod az alábbi opciók egyikét is.

a) Csatlakozz az adatokkal feltöltött, közös adatbázishoz. A *Visual Studio Server Explorer*-ben állítsd be a paramétereket az alábbiak szerint:

|                |                                                         |
| -------------- | ------------------------------------------------------- |
| Szerver        | bit.uni-corvinus.hu                                     |
| Felhasználónév | hallgato                                                |
| Jelszó         | Password123                                             |
| Adatbázis      | Studies **--Vigyázat, nem Student, mint a múlt héten!** |

   Ez az adatbázis csak az egyetemi IP tartományból érhető el, tehát otthonról VPN kell hozzá!

b) Hozz létre egy új adatbázist (Azure-ban vagy lokálisan), és egyszerűen futtasd benne [ezt az sql scriptet](studies.sql).





## A gyakorlat célja

A feladat: több egyszerű tábla és a köztük levő kapcsolatok megvalósítása, illetve a táblákhoz tartozó űrlapok felépítése: 
- A gyakorlat első részeben felépítjük az adatbázist saját szerverünkön, vagy lokális adatbázisban, 
- a gyakorlat második részében az adatokkal feltöltött oktatói szerveren lévő adatbázishoz építünk felhasználói felületet. 

## 1. rész: Adatbázistáblák felépítése SSMS-ben, vagy Visual Studio-ban lokális adatbázisban

Az adatbázis sémáját az alábbi ábra tartalmazza. 

![kep2]

#### Jelölések
||||
|-|-|-|
|_SK|surrogate key|Helyettesítő kulcs, automata számláló (Elsődleges kulcs)
|_ID|identification|Azonosító (Elsődleges kulcs)
|_FK|foreign key|Idegen kulcs


#### Hozd létre az alábbi táblákat a megadott mezőkkel:  

Dolgozz az Azure-ban telepített SQL szervereden a már meglévő adatbázissal vagy hozz létre egy lokális adatbázist a projektedbe! Ahol nincs kitöltve a mezőtípus, ott a megadott adatok alapján kell kikövetkeztetni.

**Status** tábla:

|||
|-|-|
|StatusID| kézzel kitöltendő kis szám|
|Name| a státusz megnevezése, pl: "tanársegéd", "adjunktus", "docens"  |

> A `StatusID`  mező értéke egyfajta sorrendiséget is jelenthet a fokozatok között, mely később egy sorba rendezés alapjául is szolgálhat. Ezért nem érdemes automatikus számlálót használni. 

**Employment** tábla:

|||
|-|-|
|EmploymentID|egy betű: értéke lehet "F" vagy "R"|
|Name|a típus megnevezése, pl.: F - főállású, R - részmunkaidős|

**Instructor** tábla (Oktatók tárolására): 

|||
|-|-|
|InstructorSK||
|Salutation|titulus, pl. "Dr", "Prof."|
|Name|Az oktató teljes neve|
|StatusFK|
|EmploymentFK|


**Day** tábla (Nap): 

|||
|-|-|
|DayID||
|Name| 1: "hétfő", 2: "kedd", …|

**Time** tábla (Sáv): 

|||
|-|-|
|TimeID|sáv száma|
|Name| "08:00-09:30" formátumú string|

> A `Name` mező fixen 13 karakterből áll, melyek között nem lehet ékezetes. 

**Room** tábla (tanterem): 

|||
|-|-|
|RoomSK||
|Name| Pl: "S116"|

**Lesson** tábla:

|||
|-|-|
|LessonSK||
|Name|A tárgy címe |
|InstructorFK| |
|DayFK||
|TimeFK||
|RoomFK ||

(+/-) Építsd fel a fenti adatbázistáblákat.

(+/-) Állítsd be a táblák közti kapcsolatokat!

### Adatbázis feltöltése adatokkal

(+/-) Töltsd fel a táblákat néhány mintaadattal! Figyelj, hogy az idegen kulcsokban csak létező adatok szerepeljenek! (Jobbklikk a kész táblára, majd: *Edit top 200 rows*)

A következő feladatokban megvalósítandó alkalmazás az előbb létrehozott adatbázisra épül. Ha szeretnéd, hogy az adatbázisodban több adat legyen a teszteléshez, vagy csak bizonytalan vagy a felépítésével kapcsolatban, akkor választhatod az alábbi opciók egyikét is.

a) Csatlakozz az adatokkal feltöltött, közös adatbázishoz. A *Visual Studio Server Explorer*-ben állítsd be a paramétereket az alábbiak szerint:

   |              | |
   |-             |-|
   |Szerver       |bit.uni-corvinus.hu|
   |Felhasználónév|hallgato|
   |Jelszó        |Password123|
   |Adatbázis     |Studies **--Vigyázat, nem Student, mint a múlt héten!**|

   Ez az adatbázis csak az egyetemi IP tartományból érhető el, tehát otthonról VPN kell hozzá!

b) Hozz létre egy új adatbázist (Azure-ban vagy lokálisan), és egyszerűen futtasd benne [ezt az sql scriptet](studies.sql).


## 2. rész: Felhasználói felület építése Visual Studio-ban

### Adattáblák *mappelése* (ORM)
(+/-) Hozz létre új projektet a Visual Studio-ban (akkor is, ha lokális adatbázist hoztál létre)

(+/-) A *Server Explorer*-ben kapcsolódj az adatbázisodhoz 
> A *Server Explorer*-nek semmi köze a projekthez, a *Server Explorer* egy segédeszköz az adatbázis adatainak áttekintésére és kezelésére. 

(+/-) majd hozz létre új "ADO. NET Entity Data Model" elemet! A varázslóban válaszd a fenti adatbázist, majd jelöld ki az összes tábláját! Ha mindent jól csináltál, az alábbi sémához hasonló jelenik meg, esetleg más elrendezésben:

![kep2]

### Adkötött objektumok hozzáadása a projekthez

 (+/-) Build-ed a projektet, különben a következő lépésben nem fognak megjelenni az adatbázissal kapcsolatos osztályok.

 (+/-) Hozd létre a megfelelő adatkötött objektumokat *Data Sources* panel: *Add New Data Source* - *Object*. Itt nyisd ki a listát, és válaszd ki a tábláidat, majd nyomj a *Finish*-re.

![kep3]

### Felhasználói felület felépítése

(+/-) Az eredeti `Form1`-en hozz létre két gombot!

(+/-) Hozz létre két új `Form`-ot! Az egyes gombok ezeket a `Form`-okat nyissák meg a `ShowDialog()` metódussal! Az egyiken az oktatókat, a másikon az órákat kezelő `DataGridView` szerepeljen. Ezeket a `Data Sources` ablakból tudod behúzni.
```csharp
private void button1_Click(object sender, EventArgs e)
{
    Form2 f2 = new Form2();
    f2.Show();
}
```

(+/-) Húzd az egyik űrlap felületére a `Instructors` táblát, a másikra az `Lessons` táblát! (A *Data Sources* ablakból)

(+/-) Az új `Form`okban osztály szinten példányosítsd az `StudiesEntities` osztályt `context` néven, és kösd hozzá a `BindingSource` `DataSource` tulajdonságához a megfelelő táblát! (Enélkül nem jelennek meg az előre feltöltött adatok a `DataGridView`-ban.)

![kep4]

(+/-) Állítsd be értelemszerűen az összes *foreign key* mezőre a legördülő menüket. Jobbklikk a `DataGridView`-ra és *Edit Columns*, ahol: `ColumnType = DataGridViewComboBoxColumn`. Ügyelj a Value- és Display memberek helyes megválasztására! Végül töltsd fel a legördülő menükhöz használt `BindingSource`-ok `DataSource` tulajdonságait is!

> Az *Edit Columns*-ban látni fogsz olyan mezőket, amik nincsenek az adatbázisban. Ezek tipikusan a ORM során létrejövő segéd mezők, melyek a táblakapcsolatokat segítenek kezelni (lásd későbbi anyag). Például a StatusFK-hoz tartozik egy Status mező, ami egy ilyen technikai oszlop. A tartalma nem igazán értelmezhető a felhasználónak, ezért illik elrejteni előle. A *Remove* gombbal egyszerűen eltávolítható (ez csak a megjelenítésből távolítja el a mezőket, nem a táblából).

![kep5]

```csharp
public partial class Form2 : Form
{
    StudiesEntities context = new StudiesEntities();
    public Form2()
    {
        InitializeComponent();

        context.Instructors.Load();
        context.Status.Load();
        context.Employements.Load();
        instructorBindingSource.DataSource = context.Instructors.Local;
        statusBindingSource.DataSource = context.Status.Local;
        employementBindingSource.DataSource = context.Employements.Local;
    }
}
```

![kep6]

(+/-) Engedélyezd a `BindingNavigator`-ok *Mentés* gombját, és a kattintáshoz rendelt eseménykezelő metódusban mentsd le az adatbázisba a változtatásokat (`context.SaveChanges()`)!


[kep2]: edmx.png
[kep3]: AddNewDatasource.png
[kep4]: InstructorsRaw.png
[kep5]: StatusBindingSource.png
[kep6]: InstructorsWithComboBoxes.png
