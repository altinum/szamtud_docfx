# GDI grafika

A C# környezet hatékony eszközöket kínál grafikák készítésére. A rajzolás első ránézésre nem tűnik egyszerűnek, de néhány példa után könnyen áttekinthetővé válik. 

 Windows rendszerben mindenért, amit a képernyőre rajzolunk a GDI (Graphics Device Interface) felelős. A windows-os programok, és maga a Windows is ezen a kódon keresztül rajzolja a szövegeket, vonalakat, grafikákat, stb. a képernyőre. A GDI közvetlen kapcsolatban áll a grafikus kártya meghajtó programjával, és eldönti, hogy a kívánt rajz hogyan jeleníthető meg legjobban a rendelkezésre álló grafikus eszközön. Például, ha a grafikus kártyán beállított színmélység kisebb a megjelenítendő grafika színmélységénél, a GDI gondoskodik az optimális helyettesítő színek megválasztásáról. A programozónak ezért nem kell azzal törődnie, hogy milyen a rendelkezésre álló grafikus megjelenítő eszköz. 

 A C# kód a `Graphics` osztályon keresztül kommunikál a GDI-vel. 

## A Graphics osztály

Mielőtt elkezdenénk rajzolni, létre kell hoznunk egy `Graphics` objektumot. Szerencsére minden grafikus windows vezérlő automatikusan örökli a `CreateGraphics()` metódust, melyen keresztül hozzá tudunk férni a vezérlő grafikus részéhez. 

 Példának hozzunk létre az űrlapon egy gombot, és kezeljük le a kattintás eseményét! Az eseményhez rendeljük a következő kódot:

```c#
private void button1_Click(object sender, EventArgs e)
{
   Bitmap kep;
   kep = new Bitmap(@"c:\kép.jpg");

   Graphics grafika;
   grafika = this.CreateGraphics();
   grafika.DrawImage(kep,0,0);
}
```

1. Az első két sor létrehozza a `Bitmap` osztály egy példányát `kep` néven, majd a konstruktornak paraméterként átadjuk a betöltendő kép elérési útvonalát.

2. Ezután hozzuk léte a `Graphics` osztály egy példányát `grafika` néven. A `Grafika` nevű objektumunkhoz most rendeljük hozzá az aktuális űrlap (`this`) felületét. Itt az űrlap helyett választhatnánk bármely vezérlőt az űrlapon pl:

   ` grafika = this.TextBox1.CreateGraphics();`

3. Ezután már csak a kép felrajzolása marad hátra a `DrawImage()` metóduson keresztül a (0,0) koordinátájú ponttól. A koordinátarendszer origója a bal felső sarokban van, a tengelyek jobbra, illetve lefelé mutatnak. 

 A példa szemléletes, de nem működik tökéletesen. Ha a Windows-nak újra kell rajzoltatnia ablakunkat, az általunk elhelyezett grafikát nem fogja újrarajzolni. Ha letesszük az ablakot a tálcára, majd vissza, a grafika eltűnik. Ugyanez történik, ha egy másik ablak egy időre fedi a miénket. Ha a fenti programsorokat az űrlap `Paint` eseményéhez rendeljük, a rajzolás megtörténik minden alkalommal, amikor az ablak többi elemét újra kell rajzolni. 

## A színek (Color)

Színválasztásra három lehetőségünk kínálkozik:

 

1. Választunk a `System.Drawing.Color` osztály előre definiált színei közül. Ezek a színek angol nevei: pl, `Red`, `Green`, `DarkBlue`. A teljes felsorolás értelmetlen lenne, a komplett lista megjelenítéséhez használjuk az automatikus kódkiegészítőt! (A „color.” legépelése után ctrl+betűköz billentyűk lenyomásával megjelenő lista.)

    Pl: `Color.Orange`

1. A rendszerszínek közül választunk. Az asztal beállításai között a felhasználó át tudja állítani a Windows színeit. Ha azt szeretnénk, hogy grafikánk kövesse a felhasználó beállításait, a `System.Drawing.SystemColors`  színeire hivatkozzunk! (Pl: `Window` – alak színe ; `Higlight` – szövegkijelölés háttérszíne ;  `HiglightText` – szövegkijelölés szövegszíne ; `Desktop` – asztal színe , stb.)

   Pl: `SystemColors.WindowText`

2. Saját színt definiálunk, melynek megadjuk a piros, kék és zöld összetevőit. A `Color` osztály `FromArgb()` metódusa három byte típusú paraméterrel rendelkezik, melyeken keresztül beállíthatjuk a három összetevőt. A piros színt a következőképpen adhatjuk meg:

   Pl: `Color.FromArgb(255, 0, 0);`

## A toll (Pen)

