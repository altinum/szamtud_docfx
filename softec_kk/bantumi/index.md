
# Bantumi játék

## Videók

(!Vid) e1. videó
> [!Video https://storage.altinum.hu/szoft1/S1value_Ref1.m4v]

(!Vid) e2. videó
> [!Video https://storage.altinum.hu/szoft1/S1value_Ref2.m4v]

(!Vid) 1. videó
> [!Video https://storage.altinum.hu/szoft1/S1bantumi1.m4v]

(!Vid) 2. videó
> [!Video https://storage.altinum.hu/szoft1/S1bantumi2.m4v]

(!Vid) 3. videó
> [!Video https://storage.altinum.hu/szoft1/S1bantumi3.m4v]

(!Vid) 4. videó
> [!Video https://storage.altinum.hu/szoft1/S1bantumi4.m4v]

(!Vid) 5. videó
> [!Video https://storage.altinum.hu/szoft1/S1bantumi5.m4v]

(!Vid) 6. videó
> [!Video https://storage.altinum.hu/szoft1/S1bantumi6.m4v]

A játéknak nagyon sok változata létezik elérő szabályokkal. A nyerést éppen ezért nem implementáljuk, csak a játéktáblát. 

## Feladatmegoldás lépésről lépésre

(+/-)  Származtass egy osztályt `Lyuk` néven a `Button` osztályból!

``` csharp
public class Lyuk: Button
{
}
```

(+/-)  A Lyuk konstruktorában méretezze magát `50x50` képpontosra!

``` csharp
	public Lyuk()
	{
		this.Height = 50;
		this.Width = 50;
	}
```
(+/-) Bővítsd a Lyuk osztályt teljesen kifejtett getter-setter metódusokkal ellátott `BabokSzáma` tulajdonsággal! (*propfull-tab-tab*)

``` csharp
class Lyuk : Button
{
    private int babokSzáma;
    public int BabokSzáma
    {
        get { return babokSzáma; }
        set { babokSzáma = value; }
    }
    ...
```


(+/-) A setter metódusban állítsd be a `Lyuk` `Button`-tól örökölt `Text` tulajdonságát a beállított babok számának megfelelően!

``` csharp
class Lyuk : Button
{
    private int babokSzáma;
    public int BabokSzáma
    {
        get { return babokSzáma; }
        set { 
            babokSzáma = value;
            Text = babokSzáma.ToString(); 
        }
    }
    ...
```

(+/-) Fordítsd le az alkalmazást, majd helyezz el néhány példányt tervező nézetből a `Fomr1`-en! A *Properties* ablakban be kell tudni állítani a `BabokSzáma` tulajdonságot, ami azonnal megjelenik a `Lyuk` felirataként.

(+/-) Bővítsd a `Lyuk` osztályt szintén `Lyuk` típusú, `KövetkezőLyuk` nevű tulajdonsággal, melyben minden lyuknál beállítható, ki a soron következő lyuk. A getter-setter metódusokat itt nem kell kifejteni. (*prop-tab-tab*)

``` csharp
     public Lyuk KövetkezőLyuk { get; set; }
```

(+/-) Az űrlapon helyezz el tervező nézetben lyukakat, és az óramutató járásával ellentétes irányban haladva a *Properties* ablakon keresztül minden `Lyuk`nál állítsd be a `KövetkezőLyuk` értékét! (Egyértelmű lesz, ha oda jutsz.)

(+/-) Bővítsd a `Lyuk` osztályt `void` típusú `BabotKap` nevű publikus metódussal, mely paraméterként `mennyiBabot` nevű égész típusú paramétert kap! Ha a `mennyiBabot> 0,`
- növelje a `Lyuk` saját babjainak számát egyel a `BabokSzáma` tulajdonságának beállításával, majd
- hívja meg a `KövetkezőLyuk` `BabotKap` függvényét `mennyiBabot-1` paraméterrel!  
        (Egy babot megtart magának, a többit tovább adja a következő Lyuknak. Ha már nincs mit tovább adni, nem csinál semmit.)

``` csharp
    public void BabotKap(int mennyiBabot)
    {
        if (mennyiBabot>0) BabokSzáma++;
            
        if (mennyiBabot-1 >0)
        {                
            KövetkezőLyuk.BabotKap(mennyiBabot - 1);
        }
    }
```

        
(+/-) A `Lyuk` konstruktorában rendelj esemény-kiszolgálót a `Button`-tól örökölt `Click` eseményhez.

(+/-) Az esemény-kiszolgáló hívja meg `KövetkezőLyuk` `BabotKap` metódusát `BabokSzáma` paraméterrel, majd nullázza saját `BabokSzáma` tulajdonságát!   (A megkattintott `Lyuk` minden babját odaadja a következő `Lyuk`-nak.)

``` csharp
    private void Lyuk_Click(object sender, EventArgs e)
    {
        KövetkezőLyuk.BabotKap(this.BabokSzáma);
        this.BabokSzáma = 0;
    }
```
