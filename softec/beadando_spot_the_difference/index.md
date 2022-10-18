# Projektfeladat:  „Keresd a különbséget” játék
## A feladat leírása
Gyerekeknek szóló foglakoztatófüzetekben gyakori a feladat, ahol két kép közti apró különbségeket kell felfedezni. A feladat a játék számítógépes változatának elkészítése, ahol egérrel kell a különbségekre kattintani. Az interneten „spot the difference” keresőkifejezéssel érdemes kiinduló képet keresni. A játékhoz készítsetek egy szövegfájlt, melynek első sora a kép nevét tartalmazza, az ezt követő sorok pedig a különbségeket lefedő téglalapok bal felső sarkának koordinátáit, valamint szélességét és magasságát, mindezt pontosvesszővel tagolva. Ezek alapján lehet átlátszó hátterű `PictureBox`-okat felrakosgatni, melyek kattintásra átszínezhetők. Teszteléshez érdemes világoskék színű dobozokat használni.

- A fájl előállításához érdemes egy kis segédprogramot írni, mely megjeleníti az egérkurzor koordinátáját az űrlapon vagy annak fejlécében. Ennek segítségével könnyebb előállítani a különbségeket tartalmazó szövegfájlt.

-  Az eltelt időt és a megtalált különbségek számát, valamint arányát meg kell jeleníteni.

 - Lehessen új játékot kezdeni.

 - A fájl megnyitásakor és olvasásakor keletkező esetleges kivételeket le kell kezelni.
 
 - A hibás fájlformátumot is kezelni kell (pl. nem négy szám szerepel pontosvesszővel elválasztva a sorban.) 


## Tippek a megvalósításhoz

### Különbségeket leíró fájl előállítása

Ha valaki nem szeretné kézzel írogatni a koordinátákat, automatizálhatja. A `StreamWriter` osztályon keresztül lehet szövegfájlba írni. 

``` csharp
private void Form1_MouseClick(object sender, MouseEventArgs e)
{
    StreamWriter sw = new StreamWriter("Különbségek.csv", true);
    sw.WriteLine($"{e.X};{e.Y}");
    sw.Close();
}
```
A konstruktor második argumentumában a `true` arra vonatkozik, hogy a már meglévő fájlt bővíteni kell (append), nem felülírni. 
