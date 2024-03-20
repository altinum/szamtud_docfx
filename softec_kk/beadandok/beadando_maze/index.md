
# Projektfeladat:  Labirintus játék
## A feladat leírása

A feladat egy olyan labirintusos játék készítése, melyben a játékos egy fájlmegnyitó ablakon keresztül kiválaszthat egy labirintust leíró fájlt, majd a billentyűk segítségével végigvezethet egy figurát a pályán.

A labirintus (maze) legenerálására vannak online eszközök, mint [ez itt](https://www.dcode.fr/maze-generator). A legenerált labirintus szövegfájlként letölthető. A letöltött fájlokban jelöljétek a START és a CÉL mezőt is tetszőleges módon.

- A labirintust tartalmazó fájlt fájlmegnyitó ablakból lehessen kiválasztani!

- A fájl megnyitásakor és olvasásakor keletkező esetleges kivételeket le kell kezelni.

- A labirintust érdemes `PictureBox`-ból származtatott osztályokból felépíteni, mert a gombok könnyen "lenyelik" a gomblenyomás eseményeket. 

- A játékost gombokkal lehessen irányítani -- az irányítás és az ütközésvizsgálat a kígyós játékhoz hasonlóan történhet. 

- A lépések számát és az eltelt időt meg kell jeleníteni.

- Legyen lehetőség újrakezdeni a pályát.

- A játék bővíthető megehető pöttyökkel vagy tetszőleges extrával. 

> Teams-en várjuk a feladattal kapcsolatban kérdéseket, és igyekszünk mihamarabb válaszolni.


## Tippek a megvalósításhoz

### Hivatkozás a `string` elemeire

A `string`-ben szereplő betűkre ugyanúgy lehet hivatkozni, mint egy tömb elemeire. Az alábbi kódrészlet fukszia és kék gombokat pakol egymás mellé az `s` karakterláncban szereplő betűknek megfelelően. Ez a gondolatmenet felhasználható a labirintusfájl olvasásánál. A karakterlánc hossza a `Length` tulajdonságán keresztül olvasható ki. 

``` csharp
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
### Objektumok típusának megállapítása

Az alábbi kódrészlet az űrlapon szereplő vezérlők közül a gombokat fuksziára színezi, a címkéket nem fuksziára. Ez a megoldás felhasználható annak eldöntésére, hogy falnak vagy a célnak ütköztünk. 

``` csharp
//Bejárjuk egy iterációval az űrlap összes vezérlőjét, azaz a Controls gyűjteményt
foreach (var elem in Controls)
{
    //Az épp vizsgált elem Button?
    if (elem is Button)
    {
        //Ha igen, cast-oljuk Buttonná, és színezzük
        Button b = (Button)elem;
        b.BackColor = Color.Fuchsia;
    }


    //Az épp vizsgált elem Label?
    if (elem is Label)
    {
        //Ha igen, cast-oljuk Labellé, és színezzük
        Label l = (Label)elem;
        b.BackColor = Color.Blue;
    }
}
```
