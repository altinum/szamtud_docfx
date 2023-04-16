# Hands-on Lab: LINQ lekérdezések a  Studies adatbázis táblaira 

## A feladat háttere

A gyakorlat célja olyan kliens építése, mely LINQ-lekérdezések segítségével szűri és jeleníti meg egy adott tábla tartalmát. A mintafeladat egy tanszék óráit tartalmazó adatbázis köré épül.

![1585069392831.png](1585069392831.png)

Az `Instructor` tábla az oktatókat tartalmazza, az oktató státusza (Pl: *Adjunktus*, *Docens*, *Egyetemi tanár*, stb.) idegen kulcsként van tárolva, akárcsak az `Emplolyment` (Pl: *Főállású*, *félállású*, *óraadó*). A `Lesson` tábla a saját kulcsa mellett csak idegen kulcsokat tartalmaz. Itt kerül tárolásra, hogy  milyen tantárgyból melyik oktatónak a hét melyik napján, melyik sávban és melyik teremben van órája. `Cousre` például a *szoftvertechnológia*, amiből van 7 `Lesson` egy héten. 

A cél kliens felület építése, mely kétféle nézetben teszi lehetővé az adatbázisban tárolt adatok megjelenítését. A nézetek között gombokkal lehet választani. 
- Az egyik nézet egy listában megjeleníti az oktatókat, és a kiválasztott oktatónak listázza az óráit, de úgy, hogy az idegen kulcsok helyén a csatolt táblában szereplő érték jelenjen meg. Az oktatók név szerint szűrhetők az oktatók listája felett lévő szövegdobozban.
- A másik gombhoz tartozó nézetben kurzusonként lehet megtekinteni az órákat.

![kep1]

## Gyakorlati feladatsor

### 1. Projekt létrehozása és elnevezése

(+/-) Hozz létre egy *Widows Forms App* típusú **projekt**et, melynek **neve legyen gyak6_[neptun kód]**!
Az elkészült projekteket Moodle-ben a gyakorlatnál fel kell tölteni a jelenlét igazolásaként!

### 2. Adatbázis felépítése és ORM

Dolgozz a saját Azure-os szervereden, 
-- vagy --
hozz létre egy lokális adatbázist a projektedben! 

(+/-) Töltsd le és futtasd adatbázist felépítő SQL-t: [Studies_CREATE_FILL.sql](Studies_CREATE_FILL.sql) a választott adatbázison. 

Csak akkor használd az alábbi paraméterekkel elérhető adatbázist, ha valamilyen technikai okból nem sikerült felépíteni a sajátodat! Ez az adatbázis csak az egyetemi IP-tartományból vagy egyetemi VPN-el érhető el!

|              | |
|-             |-|
|Szerver       |bit.uni-corvinus.hu
|Felhasználónév|hallgato
|Jelszó        |Password123
|Adatbázis     |Studies


### 3. Adatkötött objektumok létrehozása

Ebben a példában nincs szükség adat-kötött objektumokra. Lekérdezéseket fogunk megvalósítani és megjeleníteni. Mivel egyes megjelenítések során több tábla adatait fogjuk kombinálni, nem lesz értelmezhető az adatkötés. (Ezen a héten nem kell a *Data Sources* panel és az *Add new data source*.) 

### 4. Felhasználói felület

Hozd létre a fenti ábrán látható felületet az alábbi lépésekben! 

(+/-) A `Form1`-en hozz létre két gombot és egy `Panel`-t! A `Panel`-t tervező nézetben a *Toolbox*-ból behúzhatod. A gombok fogják a UC-ket cserélgetni a paneleken, így tud majd a felhasználó váltogatni a nézetek között. 

(+/-) Állítsd be a panel horgonyait (`Anchor` a *Properties* panelen) úgy, hogy a panel kövesse az ablak méretét. 

(+/-) Adj a projekthez két `UserControl`-t is `UserControl1` és `UserControl2` néven. Az `UserControl`-ok háttérszínét tervezőből állítsd különbözőre, hogy könnyen ellenőrizhető legyen a funkciók működése. 

(+/-) A két `UserControl` a panelba kerüljön bele. Hozzál létre eseménykiszolgálót a gombok kattintás eseményéhez. 

