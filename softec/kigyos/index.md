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

## Játék felépítése lépésenként

### Lépések a kígyós játék felépítéséhez

(+/-)  Származtass a `PictureBox` osztálytól egy új osztályt `KígyóElem` néven!

(+/-) A `KígyóElem` osztályt bővítsd egy méret statikus egész konstanssal, melynek értéke legyen `20`.

(+/-) A `KígyóElem` osztályt bővítsd konstruktorral, melyben az a fenti konstansnak megfelelően 20x20 képpontosra méretezi magát.

(+/-) A `Form1` osztályt bővítsd `fejX` és `fejY` változókkal, melyekben az utoljára kirakott kígyófej koordinátáit tárolod! Állíts be értelemszerű kezdőéréket! (Pl. 100, 100)

(+/-) A `Form1` osztályt bővítsd `irányX` és `irányY` változókkal, melyekben kígyó haladási irályát tárolod! (`-1`,`0`,`1` értékeket vehet fel.) Állíts be kezdőértéket -- ettől függ majd, hogy merre indul a kígyónk!

(+/-) A `Form1` osztályt bővítsd `sorszám` nevű, `0` kezdőértékű változóval!

(+/-) A `Form1`-en helyezz el egy engedélyezett számlálót fél másodperces intervallummal, majd rendelj a `Tick` eseményéhez esemény-kiszolgáló függvényt!

(+/-) Az esemény-kiszolgálóban hozz létre egy új példányt a `KígyóElem` osztályból, majd az iránynak és a méretnek megfelelően változtasd a `fejX` és `fejY` változók értékeit! Ezután már mozogni kell a kígyóknak.

(+/-) Rendelj esemény-kiszolgálót az űrlap `KeyDown` eseményhez.

(+/-) Változtasd a kígyó irányát az esemény-kiszolgáló paramétereként kapott `e.KeyValue` (vagy `KeyCode`) értéke alapján!

(+/-) Valósítsd meg az ütközésvizsgálatot! Járd be az űrlap `Controls` listáját `foreach` ciklussal, és vizsgálj meg minden `KígyóElemet` `ke` néven. Ha van olyan, melynek `Top` illetve `Left` tulajdonságai megegyeznek a `fejY` illetve `fejX` változók értékeivel, a kígyó farkába harapott.

(+/-) Rövidüljön a kígyó. Ehhez először bővítsd egy `hossz` nevű változóval az osztályt, melyben a kígyó aktuális hosszát tárolod! Ha az űrlapon lévő vezérlők száma meghaladja a hossz változó értékét, vedd ki az űrlap `Controls` listájának nulladik elemét!

(+/-) A kígyóelem konstruktorában páros és a páratlan sorszámú kígyóelemeket színezd eltérően!

### Ellenőrző kérdések

1.  Egy űrlapon csak a `Button` osztály példányai vannak. Írd le azt a `foreach` ciklust, mely bejárja az űrlap `Controls` listáját és minden gomb `Visible` tulajdonságát hamis értékűre állítja!
2.  Hogyan lehet az űrlap `Contrlos` listájának egy meghatároztt sorszámú elemét törölni?
3.  Hogyan lehet megtudni, hogy egy lista hány elemet tartalmaz?
4.  Írd le azt a kódrészletet, mely egy számról eldönti, hogy páros-e!
5.  Származtass egy osztályt a `Button` osztályból, mely automatikusan átmétetezi magát 30x30 pixelesre!
