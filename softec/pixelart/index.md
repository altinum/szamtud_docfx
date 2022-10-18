# PixelArt
A feladat célja egy egyszerű rajzoló program elkészítése, mellyel 8x8 pixeles ábrákat lehet rajzolni Label-ből származtatott objektumok átszínezésével.
 
## 1. Pixel osztály

(+/-) a.	Származtass osztályt a `Label` osztályból `Pixel` néven!

(+/-) Az osztály szintjén legyen egy `Selected` nevű `bool` típusú változó, mely alapértelmezetten `false` értéket kap. 

(+/-) Az osztályban szintjén ezen felül hozz létre egy `DefaultColor` nevű `Color` típusú objektumot is, amely a „sötét szürke” színt kapja alapértékként, valamint egy `SelectedColor` nevűt, ami a feketét. Utóbbi objektum publikus legyen!

(+/-) A konstruktorban állítsd be a `Pixel` színét a `DefaultColor`-ra és rendelj eseménykezelőket kódból a `Click`, a `MouseLeave`, és a `MouseEnter` eseményekhez.

(+/-) A `MouseEnter` eseménykezelőben állítsd be a `Pixel` hátterét a `SelectedColor`-ra, amennyiben a `Selected` változó értéke hamis.

(+/-) A `MouseLeave` eseménykezelőben állítsd be a `Pixel` hátterét a `DefaultColor`-ra, amennyiben a `Selected` változó értéke hamis.

(+/-) A `Click` eseménykezelőben váltsd át a `Selected` változó értékét (`true` -> `false`, `false` ->`true`), majd, ha a `Selected` igaz, akkor a `Pixel` háttere legyen a `SelectedColor`, egyébként pedig a `DefaultColor`. 

## 2.	 Form összeállítása

(+/-)Tegyél ki a `Form1`-re egy `Panel`-t és három `TextBox`-ot az ábrán látható módon. A `TextBox`-ok `Text` tulajdonságát tervezőből állítsd „0”-ra. A `Panel` mérete legyen 240x240. 

(+/-) A `Form1` konstruktorában egymásba ágyazott for ciklusokkal helyezz ki 8x8 példányt a `Pixel` osztályból a `Panel`-re. (A `panel1` vezérlőihez add az objektumokat és ne a `Form1`-hez.) A `Pixel`-ek értelem szerűen helyezkedjenek el hézagok nélkül és mindegyik legyen 30x30-as méretű. 

## 3. Színezés

(+/-)Rendelj közös eseménykezelőt a három `TextBox`-hoz!

(+/-)Az eseménykezelőn belül hozz létre három `byte` típusú változót `r`, `g` és `b` néven `0` kezdőértékkel.

(+/-)Egy `try-catch` blokkon belül olvasd be a három változó értékét rendre a három `TextBox`-ból és a `catch` ágat hagyd üresen. 

(+/-)A beolvasás után egy `foreach` ciklussal menj végig a `panel`-ben található `Pixel`-eken és mindegyik `SelectedColor` tulajdonságát állítsd a megadott RGB értékeknek megfelelően. Segítség: `Color.FromArgb(r,g,b)`

![1602072975369.png](../../images/1602072975369.png)