(+/-) Az esemény-kiszolgálókban hozd létre a gombhoz tartozó `UserControl`-t, majd add hozzá a panelhez úgy, hogy töltse ki a rendelkezésére álló területet (a `UserControl` `Dock` tulajdonságának `DockStyles.Fill` értékre történő beállításával). Az esemény-kiszolgálóban még a `UserControl` létrehozása előtt töröljük a panel korábbi tartalmát, végül adjuk a `Panel` `Controls` gyűjteményéhez a `UserControl`-t.

> [!INFO]
>
> **Dock**: Az objektum szülőobjektumához való illeszkedését határozza meg. Így oldható meg legegyszerűbben, hogy a panel átméretezésével a benne lévő UC mindig vegye fel a panel méretét. 

◯ Példaként az első gombhoz tartozó eseménykiszolgáló:
``` csharp
private void button1_Click(object sender, EventArgs e)  
{  
	// Kitöröljük az összes vezérlőt a panelről  
	panel1.Controls.Clear();  
  
	// Létrehozzuk az 1. UserControlt  
	UserControl userControl1 = new UserControl1();  
  
	// Hozzáadjuk a panelhez.  
	panel1.Controls.Add(userControl1);  
  
	// Dock: Az objektum szülőobjektumához való illeszkedését határozza meg  
	// DockStíle.Fill: A vezérlő mind a négy oldala illeszkedjen (és méreteződjön) a szülőobjektumhoz.  
	userControl1.Dock = DockStyle.Fill;  
}
```
(+/-) Az ábrán látható `TextBox`, `ListBox` és `DataGridView` vezérlőket az egyik `UserControl`-on helyezd el (a *Toolbox*ról behúzva)! A továbbiakban az első `UserControl`-ra dolgozz!

### 5. UserContorl1: Oktatók lekérdezése

#### 5.1 Lista feltöltése az oktatók neveivel

Fel kell tölteni adattal a `listBox1`-et az alábbiak szerint:

(+/-) Példányosítsd a `context`-et az osztály szintjén!

