# 2. ZH - delta

A [italok.txt](italok.txt) fájlban található adatok alapján kell egy alkalmazást felépíteni. 

A fájl felépítése:

|                    |                                                            |      |
| ------------------ | ---------------------------------------------------------- | ---- |
| `ItalID `          | az ital azonosítója                                        |      |
| `Nev   `           | az ital neve                                               |      |
| `Alkoholtartalom ` | az ital alkoholtartalma, 0-100, százalékban értendő        |      |
| `EgysegAr `        | az ital egységára                                          |      |
| `Nepszeru   `      | boolean típus, 1- az ital népszerű 0- az ital nem népszerű |      |

> [!NOTE]
>
> Az alkalmazás felépítésekor célszerű követni a feladat mellé rakott képernyőképeket, melyek segítségül és kiindulási alapként szolgálnak!

Készíts alkalmazást, amely:

(+/-) A csv állományt tedd be a projektbe, és másoltasd a futtatható állomány mellé!

(+/-) Adj a projekthez egy osztályt, amely leképezi az állomány egy sorát!

(+/-) A program legyen képes megnyitni az állományt, és a sorait felolvasni egy `BindingList` típusú, `Form1` osztály szintjén létrehozott listába, majd ezeket megjeleníteni `BindingSource`-on keresztül egy `DataGridView`-ban. A lehetséges hibákat kezeld! A betöltés művelet történjen gombnyomásra!

![image1](image1.png)

(+/-) Az alkalmzás legyen képes menteni a `Form1` osztályban lévő listát. A mentés helye SaveFileDialog-ban legyen kiválasztható

Mentés közben kezeld a hibákat (try-catch)! 

![image3](image3.png)

(+/-) Hozz létre egy gombot, melynek segítségével a rácsban az éppen kiválasztott sor törölhető. A törlés csak megerősítő kérdés után történjen meg.
Ellenőrizd, hogy van-e kiválasztott sor!

![image4](image4.png)



![image5](image5.png)



(+/-) Felugró ablakon keresztül legyen lehetőség új sor rögzítésére!



![image6](image6.png)



(+/-) Hozz létre egy gombot, amelyre felugrik egy MessageBox, ami a következő kérdésekre ad nekünk választ:

1) Hány népszerű ital szerepel a listában?
2) Melyik italt kell választanom ha igazán be akarok rúgni ma este és nem akarom a véletlenre bízni? Mennyi ennek az alkoholtartalma?

![image7](image7.png)