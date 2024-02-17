# Verziókövetés a gyakorlatban

## Bevezetés
A verziókövetés (vagy forrás-menedzsment) azoknak a folyamatoknak és eszközöknek az összessége, melyek segítségével a fejlesztés alatt álló munka egyes változatai elkülöníthetőek, és így a változások is nyomonkövethetőek.

Általánosságban az egyes változatokat valamilyen egyedi azonosítóval látják el (ami lehet egy név, egy szám, vagy akár egy hash-kód is).

## Célok
A verziókövetési folyamatok kialakításának többféle célja van, a fejlesztő csapat igényeitől és a projekttől függően.
* Változatok elkülönítése
* Biztonsági mentések
* Magas reszponzibilitás az ügyfelek felé
* Közös munka támogatása
* Robusztus fejlesztési folyamat
* Különböző termékverziók támogatása  

A fenti céloknak együttesen nem feltétlenül kell megvalósulnia, mivel ez feleslegesen megnövelheti az adminisztrációs többletterhelést.

### Változatok elkülönítése
Fontos célja a verziókövetésnek, hogy az egyes termékverziók elkülöníthetőek legyenek, és ezzel a fejlesztőnek lehetősége legyen javításokat, vagy kisebb ügyféligényeket is kielégítenie amellett, hogy új termékverziót fejleszt.

### Biztonsági mentések
Abban az esetben, ha egy feladat során a választott megoldás hibás, nem optimális, vagy az ügyfélnek végül nincs is szüksége rá, a biztonsági mentések megléte lehetőséget ad visszatérni a kiindulási állapotra. A mentések mindemellett menekülési utat jelentenek a gondatlanságból (vagy szándékosan) elkövetett károkozás esetén is (például a fejlesztő véletlenül letörölt egy egyébként szükséges kódrészletet).

### Magas reszponzibilitás az ügyfelek felé
Napjaink egyik legfontosabb ügyfél-követelménye a rövid válaszidő. A fejlesztést végző csapatnak törekednie kell arra, hogy egy új igény felmerülésétől (ami lehet egy hibabejelentés is) a megoldás szállításáig a lehető legrövidebb idő teljen el.

### Közös munka támogatása
A komplex ügyféligények (rugalmas üzleti logika, intuitív felhasználói felület, üzemeltethetőségi és automatizálási szempontok, stb) miatt a fejlesztett termékek maguk is olyan összetettek, hogy általában többtagú csapatok együttműködését igénylik. A rendelkezésre álló munkaerő kihasználtságát leghatékonyabban úgy lehet növelni, ha ugyanazon a feladaton párhuzamosan többen is tudnak dolgozni.

### Robusztus fejlesztési folyamat
Egy-egy új fejlesztés mindig rejt valamilyen kockázatot magában. A verziókövetés egyik célja emiatt a felmerülő kockázatok minimalizálása, például a karbantartó-jellegű munkák (hibajavítások és kisebb módosítások) és az új termékverzió fejlesztésének izolálásával.

### Különböző termékverziók támogatása
Egyes esetekben (pl. "dobozos termékek") a gyártónak több termékverziót is párhuzamosan kell tudnia fejlesztenie és karbantartania. A verziókövetési módszertanok lehetőséget biztosítanak arra, hogy a termékverziók karbantartása és fejlesztése párhuzamosan és elkülönítve futhasson, illetve egyes fejlesztéseket át lehessen vezetni az izolált verziók között.

## Eszközök
Verziókövetésre számtalan rendszer létezik. Ebben a fejezetben röviden szó esik néhány elterjedtebb eszközről. Célszerű olyan eszközt választania a fejlesztőnek, vagy csapatnak, amiben van tapasztalata, vagy közel áll a megközelítéséhez.

A legtöbb verziókövető rendszer centralizált. Ilyen rendszerekben általában a változtatások azonnal bekerülnek a központi repository-ba, illetve addig nem is kerülhetnek be, amíg a fejlesztő környezete nincs szinkronban a központi változattal. A szinkronizáció ilyenkor gyakorlatilag folyamatos.

Léteznek elosztott rendszerek is. Ebben az esetben a szinkronizáció nagyobb odafigyelést igényel, hiszen a helyi változatba a távoli változatoktól függetlenül is bekerülhetnek változtatások egész sorozatai. A szinkronizáció ilyenkor alapvetően a helyi és távoli, azonosnak tekintett fejlesztési ágak összefésülését jelenti.

