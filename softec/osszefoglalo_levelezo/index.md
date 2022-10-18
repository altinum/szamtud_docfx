# Szoftvertechnológia I összefoglaló feladatsor 

Az alábbi feladatsor célkitűzése, hogy a félév során érintett valamennyi feladatra mutasson valamilyen formában példát. Nem MintaZH, annál jóval nehezebb és több feladatot tartalmaz, gyakorláshoz melegen ajánlott.

1.	Hozz létre egy osztályt `Ember` néven. Származtasd a `Button` osztályból.
2.	Az osztályban vegyél fel egy-egy nem kifejtett propertyt a keresztnév és a vezetéknév számára.
3.	Vegyél fel egy propertyt a születési dátum számára. Típusa legyen `DateTime`.
4.	Vegyél fel egy propertyt Nem néven. Típusa legyen `char`.
5.	Vegyél fel egy kifejtett propertyt Teljesnév néven. A property ne legyen írható, a getter-ben add vissza a vezetéknevet és a keresztnevet egy szóközzel összefűzve.
6.	Vegyél fel egy kifejtett propertyt Kor néven. A property ne legyen írható, a getterben add vissza a mai dátum és a születési dátum években vett különbségét. Ehhez venned kell a DateTime beépített osztály Now tulajdonságának Year tulajdonságát, és ebből levonni a születési dátum property Year tulajdonságát. 
7.	Készíts paraméterezett konstruktort az Ember számára,  paraméterül kapja a vezetéknevet, a keresztnevet, a nemet és a születési dátumot. Vigyázz, hogy ne legyen a bemenő paraméterek neve azonos a propertykével (vagy kezeld ezt a problémát)
8.	A konstruktorban add értékül a tulajdonságoknak a kapott paramétereket, állítsd be, hogy a gomb szélessége és a magassága egyaránt 60-60 pixel legyen. A férfi nemű emberek esetén kék, a nőnemű emberek esetében rózsaszín háttérszínt állíts be. Figyelj arra, hogy a Nem tulajdonság nem string, hanem karakter, karakterkonstansként kell az egyenlőséget vizsgálni, aposztófjelekkel, lásd: Split tagfüggvény paramétere)
9.	Szintén a konstruktorban rendelj Click eseménykezelőt az Emberhez. Az eseménykezelőben írd ki a teljes nevet és a kort szabványos üzenetablakban.
10.	Készíts az ember osztályában GetMonogram néven egy karakterlánc visszatérési értékű függvényt, bemenő paraméter nem szükséges. 
11.	A függvény adja vissza nagybetűssé alakítva a vezetéknév és a keresztnév első karakterét összefűzve. (ehhez a Substring és  ToUpper tagfüggvényekre lesz szükséged)
12.	Valósíts meg egy egyszerű adatbeviteli felületet a Form1-en, ahol megadható a vezetéknév, a keresztnév, a születési dátum és a nem egy-egy textboxban. A felülethez labeleket is adj, illetve nevezd a kontrollokat értelemszerűen.
13.	Készíts Leave eseményt a születési dátum szövegmezőjéhez. A Datetime.Parse függvény segítségével próbáld date-té alakítani a beírt adatot, ha ez nem sikerül, töröld a textbox tartalmát. A sikertelen értelmezés kivételt okoz, a problémát try-catch hibakezeléssel vagy a TryParse függvény használatával kezeld.
14.	Készíts az előzőhöz hasonló hibakezelést a nem mező számára, csak nagy F és nagy N betűket fogadjon el. Állítsd be a textbox számára hogy csak maximum 1 karakter hosszú szöveget lehessen beleírni (MaxLength tulajdonság)
15.	Hozz létre egy emberekből álló listát `(List<Ember>)`a Form1 osztály szintjén.
16.	Adj egy gombot a formhoz.
17.	A gombhoz rendelj Click eseménykezelőt.
18.	Az eseménykezelőben vizsgáld meg, hogy minden szükséges adat meg van-e adva, és ha igen, példányosíts egy Ember-t, állítsd be a tulajdonságait a megadott adatok alapján, majd add az emberlistához. Ezt követően töröld a beviteli mezőket. Ha nem helyesek az értékek, akkor írd ezt ki egy szabványos üzenetablakban. (A művelethez érdemes tudni, hogy egy karakterlánc első karakterét az s[0] formában nyerhetjük ki.)
19.	Adj a formhoz egy panelt. Állítsd be az Autoscroll tulajdonságát true-re.
20.	Adj a formhoz egy másik gombot Betölt szöveggel. Adj hozzá Click eseménykezelőt.
21.	Az eseménykezelőben egy megfelelő ciklussal haladj végig az emberlistán és add a panel kontrolljainak listájához a benne szereplő embereket. Az egyes gombok Text tulajdonsága legyen az adott ember monogramja, amit a korábban megírt GetMonogram függvény segítségével kaphatsz meg. A gombok egymás alatt helyezkedjenek el! Próbáld megvalósítani a sakktábla elrendezést is, illetve próbáld többféle ciklussal is megoldani a problémát!
22.	A cikllusban rendelj közös eseménykezelőt a MouseEnter és a MouseLeave eseményhez. 
23.	Az Enter eseménykezelő állítsa be a textboxok adatait az aktuális példány segítségével. A Leave eseménykezelő törölje az adatokat. (Ehhez a „sender” castolására lesz szükség - `as` operátor ) 
24.	Egészítsd ki az alkalmazást fájl beolvasással. Kétféle input formátumot kezelj: az egyikben soronként a másikban pontosvesszővel elválasztott formátumban legyenek az `Ember` adatok. A fájlokat manuálisan hozd létre, pl. Jegyzettömb segítségével. 
25.	Mindkét fájl típusohoz helyezz el egy-egy gombot a formon.
26.	A fájlok megnyitását `OpenFileDialog` segítségével végezd, majd a beolvasó ciklusban hozz létre ember példányokat és add a listához.
27.	Adj egy nem engedélyezett időzítőt a Form1-hez, lehet kódból vagy tervezőnézetből is.  Állítsd az időközt 1 másodpercre.
28.	A Form1 konstruktorában engedélyezd az időzítőt.
29.	Írd meg a Tick eseménykezelőt, minden Tick esemény írja ki a Form fejlécébe (Text tulajdonság) az aktuális időpontot. (`DateTime.Now.ToString()`)
30.	Adj két gombot a formhoz nőkszáma és férfiakszáma felirattal. Mindkettőhöz rendelj eseménykezelőt. Az eseménykezelő egy megfelelő ciklussal járja be az ember példányokat a panelen és számolja meg a nőket illetve a férfiakat. Végül üzenetablakban írja ki a férfiak illetve nők számát. Próbáld meg a problémát közös eseménykezelővel is megoldani!
31.	Keress két képfájlt az interneten. A képek férfiak és nők szimbolizálására legyenek alkalmasak (pl gender jel, toalett jel), és legyenek kis méretűek.
32.	Add a képeket  projekthez, állítsd be, hogy automatikusan kimásolódjanak a projekt bin\Debug mappájába.
33.	Alakítsd át az ember osztályt úgy, hogy ne Buttonból hanem PictureBoxból örököljön.
34.	Egészítsd ki az Ember osztály konstruktorát úgy, hogy háttérképének beállítsa ezeket a képeket.
(A két előző lépés nyomán a gombra kiírt monogram eltűnik, mivel a PictureBox Text tulajdonsága más célt szolgál. Ezt  problémát orvosolhatod például úgy, hogy az Embert nem alakítod Picturebox-szá, hanem Button marad, és a Button BackgroundImage tulajdonságát állítod be, pl:  
`this.BackgroundImage = Image.FromFile("Névtelen.png"); `
Ha szeretnéd, hogy a gomb felirata ne lógjon bele a képbe, a gomb `TextAlign` tulajdonságát lehet beállítani.)
35.	Helyezz ki a formra egy másik panelt. Állítsd be, hogy a háttérszíne fehér legyen.
36.	Készíts két visszatérési érték nélkül függvényt a form1-re, amely erre az új panelre kirajzol egy egyszerű férfi illetve női vonalrajzot (grafika használatával, vonalak és ellipszisek segítségével, például). 
37.	A korábban megírt MouseEnter eseményeket egészítsd ki a nemtől függően vagy az egyik, vagy a másik meghívásával. Ha szeretnéd, hogy a MouseLeave esemény törölje a rajzpanelt, akkor az új panel `Invalidate` tagfüggvényének meghívásával ezt megteheted.
38.	Helyezz el egy új gombot a Form1-en "Sorsolás" felirattal, rendelj hozzá Click eseménykezelőt. Az eseménykezelőben generálj egy véletlenszámot az Ember lista méretének megfelelően, majd írd ki szabványos üzenetablakban a kisorsolt ember nevét. A sorsolás ne csináljon semmit, ha az emberek lista üres! Figyelj rá, hogy a lista indexelése 0-tól indul!
39.	Próbáld megoldani, hogy a sorsolás ne csak megjelenítse, hanem törölje is ki a véletlenszerűen kiválasztott embert a Control listából.
40.	Egy újabb gomb segítségével töröld a gombokat tartalmazó panelt, illetve az emberek lista tartalmát.
