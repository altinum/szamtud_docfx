# Kígyós játék







## Videók

(!Vid) 1. rész
> [!Video https://storage.altinum.hu/szoft1/S1snake1.m4v]

(!Vid) 2. rész
> [!Video https://storage.altinum.hu/szoft1/S1sanke2.m4v]

(!Vid) 3. rész
> [!Video https://storage.altinum.hu/szoft1/S1sake3.m4v]

(!Vid) 4. rész
> [!Video https://storage.altinum.hu/szoft1/S1snake4.m4v]

(!Vid) 5. rész
> [!Video https://storage.altinum.hu/szoft1/S1snake5.m4v]

(!Vid) 6. rész
> [!Video https://storage.altinum.hu/szoft1/S1snake6.m4v]

## Előadás: alap játék felépítése

(+/-)  Származtass a `PictureBox` osztálytól egy új osztályt `KígyóElem` néven!

(+/-) A `KígyóElem` osztályt bővítsd egy méret statikus egész konstanssal, melynek értéke legyen `20`.

``` csharp
class KígyóElem : PictureBox
{
    public static int Méret = 20;
}
```

(+/-) A `KígyóElem` osztályt bővítsd konstruktorral, melyben az a fenti konstansnak megfelelően 20x20 képpontosra méretezi magát.

```csharp
class KígyóElem : PictureBox
{
    public static int Méret = 10;

    public KígyóElem()
    {
        Width = KígyóElem.Méret;
        Height = KígyóElem.Méret;
    }
}
```

(+/-) A `Form1` osztályt bővítsd `fejX` és `fejY` változókkal, melyekben az utoljára kirakott kígyófej koordinátáit tárolod! Állíts be értelemszerű kezdőéréket! (Pl. 100, 100)

``` csharp
int fej_x = 100;
int fej_y = 100;
```

(+/-) A `Form1` osztályt bővítsd `irány_x` és `irány_y` változókkal, melyekben kígyó haladási irályát tárolod! (`-1`,`0`,`1` értékeket vehet fel.) Állíts be kezdőértéket -- ettől függ majd, hogy merre indul a kígyónk!

``` csharp
int irány_x = 1;
int irány_y = 0;
```

(+/-) A `Form1` osztályt bővítsd `lépésszám` nevű, `0` kezdőértékű változóval!

> [!NOTE]
>
> Ha létrehozol egy `int` típusú változót, `0`  lesz a kezdőértéke, nem kell külön inicializálni.

(+/-) A `Form1`-en helyezz el tervezőből egy `Timer`-t fél másodperces intervallummal, majd rendelj a `Tick` eseményéhez esemény-kiszolgáló függvényt!

(+/-) Az esemény-kiszolgálóban az iránynak és a méretnek megfelelően változtasd a `fejX` és `fejY` változók értékeit, majd hozz létre egy új példányt a `KígyóElem` osztályból, majd ! Ezután már mozogni kell a kígyóknak.

``` csharp
private void timer1_Tick(object sender, EventArgs e)
{
    lépésszám++;
    
    //Fejnövesztés
    fej_x += irány_x * KígyóElem.Méret;
    fej_y += irány_y * KígyóElem.Méret;   
    KígyóElem ke = new KígyóElem();
    Controls.Add(ke);
}
```

(+/-) Rendelj esemény-kiszolgálót az űrlap `KeyDown` eseményhez.

(+/-) Változtasd a kígyó irányát az esemény-kiszolgáló paramétereként kapott `e.KeyValue` (vagy `KeyCode`) értéke alapján!

``` csharp
private void Form1_KeyDown(object sender, KeyEventArgs e)
{
    if (e.KeyCode == Keys.Up)
    {
        irány_y = -1;
        irány_x = 0;
    }

    if (e.KeyCode == Keys.Down)
    {
        irány_y = 1;
        irány_x = 0;
    }

    if (e.KeyCode == Keys.Left)
    {
        irány_y = 0;
        irány_x = -1;
    }

    if (e.KeyCode == Keys.Right)
    {
        irány_y = 0;
        irány_x = 1;
    }
}
```



(+/-) Valósítsd meg az ütközésvizsgálatot! Miután kiszámoltad az új `fej_x` és `fej_y` értékeket, járd be az űrlap `Controls` listáját `foreach` ciklussal, és vizsgálj meg minden `KígyóElemet` `ke` néven. Ha van olyan, melynek `Top` illetve `Left` tulajdonságai megegyeznek a `fej_x` illetve `fej_y` változók értékeivel, a kígyó farkába harapott.

``` csahrp
foreach (KígyóElem item in Controls)
{
   //Ha vannak már valami ott, ahova az új fejet tenném, vége a játéknak
   if (item.Top == fej_y && item.Left == fej_x) 
   {
       timer1.Enabled = false;
       return;
   }
}
```

(+/-) "Másszon" a kígyó! Ehhez először bővítsd egy `hossz` nevű változóval az osztályt, melyben a kígyó aktuális hosszát tárolod! Ha az űrlapon lévő vezérlők száma meghaladja a hossz változó értékét, vedd ki az űrlap `Controls` listájának nulladik elemét! 

Ha a kígyónk hossza nagyobb, mint a kívánt hossz, kivesszük a `Controls` gyűjtemény nulladik elemét, vagyis a legrégebben belepakolt elemet:

```csharp
//Farokvágás
if (kígyó.Count > hossz)
{
    KígyóElem levágandó = kígyó[0];
    Controls.RemoveAt(0);
}
```

(+/-) A  páros és a páratlan sorszámú kígyóelemeket színezd eltérően!

```csharp
if (lépésszám % 2 == 0) ke.BackColor = Color.Yellow;
```



## Feladatok gyakorlatra

### Mérgek és kaják

Ha  kajákat és mérgeket is elhelyezel az űrlap vezérlőinek listájában,  működésképtelenné válik az az elv,  hogy a `Controls.RemoveAt(0);`  megoldással kivesszük a legrégebben berakott elemet. A probléma megodására azokat a `KígyóElem` típusú objektumokat, amelyek a kígyónk testét képezik, külön listában is tároljuk. Hozz létre egy `KígyóElem` típusú elemekből álló listát a `From1`-ben, osztály szinten:

``` csharp
List<KígyóElem> kígyó = new List<KígyóElem>();
```

Amikor új fejet  neveztünk a kígyónak,  azt beletesszük a `kígyó` listába is  és az űrlap vezérlőinek a listájába is:

```csharp
//Fejnövesztés
fej_x += irány_x * KígyóElem.Méret;
fej_y += irány_y * KígyóElem.Méret;   
KígyóElem ke = new KígyóElem();
kígyó.Add(ke); //Amikor új fejet neveztünk a kígyónak, azt beletesszük a `kígyó` listába is ..
Controls.Add(ke); //.. és az űrlap vezérlőinek a listájába is
```

A farokvágásnál viszont a `kígyó` lista legrégebbi eleme alapján jelöljük ki a levágandó kígyóelement:

```csharp
//Farokvágás
if (kígyó.Count > hossz)
{
    KígyóElem levágandó = kígyó[0];
    kígyó.RemoveAt(0);
    Controls.Remove(levágandó);
}
```

Az ütközésvizsgálat is másképp alakul:

``` csharp
foreach (object item in Controls)
{
    if (item is KígyóElem)
    {
        KígyóElem k = (KígyóElem)item;

        if (k.Top == fej_y && k.Left == fej_x)
        {
            timer1.Enabled = false;
            return;
        }
    }
}
```

Ezután már létrehozhatunk új osztályokat a kajálnak és a mérgeknek, amelyeket valahány lépésenként véletlenszerűen elhelyezhetünk az űrlapon. 

### Két kígyó egymás ellen

Lehet két kígyók:

```csharp
List<KígyóElem> kígyó_1 = new List<KígyóElem>();
List<KígyóElem> kígyó_2 = new List<KígyóElem>();
```

A többi már jön magától :)

### Ellenőrző kérdések

1.  Egy űrlapon csak a `Button` osztály példányai vannak. Írd le azt a `foreach` ciklust, mely bejárja az űrlap `Controls` listáját és minden gomb `Visible` tulajdonságát hamis értékűre állítja!
2.  Hogyan lehet az űrlap `Contrlos` listájának egy meghatároztt sorszámú elemét törölni?
3.  Hogyan lehet megtudni, hogy egy lista hány elemet tartalmaz?
4.  Írd le azt a kódrészletet, mely egy számról eldönti, hogy páros-e!
5.  Származtass egy osztályt a `Button` osztályból, mely automatikusan átmétetezi magát 30x30 pixelesre!