### SVN
A Subversion egy nyílt forráskódú, centralizált verziókövető rendszer, amelyet az Apache Foundation gondoz.

A Subversion használata során a working copy egyszerre tartalmaz(hat)ja az összes fejlesztési ágat, így esetenként jelentős tárhelyet is igényelhet a fájlrendszeren. Ennek köszönhetően ugyanakkor a fejlesztési ágak közötti váltás igen gyors, gyakorlatilag annyit jelent, hogy a fejlesztő átáll egy másik munkakönyvtárra. Ezt ugyanakkor figyelembe kell venni a projekt tervezésekor: gyakori hiba, hogy a forrásállományokban abszolút elérési útvonalak szerepelnek, amelyek az SVN-hez hasonló working copy kezelés esetén teljesen ellehetetlenítik a több branch-es munkamódszereket.

Subversion-t alkalmazó projektek:
* Free Pascal
* Free BSD
* GCC
* SourceForge

### TFVC
A Microsoft DevOps (Régebben: Microsoft Team Foundation Server) belső verziókövetője a Team Foundation Version Control. Ez egy Microsoft által fejlesztett, zárt forráskódú verziókövető rendszer, amelyet az emel ki a mezőnyből, hogy egy teljes projektmenedzsment szoftver része, ahhoz pedig így szorosan integrált. Ez az integráció azt jelenti, hogy az egyes delták (a Microsoft terminológiájában "change set"-ek) azonosítójukkal együtt összerendelhetőek a feladatokat leíró objektumokhoz (Work item).

A TFVC gyakorlatban az SVN-hez hasonló módon kezeli a working copy-t, és szorosan integrált a Microsoft Visual Studio-val is. A szoros integráció okán gyakran "TFS"-ként hivatkoznak a rendszerre.

### GIT
A Linux kernel fejlesztésére Linus Torvalds fejlesztette ki ezt az elosztott verziókövető-rendszert. A GIT-ben éppen ezért általánosságban nem beszélünk központi repository-ról, hanem csak helyi és távoli repository-t különböztetünk meg. Nagyobb csapatok mindazonáltal egy közös tárolóhelyen tartanak egy working copy nélküli (ún. "bare") repository-t, amelyet központiként kezelnek.

A GIT egyik legfontosabb karakterisztikája, hogy a tervezéskor feltételezték, hogy egy változtatást többször kell majd összefésülni más változtatásokkal, mint módosítani. A GIT-ben a delták egy mutatót tartalmaznak a szülőjükre, ezzel együtt a branch is egyszerűen egy címke, amellyel egy deltát megjelöl a rendszer.

## A verziókövetők működése
Általánosságban a verziókövetők rendelkeznek egy adatbázissal, amelyben az egymásra épülő változtatásokat tárolják. A változtatások újraalkalmazásával tudják előállítani a kezelt projekt egy adott változatát.

Egy változtatás úgy jön létre, hogy a program összehasonlítja az általa ismert legfrissebb változatot az aktuálisan szerkesztett fájlokkal. Az aktuális változások összességét **delta**-nak nevezzük, és ezeket tároljuk az adatbázisban. Ez a gyűjtemény a projekt **repository**.

Az éppen szerkesztett fájlok és könyvtárak összessége a munkaváltozat, vagy **working copy**.

Bizonyos fájlokat a verziókövető elől el lehet, és javasolt is elrejteni. Tipikusan ilyenek a felhasználó helyi környezetével kapcsolatos állományok (Visual Studio esetén pl. a ".suo" kiterjesztésű fájlok), illetve a generált, vagy fordított fájlok. Ezek kizárásával egyrészt biztosítható, hogy a repository ne tartalmazzon egy-egy felhasználóhoz köthető, specifikus konfigurációt, és csökkenthető a repository mérete a felesleges fájlok kizárásával.

### Bináris állományok kezelése
Mivel a forráskódok általában szöveges fájlok, ezért a verziókezelők is elsősorban szöveges fájlok kezelésére vannak felkészítve. Bináris fájlok változtatásait általában nem, vagy csak limitált módon tudják kezelni. Ilyenkor általában a régi és az új fájl teljes egészében szerepel a repository-ban.

