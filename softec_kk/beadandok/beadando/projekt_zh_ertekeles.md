

# Projekt ZH értékelésének szempontrendszere

> [!IMPORTANT]
>
> Maximális pont arra a projektfeladatra kapható, mely a feltöltött forráskódból lefrodítható, és a feladatleírásban lefektetett követelményeknek eleget tesz. A feltöltött alkalmazásnak használhatónak és hibatűrőnek kell lennie!

## ZH-ra behozható anyagok

A ZH-ra kiinduló fájlok, mint képek, adatokat tartalmazó csv, és egyéb állományok behozhatóak, ezeket Moodle-be kell feltölteni csütörtök reggelig, és onnét lehet letölteni a ZH sáv első 5 percében. Ezután már csak a Visual Studio fejlesztőkörnyezet és a futtatott alkalmazás lehet nyitva. Forráskódot és papír alapú segítséget használni nem lehet. 

## A pontozás menete 

A pontozás során 20 pontról indulunk, és az esetleges hiányosságokért pontlevonásra kerül sor -- arra számítunk, hogy a feltöltött megoldások döntő többsége megfelel a követelményeknek, így maximális pontot kap. 

Az egységesen alkalmazandó pontlevonásokat az alábbi táblázat foglalja össze:

|                                                              |               |
| ------------------------------------------------------------ | ------------- |
| **Fordíthatóság**: Ha a forráskód nem fordítható le, megjegyzésbe tesszük a hibás részeket, és fordítás után kerül a kód értékelésre. Nem fordítható kód esetén a működő feladatrészekre kapott pontból 5 pont kerül levonásra. Ha a kód súlyos elvi hiba miatt nem fordítható (pl. osztály szintjére írt vezérlő szerkezetek stb.), további 5 pont kerül levonásra. Megjegyzésbe írt kódrészleteket nem értékelünk. | **-2x5p**     |
| **Megvalósítás**: az elkészült alkalmazás milyen mértékben nyújt megoldást a kapott feladatra – a program valóban alkalmas-e a kapott probléma kezelésére. Ha valamely funkció nem működik, vagy hibásan működik, a nem működő feladatrész komplexitásával arányosan kerül levonásra pont. | **arányosan** |
| **Vizuális megjelenés és kezelhetőség** vezérlők kézre eső, áttekinthető elhelyezése, átméretezhető ablakok kezelése, stb. Ha egy felhasználó ránéz a programra, akkor segítség nélkül rá tudjon jönni, hogyan kell használni. Itt kerül értékelésre az igényes megjelenés. A szürke háttéren szürke gombok is lehetnek igényesek, de egy egyszerű design sokat javíthat a megjelenésen. Ha javítás során a kódból kell kiovasni, hogy hogyan kell hasznáni a programot, 3 pont kerül levonsára. A kígyónál az irányításra az `ASWD` gombokkal illetve a nyilakkal történő irányítást ismertnek vesszük. | **-3p**       |
| **Az alkalmazás hibatűrő képessége**: itt azt vizsgáljuk, hogy hibás adatok megadásával meg lehet-e akasztani a program működését, vagy egy hiányzó, esetleg hibás adatokat tartalmazó fájl kezeletlen kivételt generál-e. A `try` `catch` blokkok fontos szerepet játszanak ebben a kategóriában. Ezen a kategórián legfeljebb 5 pontot lehet veszteni. | **-5p**       |
| **Kód olvashatósáága**: Itt kerül értékelésre a forráskód olvashatósága – beszédes változónevek, kód tördelése, megfelelő behúzások, stb. Működő, de olvashatatlan kódon egfeljebb 2 pont veszthető. A kód automatikus formázására érdems a `Ctrl` billentyű nyomvatartása mellett lenyomni a `K` majd a `D` billentyűket. | **-2p**       |
| **Fájlok elérhetősége:** Ha a projekt adatokat vagy képeket olvas fájlból, ezeket a projekthez kell adni, és a `Copy to output directory` megfelelő beállításával fordításkor a futtattható állomány mellé másoltatni. Ha abszolút elérési útvonal kerül beállításra (pl. `C:\User\......`, melyet javításkor át kell írni, 4 pont kerül levonásra. | **-3p**       |

## Pótlási lehetőség

A vizsgaidőszak első péntekén de. 10 órára adtam le teremfoglalást, amit visszaigazolják, írok. Ezen alalommal egy ZH pótolható -- a projekt ZH is ZH-nak tekintendő. 