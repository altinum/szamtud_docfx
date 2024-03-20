# Pascal-háromszög kirakása gombokból

A feladat a  [Pascal-háromszög](https://hu.wikipedia.org/wiki/Pascal-h%C3%A1romsz%C3%B6g)  első néhány sorának kirakása gombokból.

A Pascal háromszögben szereplő binomiális együtthatók kifejezhetők a faktoriálissal:

![{\displaystyle {n \choose k}={\frac {n!}{k!\,(n-k)!}}}](https://wikimedia.org/api/rest_v1/media/math/render/svg/c42a41f48e94296543f7f82ae26e19f69cc73ece)

### 2.1 Faktoriális kiszámolása

A .NET keretrendszer nem tartalmaz kész függvényt a faktoriális kiszámítására, ezért első lépésként nekünk kell megírnunk. Kétféle úton is el lehet indulni, bármelyik megoldást választhatjátok.

#### 1. lehetőség: faktroiális kiszámítása iterációval

![](https://wikimedia.org/api/rest_v1/media/math/render/svg/4234ee890533fa15c15af33b07648b46ef87f08a)

A C# függvény a fenti szorzatösszeget képezi:

```csharp
int Faktorialis(int n)
{
    int eredmény = 1;
    for (int i = 1; i <= n; i++) eredmény *= i;
    return eredmény;
}

```

- A `*=` operátor megszorozza a változó értékét az operátor után szereplő értékkel. Hasonlóképpen működnek a `+=`,`-=` és a `/=` operátorok. 
- A `++` operátor növeli a változó értékét 1-el, míg a `--` csökkenti. 

#### 2. lehetőség: faktoriális kiszámítása rekurzióval

Mint korábban írtuk, rekurzív függvényeknek azokat a függvényeket nevezzük, melyek saját magukat meghívják. Ebben a megközelítésben abból indulunk ki, hogy ha $n>0$ akkor $n!=(n-1)!$, ha viszont $n\leq0$, akkor $n=1$. 

C#-ul:

```csharp
int Faktorialis2(int n)
{ 
    if (n == 0) return 1;
    return n * Faktorialis2(n - 1);            
}
```

## 2.2 A háromszög kirakása

(+/-)  Rakjátok ki a binomiális együtthatókat egy 10x10-es négyzetrácsba gomb (`Button`) vezérlőkből az alábbi összefüggés alapján:

![{\displaystyle {n \choose k}={\frac {n!}{k!\,(n-k)!}}}](https://wikimedia.org/api/rest_v1/media/math/render/svg/c42a41f48e94296543f7f82ae26e19f69cc73ece)

A _n_ helyére a sor számát, _k_ helyére az oszlopét helyettesítsd!

Először egy négyzetrácsba tesszük az elemeket, majd később csináljuk meg azt, hogy ne jelenjenek meg a főátló felettiek, és később rendezzük őket piramis alakba: 

```csharp
namespace Pascal
{
    public partial class Form1 : Form
    { 
        public Form1()
        {
            InitializeComponent();
            for (int sor = 0; sor < 10; sor++)
            {
                for (int oszlop = 0; oszlop <= 10; oszlop++)
                {
                    Button b = new Button();
                    b.Top = sor * 60;
                    b.Left = oszlop * 60;
                    b.Height = 60;
                    b.Width = 60;
                    this.Controls.Add(b);
                    int p = Faktorialis(sor) / (Faktorialis(oszlop) * (Faktorialis(sor-oszlop)));
                    b.Text = p.ToString();
                }
            }
        }

        int Faktorialis(int n)
        {
            int eredmény = 1;
            for (int i = 1; i <= n; i++) eredmény *=  i; 
                       
            return eredmény;
        }

        int Faktorialis2(int n)
        { 
            if (n == 0) return 1;
            return n * Faktoriális2(n - 1);            
        }
    }
} 
```

(+/-) Oldjátok meg, hogy csak a főátló, és a főátló alatti “kockák” jelennenek meg. 

> [!Tip]
> A főátló alatt azok az elemek vannak, amelyeknél az oszlop száma nagyobb, vagy egyenlő, mint a sor száma. A Pascal-háromszög háromszög, és nem négyzet  Egyenlőre most derékszögű háromszögünk lesz.

(+/-) Az elemek jelenjenek meg piramis-szerűen.

> [!Tip]
> Minden sorban egy kicsit jobban balra kell tolni az elemeket, mint az előző sorben. Egész pontosan minden sorban az elemeket egy fél elemnyivel balrább kell kell tolni, mint az előző sor elemeit.

> [!Tip]
> A ClientRectangle.Width kifejezés értéke az ablak belső mérete – keretek nélkül – pixelekben. (Ablak esetén a Width és a Height a keretet is magában foglalja, ami függ Windows verziótól és a beállított témától is.) Az első sort az ablak szélességének felével érdemes jobbra tolni, amiből – ha nagyon szőrszálhasokgatunk – ki kell vonni egy fél elemszélességnyit.