# Osztályok és Objektumok

Ez az oldal arra szolgál, hogy mindenki magabiztosan tudja használni az osztályokat és szilárd alapokat adjon a jővőre. A feltétlenül szükségesnél többet tartalmaz, de a megértéshez jobb látni a teljes képet.
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
>Összefoglalva: A függvények és metódusok között annyi a különbség, hogy a metódusok egy objektumhoz tartoznak, tehát osztályszinten vannak definiálva. Gyakorlatban sokszor felváltva használják a kettő kifejezést.

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
```csharp {highlight=[8-11]}
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
```csharp {highlight=[26-29]}
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
(!Hint) Kérdés [!Válasz]

(!EndStep)

(!Step)[Szöveg]
# [lényeg](#tab/focus)
```csharp

```
# [teljes kód](#tab/entire)
```csharp

```
***
(!Hint) Kérdés [!Válasz]

(!EndStep)

(!EndStepper)
