---

(+/-) A `StreamReader` osztály mely tulajdonságából tudható meg, hogy tudunk-e még olvasni a fájlból?

(+/-) Miért fontos, hogy egy fájlt lezárjunk olvasás után?

(+/-) Mit jelent `@` karakter a `string` literálók előtt? Pl:

```csharp
string fileName = @"c:\temp\kerdesek.txt";
```

(+/-) Mi a hiba a következő kódrészletben:  

```csharp
StreamReader sr = new StreamReader("c:\tmp\valami.txt");
```

(+/-) Mi a hiba a következő kódrészletben:  

```csharp
string s = 'Добар дан';
```

(+/-) Mi a hiba a következő kódrészletben:  

```csharp
for(int i=1,i<5,i++) 
{
    Console.WriteLine(i);
}
```

(+/-) Mi a hiba a következő kódrészletben:  

```csharp
if(a % 2 = 0) MessageBox.Show("Páros");
```

(+/-) Mikor fut le egy osztály konstruktora?

(+/-) Milyen ciklus (iteráció) típusokat ismersz?

(+/-) Hogyan lehet int típust stringgé konvertálni?

```csharp
int i = 13;
string s = ______ ;
```

(+/-) Hogyan lehet `string` típust `int`-é konvertálni?

```csharp
string s = textBox1.Text;
int i = _________
```

(+/-) Hogyan lehet `string` típust `double`-é konvertálni?

```csharp
double d = Math.PI;
string s = ______ ;
```