### Repository
A GIT az egyik legelterjedtebb verzió követő megoldás. Ez egy úgynevezett elosztott verziók követő rendszer, vagyis nincs kijelölt központi repository-ja, csak különböző lokális és távoli gyűjteményeket kezel.

A távoli, vagy **remote repository** bárhol lehet, de általában egy kijelölt, szerver szolgáltatást (pl.: GitHub, GitLab) használnak a csapat által létrehozott delták tárolására.

A helyi vagy **local repository**-k az egyes fejlesztők gépein találhatók, és bizonyos időpontokban pontosan megegyeznek a távoli repo-val. A verzió követési folyamatok központi eleme a távoli és a helyi repository-k szinkronizálása.

A **klónozás** az a folyamat, mely során egy kiinduló másolatot készítünk a távoli repo-ról a helyi repository-ba. Klónozáskor ki kell választani egy munkakönyvtárat (**working directory**). Ebben lesznek elérhetők az aktuális munkaverzió állományai.

### Alapfogalmak
A forráskód eredeti állapotából és a deltákból bármely tárol állapot újra előállítható. A fájlok egy aktuális változatának kiválasztását **checkout**-nak hívjuk. A checkout-ot követően a munkakönyvtár állományai a kiválasztott verziónak megfelelően módosulnak.

A munkakönyvtárban végzett változtatások önmagukban nem befolyásolják a repository-t. Túl nagy terhelést jelentene, és a delták átláthatatlan méretű halmazát eredményezné, ha minden egyes karakterleütést külön tárolnánk. Ezért a változások csak akkor tárolódnak az adatbázisban, ha azok jóvá lettek hagyva (**commit**). A commit következtében azonban csak a lokális repository frissül. A változásokat még fel kell küldeni (**push**) a távoli repo-ba annak érdekében, hogy a többi fejlesztő is elérje az aktuális változásokat.

Az összetett fejlesztési projektek ritkán lineárisak, ezért szükség van a különböző fejlesztési irányok közti váltás lehetőségére. A változtatások egy új ágát **branch**-nek nevezzük. Ha a munka könyvtár módosult, akkor a létrejövő delta a legutoljára checkout-olt branch-hez lesz rendelve. Lehetőség van arra, hogy a commit előtt váltsunk branch-et, de nem ajánlott.

A **fetch** folyamata frissíti a lokális repository-t távoli tartalmának megfelelően. Fontos azonban megjegyezni, hogy ez csak az adatbázist érinti, a fetch a munkakönyvtárat nem fogja befolyásolni.

A verziókövető szoftverek nagyon gyorsan képesek váltani a kód különböző verziói között. Ennek érdekében az egyes ágak különböző változatainak előre összeállított változatait a lokális gépen tárolják. Így ahhoz, hogy elkezdjünk dolgozni egy branch-en, először létre kell hozni belőle egy lokális változatot. A fetch-elés nem fogja megváltoztatni ezeket a lokális verziókat. Az adott branch legújabb verziójának eléréshez (tehát a munka könyvtár frissítéséhez is) a változásokat le kell húzni (**pull**) a repository-ból.

Előfordulhat, hogy a távoli repository-ban változtatások történtek egy olyan ágon, amin éppen dolgozunk. Ebben az esetben a szoftver hibát fog jelezni, amikor megpróbáljuk push-olni a változtatásainkat. A megoldás, hogy a távoli változtatásokat lehúzzuk a lokális branch-ünkbe. Ha a másik változások a szoftver eltérő részét érintik, akkor a verziókövető szoftver általában gond nélkül összefésüli, azaz **merge**-eli a távoli és a lokális változtatásokat. Ha azonban ugyanazokat a részeket módosított a két fejlesztő, akkor a szoftver nem lesz képes priorizálni, és jelezni fogja az összeütköző (**conflict**) részeket. Ebben az esetben manuálisan kell megoldani a változások összefésülését. A konfliktusok esélyét egyrészt kisméretű fájlok használatával (vö.: Single Responsibility Principle), másrészt a munka megfelelő kiszervezésével lehet csökkenteni, de hosszú távon gyakorlatilag elkerülhetetlenek.

## Módszertanok
Amikor verziókövetésről beszélünk, akkor együttesen értjük az alkalmazott folyamatokat, és a folyamatokat kiszolgálni képes eszközöket. Emiatt ez a fejlesztők részéről feltételezi mind a folyamatok, mind pedig az eszközök megfelelő szintű ismeretét.

