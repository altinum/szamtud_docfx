# Osztályok és Objektumok

Ez az oldal arra szolgál, hogy mindenki magabiztosan tudja használni az osztályokat és szilárd alapokat adjon a jővőre. A feltétlenül szükségesnél többet tartalmaz, de a megértéshez jobb látni a teljes képet.
A projekt a szokásos `Windows Forms App`-ban készül, a `Form1.cs`-ben. Rendhagyó módon más fájlba nem is dolgozunk.
>[!Note]
>A hatékony tanulást segítheti, ha a kódot kipróbáljátok és játszotok vele. Az oldalon végig állatos példák lesznek, érdemes lehet a saját kódot járművekre (vagy bármi másra) megírni. 

## Alapok
Az osztályok egyfajta sablonként szolgálnak, segítségégükkel létrehozhatunk objektumokat, melyek adattagokat és metódusokat tartalmaznak. Az osztályok lehetővé teszik a programozók számára, hogy strukturáltabb és modulárisabb kódot írjanak, valamint egyszerűbbé tegyék az adatok kezelését és azokat megoszthassák a kód különböző részei között.

(!Stepper)

(!Step)[Ez itt a Form1.cs]

# [lényeg](#tab/focus)
```csharp
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
(!Step)[Ez itt a Form1.cs]
# [lényeg](#tab/focus)
```csharp
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

(!EndStepper)
