# Emory game
## Videók

(!Vid) 1. videó
> [!Video https://storage.altinum.hu/szoft1/S1emo_1.m4v]

(!Vid) 2. videó
> [!Video https://storage.altinum.hu/szoft1/S1emo_2.m4v]

(!Vid) 3. videó
> [!Video https://storage.altinum.hu/szoft1/S1emo_3.m4v]

(!Vid) 4. videó
> [!Video https://storage.altinum.hu/szoft1/S1emo_4.m4v]

(!Vid) 5. videó
> [!Video https://storage.altinum.hu/szoft1/S1emo_5.m4v]

(!Vid) 6. videó
> [!Video https://storage.altinum.hu/szoft1/S1emo_6.m4v]

(!Vid) 7. videó
> [!Video https://storage.altinum.hu/szoft1/S1emo_7.m4v]

## Feladat lépésenként

[kepek.zip](Kepek.zip)

(+/-)  Letöltés után add a honlapon található képeket a projekthez egy almappába.

(+/-)  Származtass osztályt a `Kártya` néven a `PictureBox` osztályból, mely a konstruktorában átvesz három egész típusú paramétert: a kártya sor és oszlop pozícióját, valamint a kártyán szereplő kép sorszámát. A konstruktorban oldd meg, hogy az átvett paraméterek alapján kártya el is helyezze magát!

(+/-)  Bővítsd a `Kártya` osztályt egy egész típusú `képSzám` nevű változóval, mely a konstruktorban átvett kép sorszám értékét tárolja. A konstruktort bővítsd úgy, hogy tárolja is a `képSzám` változóban a megfelelő átvett paramétert.

(+/-) Bővítsd a kártya osztályt `Felfordít()` metódussal, mely a `PictureBox`-tól örökölt `Load()` metóduson keresztül betölti a megfelelő képet.

(+/-) Bővítsd a kártya osztályt `Lelfordít()` metódussal, mely a `PictureBox`-tó örökölt `Load()` metóduson keresztül betölti a megfelelő „card_back” képet! Tesztelési célból a konstruktor a egyenlőre a `Felfordít()` metódust hívja!

(+/-) A `Form1`  `Load` eseményéhez rendelet eseménykiszolgálóban rakj ki 4x4 Kártyát, most minden kártyára kerülhet más kép.

(+/-) A kártya osztályban `Timer` segítségével oldd meg, hogy a felfordított kártya pár másodperc múlva leforduljon!

(+/-) A kártya osztályban oldd meg, hogy a kártya kattintásra leforduljon!

(+/-) A `Form1` osztályban hozz létre egy 16 elemű egészekből álló tömböt!

(+/-) A `Form1` osztályban hozz létre egy Keverés() nevű függvényt! A függvény helyezze el 1 és 8 között a számokat a tömb elemeiben úgy, hogy minden szám kétszer szereplejen.

(+/-) A kártyákat kirakó ciklus most már a tömb alapján adja át a kártyához tartozó kép sorszámát!

(+/-) Oldd meg, hogy a `Keverés()` metódus a tömb elemeinek cserélgetésével bekeverje a tömböt!

(+/-) A `Form1` kártyákat kipakoló ciklusának törzsében rendelj közös eseménykiszolgálót a kártyák kattintás eseményéhez.

(+/-) A `From1` osztályt bővítsd `utolsóKártya` nevű `Kártya` típusú referenciával. Ebben fogjuk tárolni, hogy melyik kártyát kattintottuk meg utoljára!

(+/-) A közös eseménykiszolgálóban oldd meg, hogy ha az utoljára megkattintott két kártya sorszáma megegyezik, mindkét kártya tűnjön el!