Általánosságban a folyamatok összességét "branching strategy"-nek nevezik.

### Fájlszintű mentés és névkonvenció alkalmazása
A legegyszerűbben megvalósítható verziókövetési módszertan, amikor az egyes változatokat a forrásállományokról és a forrásállományokat tartalmazó könyvtárakról a munka során ismételten mentéseket készítünk.

A módszer előnye, hogy minden eszköz nélkül alkalmazható, egyedül egy névkonvencióra van szükség, amivel a fejlesztő azonosítani tudja az egyes változatokat. Az egyes változatok összehasonlítása azonban már nehézkes, és a módosítások visszaállítása sem feltétlenül egyértelmű. Ez a megközelítés csapatmunkára sem alkalmas.

Tanulási célokra, vagy PoC feladatok megoldására mindazonáltal alkalmazható, mivel nincs szükség egyéb eszközök bevonására.

### Verziókövető eszköz alkalmazása egy branch követésével
Egy tetszőlegesen választott verziókövető rendszer alkalmazásával lehetővé válik a fájlszintű mentések készítéséhez képest jóval kisebb változtatások (ún. "delták") követése, így biztonságosabbá tehető a fejlesztés folyamata. Ezek a szoftverek rendelkeznek olyan eszközökkel, amelyek segítségével egyes verziók könnyedén összehasonlíthatóak, illetve az egyes változatok közötti átállást is támogatják.

A folyamatosan egymásra épülve evolválódó kódbázisban ugyanakkor, mivel egyetlen ágon (branch-en) folyik a fejlesztés, nem, vagy csak nehézkesen dolgozhat több fejlesztő együtt. Az egyes termékverziók elkülönített kezelése sem támogatott.

Egy fejlesztési ágon az alábbi esetekben érdemes fejleszteni:
* Összetett PoC feladat megoldásakor
* Kisebb hobbiprojektek során
* Termékek korai fázisában

### Éles és fejlesztési változat izolációja
A fejlesztési és éles (esetleg teszt) változatok szétválasztásával biztosítható, hogy az ügyfél igénye szerint gyorsan hibajavításokat tudjon szállítani a fejlesztő az izolált változatokra.
Ügyelni kell azonban az izolált változatokban létrehozott módosítások átvezetésére (merge-lésére) a branch-ek között.

Ez a módszer már fokozott fegyelmezettséget igényel a fejlesztőtől, mivel a telepítéssel párhuzamosan az egyes változatok között szinkronizálni szükséges a kódbázis változtatásait.

Mivel az éles és fejlesztési változatok már izoláltak, ez a módszer már alkalmas arra, hogy kisebb üzleti projekteket is ezzel a módszerrel kövessen a fejlesztő. Sajnos a gyakorlatban gyakran előfordul, hogy ehhez képest jóval komplexebb projekteket is ilyen módon követnek a nyilvánvaló hátrányok ellenére.

Ez a megközelítés nem alkalmas csapatmunkára, illetve az agilis módszertanok kiszolgálására is legfeljebb korlátozottan.

### Feature branching
A fejlesztők megtehetik, hogy a saját fejlesztéseiket nem közvetlenül a fejlesztési ágon végzik el, hanem abból leágazva saját, ún. "feature branch"-eket hoznak létre. Ezzel a megközelítéssel lehetővé válik a hatékony csapatmunka, hiszen a fejlesztők egymástól izoláltan végezhetik a munkájukat. Emellett, mivel a fő fejlesztési ágra (leggyakrabban "development", vagy "dev" néven hivatkozott ágra) már csak viszonylag stabil változatok kerülnek, a termék fejlesztési változata általánosságban stabilabbnak tekinthető, mint a korábbi megközelítések során.

A fejlesztőktől ez a megközelítés az alkalmazott eszközök és folyamatok mélyebb ismeretét, fegyelmezettséget, és csapatszinten kidolgozott és betartatott folyamatokat követel meg. Emellett megemlítendő a komolyabb adminisztrációs teher, ami különösen kisméretű és nagy időnyomás mellett szállítandó módosítások mellett kifejezetten hátráltató tényező is lehet. (Ezt a hátrányt azonban a folyamatok rugalmas megtervezésével eliminálni lehet.)

Mivel félkész fejlesztés (elméletileg) nem kerülhet már a dev ágra sem, sokkal gyakrabban lehet új változatokat szállítani az ügyfelek részére.

