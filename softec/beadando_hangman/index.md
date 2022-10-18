# Projektfeladat:  Akasztófa játék
## A feladat leírása

A klasszikus szókitalálós játék megvalósítása a feladat. 

- A szavak listáját fájlmegnyitó ablakból válaszható fájlból lehessen beolvasni, az esetleges hibák kezelése mellett. 
- A beolvasott listából véletlenszerűen kerüljön kiválasztásra egy szó. 
- A betűk gombokként kerüljenek ki a képernyőre! (Ld. képernyőbillentyűzet példa.)
- Lehessen új játékot kezdeni. 
- A megvalósítás többi részében szabad kezetek van. 


> Teams-en várjuk a feladattal kapcsolatban kérdéseket, és igyekszünk mihamarabb válaszolni.

## Tippek a megvalósításhoz

### Annak eldöntése, hogy szerepel-e egy betű egy szóban

``` csharp
string s = "Fukszia";
if (s.IndexOf('x')>=0)
{
    MessageBox.Show("Van benne x");
}
```

### Hivatkozás a  `string`  elemeire

A  `string`-ben szereplő betűkre ugyanúgy lehet hivatkozni, mint egy tömb elemeire. Az alábbi kódrészlet fukszia és kék gombokat pakol egymás mellé az  `s`  karakterláncban szereplő betűknek megfelelően. Ez a gondolatmenet felhasználható a betűket tartalmazó gombok kipakolásakor. A karakterlánc hossza a  `Length`  tulajdonságán keresztül olvasható ki.

```csharp
string s = "KKFFKK";

for (int i = 0; i < s.Length; i++)
{
    Button b = new Button();
    b.Left = i * 30;
    b.Width = 30;

    if (s[i] == 'K') b.BackColor = Color.Blue;
    if (s[i] == 'F') b.BackColor = Color.Fuchsia;

    Controls.Add(b);
}
```

A karakterlánc elemei kiolvashatók, de nem állíthatók. Az alábbi kódrészlet hibás:
```csharp
s[1] = 's'; ///Hibás
```


### Rajzoláshoz
Szükség lesz egy függvényre, ami a megfelelő számú elemét kirajzolja az akasztófának. 

``` csharp
void Rajzolas(int szint)
{
    // Akasztófa talp rajzolása, utána return
    // ...
    if (szint == 1) return;

    //Akasztófa oszlop rajzolása
    if (szint == 2) return;

    //Akasztófa vízszintes gerenda rajzolása
    if (szint == 3) return;
            
    //...
}
```
