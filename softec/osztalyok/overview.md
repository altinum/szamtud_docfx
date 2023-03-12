# Osztályok Összefoglaló

Ez az oldal arra szolgál, hogy egy teljesebb képet adjon az osztályokról. A feltétlenül szükségesnél többet tartalmaz, de a megértéshez hasznos.
A projekt a szokásos `Windows Forms App`-ban készül, a `Form1.cs`-ben. Rendhagyó módon más fájlba nem is dolgozunk.

>[!Note]
>A hatékony tanulást segítheti, ha a kódot kipróbáljátok és játszotok vele. Az oldalon végig állatos példák lesznek, érdemes lehet a saját kódot járművekre (vagy bármi másra) megírni. 

## Alapok
Az osztályok egyfajta sablonként szolgálnak, segítségégükkel létrehozhatunk objektumokat, melyek adattagokat és metódusokat tartalmaznak. Az osztályok lehetővé teszik a programozók számára, hogy strukturáltabb és modulárisabb kódot írjanak, valamint egyszerűbbé tegyék az adatok kezelését és azokat megoszthassák a kód különböző részei között.

(!Stepper)

(!Step)[Először hozzunk létre egy eseménykiszolgálót a `Form1` load eseményére, majd hozzunk létre egy osztályt `Kutya` névvel.]

# [lényeg](#tab/focus)
```csharp
 private void Form1_Load(object sender, EventArgs e)
 {

 }
 class Kutya
 {
  
 }
```
# [teljes kód](#tab/entire)
```csharp
namespace OsztalyokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    class Kutya
    {

    }
}
```
***
(!EndStep)

(!Step)[Vegyünk fel egy `nev` változót, amiben a kutyánk nevét fogjuk rakni. Majd hozzunk létre a . `Form1_Load`-ban egy új `Kutya` objektumot és rakjuk bele egy `k` nevű változóba. Ha most megpróbálnánk kiíratni a kutya nevét, akkor nem tudjuk, mert az csak a `Kutya` osztályon belül látható, a `Form1_Load`-ban nem.]
# [lényeg](#tab/focus)
```csharp
 private void Form1_Load(object sender, EventArgs e)
        {
            Kutya k=new Kutya();
            MessageBox.Show(k.nev); //k.nev nem látszik
            //A MessageBox.Show() feldob egy ablakot azzal a szöveggel, ami a zárójelei közé kapott.
        }
 class Kutya
    {
        string nev = "Morzsa";
    }
```
# [teljes kód](#tab/entire)
```csharp
namespace OsztalyokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Kutya k=new Kutya();
            MessageBox.Show(k.name); //k.nev nem látszik
            //A MessageBox.Show() feldob egy ablakot azzal a szöveggel, ami a zárójelei közé kapott.
        }
    }
    class Kutya
    {
        string nev = "Morzsa";
    }
}
```
***

(!EndStep)

(!Step)[A megoldás, hogy átállítjuk a `nev` változót `public`-ra. Ez azt jelenti, hogy az osztályon kívül is elérhető lesz. Most, ha lefuttatjuk a progamot, fel fog ugrani egy ablak, ami kiírja, hogy "Morzsa".]
# [lényeg](#tab/focus)
```csharp
 private void Form1_Load(object sender, EventArgs e)
        {
            Kutya k=new Kutya();
            MessageBox.Show(k.nev);
        }
        class Kutya
        {
            public string nev = "Morzsa";
        }
```
# [teljes kód](#tab/entire)
```csharp
namespace OsztalyokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Kutya k=new Kutya();
            MessageBox.Show(k.nev);
        }
    }
    class Kutya
    {
        public string nev = "Morzsa";
    }
}
```
***

(!EndStep)

(!Step)[Morzsa felszedett pár kilót, ezért szeretnénk átkeresztelni Kenyérre. Ezt megtehetjük úgy, hogy `k.nev`-nek adunk egy új értéket. Ha lefuttatjuk a programot, akkor először kiírja, hogy "Morzsa", majd azt, hogy "Kenyér". Eddig egy van egy elhízott Morzsánk/Kenyerünk, de mi van, ha szeretnénk több kutyát létrehozni?]
# [lényeg](#tab/focus)
```csharp
 private void Form1_Load(object sender, EventArgs e)
        {
            Kutya k=new Kutya();
            MessageBox.Show(k.nev);
            k.nev = "Kenyér";
            MessageBox.Show(k.nev);
        }
```
# [teljes kód](#tab/entire)
```csharp
namespace OsztalyokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Kutya k=new Kutya();
            MessageBox.Show(k.nev);
            k.nev = "Kenyér";
            MessageBox.Show(k.nev);
        }
    }
    class Kutya
    {
        public string nev = "Morzsa";
    }
}
```
***

(!EndStep)

(!Step)[A `k` változónkat cseréljük ki többre, adjunk nekik nevet, majd írassuk ki a nevüket a képernyőre.]
# [lényeg](#tab/focus)
```csharp
private void Form1_Load(object sender, EventArgs e)
        {
            Kutya k1 = new Kutya();
            Kutya k2 = new Kutya();
            Kutya k3 = new Kutya();

            k2.nev = "Liza";
            k3.nev = "Bodri";

            MessageBox.Show($"k1: {k1.nev} k2: {k2.nev} k3: {k3.nev}");
            //Ha egy string elé `$` jelet teszünk, akkor a kapcsos zárójelekbe berakhatunk közvetlenül változókat, így olvashatóbb a kód és szebb, mint a +-jeles megoldással.
        }
```
# [teljes kód](#tab/entire)
```csharp
namespace OsztalyokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Kutya k1 = new Kutya();
            Kutya k2 = new Kutya();
            Kutya k3 = new Kutya();

            k2.nev = "Liza";
            k3.nev = "Bodri";

            MessageBox.Show($"k1: {k1.nev} k2: {k2.nev} k3: {k3.nev}");
             //Ha egy string elé `$` jelet teszünk, akkor a kapcsos zárójelekbe berakhatunk közvetlenül változókat, így olvashatóbb a kód és szebb, mint a +-jeles megoldással.
        }
    }
    class Kutya
    {
        public string nev = "Morzsa";
    }
}
```
***
(!Hint) Mit fog kiírni a program? [!"k1: Morzsa k2: Liza k3: Bodri", mert a `nev` alapértelmezett értéke "Morzsa".]

(!EndStep)

(!Step)[Miért pont "Morzsa" legyen az alapértelmezett neve egy kutyának? Vegyük ki.]
# [lényeg](#tab/focus)
```csharp
class Kutya
    {
        public string nev;
    }
```
# [teljes kód](#tab/entire)
```csharp
namespace OsztalyokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Kutya k1 = new Kutya();
            Kutya k2 = new Kutya();
            Kutya k3 = new Kutya();

            k2.nev = "Liza";
            k3.nev = "Bodri";

            MessageBox.Show($"k1: {k1.nev} k2: {k2.nev} k3: {k3.nev}");
        }
    }
    class Kutya
    {
        public string nev;
    }
}
```
***
(!Hint) Most mit fog kiírni a program? [!"k1: k2: Liza k3: Bodri", mert a `nev` most null és az alapból egy üres `string`.]

(!EndStep)

(!Step)[Ami nem tud ugatni, az nem lehet kutya. Hozzunk létre egy függvényt a `Kutya` osztályon belül, ami kiírja a kutya nevét és azt, hogy ugat.] 
# [lényeg](#tab/focus)
```csharp
 class Kutya
    {
        public string nev;
        public void Ugat()
        {
            MessageBox.Show(nev + " ugat.");
        }
    }
```
# [teljes kód](#tab/entire)
```csharp
namespace OsztalyokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Kutya k1 = new Kutya();
            Kutya k2 = new Kutya();
            Kutya k3 = new Kutya();

            k2.nev = "Liza";
            k3.nev = "Bodri";

        }
    }
    class Kutya
    {
        public string nev;
        public void Ugat()
        {
            MessageBox.Show(nev + " ugat.");
        }
    }
}
```
***

(!EndStep)

(!Step)[A kutyáink még nem ugatnak, mert nem hívtuk meg egyiken sem az `Ugat` metódust. Bírjuk őket ugatásra.]
# [lényeg](#tab/focus)
```csharp
 private void Form1_Load(object sender, EventArgs e)
        {
            Kutya k1 = new Kutya();
            Kutya k2 = new Kutya();
            Kutya k3 = new Kutya();

            k1.nev = "Morzsa";
            k2.nev = "Liza";
            k3.nev = "Bodri";

            k1.Ugat();
            k2.Ugat();
            k3.Ugat();
        }
```
# [teljes kód](#tab/entire)
```csharp
namespace OsztalyokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Kutya k1 = new Kutya();
            Kutya k2 = new Kutya();
            Kutya k3 = new Kutya();

            k1.nev = "Morzsa";
            k2.nev = "Liza";
            k3.nev = "Bodri";

            k1.Ugat();
            k2.Ugat();
            k3.Ugat();
        }
    }
    class Kutya
    {
        public string nev;
        public void Ugat()
        {
            MessageBox.Show(nev + " ugat.");
        }
    }
}
```
***
(!Hint) Mit fog kiírni a program? [!"Morzsa ugat","Liza ugat","Bodri ugat" három külön felugró ablakban.]