A fő fejlesztési ág emellett további policy-k alkalmazásával tovább védhető:
* **Code review** - Az elkészült fejlesztést a csapat, és kiemelten a csapat vezető fejlesztője átnézi (statikus kódelemzés), és jelzik az eltéréseket a közös konvencióktól, vagy a kódban felfedezett egyéb architekturális vagy szemantikai hibákat.
* **Sikeres build** - Az ún. "build szerveren" futtatott sikeres build, mint előfeltétel, biztosítja, hogy a fő fejlesztési ágra olyan kódváltozat kerülhet csak be, ami legalább fordítási hibát okozó problémákat (pl. szintaktikai hibákat, vagy nem megfelelően feloldott függőségeket) nem tartalmaz.
* **Kötelező unit tesztek** - A kód egyes elemi egységeit automatizáltan tesztelő tesztek előfeltételként történő futtatása lehetőséget ad a fejlesztő csapatnak arra, hogy a kód egymástól logikai értelemben véve távol álló komponenseiben keletkező hibákat időben felfedezzék.

### Termékverziók izolációja
Egyes esetekben szükségessé válhat egy kódbázisban, hogy a fejlesztést végző csapat különböző termékverziókat párhuzamosan támogasson. Ilyen lehet például egy dobozos termék fejlesztése. Ebben az esetben a korábbiakhoz képest nem csak egyetlen fejlesztési (és teszt és éles) ágat vezet a csapat, hanem termékverziónként egyet-egyet. Ez a megközelítés ugyanakkor nagyon komoly felkészültséget igényel a fejlesztő csapattól, és igen jelentős az adminisztrációs teher. Fokozott odafigyelést igényel a hibajavítások, és egyéb fejlesztések átvezetése a termékverziók között, hiszen azok kódbázisai jelentős mértékben eltérhetnek egymástól.

## Példa munkafolyamat 
Tegyük fel, hogy egy fejlesztői csapat dolgozik egy nagyobb projekten, és már a publikus kiadás kapujában állnak. Azért, hogy jelezzék, a termék még fejlesztési fázisban van, a főverziószám "0", jelenleg a v0.2-es termékverziónál tartanak.

![version-control.png](./version-control.png)
A fejlesztői csapat két fejlesztést indít el párhuzamosan. Egy nagyobb lélegzetvételű projektet indítanak, amelyet csak élesindulás után indítanak el, illetve ezzel párhuzamosan egy kisebb fejlesztést is, aminek viszont el kell készülnie. Ezért a két fejlesztő két branch-et indít el, amelyen fejleszteni kezdik a funkciókat. Amint elkészült az élesinduláshoz elengedhetetlen funkció, azt visszamerge-ölik a development ágra, majd sikeres tesztet követően létrehoznak egy v1.0 nevű "release" branch-et. Erre a branch-re már csak hibajavításokat fogadnak el a továbbiakban.

Mindeközben a bétatesztelőktől érkezik egy komoly hibabejelentés, amelyre azonnal válaszolni kell, ezért a hotfixet soron kívül implementálják. A hotfix-et külön branch-en implementálja a fejlesztő. A sikeres tesztet követően ezt a branch-et azonnal átvezetik a futtatókörnyezetet leképező "master" branch-re, és indítanak egy build-et, amelynek eredményeként a javítás azonnal települ is a szerverre. Közben a javítást visszavezetik a "development" branch-re is, hogy a kódbázis része legyen.

A csapat a példában a verziókövető eszközök és módszertanok használatával képes volt párhuzamosan javítani egy kritikus hibát, befejezni egy, az élesinduláshoz nélkülözhetetlen fejlesztést, és dolgozni egy nagyobb méretű, jövőben átadandó funkción.

## Végül
Az alkalmazott eszközök és folyamatok hatékonysága nagyban függ az azt alkalmazó csapat fegyelmezettségétől, és rugalmasságától. A gyakorlati tapasztalat azt mutatja, hogy bizonyos szituációkban - leggyakrabban nagy időnyomás esetén - az egyébként szofisztikált szabályok tudatos és körültekintő áthágása (pl. "kalóz" kommit a "dev" branch-re) segíthet. Ez azonban nem válhat általános gyakorlattá, hiszen azzal a korábban megszerzett előnyök azonnal elillannak.
