# Táblakapcsolatok és kényszerek

> [!NOTE]
>
> Ez az oldal ismétlésként szolgál. Az itt bemutatottakat az Adatbázisrendszerek kurzus részletesen tárgyalta.

## Videók



(!Vid) 1. rész

> [!Video https://storage.altinum.hu/softeng_lev/TAO1.m4v]

(!Vid) 2. rész

> [!Video https://storage.altinum.hu/softeng_lev/TAO2.m4v]

(!Vid) 3. rész

> [!Video https://storage.altinum.hu/softeng_lev/TAO3.m4v]

(!Vid) 4. rész

> [!Video https://storage.altinum.hu/softeng_lev/TAO4.m4v]

(!Vid) 5. rész

> [!Video https://storage.altinum.hu/softeng_lev/TAO5.m4v]

(!Vid) 6. rész

> [!Video https://storage.altinum.hu/softeng_lev/TAO6.m4v]

(!Vid) 7. rész

> [!Video https://storage.altinum.hu/softeng_lev/TAO7.m4v]





## Fogalmak

### Kulcsok

A relációs adatbázisokban a táblák közti kapcsolatok az idegen kulcsokon és a hozzájuk tartozó kényszereken (**constraint**) keresztül valósulnak meg.

Tegyük fel, hogy van egy `Hallgató` és egy `Osztály` táblánk, és a kettő között az jelenti a kapcsolatot, hogy tudjuk melyik hallgató melyik osztályba jár. Ez egy úgynevezett egy-több kapcsolat: egy hallgató egyszerre csak egy osztályba járhat (tekintsünk el a rendhagyó esetektől), de egy osztálynak számos hallgatója lehet. Annak jelölésére, hogy egy adott hallgató melyik osztályba jár, a `Hallgató` táblát kibővítjük egy mezővel, ami alapján a hozzá tartozó `Osztály` rekord egyértelműen azonosítható. Ennek legegyszerűbb módja, ha a `Hallgató` tábla mezőjében az `Osztály` tábla kulcs mezőjének megfelelő értéke szerepel, ezt a mezőt hívjuk idegen kulcs-nak (**foreign key**).

> [!IMPORTANT]
>
> Relációs adatbázisokban megengedett, hogy egy tábla kulcsa egynél több mezőből épül fel, az általunk használt Entity Framework azonban megköveteli, hogy minden táblának legyen egy olyan mezője, ami egyedi kulcsként funkcionál. Ennek következtében mi nem foglalkozunk a több mezőből álló kulcsokkal, így az ezekhez kapcsolódó idegen kulcsokkal sem.

Az idegen kulcs mező beállítása esetén tehát értelemszerűen ugyanazt az adattípust kell használnunk, mint az eredeti tábla kulcsmezőjénél. Ez a beállítás azonban csak annyit biztosít, hogy a megfelelő formájú adat kerülhessen a mezőbe, de nincs semmilyen védelem arra, hogy ne lehessen például egy nem létező osztályt felvinni egy hallgatóhoz. A megfelelő korlátozás beállításával biztosíthatjuk, hogy csak olyan érték kerülhessen a `Hallgató` idegen kulcs mezőjébe, ami szerepel az `Osztály` tábla kulcs mezőjében. Az idegen kulcs és a hozzá tartozó megkötés együtt alakítják ki a két tábla közti kapcsolatot.

### Több-több kapcsolat
A relációs adatbázisokban nem lehet közvetlenül több-több megfeleltetést megvalósítani. Vegyünk egy az előzőhöz hasonló, de egyetemi példát egy `Hallgató` és egy `Szeminárium` táblával. Nyilván igaz, hogy egy hallgató több szemináriumot is felvehet egy félévben, és az is, hogy egy szemináriumra több hallgató is jelentkezhet.

Könnyen belátható, hogy ez a kapcsolat nem írható le egyszerűen úgy, hogy mindkét táblába idegen kulcs mezőket veszünk fel. Ez a probléma orvosolható, ha felveszünk egy köztes táblát, amelyikhez mindkét eredeti tábla egy-több kapcsolaton keresztül kapcsolódik, így több-több kapcsolatot létrehozva a két eredeti tábla között. A példában legyen ez a tábla a `Tárgyfelvétel`. A köztes tábla a "több" oldal, tehát mindkét irányból ebben a táblában kell szerepelnie az idegen kulcsnak, tehát a `Tárgyfelvétel` táblának biztosan rendelkeznie kell legalább az alábbi három mezővel: saját azonosító mező, idegen kulcs mező a `Hallgató` táblához, valamint egy idegen kulcs a `Szeminárium` táblához.

### Táblakapcsolatok beállítása VS2019-ben és VS2022-ben
1. Server Explorer-ben az adatkapcsolatot lenyitva a Tables mappán belül duplaklikk a releváns táblára. Így megnyílik a tábla szerkesztő felülete.
2. Ellenőrizd le a cél tábla kulcs mezőjének adattípusát. Ezzel kell megegyezzen a másik táblában az idegen kulcs mező típusa.
   ![kep1]
3. A másik táblához add hozzá az idegen kulcs meződet. Az elnevezése tetszőleges, de mi a félév során feltöltött anyagokban a CéltáblaNeveFK (FK = Foreign Key) névkonvenciót fogjuk alkalmazni.
   ![kep2]
4. Jobb klikk oldalt a `Foreign Keys` feliratra és `Add New Foreign Key`. Ennek hatására egy új sor íródik be az alsó SQL script-be. (Mi az olvashatóság kedvéért betördeltük.)
5. Töltsd ki a változó részeket a megfelelő értékekkel:
	**FK_TáblaNeve_ToTable** - Ez egy elnevezés, tetszőleges lehet, de egyedinek kell lennie. Érdemes a végén a Table szót a céltábla nevére cserélni.
	**Column** - Az idegen kulcs neve ebben a táblában.
	**ToTable** - Céltábla neve.
	**ToTableColumn** - Céltábla kulcsmezőjének neve.
6. A kitöltés után `Update` és `Update table...`

Visual Studio-ban sajnos nem lehet azonnal megtekinteni a táblakapcsolathoz tartozó diagramot, de egy projektben az [ORM](/szoft2/object_relational_mapping/)-et megvalósítva láthatóak lesznek a kapcsolatok.

> [!WARNING]
>
> Adatfeltöltéskor célszerű először a céltáblát feltölteni adatokkal, mert másképp a constraint miatt egyetlen értéket sem fogunk tudni beírni a másik tábla idegen kulcs mezőjébe.  Törlés esetén pont fordítva: amíg van hivatkozás az idegen kulcs mezőn keresztül a céltábla valamelyik rekordjára, addig azt nem fogjuk tudni törölni.

> [!INFO]
>
> Az idegen kulcsok mentén történő automatikus törlés az úgynevezett kaszkádolt törlés. Ha ez a funkció aktív egy táblakapcsolatra, akkor engedélyezett az idegen kulcsból hivatkozott rekordok törlése is, de ebben az esetben automatikusan törlődik az összes hivatkozó rekord is a másik táblából.

[kep1]: osztaly.png
[kep2]: hallgato2.png

## 1. rész: Adatbázistáblák felépítése SSMS-ben, vagy Visual Studio-ban lokális adatbázisban

Az adatbázis sémáját az alábbi ábra tartalmazza. 

![kep2]

#### Jelölések

|      |                |                                                          |
| ---- | -------------- | -------------------------------------------------------- |
| _SK  | surrogate key  | Helyettesítő kulcs, automata számláló (Elsődleges kulcs) |
| _ID  | identification | Azonosító (Elsődleges kulcs)                             |
| _FK  | foreign key    | Idegen kulcs                                             |


#### Hozd létre az alábbi táblákat a megadott mezőkkel:  

Dolgozz az Azure-ban telepített SQL szervereden a már meglévő adatbázissal vagy hozz létre egy lokális adatbázist a projektedbe! Ahol nincs kitöltve a mezőtípus, ott a megadott adatok alapján kell kikövetkeztetni.

**Status** tábla:

|          |                                                              |
| -------- | ------------------------------------------------------------ |
| StatusID | kézzel kitöltendő kis szám                                   |
| Name     | a státusz megnevezése, pl: "tanársegéd", "adjunktus", "docens" |

> A `StatusID`  mező értéke egyfajta sorrendiséget is jelenthet a fokozatok között, mely később egy sorba rendezés alapjául is szolgálhat. Ezért nem érdemes automatikus számlálót használni. 

**Employment** tábla:

|              |                                                           |
| ------------ | --------------------------------------------------------- |
| EmploymentID | egy betű: értéke lehet "F" vagy "R"                       |
| Name         | a típus megnevezése, pl.: F - főállású, R - részmunkaidős |

**Instructor** tábla (Oktatók tárolására): 

|              |                            |
| ------------ | -------------------------- |
| InstructorSK |                            |
| Salutation   | titulus, pl. "Dr", "Prof." |
| Name         | Az oktató teljes neve      |
| StatusFK     |                            |
| EmploymentFK |                            |


**Day** tábla (Nap): 

|       |                          |
| ----- | ------------------------ |
| DayID |                          |
| Name  | 1: "hétfő", 2: "kedd", … |

**Time** tábla (Sáv): 

|        |                                |
| ------ | ------------------------------ |
| TimeID | sáv száma                      |
| Name   | "08:00-09:30" formátumú string |

> A `Name` mező fixen 13 karakterből áll, melyek között nem lehet ékezetes. 

**Room** tábla (tanterem): 

|        |            |
| ------ | ---------- |
| RoomSK |            |
| Name   | Pl: "S116" |

**Lesson** tábla:

|              |              |
| ------------ | ------------ |
| LessonSK     |              |
| Name         | A tárgy címe |
| InstructorFK |              |
| DayFK        |              |
| TimeFK       |              |
| RoomFK       |              |

(+/-) Építsd fel a fenti adatbázistáblákat.

(+/-) Állítsd be a táblák közti kapcsolatokat!

