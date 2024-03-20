# Fibonacci sor 

## Sor kirakása gombokból

(+/-)  Rakjátok ki a  [Fibonacci-sor](https://hu.wikipedia.org/wiki/Fibonacci-sz%C3%A1mok)  első tíz elemét gombokból az űrlapra. 

Segítségül:

![](https://wikimedia.org/api/rest_v1/media/math/render/svg/47f0f322e5c0d6f9ef56bd8236e4163f8816e870)


A fentiek alapján a Fibonacci sor *n*-edik elemét megadó függvény:

```csharp
int Fibonacci(int n)
{
    if (n == 0) return 0;
    if (n == 1) return 1;
    return Fibonacci(n - 1) + Fibonacci(n - 2);
}
```

> [!NOTE]
> Rekurzív függvényeknek azokat a függvényeket nevezzük, melyek saját magukat meghívják. A fenti függvény jó példa erre. 

A gombok kihelyezése elvégezhető az űrlap konstruktorában, de létrehozhattunk volna eseménykiszolgálót az űrlap `Load` eseményéhez is:

```csharp
public Form1()
{
    InitializeComponent();
    for (int i = 1; i < 10; i++)
    { 
        Button b = new Button();
        b.Top = i * 30;
        b.Text = Fibonacci(i).ToString();
        Controls.Add(b);
    }
}      
```

## Adatok megjelenítése rácsban

(+/-) Helyezz el az űrlapon egy `DataGridView` vezérlőt, ebbe kerülnek majd az értékek!

(+/-) Addj egy `Elem` nevű osztályt a prokethez. Az osztálynak legyen egy `int` típusú `Sorszám` nevű, és egy `long` típusú `Érték` nevű tulajdonsága!

(+/-) Hozz létre egy `elemek` nevű listát, mely `Elem` típusú elemekből áll! Ezt még a ciklus előtt érdemes.

(+/-) Minden cikluslépésben hozz létre egy új elemet, állítsd be a tulajdonságait, és add hozzá az `elemek` listához.

(+/-) A `DataGridView`  `DataSource` tulajdonságán keresztül jelenítsd meg a lista tartalát az űrlapon!

> [!TIP]
>
> A feladat szövegezése hasonlít a ZH-ban várható megfogalmazáshoz.