(+/-) Milyen értékeket vehet fel az `i változó a következő ciklus törzsében: 

```csharp
for(int i=1;i<5;i++) 
{
    Console.WriteLine(i);
}
```

(+/-) Milyen tanult módszerekkel lehet bekapcsolt `Timer`-t elhelyezni egy űrlapon?

(+/-) Mit tartalmaz egy `Form` `Controls` struktúrája?

(+/-) A `Button` osztályt melyik névtér tartalmazza -- illetve hogyan lehet kideríteni, hogy egy osztály melyik névtérbe tartozik? (Milyen using szükséges?) 

(+/-) Mi a fő különbség a `List` és az tömb  között?

(+/-) Lehet anélkül növelni a tömb elemeinek számát, hogy átmásolnánk a tömb elemeit?

(+/-) Milyen metódussal lehet egy `string`-et feldarabolni adott karakter mentén?

(+/-) Lehetséges azonos eseménykezelőt (pl. Click) rendelni több gombhoz?

(+/-) Milyen osztály segítségével lehet fájlból olvasni a tanultak szerint?

(+/-) Mire szolgál az "is" operátor?

(+/-) Hogyan lehet megjeleníteni egy szabványos fájlválasztó dialógusablakot?

(+/-) Mi a különbség a = és a == operátor között?

(+/-) Hogyan lehet szabványos üzenetablakot megjeleníteni?

(+/-) Egészítsd ki a kódrészletet úgy, hogy a `Sajátgomb` osztály a `Button` osztálytól származzon:

```csharp
class SajatGomb
{
}
```

(+/-) Milyen formában kell változót deklarálni egy gombból származtatott osztályban, ha azt szeretnénk, hogy az megjelenjen a _Properties_ ablaban?

(+/-) Mi a különbség a `public` és a `private` láthatóság között?

(+/-) Mikor fut le egy tulajdonság (property) setter ága?

(+/-) Milyen értékeket vehet fel egy `int` típusú változó?

(+/-) Milyen értékeket vehet fel egy `bool` típusú változó?

(+/-) Milyen értékeket vehet fel egy `double` típusú változó?

(+/-) Hogyan törlöd a lista első elemét?

(+/-) A `List<>` mely tulajdonságán keresztül olvasható ki a lista elemeinek száma?

(+/-) Hogyan állapítható meg, hogy egy `strting` hány karakterből áll?

(+/-) Irasd ki a string első karakterét:

```csharp
string s = "Helló";
Console.WriteLine(___________);
```

(+/-) Egészítsd ki a kódrészletet úgy, hogy 1 és 10 között írja ki a számokat:

```csharp
for(int i=1;i _____ 10;i++) 
{
    Console.WriteLine(i);
}
```

(+/-) Milyen számokat ír ki az alábbi kódrészlet?

```csharp
for(int i=1;i < 10;i++) 
{
    Console.WriteLine(i);
}
```

(+/-) Mire való az űrlap konstruktorában az `InitializeComponent()` metódushívás?

(+/-) Mikor fut le egy osztály konstruktora?

(+/-) Hogyan készítesz konstruktort egy osztályhoz?

(+/-) Mi az oka annak, hogy a `Random` osztályból tipikusan csak egy példányt hozunk létre? Miért nem szerencsés az alábbi kódrészlet?

```csharp
For(int i=1;i<10;i++)
{
    Random rnd = new Random();
    Console.WriteLine(rnd.Next(100));
}
```

(+/-) Milyen értékeket vehet fel az `x` változó értéke?

```csharp
Random rnd = new Random();
int x= rnd.Next(100);
```

(+/-) Hogyan lehet kiolvasni, hogy milyen széles egy űrlap?

(+/-) Sorolj fel 5-öt a Form osztály tulajdonságai közül!

(+/-) Sorolj fel 2-öt a Form osztály metódusai közül!

(+/-) Sorolj fel 5-öt a Form osztály eseményei közül!

(+/-) Mikor következnek be az alábbi események pl. egy gomb esetén?

- MouseUp
- MouseDown
- MouseMove
- MouseEnter
- MouseLeave

(+/-) Példaként adott az alábbi esemény-kiszolgáló függvény. Milyen információt hordoz az `e` paraméter?

```csharp
void b_MouseDown(object sender, MouseEventArgs e)
{
...
}
```

(+/-) Hogyan lehet elindítani illetve leállítani egy `Timer` típusú objektumot?

(+/-) Milyen mértékegységben méri `Timer` osztály  `Interval` tulajdonsága az időt?

(+/-) Mi a hiba az alábbi kódrészletben?

```csharp
int a = 13;
Messagebox.show(a+1);
```

(+/-) Mi a hiba az alábbi kódrészletben?

```csharp
Buttom[,] t = new Button[5,5]();
t[1,5] = new Button();
```

(+/-) Mi a hiba az alábbi kódrészletben?

```csharp
int(,) t = new int(5,5)();
t(0,0) = 13;
```

(+/-) A `StreamReader` osztály mely tulajdonságából tudható meg, hogy tudunk-e még olvasni a fájlból?

(+/-) Hol keresi a fájlrendszerben a program azokat a fájlokat, melyekhez nincs elérési útvonal megadva? Pl:

```csharp
StreamReader sr = new StreamReader("minta.txt");
```

(+/-) Hogyan lehet megszakítani a `Form` `Closing` eseményéhez rendelt esemény kiszolgálóból az űrlap tulajdonságát?

(+/-) Mi történik akkor, ha egy tömb nem létező elemére hivatkozol?

### Kódolós feladatok

(+/-) Hogy cseréled fel `a` és `b` változók értékét?

(+/-) Generálj egy véletlen számot 0 és 10 között!

(+/-) Írd le azt a kódrészletet, mely ciklusból kirak egy űrlapra egymás alá 10 gombot!

(+/-) Származtass egy osztályt a Button osztályból, mely automatikusan átmétetezi magát 30x30 pixelesre!

(+/-) Hogyan lehet int típust string-é konvertálni? (Írj példát!)

(+/-) Hogyan lehet az űrlap Contrlos listájának egy meghatároztt sorszámú elemét törölni? (Írj példát!)

(+/-) Írd le azt a kódrészletet, mely egy számról eldönti, hogy páros-e!

(+/-) Írd le azt a kódrészletet, ami létrehoz egy 2x2-es egészekből álló tömböt!

(+/-) Írd le azt a kódrészletet, ami létrehoz egy string-ekből álló tömböt, majd hozzáad egy elemet!

(+/-) Írd le azt a néhány kódsort, mely létrehozza a `Button` osztály egy példányát, majd elhelyezi az űrlapon!

(+/-) Írd le azt a néhány kódsort, mely generál egy véletlen számot 0 és 10 között!

(+/-) Tegyük fél, hogy az űrlapon csak a `Button` osztály példányai vannak. Írd le azt a `foreach` ciklust, mely bejárja az űrlap `Controls` listáját és minden gomb `Visible` tulajdonságát hamis értékűre állítja!

## Egyéb témák

- UserControl

- Random

- … létrehoz egy 10x10 bool típusú elemből álló tömböt

- Írd le azt a néhány kódsort, mely SajátGomb néven származtat egy osztályt a Button osztályból!

- Írj példát for ciklusra!

- Hány közvetlen őse lehet C#-ban egy osztálynak?

- Hol lehet átírni, hogy melyik űrlappal induljon az alkalmazás?

- Írd le azt a kódrésztelet, amit 10x10 gombot kirak az űrlapra!

- Melyik osztálytól ötököl a Példa osztály?  
  class Példa {...}

- Írd le azt a kódrészletet, mely megnyit egy tetszőleges szövegfájlt olvasásra, majd soronként beolvassa a tartalmát!

- Unicode-dal kapcsolatos tudnivalók
