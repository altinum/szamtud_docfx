# Egészen kicsi LINQ összefoglaló
## Mi az a LINQ

A LINQ NET keretrendszerbe épített lekérdező nyelv (szabálygyűjtemény), amely rendelkezik a hagyományos lekérdező nyelvek (pl.: MSSQL) funkcionalitásának egy részével, egyszersmind integrálva van a C# nyelvebe. 

A gyakorlatban ez azt jelenti, hogy a programkódba közvetlenül írhatjuk a lekérdezéseket úgy, hogy az automatikus kódkiegészítés és a szintaxis ellenőrzés végig segít. Az *Entity Framework* a korábbi hetekben bemutatott módon leképezi C# osztályok formájába az adatbázis tábláinak sémáját (ORM), így az Intellisense a C# kód írása közben tisztában van az adatbázis felépítésével. 


## LINQ példák

### A legegyszerűbb példa

A klasszikus `SELECT * FROM hallgatok` LINQ megfelelője:

```csharp
var eredmény = from x in context.Hallgatok select x;
```
Ebben a példában az `x` az úgynevezett soriterátor. Neve tetszőleges lehet -- az a lényeg, hogy következetesen használjuk -- de a tömörség miatt egybetűs neveket szokás adni. 

> Az SQL-ben a záradékok sorrendje a gépi adatfeldolgozás sorrendjét követik. Fugunk egy vagy több táblát (FROM), kiválasztjuk, hogy melyik rekordokra van szükségünk (WHERE), ami a szűrés után bent maradt, csoportosíthatjuk (GROUP BY), a csoportosítás eredményére is szűrhetünk (HAVING), és a legvégén rendezünk csak sorba (ORDER BY).  A SELECT kucsszó a lekérdezés elejére kerül. LINQ-ban a `select` a végére kerül.

LINQ esetében a `from`-mal kezdődik a kifejezés, melyet a soriterátor követ -- ami most éppen `x`, de lehetne bármi--, majd az `in` kulcsszó után következik a gyűjtemény neve, amiből kérdezni szeretnénk. Ez most épp a `Context.Hallgatók`. A példát a `select` zárja, amiben ki lehet kötni, hogy milyen adatokat jelenítsünk meg. A soriterátor szerepe a következő példából talán jobban megérthető:

```csharp
var eredmény = from x in context.Hallgatok 
               where x.Neptun == "NEPTUN"
               select x;
```

A fenti LINQ kifejezést talán így lehetne magyarra fordítani: "Menj végig a `context.Hallgatok` gyűjtemény minden egyes elemén. A `where` kulcsszó után szereplő kifejezést futtasd le a gyűjtemény minden elemére, úgy hogy a soriterátorba (most épp `x`) kerül az éppen vizsgált elem. Az eredményhalmazban azok az elemek maradnak bent, melyek megfeleltek a `where`  után szereplő feltételnek. 

### Egyszerű lekérdezés where záradékkal (szelekció)

A fenti példa az eredményhalmazba beteszti az összes olyan objektumot, ami megfelel a feltételnek, de a következő példa már csak a neveket gyűjti ki: 
```csharp
var eredmény = from x in context.Hallgatok 
               where x.Neptun == "NEPTUN"
               select x.Nev;
```
A szűrési feltétel lehet bonyolult kifejezés is C# szintaktikával -- majd az Entity Framework  a motorháztető alatt lefordítja SQL-re ha szükséges. 

```csharp
var eredmény = from x in context.Hallgatok 
               where x.Neptun != null && x.Nev.StartsWith("Moh")
               select x;
```


### Több mezővel a select után

```csharp
var eredmény = from x in context.Hallgatok 
               select new 
               { 
                   x.Nev, 
                   x.Hallgato_id 
               };
```
Ebben az esetben egy úgynevezett anonym típus jön létre két tulajdonsággal: `Nev` és `Hallgato_id`. (Létre lehetne hozni egy külön osztály ezzel a két tulajdonsággal, de ez unalmas favágás, és legtöbbször felesleges is.) 

### Egymásba ágyazott lekérdezések

Egy lekérdezés eredményéből gond nélkül kérdezhetünk tovább:

```csharp
var eredmény = from x in context.Hallgatok 
               where x.Nev.StartsWith("A")
               select x;

var második = from y in eredmény
              orderby y.Nev
              select y;
```
> Az SQL szerveren majd csak akkor fult le a lekérdezés, ha használni akarjuk az eredményét. Tehát az első lekérdezés eredménye nem kerül rögtön a memóriába. 

### Saját új mezők képzése (projekció), mezők elnevezése (AS)

```csharp
var eredmény = from x in context.Hallgatok 
               select new 
               {
                   nev_es_neptun = x.Nev + " - " + x.Neptun,
                   x.Hallgato_id 
               };
```
Ennek a példának az eredményeképp is létrejön egy anonym típus, de mivel itt nem csak az eredeti mezőket használjuk, a kifejezés eredményét el is kell nevezni: `nev_es_neptun =`. 

### Többtáblás lekérdezések

```csharp
var eredmény = from k in context.Konyvek
               join r in context.Rendelesek
               on k.Konyv_id equals r.Konyv
               select new 
               {
                   r.Hallgato, 
                   r.Konyv, 
                   k.Cim
               };
```
Itt már külön soriterátor van a lekérdezésen szereplő két táblához, 

De a helyzet általában nem ennyire bonyolult. Ha az adatbázis tervezésénél be voltak állítva a kényszerek (táblák közti kapcsolatok), akkor az idegen kulcsok mentén `join` írása nélkül is el lehet 'lépkedni'. Nézzünk erre egy példát: 


## Lekérdezés eredményének megjelenítése, bejárása

### Megjelenítés DataGridView-ban
Az eredményeket megjeleníthetem pl. egy rácsban:
```csharp
dataGridView1.DataSource = eredmény;
```
Ez a legegyszerűbb, hiszen a rács tetszőleges számú oszlopot meg tud jeleníteni. 

### Megjelenítés ListBox-ban

```csharp
listBoxHallgatók.DataSource = eredmény;
listBoxHallgatók.DisplayMember = "nev";
listBoxHallgatók.ValueMember = "hallgato_id";
```

A `DataGridView`-val ellentétben a `ListBox` csak egyetlen oszlopot tud megjeleníteni, ezért a `DisplayMember`  tulajdonságában meg kell neki adni, hogy melyik legyen az. Sajnos itt be kell gépelni egy string literálba a mező nevét. Ha elírjuk, az oszály neve jelenik meg benne annyiszor, ahány elemű az adatforrásként használt gyűjtemény. 

A `ListBox` `SelectedItem` tulajdonságából olvasható ki a felhasználó által kiválasztott elemhez tartozó objektum. A `SelectedItem`  `object` típusú, ezért ha használni akarjuk a kiolvasott értéket, cast-olni kell:

``` csharp
Hallgato kiválasztottHallgato = (Hallgato)listBox1.SelectedItem;
```

A `ValueMember` tulajdonságban a gyakolatban szinte mindig a saját kulcsot tartalmazó mező nevét állítjuk be. Ebben az esetben  `ListBox` `SelectedValue` tulajdonságából kiolvsható a felhasználó által kiválasztott elemhez tartozó kulcsérték. 

### Megjelenítés ComboBox-ban

A `ComboBox` szinte tökéletesen úgy működik, mint a `ListBox`, csak máshogy néz ki. A `ListBox`-ban viszont be lehet állítani, hogy több elemet is választhasson a felhasználó. 

### Az eredmény bejárása 

Az eredmény bejárható egyszerű foreach-el. (Trace -> resolve)
```csharp
foreach (Hallgatok x in eredmény)
{
    Trace.WriteLine(x.Nev);
}
```
Ugyanígy lehet fájlba is írni az eredményt. 

Ha nem ismerem az entitástípust -- vagy csak szimplán lusta vagyok--, használhatok var-t is:

```csharp
foreach (var x in eredmény)
{
    Trace.WriteLine(x.Nev);
}
```

## Miért LINQ?

Van lehetőség arra is, hogy az SQL mondatokat string formájában írjuk meg és küldjük el a szervernek, de ebben az esetben csak futás közben derül ki a hiba -- például el van gépelve egy mezőnév vagy táblanév. A gyakorlatban ritka (értsd: nincs) olyan összetettebb projekt, ahol ne válotzna az adatbázis sémája a fejlesztés során. Ha az SQL mondatok string formában vannak, nagyon körülményes annak lekövetése, hogy a sémaváltozás hol okoz gondot.