Míg `Graphics` osztály biztosítja számunkra a felületet, amire rajzolhatunk, szükségünk van egy eszközre, amivel rajzolunk. Hozzuk létre a `Pen` osztály egy példányát, és állítsuk be tollunk jellemzőit: adjuk meg a vonal színét, vastagságát és stílusát! A `Pen` konstruktorának első paramétere a vonal színe, ezután következik a vonal vastagsága.

```c#
Pen toll;
toll = new Pen(Color.DarkBlue, 3);
toll.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
```

A `System.Drawing.Drawing2D.DashStyle` felsorolás tartalmazza a rendelkezésünkre álló vonalstílusokat, ezek közül választhatunk. Ha nem adunk meg külön vonalstílust, a vonal folytonos lesz.

| **Érték**  | **Leírás**                                                   |
| ---------- | ------------------------------------------------------------ |
| Dash       | ------                                                       |
| DashDot    | ·-·-·-·-                                                     |
| DashDotDot | ··-··-··-                                                    |
| Dot        | ·············                                                |
| Solid      | Folytonos                                                    |
| Custom     | Egyedi. A Pen osztály rendelkezik olyan tulajdonságokkal,  melyeken keresztül egyedi vonalstílus is kialakítható. A részletekre itt nem  térünk ki. |

A rajzoljunk egy vonalat, ellipszist és egy téglalapot! A `DrawEllipse()` metódus utolsó négy paramétere az ellipszist befoglaló téglalap bal-felső sarkának x és y koordinátája, valamint a téglalap szélessége és magassága:

```c#
Pen toll;
toll = new Pen(Color.DarkBlue, 3);
toll.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

grafika.DrawLine(toll, 10, 10,100,100);

grafika.DrawEllipse(toll, 10, 10, 100, 100);

grafika.DrawRectangle(toll, 10, 10, 100, 100);
```

## Az ecset (Brush)

Míg a toll a vonalak jellemzőit tartalmazza, az ecset a kitöltendő alakzatok kitöltési tulajdonságait írja le. Hozzunk létre egy saját ecsetet és rajzoljunk vele:

```csharp
Brush ecset;
ecset = new System.Drawing.SolidBrush(Color.DarkBlue);

grafika.FillEllipse(ecset,10,10,100,100);
```

### Mintás ecset és toll (TexturedPen)

Létrehozhatunk olyan ecsetet, illetve tollat is, mely egy képből nyert mintával rajzol:

```csharp
Bitmap kep;
kep = new Bitmap(@"c:\kép.jpg");

Brush mintasEcset;
mintasEcset = new System.Drawing.TextureBrush(kep);

Pen mintasToll = new Pen(MintasEcset, 30);
grafika.DrawRectangle(mintasToll, 10, 10, 100, 100);
```

## Szöveg rajzolása

Szöveg rajzolásához két objektumot is létre kell hozni: egy betűtípust és egy ecsetet: 

 ```csharp
 Font betu;
 betu = new System.Drawing.Font("Arial", 30);
 
 Brush ecset;
 ecset = new System.Drawing.SolidBrush(Color.Black);
 
 grafika.DrawString("Hello", betu, ecset, 10, 10);
 ```

## 1.1    Állandó grafikák létrehozása az űrlapon

Egyszerűbb alakzatok rajzolásánál járható út, hogy a rajzolást az űrlap objektum `Paint` eseményéhez kötve minden alkalommal elvégezzük, amikor az űrlap újrarajzolja magát. 

Számításigényes grafikák esetén a fenti megoldás nagyon lelassítja a programot. Ilyenkor létrehozhatunk egy `Bitmap` objektumot a memóriában, amire egyszer elég megrajzolni a grafikát. A `Paint` metódusban ezt az objektumot másoljuk az űrlapra. 

```c#
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication5
{
    public partial class Form1 : Form
    {
        Bitmap rajzFelulet;

        public Form1()
        {
            InitializeComponent();

            //Létrehozzuk a bittérképet a konstruktorban
            //átadott méretben
            rajzFelulet = new Bitmap(200,200);
            
            //Létrehozzun a Graphics osztály egy példányát, 
            //melyen keresztül rajzolhatunk a rajzfelületre
            Graphics grafika;
            grafika = Graphics.FromImage(rajzFelulet);

            Brush ecset;
            ecset = new System.Drawing.SolidBrush(Color.DarkBlue);

            grafika.FillEllipse(ecset, 10, 10, 100, 100);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics grafika;
            //A grafika objektum űrlapunk-ra (this) mutat
            grafika = this.CreateGraphics();

            //A DrawImage metódussal felrajzoljuk a rajzFelulet
            //az űrlapra
            grafika.DrawImage(rajzFelulet, 0, 0);

            //Megszüntetjük a grafika objektumot
            grafika.Dispose();


        }
    }
}
```



