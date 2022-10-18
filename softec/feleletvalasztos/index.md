# Feleltválasztós játék
A példaalkalmazás az alábbi témákat érinti:
 - Szövegfájlok megnyitása és soromként történő olvasása 
 - Szövegfájl karakterkódolásának megadása
-  UserControlok használata 
- Metódusok túlterhelése

## Kiinduló állományok és megoldás
|||
|-|-|
|[jatek.csv](jatek.csv)|  Kérdések - pontosvesszővel tagolt sorokban
|[jatek2.txt](jatek2.txt)|Kérdések - külön sorokba fejtve
|[handout.docx](handout.docx)|Előadás handout
|[Jatek.zip](Jatek.zip)|Előadás handout
## A megoldás menete videókon

[Fájlkezelés](S1quiz1Filehandling-1.m4v)

[UserControl építése](S1quiz2Uc-2.m4v)

[UserControl-ok kirakása](S1quiz3Ucfromon-3.m4v)

[Túlterhelt konstruktor](S1quiz4Overload-4.m4v)

[Válaszok színezése](S1quiz5Coloring-5.m4v)

[CSV fájl kezelése](S1quiz6Csv-6.m4v)

[Karakterkódolások](S1quiz7Utf-7.m4v)


### Ellenőrző kérdések 

1.  A StreamReader osztály mely tulajdonságából tudható meg, hogy tudunk-e még olvasni a fájlból?
2.  Írd le azt a kódrészletet, mely megnyit egy tetszőleges szövegfájlt olvasásra, majd soronként beolvassa a tartalmát!
3.  Írd le azt a kódrészletet, mely ciklusból kirak egy űrlapra egymás alá 10 gombot!
4.  Mi a hiba a következő kódrészletbe: `StreamReader sr = new StreamReader("c:\tmp\valami.txt")`;
5.  Mit jelöl a `@` karakter stringek előtt?
6.  Hogyan lehet `string` típust `int`-é konvertálni? (Írj példát!)
7.  Hogyan lehet `int` típust `string`-é konvertálni? (Írj példát!)

## Feleltválasztós játék felépítése lépésről lépésre

> Azt tanácsoljuk, hogy a videók után önálóan probáljátok felépíteni a játékot az alábbi lépések mentén. Arra kérnénk mindenkit, hogy jelöljétek azokat a lépéseket, amivel kész vagytok, vagy ahol elakadtatok. 

### Kiinduló adatok hozzáadása a projekthez

(+/-) Töltsd le a honlapról a `jatek2.txt` állományt, és vizsgáld meg a tartalmát!

(+/-) A fájlt húzd be a projektbe és a *Properties* ablakban a *Copy to output directory* beállítást állítsd „Copy if newer”-re!

### UserControl létrehozása

(+/-) Hozz létre `UserControl`-t `KérdésUserControl` néven. A `KérdésUserControl`-ban helyezz el négy gombot és egy címkét a kérdésnek! A fenti vezérlők `Modifiers` tulajdonságát állítsd `public`-ra!

### Fájl felolvasása

(+/-) A `Form1` osztály konstruktorában a `StreamReader` osztály segítségével nyiss d meg a `jatek2.txt` fájlt.

(+/-) A `StreamReader` osztály segítségével nyisd meg a fájlt, és egy `while` ciklus segítségével olvass be cikluslépésenként hat sort találó nevű és megfelelő típusú változókba:
    -   az első sor a kérdés
    -   az ezt kévető négy sor a négy lehetséges választ tartalmazza
    -   a hatodik sor a helyes válasz sorszámát tartalmazó egész szám

(+/-) A ciklus törzsében hozz létre példányt a `KérdésUserControl-ból`, és add az űrlap vezélőiek listájához!

(+/-) Oldd meg, hogy a `KérdésUserControl`-ból létrehozott példányok egymás alá kerüljenek!

(+/-) Állítsd be `KérdésUserControl`-ból létrehozott példányban lévő címke és gomb szövegét értelemszerűen!

### Játékos válaszainak ellenőrzése

(+/-) Hozz létre egy publikus egész típusú változót a `KérdésUserControl` osztályban `JóVálasz` néven. Ebből tudja majd ellenőrizni a `KérdésUserControl`, hogy a felhasználó jó gombra kattintott-e.

10.  A sorokat olvasó ciklus törzsében a `KérdésUserControl` `JóVálasz` változóját is állítsd be!
11.  `KérdésUserControl`-ban rendelj eseménykiszolgálókat a gombokhoz. Minden eseménykiszolgáló színezze pirosra a hozzá tartozó gombot!
12.  Ezután a helyes válaszhoz tartozó gombot színezd zöldre!

### Megoldás

Kérdés UserControl code-behind
``` csharp
public partial class KérdésUserControl : UserControl
{
    int jóválasz;
    public bool eltaláta = false;

    public Kérdés()
    {
	    InitializeComponent();
    }

    public Kérdés(string kédés, string v1, string v2, string v3, string v4, int jóválasz)
    {
	    InitializeComponent();
	    label1.Text = kédés;
	    button1.Text = v1;
	    button2.Text = v2;
	    button3.Text = v3;
	    button4.Text = v4;
	    this.jóválasz = jóválasz;
    }

    private void button1_Click(object sender, EventArgs e)
    {
	    button1.BackColor = Color.Red;
	    Színezd();
	    if (jóválasz == 1) eltaláta = true;
    }

    private void button2_Click(object sender, EventArgs e) (...)
    private void button3_Click(object sender, EventArgs e) (...)
    private void button4_Click(object sender, EventArgs e) (...)

    void Színezd()
    {
	    if (jóválasz == 1) button1.BackColor = Color.Green;
	    if (jóválasz == 2) button2.BackColor = Color.Green;
	    if (jóválasz == 3) button3.BackColor = Color.Green;
	    if (jóválasz == 4) button4.BackColor = Color.Green;
    }
}
```

Form1 code-behind
``` csharp
private void Form1_Load(object sender, EventArgs e)
{
    StreamReader sr = new StreamReader("jatek.csv", Encoding.Default);
    int kérdésszám = 0;
    while (!sr.EndOfStream)
    {
        string sor = sr.ReadLine();
        string[] s = sor.Split(';');
        string kérdés = s[0];
        string v1 = s[1];
        string v2 = s[2];
        string v3 = s[3];
        string v4 = s[4];
        byte jó = byte.Parse(s[5]);

        KerdesUserControl kuc = new KerdesUserControl(kérdés, v1,v2,v3,v4,jó);
        kuc.Top = kuc.Height * kérdésszám;
        Controls.Add(kuc);

        if (kérdésszám == 100) break;

        kérdésszám++;
    }

    sr.Close();
}
```