> [!INFO]
>
> **LINQ**: a .NET keretrendszerbe épített lekérdező nyelv (szabálygyűjtemény), amely rendelkezik a hagyományos lekérdező nyelvek (pl.: MSSQL) funkcionalitásának egy részével, egyszersmind integrálva van a programozási nyelvekbe (C#, VB).

(+/-) Az alábbi egyszerű lekérdezéssel, melyet a konstruktorban vagy a `Load` eseményhez tartozó eseménykiszolgálóban is elhelyezhetünk, megkapjuk az `Instructor` tábla tartalmát. A LINQ eredményét adjuk meg a `listBox1` adatforrásaként:

```csharp
var ilist = from i in context.Instructors
            select i;
listBox1.DataSource = ilist.ToList();
```
(+/-) Ahhoz, hogy a `listBox1`-ben csak az oktatók neve jelenjen meg, a `dataGridView` legördülő mezőihez hasonlóan be kell állítani a lista `DisplayMember` tulajdonságát. Ezt a kódban az alábbi utasítás végzi el:

```csharp
listBox1.DisplayMember = "Name";
```

> A `DisplayMember` értékét pontosan kell megadni, különben nem fog működni! Mindenképpen be kell gépelni, nincs kerülőút tervezőben. Ha rosszul van megadva, vagy nincs megadva a `DisplayMember`, a tábla sorait leképező osztály neve jelenik meg annyiszor, ahány eleme van a táblának. 

#### 5.2 Oktatók szűrése névre
A cél az, hogy ahogy a felhasználó gépel, úgy szűküljön az oktatók listája.

A LINQ lekérdezésekben az SQL nyelvekhez hasonló módon lehet `WHERE` záradékokat írni. Az oktatók lekérdezéséhez használt lekérdezést az alábbi módon átalakítva a `textBox1`-be beírt szöveg alapján szűrve kerülnek az oktatók nevei az adatforrásba. Az alábbi kódrészletet a `textBox1` `TextChanged` eseményéhez létrehozott eseménykiszolgálóban célszerű elhelyezni:

```csharp
listBox1.DataSource = (from i in context.Instructors
                       where i.Name.Contains(textBox1.Text)
                       select i).ToList();
```

A `Contains()` helyett használható még a `StartsWith()` metódus is, ha csak név eleji egyezésekre akarunk összpontosítani.

```csharp
listBox1.DataSource = (from i in context.Instructors
                       where i.Name.StartsWith(textBox1.Text)
                       select i).ToList();
```
Ahhoz, hogy a lekérdezés szűrő jellege ténylegesen működjön, nem elég a konstruktorból meghívni. Szervezd ki a lekérdezést és az adatforrás feltöltését egy külön metódusba, amit aztán hívj meg a konstruktorból és a `textBox1` `TextChanged` eseményéhez rendelt eseménykezelőből is!

Megoldás:

```csharp
public UserControl1()
{
    InitializeComponent();

    FillDataSource();
    listBox1.DisplayMember = "Name";
}

private void FillDataSource()
{
    listBox1.DataSource = (from i in context.Instructors
                           where i.Name.Contains(textBox1.Text)
                           select i).ToList();
}

private void TextBox1_TextChanged(object sender, EventArgs e)
{
    FillDataSource();
}
```

#### 5.3 A kiválasztott oktató óráinak lekérdezése

(+/-) Rendelj eseménykezelőt a `listBox1` `SelectedIndexChanged` eseményéhez! Az eseménykezelőben kérdezd le egy változóba kiválasztott oktató rekordját:

```csharp
Instructor instructor = (Instructor)listBox1.SelectedItem;
```

(+/-) Ezt a rekordot felhasználva megírható egy lekérdezés, ami visszaadja az adott oktató tanóráit. A `Lessons` tábla azonban kizárólag idegen kulcsokat tartalmaz. Így a pontos értékek megjelenítéséhez a táblák összekapcsolására (INNER JOIN) lenne szükség. A LINQ ennél egyszerűbb lehetőséget is ad a táblakapcsolatokon keresztüli lekérdezésekre:

```csharp
var lessons = from l in context.Lessons
              where l.InstructorFK == instructor.InstructorSK
              select new
              {
                  Kurzus = l.CourseFkNavigation.Name,
                  Nap = l.DayFkNavigation.Name,
                  Sáv = l.TimeFkNavigation.Name
              };
```

A `select` után a `new` kulcsszó a három lekérdezett mezőt egy úgynevezett „névtelen típusú” objektumba gyűjti össze a fenti utasítás. A megfelelő kapcsolt táblákon keresztül hivatkozva pedig az idegen kulcsok helyett az egyes értékekhez tartozó neveket is meg tudjuk jeleníteni.

(+/-) Töltsd be a LINQ-lekérdezés eredményét a dataGridView1-be! (Állítsd be a dataGridView1 adatforrását!)

```csharp
dataGridView1.DataSource = lessons.ToList();
```

### 6. UserControl2: oktató kurzusainak lekérdezése

(+/-) A második `UserControl` felületén valósítsd meg a fent leírt szerkezetet, de most a kurzusok jelenjenek meg a `ListBox`-ban, és az adott kurzus órái legyenek a `DataGridView`-ban! **Próbáld az alábbi megoldás használata nélkül megvalósítani a funkciót!**

Megoldás
```csharp
StudiesEntities context = new StudiesEntities();

public UserControl2()
{
    InitializeComponent();

    FillDataSource();
    listBox1.DisplayMember = "Name";
}

private void FillDataSource()
{
    listBox1.DataSource = (from c in context.Courses
                           where c.Name.Contains(textBox1.Text)
                           select c).ToList();
}

private void TextBox1_TextChanged(object sender, EventArgs e)
{
    FillDataSource();
}

private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
{
    Course course = (Course)((ListBox)sender).SelectedItem;

    dataGridView1.DataSource = (from l in context.Lessons
                                where l.CourseFK == course.CourseSK
                                select new
                                {
                                    Nap = l.DayFkNavigation.Name,
                                    Sáv = l.TimeFkNavigation.Name,
                                    Oktató = l.InstructorFkNavigation.Name
                                }).ToList();
}
```

[kep1]: linq_studies.png