(!EndStep)

(!Step)[A programozásban van egy "DRY" akroníma, ami annak a rövidítése, hogy "Don't repeat yourself." Mi pedig háromszor ismételjük önmagunkat. Írjuk meg úgy a kódot, hogy ciklussal hozunk létre tíz kutyát.]
# [lényeg](#tab/focus)
```csharp
        private void Form1_Load(object sender, EventArgs e)
        {
            List<Kutya> kutyák=new List<Kutya>(); //hozzunk létre egy üres listát, amibe a kutyákat tesszük
            //A List egy osztály a C#-ban, amely lehetővé teszi a dinamikus méretű kollekciók tárolását és kezelését.

            List<string> kutyanevek = new List<string>() {//létrehozunk egy listát kutyanevekkel, kapcsos zárójelben egyből rakunk bele értékeket.
                "Bajusz",
                "Bodri",
                "Csipke",
                "Csonti",
                "Morzsa",
                "Cukor",
                "Csoki",
                "Liza",
                "Csíkos",
                "Foltos"
            };
            foreach (string nev in kutyanevek) //egy foreach ciklussal végigmegyünk a kutyanevek lista összes elemén
            {
                Kutya kutya = new Kutya(); //létrehozunk egy új kutya példányt a Kutya osztályból
                kutya.nev = nev; //ezt a példányt elnevezzük Bajusznak, majd Bodrinak, aztán Csipkének...
                kutyák.Add(kutya); //hozzáadjuk a kutyák listához az éppen aktuális példányt
            }

        }
```
# [teljes kód](#tab/entire)
```csharp
namespace OsztalyokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Kutya> kutyák=new List<Kutya>(); //hozzunk létre egy üres listát, amibe a kutyákat tesszük
            //A List egy osztály a C#-ban, amely lehetővé teszi a dinamikus méretű kollekciók tárolását és kezelését.

            List<string> kutyanevek = new List<string>() {//létrehozunk egy listát kutyanevekkel, kapcsos zárójelben egyből rakunk bele értékeket.
                "Bajusz",
                "Bodri",
                "Csipke",
                "Csonti",
                "Morzsa",
                "Cukor",
                "Csoki",
                "Liza",
                "Csíkos",
                "Foltos"
            };
            foreach (string nev in kutyanevek) //egy foreach ciklussal végigmegyünk a kutyanevek lista összes elemén
            {
                Kutya kutya = new Kutya(); //létrehozunk egy új kutya példányt a Kutya osztályból
                kutya.nev = nev; //ezt a példányt elnevezzük Bajusznak, majd Bodrinak, aztán Csipkének...
                kutyák.Add(kutya); //hozzáadjuk a kutyák listához az éppen aktuális példányt
            }

        }
    }
    class Kutya
    {
        public string nev;
        public void Ugat()
        {
            MessageBox.Show(nev + " ugat.");
        }
    }
}
```
***
(!Hint) Mi az a List<?> [!A List egy olyan osztály a C# programozási nyelvben, amely lehetővé teszi a dinamikus méretű kollekciók tárolását. A List osztály egy generikus osztály, amelyet típusparaméterrel lehet példányosítani, és ezzel meghatározni, hogy milyen típusú elemeket tároljon a lista.A List osztály általában többféle műveletet támogat, például az elemek hozzáadását, eltávolítását, indexelését és számlálójának lekérdezését. Ezeket a műveleteket számos beépített metódus segítségével érhetjük el, mint például az Add, a Remove, a Count és az IndexOf metódusok.Az előző példában egy List<string> típusú változót hoztunk létre, amely a típusparaméterként megadott string típusú elemeket tárolja. Ezután az Add metódussal adtunk hozzá tíz elemet a listához. A lista változót további műveletekre is használhatjuk, például a foreach ciklus segítségével bejárhatjuk az összes elemét.]

(!Hint) Hogy nézne ki `for` ciklussal a `kutyák` lista feltöltése? [!for (int i = 0; i < kutyák.Count; i++){Kutya kutya = new Kutya();kutya.nev = kutyanevek[i];kutyák.Add(kutya);}]

(!EndStep)

(!Step)[Még mielőtt átmennénk a következő részre, adjunk értelmet ennek a két ciklusnak egy harmadikkal és bírjuk ugatásra a falkát.]
# [lényeg](#tab/focus)
```csharp
            foreach (Kutya kutya in kutyák)
            {
                kutya.Ugat();
            }
            //vagy
            for (int i = 0; i < kutyák.Count; i++)
            {
                kutyák[i].Ugat();
            }
```
# [teljes kód](#tab/entire)
```csharp
namespace OsztalyokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Kutya> kutyák=new List<Kutya>(); //hozzunk létre egy üres listát, amibe a kutyákat tesszük
            //A List egy osztály a C#-ban, amely lehetővé teszi a dinamikus méretű kollekciók tárolását és kezelését.

            List<string> kutyanevek = new List<string>() {//létrehozunk egy listát kutyanevekkel, kapcsos zárójelben egyből rakunk bele értékeket.
                "Bajusz",
                "Bodri",
                "Csipke",
                "Csonti",
                "Morzsa",
                "Cukor",
                "Csoki",
                "Liza",
                "Csíkos",
                "Foltos"
            };
            foreach (string nev in kutyanevek) //egy foreach ciklussal végigmegyünk a kutyanevek lista összes elemén
            {
                Kutya kutya = new Kutya(); //létrehozunk egy új kutya példányt a Kutya osztályból
                kutya.nev = nev; //ezt a példányt elnevezzük Bajusznak, majd Bodrinak, aztán Csipkének...
                kutyák.Add(kutya); //hozzáadjuk a kutyák listához az éppen aktuális példányt
            }
            //for (int i = 0; i < kutyák.Count; i++)
            //{
            //    Kutya kutya = new Kutya();
            //    kutya.nev = kutyanevek[i];
            //    kutyák.Add(kutya);
            //}
            foreach (Kutya kutya in kutyák)
            {
                kutya.Ugat();
            }
            //vagy
            for (int i = 0; i < kutyák.Count; i++)
            {
                kutyák[i].Ugat();
            }

        }
    }
    class Kutya
    {
        public string nev;
        public void Ugat()
        {
            MessageBox.Show(nev + " ugat.");
        }
    }
}
```
***

>[!Note]
>Összefoglalva: létrehoztunk egy Kutya osztályt, ami egy tervrajz és létrehoztunk belőle sok példányt. Az osztályok példányai az objektumok. Egy kutya példánynak volt egy nev tulajdonsága és egy Ugat metódusa. 

>[!Note]
>A függvények és metódusok között annyi a különbség, hogy a metódusok egy objektumhoz tartoznak, tehát osztályszinten vannak definiálva. Gyakorlatban sokszor felváltva használják a kettő kifejezést.

(!EndStep)

(!EndStepper)

## A Konstruktor
A konstruktor egy speciális függvény az osztályon belül. Ugyanazzal a névvel rendelkezik mint, az osztály és publikus. Amikor létrehozunk egy példányt és azt írjuk le, hogy ```csharp Kutya k=new Kutya();```, akkor a `Kutya()` maga a konstruktor függvény. Ha nem hoztunk létre konstruktort az osztályban nem probléma, mert automatikusan generálódik egy.

(!Stepper)

(!Step)[Ahhoz, hogy tudjuk értékelni, hogy milyen jó dolog a konstruktor adjunk néhány új tulajdonságot a Kutya osztálynak. Nem nehéz rájönni, hogy ha ismét szeretnénk egy ciklussal létrehozni sok példányt az mennyivel több sort igényelne.]
# [lényeg](#tab/focus)
```csharp
        private void Form1_Load(object sender, EventArgs e)
        {
            Kutya kutya = new Kutya();
            kutya.nev = "Morzsa";
            kutya.fajta = "tacskó";
            kutya.hím_E = true;
            kutya.kor = 1;
            kutya.súly = 7.6f; //az f azt jelenti, hogy ez egy float típusú változó és nem double, mert ha leírom, hogy 7.6, akkor azt double-nek tekinti a C#. Nincs szükség nagy pontosságra és ezzel így nem kell parse-olni.
        }
    class Kutya
    {
        public string nev;
        public string fajta;
        public bool hím_E; //angolban isMale
        public int kor;
        public float súly;
        public void Ugat()
        {
            MessageBox.Show(nev + " ugat.");
        }
    }
```
# [teljes kód](#tab/entire)
```csharp
namespace OsztalyokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Kutya kutya = new Kutya();
            kutya.nev = "Morzsa";
            kutya.fajta = "tacskó";
            kutya.hím_E = true;
            kutya.kor = 1;
            kutya.súly = 7.6f; //az f azt jelenti, hogy ez egy float típusú változó és nem double, mert ha leírom, hogy 7.6, akkor azt double-nek tekinti a C#. Nincs szükség nagy pontosságra és ezzel így nem kell parse-olni.
        }
    }
    class Kutya
    {
        public string nev;
        public string fajta;
        public bool hím_E; //angolban isMale
        public int kor;
        public float súly;
        public void Ugat()
        {
            MessageBox.Show(nev + " ugat.");
        }
    }
}
```
***

(!EndStep)

(!Step)[Itt jön kapóra a konstruktor. Most még nem vagyunk előrébb, ezt kapjuk gyárilag is. Létrehozni a `ctor tab tab` shortcuttal is lehet. A tulajdonságok után és a metódusok elé szokás elhelyezni.]
# [lényeg](#tab/focus)
```csharp hl_lines="8:11"
    class Kutya
    {
        public string nev;
        public string fajta;
        public bool hím_E; //angolban isMale
        public int kor;
        public float súly;
        public Kutya()//ez itt a konstruktor
        {

        }
        public void Ugat()
        {
            MessageBox.Show(nev + " ugat.");
        }
    }
```
# [teljes kód](#tab/entire)
```csharp hl_lines="26:29"
namespace OsztalyokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Kutya kutya = new Kutya();
            kutya.nev = "Morzsa";
            kutya.fajta = "tacskó";
            kutya.hím_E = true;
            kutya.kor = 1;
            kutya.súly = 7.6f; //az f azt jelenti, hogy ez egy float típusú változó és nem double, mert ha leírom, hogy 7.6, akkor azt double-nek tekinti a C#. Nincs szükség nagy pontosságra és ezzel így nem kell parse-olni.
        }
    }
    class Kutya
    {
        public string nev;
        public string fajta;
        public bool hím_E; //angolban isMale
        public int kor;
        public float súly;
        public Kutya()//ez itt a konstruktor
        {

        }
        public void Ugat()
        {
            MessageBox.Show(nev + " ugat.");
        }
    }
}
```
***

(!EndStep)

(!Step)[A konstruktor arra való, hogy az általa kapott paraméterek segítségével legyártsa a példányokat. Itt minden értéket, amit kap hozzárendel az osztály megfelelő tulajdonságaihoz.]
# [lényeg](#tab/focus)
```csharp
        private void Form1_Load(object sender, EventArgs e)
        {
            Kutya kutya = new Kutya();//hibás, mert nem talál ilyen konstrukort, ami nem kér egy paramétert sem
        }
    class Kutya
    {
        public string nev;
        public string fajta;
        public bool hím_e; 
        public int kor;
        public float súly;
        public Kutya(string név,string fajta,bool hím_e,int kor, float súly)
        {
            this.nev = név; //mivel a konstruktor paraméterei között lévő név és a Kutya osztály nev tulajdonsága nem ugyanaz, ezért a this előtagra, ami az osztályra utal nincsen szükség, mindenhol máshol van.
            this.fajta = fajta;
            this.hím_e = hím_e;
            this.kor = kor;
            this.súly = súly;
        }
        public void Ugat()
        {
            MessageBox.Show(nev + " ugat.");
        }
    }
```
# [teljes kód](#tab/entire)
```csharp
namespace OsztalyokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Kutya kutya = new Kutya();//hibás, mert nem talál ilyen konstrukort, ami nem kér egy paramétert sem
        }
    }
    class Kutya
    {
        public string nev;
        public string fajta;
        public bool hím_e; 
        public int kor;
        public float súly;
        public Kutya(string név,string fajta,bool hím_e,int kor, float súly)
        {
            this.nev = név; //mivel a konstruktor paraméterei között lévő név és a Kutya osztály nev tulajdonsága nem ugyanaz, ezért a this előtagra, ami az osztályra utal nincsen szükség, mindenhol máshol van.
            this.fajta = fajta;
            this.hím_e = hím_e;
            this.kor = kor;
            this.súly = súly;
        }
        public void Ugat()
        {
            MessageBox.Show(nev + " ugat.");
        }
    }
}
```
***
(!Hint) Mit jelent a `this`? [!Osztályon belül az osztályra utal. Osztályon kívül azt mondanánk, hogy kutya1.nev, osztályon belül this.nev lenne.]

(!EndStep)

(!Step)[Nézzük meg, hogyan tudjuk használni a konstruktort.]
# [lényeg](#tab/focus)
```csharp
        private void Form1_Load(object sender, EventArgs e)
        {
            Kutya kutya = new Kutya("Morzsa","puli",true,3,25.5f); //konstruktorba, mint egy függvénynek odaadjuk az értékeket
        }
```
# [teljes kód](#tab/entire)
```csharp
namespace OsztalyokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Kutya kutya = new Kutya("Morzsa","puli",true,3,25.5f); //konstruktorba, mint egy függvénynek odaadjuk az értékeket
        }
    }
    class Kutya
    {
        public string nev;
        public string fajta;
        public bool hím_e; 
        public int kor;
        public float súly;
        public Kutya(string név,string fajta,bool hím_e,int kor, float súly)
        {
            this.nev = név; //mivel a konstruktor paraméterei között lévő név és a Kutya osztály nev tulajdonsága nem ugyanaz, ezért a this előtagra, ami az osztályra utal nincsen szükség, mindenhol máshol van.
            this.fajta = fajta;
            this.hím_e = hím_e;
            this.kor = kor;
            this.súly = súly;
        }
        public void Ugat()
        {
            MessageBox.Show(nev + " ugat.");
        }
    }
}
```
***
(!Hint) Mit jelent az f a 25.5f-ben? [!Azt, hogy az érték float (lebegő pontos szám).]

(!EndStep)

(!Step)[Állatorvos Józsinál a kliensek egy CSV fájlba vannak elmentve. Töltsük fel a kutyák listát a CSV soraiból. Az egyszerűség szellemében a CSV sorai legyenek most egy lista elemei.]
# [lényeg](#tab/focus)
```csharp
         List<string> kutyaCSV = new List<string>()
         {
            "dog1,Labrador,true,3,45.5",
            "dog2,Poodle,false,5,10.2",
            "dog3,Bulldog,true,2,30.0",
            "dog4,Golden Retriever,false,1,20.7",
            "dog5,Siberian Husky,true,4,55.0"
        };
```
# [teljes kód](#tab/entire)
```csharp
namespace OsztalyokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<string> kutyaCSV = new List<string>()
         {
            "dog1,Labrador,true,3,45.5",
            "dog2,Poodle,false,5,10.2",
            "dog3,Bulldog,true,2,30.0",
            "dog4,Golden Retriever,false,1,20.7",
            "dog5,Siberian Husky,true,4,55.0"
        };

        private void Form1_Load(object sender, EventArgs e)
        {
            Kutya kutya = new Kutya("Morzsa","puli",true,3,25.5f);
        }
    }
    class Kutya
    {
        public string nev;
        public string fajta;
        public bool hím_e; 
        public int kor;
        public float súly;
        public Kutya(string név,string fajta,bool hím_e,int kor, float súly)
        {
            
            this.nev = név; 
            this.fajta = fajta;
            this.hím_e = hím_e;
            this.kor = kor;
            this.súly = súly;
            
        }
        public void Ugat()
        {
            MessageBox.Show(nev + " ugat.");
        }
    }
}
```
***
(!Hint) Mi az a CSV? [!Comma Separated Values, egy olyan fájl, ahol az értékek valamilyen vesszővel (pontos/sima) vannak elválasztva és minden elem új sorban van.]

(!EndStep)

(!Step)[Egy foreach ciklussal menjünk végig a CSV listán és töltsük fel Kutya példányokkal a kutyák listát.]
# [lényeg](#tab/focus)
```csharp
        List<Kutya> kutyák = new List<Kutya>(); //a kutyaCSV-vel együtt most ez a lista nem a Form1_Load-ban van benne, de mivel egy osztályban van a Form1_Load ezzel és eggyel feljebb, ezért a Form1_Load-ban látszani fog.
        //ha lenne egy másik metódusa a Form1-nek, akkor a Form1_Load-ban definiált változó nem látszana a másik metódusban. A Form1_Load látja azt, ami fölötte van, (kutyaCSV, kutyák), de azt ami mellette azt nem.
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string sor in kutyaCSV)
            {
                string nev = sor.Split(',')[0]; //stringen meghívva a split metódus az feldarabolja a szövegláncot a beadott karakter szerint és egy tömböt ad vissza, itt ennek a tömbnek az első elemére van szükségünk
                string fajta = sor.Split(',')[1];
                bool him_e = bool.Parse(sor.Split(',')[2]); //mivel a him_e változó bool és a split tömb harmadik eleme string, ezért át kell konvertálni a szöveget igaz/hamissá
                int kor= int.Parse(sor.Split(',')[3]);
                float súly = float.Parse(sor.Split(',')[4]);
                kutyák.Add(new Kutya(nev, fajta, him_e, kor, súly)); //egy sorban hozzáadunk egy új Kutya példányt a kutyák listához
            }
        }
```
# [teljes kód](#tab/entire)
```csharp
namespace OsztalyokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<string> kutyaCSV = new List<string>()
        {
            "Árnyék,Labrador,true,3,45.5",
            "Karcsi,Pudli,false,5,10.2",
            "Bodri,Bulldog,true,2,30.0",
            "Tappancs,Golden Retriever,false,1,20.7",
            "Luna,Szibériai Husky,true,4,55.0"
        };

        List<Kutya> kutyák = new List<Kutya>(); //a kutyaCSV-vel együtt most ez a lista nem a Form1_Load-ban van benne, de mivel egy osztályban van a Form1_Load ezzel és eggyel feljebb, ezért a Form1_Load-ban látszani fog.
        //ha lenne egy másik metódusa a Form1-nek, akkor a Form1_Load-ban definiált változó nem látszana a másik metódusban. A Form1_Load látja azt, ami fölötte van, (kutyaCSV, kutyák), de azt ami mellette azt nem.
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string sor in kutyaCSV)
            {
                string nev = sor.Split(',')[0]; //stringen meghívva a split metódus az feldarabolja a szövegláncot a beadott karakter szerint és egy tömböt ad vissza, itt ennek a tömbnek az első elemére van szükségünk
                string fajta = sor.Split(',')[1];
                bool him_e = bool.Parse(sor.Split(',')[2]); //mivel a him_e változó bool és a split tömb harmadik eleme string, ezért át kell konvertálni a szöveget igaz/hamissá
                int kor= int.Parse(sor.Split(',')[3]);
                float súly = float.Parse(sor.Split(',')[4]);
                kutyák.Add(new Kutya(nev, fajta, him_e, kor, súly)); //egy sorban hozzáadunk egy új Kutya példányt a kutyák listához
            }
        }
    }
    class Kutya
    {
        public string nev;
        public string fajta;
        public bool hím_e; 
        public int kor;
        public float súly;
        public Kutya(string név,string fajta,bool hím_e,int kor, float súly)
        {
            
            this.nev = név; 
            this.fajta = fajta;
            this.hím_e = hím_e;
            this.kor = kor;
            this.súly = súly;
            
        }
        public void Ugat()
        {
            MessageBox.Show(nev + " ugat.");
        }
    }
}
```
***

(!EndStep)

(!Step)[Ha többször be kell olvasni ezt a listát, akkor hamar bele lehet únni abba, hogy minden értéket egyesével ki kell műteni minden sorból, még akkor is, ha nem deklaráljuk külön változóba és egyből a konstruktorba adjuk. Milyen jó lenne, ha csak a elég lenne a konstruktornak a sor-t beadni. Erre való a polimorphizmus (többalakúság).]
# [lényeg](#tab/focus)
```csharp
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string sor in kutyaCSV)
            {
                kutyák.Add(new Kutya(sor));
            }
        }
```
# [teljes kód](#tab/entire)
```csharp
namespace OsztalyokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<string> kutyaCSV = new List<string>()
        {
            "Árnyék,Labrador,true,3,45.5",
            "Karcsi,Pudli,false,5,10.2",
            "Bodri,Bulldog,true,2,30.0",
            "Tappancs,Golden Retriever,false,1,20.7",
            "Luna,Szibériai Husky,true,4,55.0"
        };

        List<Kutya> kutyák = new List<Kutya>();
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string sor in kutyaCSV)
            {
                kutyák.Add(new Kutya(sor));
            }
        }
    }
    class Kutya
    {
        public string nev;
        public string fajta;
        public bool hím_e; 
        public int kor;
        public float súly;
        public Kutya(string név,string fajta,bool hím_e,int kor, float súly)
        {
            
            this.nev = név; 
            this.fajta = fajta;
            this.hím_e = hím_e;
            this.kor = kor;
            this.súly = súly;
            
        }
        public void Ugat()
        {
            MessageBox.Show(nev + " ugat.");
        }
    }
}
```
***

(!EndStep)

(!Step)[A polimorphizmus azt jelenti, hogy egy függvényt többször is deklarálhatunk, amíg más fajta paramétereket kér az argumentumai közé. Nem csak konstruktornál működik, minden függvénynél. Így most megtehetjük azt, hogy a korábbi módon hozunk létre egy kutya példányt, hogy egyesével be tudjuk rakni a konstruktorba a tulajdonságokat, vagy egyszerűen csak egy string-et adunk és megkíméljük magunkat attól, hogy darabolni kelljen.]
# [lényeg](#tab/focus)
```csharp
        public Kutya(string csvSor) //ugyanúgy konstruktor, de más fajta paraméter(eke)-t kér
        {
            this.nev = csvSor.Split(',')[0]; //paraméterből egyből beletöltjük a név tulajdonságba
            this.fajta = csvSor.Split(',')[1];
            this.hím_e = bool.Parse(csvSor.Split(',')[2]);
            this.kor = int.Parse(csvSor.Split(',')[3]);
            this.súly = float.Parse(csvSor.Split(',')[4]);
        }
```
# [teljes kód](#tab/entire)
```csharp
namespace OsztalyokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<string> kutyaCSV = new List<string>()
        {
            "Árnyék,Labrador,true,3,45.5",
            "Karcsi,Pudli,false,5,10.2",
            "Bodri,Bulldog,true,2,30.0",
            "Tappancs,Golden Retriever,false,1,20.7",
            "Luna,Szibériai Husky,true,4,55.0"
        };

        List<Kutya> kutyák = new List<Kutya>();
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string sor in kutyaCSV)
            {
                kutyák.Add(new Kutya(sor));
            }
        }
    }
    class Kutya
    {
        public string nev;
        public string fajta;
        public bool hím_e; 
        public int kor;
        public float súly;
        public Kutya(string név,string fajta,bool hím_e,int kor, float súly)
        {
            
            this.nev = név; 
            this.fajta = fajta;
            this.hím_e = hím_e;
            this.kor = kor;
            this.súly = súly;
            
        }
        public Kutya(string csvSor) //ugyanúgy konstruktor, de más fajta paraméter(eke)-t kér
        {
            this.nev = csvSor.Split(',')[0]; //paraméterből egyből beletöltjük a név tulajdonságba
            this.fajta = csvSor.Split(',')[1];
            this.hím_e = bool.Parse(csvSor.Split(',')[2]);
            this.kor = int.Parse(csvSor.Split(',')[3]);
            this.súly = float.Parse(csvSor.Split(',')[4]);
        }
        public void Ugat()
        {
            MessageBox.Show(nev + " ugat.");
        }
    }
}
```
***
(!Hint) Melyik programozási paradigmához lehet köze annak, hogy van egy konstruktorunk, ami bekéri a csv sort? [!DRY]

(!EndStep)

(!Step)[Ha írunk három /-jelet egy függvény elé, most nézzük meg az első konstruktorral, akkor kapunk egy speciális kommentelési lehetőséget. Amit ide beírunk, az megjelenik súgó szövegként, amikor éppen az argumentumokat írjuk. A gyári függvények is így készülnek. Jobb klikkel meg lehet nézni a deklarálásukat.]
# [lényeg](#tab/focus)
```csharp
        /// <summary>
        /// Ez a Kutya osztály egyik konstruktora
        /// </summary>
        /// <param name="név"></param>
        /// <param name="fajta">kutya fajtája kisbetűvel</param>
        /// <param name="hím_e"></param>
        /// <param name="kor"></param>
        /// <param name="súly">kutya súlya kg-ban</param>
        public Kutya(string név,string fajta,bool hím_e,int kor, float súly)
        {
            this.nev = név; 
            this.fajta = fajta;
            this.hím_e = hím_e;
            this.kor = kor;
            this.súly = súly;
            
        }
```
# [teljes kód](#tab/entire)
```csharp
namespace OsztalyokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<string> kutyaCSV = new List<string>()
        {
            "Árnyék,Labrador,true,3,45.5",
            "Karcsi,Pudli,false,5,10.2",
            "Bodri,Bulldog,true,2,30.0",
            "Tappancs,Golden Retriever,false,1,20.7",
            "Luna,Szibériai Husky,true,4,55.0"
        };

        List<Kutya> kutyák = new List<Kutya>();
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string sor in kutyaCSV)
            {
                kutyák.Add(new Kutya(sor));
            }
        }
    }
    class Kutya
    {
        public string nev;
        public string fajta;
        public bool hím_e; 
        public int kor;
        public float súly;
        /// <summary>
        /// Ez a Kutya osztály egyik konstruktora
        /// </summary>
        /// <param name="név"></param>
        /// <param name="fajta">kutya fajtája kisbetűvel</param>
        /// <param name="hím_e"></param>
        /// <param name="kor"></param>
        /// <param name="súly">kutya súlya kg-ban</param>
        public Kutya(string név,string fajta,bool hím_e,int kor, float súly)
        {
            this.nev = név; 
            this.fajta = fajta;
            this.hím_e = hím_e;
            this.kor = kor;
            this.súly = súly;
            
        }
        public Kutya(string csvSor)
        {
            this.nev = csvSor.Split(',')[0];
            this.fajta = csvSor.Split(',')[1];
            this.hím_e = bool.Parse(csvSor.Split(',')[2]);
            this.kor = int.Parse(csvSor.Split(',')[3]);
            this.súly = float.Parse(csvSor.Split(',')[4]);
        }
        public void Ugat()
        {
            MessageBox.Show(nev + " ugat.");
        }
    }
}
```
***

>[!Note]
>Összefoglalva: A konstruktor egy olyan függvény, ami akkor hívódik, meg, ha egy új példányt szeretnénk létrehozni egy osztályból. Többet is létrehozhatunk, amíg más a lenyomatuk, azaz más paramétereket kérnek. Visszaadja a példányt, amit létrehozott.

(!EndStep)

(!EndStepper)

## Tulajdonságok

Eddig amit tulajdonságnak hívtunk, az igazából csak egy adattag. A kettő között az a különbség, hogy amit eddig használtunk, az egy publikus mező volt, mindenhol lehetett látni kívül. Amikor alapértelmezett privát volt, kívülről nem lehetett elérni. A tulajdonság ezzel szemben egy ügynök, ami ezt a privát mezőt elérhetővé teszi a külső kód számára. Felmerülhet a kérdés, hogy mire jó ez az extra réteg bonyolultság. Biztonságosabbá teszi az osztályt, nagyobb kontrolt biztosít az adatok felett és lehetőséget ad dinamikusan számított tulajdonságok használatára is.

(!Stepper)

(!Step)[Elsőre bonyolultnak tűnhet, de nem az. A get és a set két speciális függvény, ami akkor fut le, ha lekérjük az adott tulajdonságot vagy értéket szeretnénk adni neki.]
# [lényeg](#tab/focus)
```csharp
        private string nev; //privát változó az osztályban
        public string Nev //publikus tulajdonság kifelé
        {
            get { return this.nev; }
            set { this.nev = value; }
        }
```
# [teljes kód](#tab/entire)
```csharp
namespace OsztalyokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Kutya> kutyák = new List<Kutya>();
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
    class Kutya
    {
        private string nev; //privát változó az osztályban
        public string Nev //publikus tulajdonság kifelé
        {
            get { return this.nev; }
            set { this.nev = value; }
        }

        public string fajta;
        public bool hím_e; 
        public int kor;
        public float súly;
        public Kutya(string név,string fajta,bool hím_e,int kor, float súly)
        {
            this.Nev = név; 
            this.fajta = fajta;
            this.hím_e = hím_e;
            this.kor = kor;
            this.súly = súly;
            
        }
        public void Ugat()
        {
            MessageBox.Show(nev + " ugat.");
        }
    }
}
```
***

>[!Tip]
>`propfull tab tab` shortcuttal is létre lehet hozni

(!EndStep)

(!Step)[A privát mező el is hagyható.]
# [lényeg](#tab/focus)
```csharp
        public string Nev
        {
            get { return this.Nev; }
            set { this.Nev = value; }
        }
```
# [teljes kód](#tab/entire)
```csharp
namespace OsztalyokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Kutya> kutyák = new List<Kutya>();
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
    class Kutya
    {
        public string Nev
        {
            get { return this.Nev; }
            set { this.Nev = value; }
        }

        public string fajta;
        public bool hím_e; 
        public int kor;
        public float súly;
        public Kutya(string név,string fajta,bool hím_e,int kor, float súly)
        {
            this.Nev = név; 
            this.fajta = fajta;
            this.hím_e = hím_e;
            this.kor = kor;
            this.súly = súly;
            
        }
        public void Ugat()
        {
            MessageBox.Show(nev + " ugat.");
        }
    }
}
```
***

(!EndStep)

(!Step)[Sőt, a gettert és settert is le lehet rövidíteni.]
# [lényeg](#tab/focus)
```csharp
        public string Nev
        {
            get;
            set;
        }
```
# [teljes kód](#tab/entire)
```csharp
namespace OsztalyokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Kutya> kutyák = new List<Kutya>();
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
    class Kutya
    {
        public string Nev
        {
            get;
            set;
        }

        public string fajta;
        public bool hím_e; 
        public int kor;
        public float súly;
        public Kutya(string név,string fajta,bool hím_e,int kor, float súly)
        {
            this.Nev = név; 
            this.fajta = fajta;
            this.hím_e = hím_e;
            this.kor = kor;
            this.súly = súly;
            
        }
        public void Ugat()
        {
            MessageBox.Show(nev + " ugat.");
        }
    }
}
```
***

(!EndStep)

(!Step)[Írjuk is át a többi adattagot, hogy tulajdonságok legyenek.]
# [lényeg](#tab/focus)
```csharp
    class Kutya
    {
        public string Nev{get;set;} //csak át lett rendezve
        public string Fajta { get; set; }
        public bool Hím_e { get; set; }
        public int Kor { get; set; }
        public float Súly { get; set; }
        public Kutya(string név,string fajta,bool hím_e,int kor, float súly)
        {
            this.Nev = név; 
            this.Fajta = fajta;
            this.Hím_e = hím_e;
            this.Kor = kor;
            this.Súly = súly;
            
        }
        public void Ugat()
        {
            MessageBox.Show(Nev + " ugat.");
        }
    }
```
# [teljes kód](#tab/entire)
```csharp
namespace OsztalyokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Kutya> kutyák = new List<Kutya>();
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
    class Kutya
    {
        public string Nev{get;set;} //csak át lett rendezve
        public string Fajta { get; set; }
        public bool Hím_e { get; set; }
        public int Kor { get; set; }
        public float Súly { get; set; }
        public Kutya(string név,string fajta,bool hím_e,int kor, float súly)
        {
            this.Nev = név; 
            this.Fajta = fajta;
            this.Hím_e = hím_e;
            this.Kor = kor;
            this.Súly = súly;
            
        }
        public void Ugat()
        {
            MessageBox.Show(Nev + " ugat.");
        }
    }
}
```
***
(!Hint) Miért neveztük át kis betűsről nagy betűsre a tulajdonságokat? [!Mert a C#-ban konvenció és olvashatóbb lesz tőle a kód. A program futása szempontjából nincs jelentősége.]

>[!Tip]
>`prop tab tab` shortcuttal gyorsabb

(!EndStep)

(!Step)[Eddig nem tudott többet semmivel ez az új megoldás. Ha a csv-fájlt egy napnál tovább használjuk fennál az esélye, hogy változik. Hogyan? Valamelyik kutya betölti a születésnapját. Ezt úgy tudjuk megoldani, hogy kor helyett születésnapot veszünk fel és a kor-t dinamikusan számoljuk.]
# [lényeg](#tab/focus)
```csharp
    class Kutya
    {
        public string Nev { get; set; }
        public string Fajta { get; set; }
        public bool Hím_e { get; set; }
        public DateTime Születésnap { get; set; } //a DateTime egy elképesztően hasznos beépített osztály C#-ban, amivel lehet dátumokat kezelni
        public int Kor
        {
            get
            {
                DateTime maiDatum = DateTime.Now; //mai dátumot megkapjuk a DateTime osztály Now tulajdonságából
                int kor = maiDatum.Year - this.Születésnap.Year; //megnézzük hány év telt el
                if (maiDatum.Month < Születésnap.Month || (maiDatum.Month == Születésnap.Month && maiDatum.Day < Születésnap.Day))
                {
                    kor--; //Ha ebben az évben még nem töltötte be a születésnapját vonjunk le egy évet
                }
                return kor;
            }
        }
        public float Súly { get; set; }
        public Kutya(string név, string fajta, bool hím_e, DateTime születésNap, float súly) //kort kicserérljük születésnapra
        {
            this.Nev = név;
            this.Fajta = fajta;
            this.Hím_e = hím_e;
            this.Születésnap = születésNap; //új
            this.Súly = súly;

        }
        public void Ugat()
        {
            MessageBox.Show(Nev + " ugat.");
        }
    }
```
# [teljes kód](#tab/entire)
```csharp
namespace OsztalyokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Kutya> kutyák = new List<Kutya>();
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    class Kutya
    {
        public string Nev { get; set; }
        public string Fajta { get; set; }
        public bool Hím_e { get; set; }
        public DateTime Születésnap { get; set; } //a DateTime egy elképesztően hasznos beépített osztály C#-ban, amivel lehet dátumokat kezelni
        public int Kor
        {
            get
            {
                DateTime maiDatum = DateTime.Now; //mai dátumot megkapjuk a DateTime osztály Now tulajdonságából
                int kor = maiDatum.Year - this.Születésnap.Year; //megnézzük hány év telt el
                if (maiDatum.Month < Születésnap.Month || (maiDatum.Month == Születésnap.Month && maiDatum.Day < Születésnap.Day))
                {
                    kor--; //Ha ebben az évben még nem töltötte be a születésnapját vonjunk le egy évet
                }
                return kor;
            }
        }
        public float Súly { get; set; }
        public Kutya(string név, string fajta, bool hím_e, DateTime születésNap, float súly) //kort kicserérljük születésnapra
        {
            this.Nev = név;
            this.Fajta = fajta;
            this.Hím_e = hím_e;
            this.Születésnap = születésNap; //új
            this.Súly = súly;

        }
        public void Ugat()
        {
            MessageBox.Show(Nev + " ugat.");
        }
    }
}
```
***

(!EndStep)

(!Step)[Próbáljuk ki!]
# [lényeg](#tab/focus)
```csharp
        private void Form1_Load(object sender, EventArgs e)
        {
            Kutya aida = new Kutya("Aida", "németjuhász", false,new DateTime(2013,11,15),37f);
            //A DateTime-nak sok konstruktora van, köztük egy olyan is, ami pont egy év,hónap,nap-ot kér
            MessageBox.Show($"Aida {aida.Kor} éves.");
        }
```
# [teljes kód](#tab/entire)
```csharp
namespace OsztalyokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Kutya> kutyák = new List<Kutya>();
        private void Form1_Load(object sender, EventArgs e)
        {
            Kutya aida = new Kutya("Aida", "németjuhász", false,new DateTime(2013,11,15),37f);
            //A DateTime-nak sok konstruktora van, köztük egy olyan is, ami pont egy év,hónap,nap-ot kér
            MessageBox.Show($"Aida {aida.Kor} éves.");
        }
    }
    class Kutya
    {
        public string Nev { get; set; }
        public string Fajta { get; set; }
        public bool Hím_e { get; set; }
        public DateTime Születésnap { get; set; }
        public int Kor
        {
            get
            {
                DateTime maiDatum = DateTime.Now;
                int kor = maiDatum.Year - this.Születésnap.Year;
                if (maiDatum.Month < Születésnap.Month || (maiDatum.Month == Születésnap.Month && maiDatum.Day < Születésnap.Day))
                {
                    kor--;
                }
                return kor;
            }
        }
        public float Súly { get; set; }
        public Kutya(string név, string fajta, bool hím_e, DateTime születésNap, float súly)
        {
            this.Nev = név;
            this.Fajta = fajta;
            this.Hím_e = hím_e;
            this.Születésnap = születésNap;
            this.Súly = súly;

        }
        public void Ugat()
        {
            MessageBox.Show(Nev + " ugat.");
        }
    }
}
```
***

>[!Tip]
>Érdemes lehet megnézni a élesben osztályokat. Például ha jobb klikkel rákattintunk a `DateTime`-ra és kiválasztjuk, hogy go to definition, akkor megnézhetjük, hogy hogyan alkalmazzák a fent említetteket.

(!EndStep)

(!EndStepper)

## Öröklés
Az öröklés egy olyan objektumorientált programozási fogalom, amely lehetővé teszi, hogy egy osztály örökölje az egy másik osztályban definiált adattagokat és metódusokat. Az öröklődés révén a leszármazott osztály (a gyermek osztály) a szülő osztályban (az ősosztály) definiált tulajdonságokat és viselkedést örökli, majd azt tovább bővítheti vagy módosíthatja. Ezáltal az öröklés elősegíti a kód újrafelhasználását és a hierarchikus osztálystruktúrák létrehozását a programozás során. Az öröklődési hierarchia fába szervezhető, ahol az ősosztály a gyökér, és az összes leszármazott osztály a fa másik pontján található.

(!Stepper)

(!Step)[Hozzunk létre egy Macska osztályt is.]
# [lényeg](#tab/focus)
```csharp
class Macska
    {
        public string Nev { get; set; }
        public string Fajta { get; set; }
        public bool Hím_e { get; set; }
        public DateTime Születésnap { get; set; }
        public int Kor
        {
            get
            {
                DateTime maiDatum = DateTime.Now;
                int kor = maiDatum.Year - this.Születésnap.Year;
                if (maiDatum.Month < Születésnap.Month || (maiDatum.Month == Születésnap.Month && maiDatum.Day < Születésnap.Day))
                {
                    kor--;
                }
                return kor;
            }
        }
        public float Súly { get; set; }
        public Macska(string név, string fajta, bool hím_e, DateTime születésNap, float súly)
        {
            this.Nev = név;
            this.Fajta = fajta;
            this.Hím_e = hím_e;
            this.Születésnap = születésNap;
            this.Súly = súly;
        }
        public void Nyávog()
        {
            MessageBox.Show(Nev + " nyávog.");
        }

    }
```
# [teljes kód](#tab/entire)
```csharp
namespace OsztalyokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Kutya> kutyák = new List<Kutya>();
        private void Form1_Load(object sender, EventArgs e)
        {
            Kutya aida = new Kutya("Aida", "németjuhász", false,new DateTime(2013,11,15),37f);
            //A DateTime-nak sok konstruktora van, köztük egy olyan is, ami pont egy év,hónap,nap-ot kér
            MessageBox.Show($"Aida {aida.Kor} éves.");
        }
    }
    class Macska
    {
        public string Nev { get; set; }
        public string Fajta { get; set; }
        public bool Hím_e { get; set; }
        public DateTime Születésnap { get; set; }
        public int Kor
        {
            get
            {
                DateTime maiDatum = DateTime.Now;
                int kor = maiDatum.Year - this.Születésnap.Year;
                if (maiDatum.Month < Születésnap.Month || (maiDatum.Month == Születésnap.Month && maiDatum.Day < Születésnap.Day))
                {
                    kor--;
                }
                return kor;
            }
        }
        public float Súly { get; set; }
        public Macska(string név, string fajta, bool hím_e, DateTime születésNap, float súly)
        {
            this.Nev = név;
            this.Fajta = fajta;
            this.Hím_e = hím_e;
            this.Születésnap = születésNap;
            this.Súly = súly;
        }
        public void Nyávog()
        {
            MessageBox.Show(Nev + " nyávog.");
        }

    }
    class Kutya
    {
        public string Nev { get; set; }
        public string Fajta { get; set; }
        public bool Hím_e { get; set; }
        public DateTime Születésnap { get; set; }
        public int Kor
        {
            get
            {
                DateTime maiDatum = DateTime.Now;
                int kor = maiDatum.Year - this.Születésnap.Year;
                if (maiDatum.Month < Születésnap.Month || (maiDatum.Month == Születésnap.Month && maiDatum.Day < Születésnap.Day))
                {
                    kor--;
                }
                return kor;
            }
        }
        public float Súly { get; set; }
        public Kutya(string név, string fajta, bool hím_e, DateTime születésNap, float súly)
        {
            this.Nev = név;
            this.Fajta = fajta;
            this.Hím_e = hím_e;
            this.Születésnap = születésNap;
            this.Súly = súly;

        }
        public void Ugat()
        {
            MessageBox.Show(Nev + " ugat.");
        }
    }
}
```
***
(!Hint) Mi a különbség a két osztály között? [!Csak annyi, hogy a Kutya ugat, a Macska nyávog.]

(!EndStep)

(!Step)[Hogy ne ismételjük magunkat hozzunkk létre egy Állat osztályt és származtassuk a Kutya és Macska osztályt belőle.]
# [lényeg](#tab/focus)
```csharp
    class Allat
    {
        public string Nev { get; set; }
        public string Fajta { get; set; }
        public bool Hím_e { get; set; }
        public DateTime Születésnap { get; set; }
        public int Kor
        {
            get
            {
                DateTime maiDatum = DateTime.Now;
                int kor = maiDatum.Year - this.Születésnap.Year;
                if (maiDatum.Month < Születésnap.Month || (maiDatum.Month == Születésnap.Month && maiDatum.Day < Születésnap.Day))
                {
                    kor--;
                }
                return kor;
            }
        }
        public float Súly { get; set; }
    }
    class Macska : Allat
    {
        public Macska(string név, string fajta, bool hím_e, DateTime születésNap, float súly)
        {
            this.Nev = név;
            this.Fajta = fajta;
            this.Hím_e = hím_e;
            this.Születésnap = születésNap;
            this.Súly = súly;
        }
        public void Nyávog()
        {
            MessageBox.Show(Nev + " nyávog.");
        }
    }
    class Kutya : Allat
    {
        public Kutya(string név, string fajta, bool hím_e, DateTime születésNap, float súly)
        {
            this.Nev = név;
            this.Fajta = fajta;
            this.Hím_e = hím_e;
            this.Születésnap = születésNap;
            this.Súly = súly;

        }
        public void Ugat()
        {
            MessageBox.Show(Nev + " ugat.");
        }
    }
```
# [teljes kód](#tab/entire)
```csharp
namespace OsztalyokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Kutya> kutyák = new List<Kutya>();
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    class Allat
    {
        public string Nev { get; set; }
        public string Fajta { get; set; }
        public bool Hím_e { get; set; }
        public DateTime Születésnap { get; set; }
        public int Kor
        {
            get
            {
                DateTime maiDatum = DateTime.Now;
                int kor = maiDatum.Year - this.Születésnap.Year;
                if (maiDatum.Month < Születésnap.Month || (maiDatum.Month == Születésnap.Month && maiDatum.Day < Születésnap.Day))
                {
                    kor--;
                }
                return kor;
            }
        }
        public float Súly { get; set; }
    }
    class Macska : Allat
    {
        public Macska(string név, string fajta, bool hím_e, DateTime születésNap, float súly)
        {
            this.Nev = név;
            this.Fajta = fajta;
            this.Hím_e = hím_e;
            this.Születésnap = születésNap;
            this.Súly = súly;
        }
        public void Nyávog()
        {
            MessageBox.Show(Nev + " nyávog.");
        }
    }
    class Kutya : Allat
    {
        public Kutya(string név, string fajta, bool hím_e, DateTime születésNap, float súly)
        {
            this.Nev = név;
            this.Fajta = fajta;
            this.Hím_e = hím_e;
            this.Születésnap = születésNap;
            this.Súly = súly;

        }
        public void Ugat()
        {
            MessageBox.Show(Nev + " ugat.");
        }
    }
}
```
***

>[!Note]
>Mindent, ami közös, átvittünk a szülő (Állat) osztályba. Ez azért is jó, mert ha valamin változtatni kell a tulajdonságok között, akkor azt csak egy helyen kell megtenni.

(!EndStep)

(!Step)[Viszont a konstruktort még mindig ismételjük. Csináljunk az Állat-nak egy konstruktort. Ezután a Kutya és a Macska konstruktorát a base kulcsszó segítségével rá tudjuk kötni az Állat konstruktorára, így amikor az lefut, első dolga lesz meghívni az Állat konstruktort.]
# [lényeg](#tab/focus)
```csharp
    class Allat
    {
        public string Nev { get; set; }
        public string Fajta { get; set; }
        public bool Hím_e { get; set; }
        public DateTime Születésnap { get; set; }
        public int Kor
        {
            get
            {
                DateTime maiDatum = DateTime.Now;
                int kor = maiDatum.Year - this.Születésnap.Year;
                if (maiDatum.Month < Születésnap.Month || (maiDatum.Month == Születésnap.Month && maiDatum.Day < Születésnap.Day))
                {
                    kor--;
                }
                return kor;
            }
        }
        public float Súly { get; set; }
        public Allat(string név, string fajta, bool hím_e, DateTime születésNap, float súly)
        {
            this.Nev = név;
            this.Fajta = fajta;
            this.Hím_e = hím_e;
            this.Születésnap = születésNap;
            this.Súly = súly;
        }
    }
    class Macska : Allat
    {
        public Macska(string név, string fajta, bool hím_e, DateTime születésNap, float súly) : base(név, fajta, hím_e, születésNap, súly)
        {

        }
        public void Nyávog()
        {
            MessageBox.Show(Nev + " nyávog.");
        }
    }
    class Kutya : Allat
    {
        public Kutya(string név, string fajta, bool hím_e, DateTime születésNap, float súly) : base(név, fajta, hím_e, születésNap, súly)
        {

        }
        public void Ugat()
        {
            MessageBox.Show(Nev + " ugat.");
        }
    }
```
# [teljes kód](#tab/entire)
```csharp
namespace OsztalyokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Kutya> kutyák = new List<Kutya>();
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    class Allat
    {
        public string Nev { get; set; }
        public string Fajta { get; set; }
        public bool Hím_e { get; set; }
        public DateTime Születésnap { get; set; }
        public int Kor
        {
            get
            {
                DateTime maiDatum = DateTime.Now;
                int kor = maiDatum.Year - this.Születésnap.Year;
                if (maiDatum.Month < Születésnap.Month || (maiDatum.Month == Születésnap.Month && maiDatum.Day < Születésnap.Day))
                {
                    kor--;
                }
                return kor;
            }
        }
        public float Súly { get; set; }
        public Allat(string név, string fajta, bool hím_e, DateTime születésNap, float súly)
        {
            this.Nev = név;
            this.Fajta = fajta;
            this.Hím_e = hím_e;
            this.Születésnap = születésNap;
            this.Súly = súly;
        }
    }
    class Macska : Allat
    {
        public Macska(string név, string fajta, bool hím_e, DateTime születésNap, float súly) : base(név, fajta, hím_e, születésNap, súly)
        {

        }
        public void Nyávog()
        {
            MessageBox.Show(Nev + " nyávog.");
        }
    }
    class Kutya : Allat
    {
        public Kutya(string név, string fajta, bool hím_e, DateTime születésNap, float súly) : base(név, fajta, hím_e, születésNap, súly)
        {

        }
        public void Ugat()
        {
            MessageBox.Show(Nev + " ugat.");
        }
    }
}
```
***
(!Hint) Mit jelent a `base`? [!Ugyanolyan, mint a "this", csak nem az adott osztályra utal, hanem az adott osztály közvetlen ősére, a szülőre.]

(!EndStep)

(!Step)[Nézzük meg hogy viselkednek ezek az osztályok a gyakorlatban. Gond nélkül hozzá tudjuk adni őket egy listához, mert mindent örökölnek, ami ahhoz kell, hogy Allat-ok legyenek.]
# [lényeg](#tab/focus)
```csharp
        List<Allat> allatok = new List<Allat>();
        private void Form1_Load(object sender, EventArgs e)
        {
            Macska m = new Macska("Cirmi", "sziámi", true, new DateTime(2022, 3, 27), 1.5f);
            Kutya k = new Kutya("Aida", "németjuhász", false, new DateTime(2013, 11, 15), 37f);

            allatok.Add(m);
            allatok.Add(k);

            MessageBox.Show(allatok[0].Nev + " " + allatok[1].Nev);
        }
```
# [teljes kód](#tab/entire)
```csharp
namespace OsztalyokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Allat> allatok = new List<Allat>();
        private void Form1_Load(object sender, EventArgs e)
        {
            Macska m = new Macska("Cirmi", "sziámi", true, new DateTime(2022, 3, 27), 1.5f);
            Kutya k = new Kutya("Aida", "németjuhász", false, new DateTime(2013, 11, 15), 37f);

            allatok.Add(m);
            allatok.Add(k);

            MessageBox.Show(allatok[0].Nev + " " + allatok[1].Nev);
        }
    }
    class Allat
    {
        public string Nev { get; set; }
        public string Fajta { get; set; }
        public bool Hím_e { get; set; }
        public DateTime Születésnap { get; set; }
        public int Kor
        {
            get
            {
                DateTime maiDatum = DateTime.Now;
                int kor = maiDatum.Year - this.Születésnap.Year;
                if (maiDatum.Month < Születésnap.Month || (maiDatum.Month == Születésnap.Month && maiDatum.Day < Születésnap.Day))
                {
                    kor--;
                }
                return kor;
            }
        }
        public float Súly { get; set; }
        public Allat(string név, string fajta, bool hím_e, DateTime születésNap, float súly)
        {
            this.Nev = név;
            this.Fajta = fajta;
            this.Hím_e = hím_e;
            this.Születésnap = születésNap;
            this.Súly = súly;
        }
    }
    class Macska : Allat
    {
        public Macska(string név, string fajta, bool hím_e, DateTime születésNap, float súly) : base(név, fajta, hím_e, születésNap, súly)
        {

        }
        public void Nyávog()
        {
            MessageBox.Show(Nev + " nyávog.");
        }
    }
    class Kutya : Allat
    {
        public Kutya(string név, string fajta, bool hím_e, DateTime születésNap, float súly) : base(név, fajta, hím_e, születésNap, súly)
        {

        }
        public void Ugat()
        {
            MessageBox.Show(Nev + " ugat.");
        }
    }
}
```
***

(!EndStep)

(!Step)[Lehet továbbá metódusokat felülírni. Nézzünk rá egy példát. Vegyük fel az Allat osztályba azt a metódust, hogy Vedlik().]
# [lényeg](#tab/focus)
```csharp
class Allat
    {
        public string Nev { get; set; }
        public string Fajta { get; set; }
        public bool Hím_e { get; set; }
        public DateTime Születésnap { get; set; }
        public int Kor
        {
            get
            {
                DateTime maiDatum = DateTime.Now;
                int kor = maiDatum.Year - this.Születésnap.Year;
                if (maiDatum.Month < Születésnap.Month || (maiDatum.Month == Születésnap.Month && maiDatum.Day < Születésnap.Day))
                {
                    kor--;
                }
                return kor;
            }
        }
        public float Súly { get; set; }
        public Allat(string név, string fajta, bool hím_e, DateTime születésNap, float súly)
        {
            this.Nev = név;
            this.Fajta = fajta;
            this.Hím_e = hím_e;
            this.Születésnap = születésNap;
            this.Súly = súly;
        }
        public void Vedlik()
        {
            MessageBox.Show(Nev + " vedlik.");
        }
    }
```
# [teljes kód](#tab/entire)
```csharp
namespace OsztalyokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Allat> allatok = new List<Allat>();
        private void Form1_Load(object sender, EventArgs e)
        {
            Macska m = new Macska("Cirmi", "sziámi", true, new DateTime(2022, 3, 27), 1.5f);
            Kutya k = new Kutya("Aida", "németjuhász", false, new DateTime(2013, 11, 15), 37f);

            allatok.Add(m);
            allatok.Add(k);

            MessageBox.Show(allatok[0].Nev + " " + allatok[1].Nev);
        }
    }
    class Allat
    {
        public string Nev { get; set; }
        public string Fajta { get; set; }
        public bool Hím_e { get; set; }
        public DateTime Születésnap { get; set; }
        public int Kor
        {
            get
            {
                DateTime maiDatum = DateTime.Now;
                int kor = maiDatum.Year - this.Születésnap.Year;
                if (maiDatum.Month < Születésnap.Month || (maiDatum.Month == Születésnap.Month && maiDatum.Day < Születésnap.Day))
                {
                    kor--;
                }
                return kor;
            }
        }
        public float Súly { get; set; }
        public Allat(string név, string fajta, bool hím_e, DateTime születésNap, float súly)
        {
            this.Nev = név;
            this.Fajta = fajta;
            this.Hím_e = hím_e;
            this.Születésnap = születésNap;
            this.Súly = súly;
        }
        public void Vedlik()
        {
            MessageBox.Show(Nev + " vedlik.");
        }
    }
    class Macska : Allat
    {
        public Macska(string név, string fajta, bool hím_e, DateTime születésNap, float súly) : base(név, fajta, hím_e, születésNap, súly)
        {

        }
        public void Nyávog()
        {
            MessageBox.Show(Nev + " nyávog.");
        }
    }
    class Kutya : Allat
    {
        public Kutya(string név, string fajta, bool hím_e, DateTime születésNap, float súly) : base(név, fajta, hím_e, születésNap, súly)
        {

        }
        public void Ugat()
        {
            MessageBox.Show(Nev + " ugat.");
        }
    }
}
```
***
(!Hint) Miért tudom meghívni Aidán és Cirmi-n a Vedlik() metódust? [!Mert mind a ketten öröklik az Allat osztálytól.]

(!EndStep)

(!Step)[Írjuk felül a Allat osztály Vedlik() metódusát a Macska osztályban. Ehhez virtuálisnak kell jelölni az Állat osztályban, és override-nak a Macska osztályban.]
# [lényeg](#tab/focus)
```csharp
    class Allat
    {
        public string Nev { get; set; }
        public string Fajta { get; set; }
        public bool Hím_e { get; set; }
        public DateTime Születésnap { get; set; }
        public int Kor
        {
            get
            {
                DateTime maiDatum = DateTime.Now;
                int kor = maiDatum.Year - this.Születésnap.Year;
                if (maiDatum.Month < Születésnap.Month || (maiDatum.Month == Születésnap.Month && maiDatum.Day < Születésnap.Day))
                {
                    kor--;
                }
                return kor;
            }
        }
        public float Súly { get; set; }
        public Allat(string név, string fajta, bool hím_e, DateTime születésNap, float súly)
        {
            this.Nev = név;
            this.Fajta = fajta;
            this.Hím_e = hím_e;
            this.Születésnap = születésNap;
            this.Súly = súly;
        }
        public virtual void Vedlik()//virtuálisnak jelöljük
        {
            MessageBox.Show(Nev + " vedlik.");
        }
    }
    class Macska : Allat
    {
        public Macska(string név, string fajta, bool hím_e, DateTime születésNap, float súly) : base(név, fajta, hím_e, születésNap, súly)
        {

        }
        public void Nyávog()
        {
            MessageBox.Show(Nev + " nyávog.");
        }
        public override void Vedlik()//override-nak jelöljük
        {
            base.Vedlik(); //meghívjuk az eredeti vedlik metódust
            MessageBox.Show("És mivel macska, ezért megeszi a szőrt");
        }
    }
```
# [teljes kód](#tab/entire)
```csharp
namespace OsztalyokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Allat> allatok = new List<Allat>();
        private void Form1_Load(object sender, EventArgs e)
        {
            Macska m = new Macska("Cirmi", "sziámi", true, new DateTime(2022, 3, 27), 1.5f);
            Kutya k = new Kutya("Aida", "németjuhász", false, new DateTime(2013, 11, 15), 37f);

            allatok.Add(m);
            allatok.Add(k);

            MessageBox.Show(allatok[0].Nev + " " + allatok[1].Nev);
        }
    }
    class Allat
    {
        public string Nev { get; set; }
        public string Fajta { get; set; }
        public bool Hím_e { get; set; }
        public DateTime Születésnap { get; set; }
        public int Kor
        {
            get
            {
                DateTime maiDatum = DateTime.Now;
                int kor = maiDatum.Year - this.Születésnap.Year;
                if (maiDatum.Month < Születésnap.Month || (maiDatum.Month == Születésnap.Month && maiDatum.Day < Születésnap.Day))
                {
                    kor--;
                }
                return kor;
            }
        }
        public float Súly { get; set; }
        public Allat(string név, string fajta, bool hím_e, DateTime születésNap, float súly)
        {
            this.Nev = név;
            this.Fajta = fajta;
            this.Hím_e = hím_e;
            this.Születésnap = születésNap;
            this.Súly = súly;
        }
        public virtual void Vedlik()//virtuálisnak jelöljük
        {
            MessageBox.Show(Nev + " vedlik.");
        }
    }
    class Macska : Allat
    {
        public Macska(string név, string fajta, bool hím_e, DateTime születésNap, float súly) : base(név, fajta, hím_e, születésNap, súly)
        {

        }
        public void Nyávog()
        {
            MessageBox.Show(Nev + " nyávog.");
        }
        public override void Vedlik()//override-nak jelöljük
        {
            base.Vedlik(); //meghívjuk az eredeti vedlik metódust
            MessageBox.Show("És mivel macska, ezért megeszi a szőrt");
        }
    }
    class Kutya : Allat
    {
        public Kutya(string név, string fajta, bool hím_e, DateTime születésNap, float súly) : base(név, fajta, hím_e, születésNap, súly)
        {

        }
        public void Ugat()
        {
            MessageBox.Show(Nev + " ugat.");
        }
    }
}
```
***
(!Hint) Mi fog történni a Kutya Vedlik() metódusával? [!Semmi, változatlan formában örökli az Allat-tól.]

>[!Note]
>Nem csak függvényeket, de operátorokat is felül lehet írni. Ez azt jelentené, hogy meg tudnánk csinálni, hogy összeadunk két kutyát pl: k1+k2 és egy harmadik kutyát kapnánk eredményül. Ennek sok értelme nincsen ugyan, de más osztályoknál pl: saját szám osztálynál igenis sok jelentősége van. Ha érdekel hogyan, nézz utána!

(!EndStep)

(!Step)[Próbáljuk ki!]
# [lényeg](#tab/focus)
```csharp
        private void Form1_Load(object sender, EventArgs e)
        {
            Macska m = new Macska("Cirmi", "sziámi", true, new DateTime(2022, 3, 27), 1.5f);
            Kutya k = new Kutya("Aida", "németjuhász", false, new DateTime(2013, 11, 15), 37f);

            m.Vedlik();
            k.Vedlik();
        }
```
# [teljes kód](#tab/entire)
```csharp
namespace OsztalyokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Allat> allatok = new List<Allat>();
        private void Form1_Load(object sender, EventArgs e)
        {
            Macska m = new Macska("Cirmi", "sziámi", true, new DateTime(2022, 3, 27), 1.5f);
            Kutya k = new Kutya("Aida", "németjuhász", false, new DateTime(2013, 11, 15), 37f);

            m.Vedlik();
            k.Vedlik();
        }
    }
    class Allat
    {
        public string Nev { get; set; }
        public string Fajta { get; set; }
        public bool Hím_e { get; set; }
        public DateTime Születésnap { get; set; }
        public int Kor
        {
            get
            {
                DateTime maiDatum = DateTime.Now;
                int kor = maiDatum.Year - this.Születésnap.Year;
                if (maiDatum.Month < Születésnap.Month || (maiDatum.Month == Születésnap.Month && maiDatum.Day < Születésnap.Day))
                {
                    kor--;
                }
                return kor;
            }
        }
        public float Súly { get; set; }
        public Allat(string név, string fajta, bool hím_e, DateTime születésNap, float súly)
        {
            this.Nev = név;
            this.Fajta = fajta;
            this.Hím_e = hím_e;
            this.Születésnap = születésNap;
            this.Súly = súly;
        }
        public virtual void Vedlik()//virtuálisnak jelöljük
        {
            MessageBox.Show(Nev + " vedlik.");
        }
    }
    class Macska : Allat
    {
        public Macska(string név, string fajta, bool hím_e, DateTime születésNap, float súly) : base(név, fajta, hím_e, születésNap, súly)
        {

        }
        public void Nyávog()
        {
            MessageBox.Show(Nev + " nyávog.");
        }
        public override void Vedlik()//override-nak jelöljük
        {
            base.Vedlik(); //meghívjuk az eredeti vedlik metódust
            MessageBox.Show("És mivel macska, ezért megeszi a szőrt");
        }
    }
    class Kutya : Allat
    {
        public Kutya(string név, string fajta, bool hím_e, DateTime születésNap, float súly) : base(név, fajta, hím_e, születésNap, súly)
        {

        }
        public void Ugat()
        {
            MessageBox.Show(Nev + " ugat.");
        }
    }
}
```
***

(!Hint) Vegyél fel egy kedvenc játék tulajdonságot a Kutya osztályba [!prop tab tab-bal meg lehet csinálni a tulajdonságot, és a konstruktort bővíteni kell egy paraméterrel]

(!EndStep)

>[!Note]
>Amikor a Button osztályból származtatunk egy osztályt, pontosan ugyanezek történnek. Egyből megkapunk mindent, amit a gombok tudnak és nem kell nekünk megvalósítani azt a rengeteg logikát, ami ahhoz kell, hogy az ablakban működjön az összes többi elemmel együtt.

>[!Note]
>Vannak még osztályokhoz kapcsolódó tartalmak, mint például az interfészek, de ezeket nem ez az oldal fogja tárgyalni.

(!EndStepper)
