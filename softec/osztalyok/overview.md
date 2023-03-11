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
            Kutya k1=new Kutya();
            Kutya k2 = new Kutya();
            Kutya k3 = new Kutya();

            k2.name = "Liza";
            k3.name = "Bodri";

            MessageBox.Show($"k1: {k1.name} k2: {k2.name} k3: {k3.name}");
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
            Kutya k1=new Kutya();
            Kutya k2 = new Kutya();
            Kutya k3 = new Kutya();

            k2.name = "Liza";
            k3.name = "Bodri";

            MessageBox.Show($"k1: {k1.name} k2: {k2.name} k3: {k3.name}");
             //Ha egy string elé `$` jelet teszünk, akkor a kapcsos zárójelekbe berakhatunk közvetlenül változókat, így olvashatóbb a kód és szebb, mint a +-jeles megoldással.
        }
    }
    class Kutya
    {
        public string name = "Morzsa";
    }
}
```
***
(!Hint) Mit fog kiírni a program? ["k1: Morzsa k2: Liza k3: Bodri", mert a `nev` alapértelmezett értéke "Morzsa".]

(!EndStep)

(!Step)[Miért pont "Morzsa" legyen az alapértelmezett neve egy kutyának? Vegyük ki.]
# [lényeg](#tab/focus)
```csharp
class Kutya
    {
        public string name;
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
            Kutya k1=new Kutya();
            Kutya k2 = new Kutya();
            Kutya k3 = new Kutya();

            k2.name = "Liza";
            k3.name = "Bodri";

            MessageBox.Show($"k1: {k1.name} k2: {k2.name} k3: {k3.name}");
        }
    }
    class Kutya
    {
        public string name;
    }
}
```
***
(!Hint) Most mit fog kiírni a program? ["k1: k2: Liza k3: Bodri", mert a `nev` most null és az alapból egy üres `string`.]

(!EndStep)

(!EndStepper)
