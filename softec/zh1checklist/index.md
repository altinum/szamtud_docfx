
Azt tanácsoljuk, hogy a felkészülést ne hagyjátok az utolsó pillanatra. A lenti *checklist* átnézése után érdemes az összes eddigi mintafeladatot megoldani a feladathoz tartozó lépésekre bontott útmutató alapján. Az első ZH-ban a feladatleírások egyértelmű, elemi lépésekre lesznek bontva. Még nem várunk el önálló ötleteket, csak némi jártasságot Visual Studio fejlesztőkörnyezet használatában, és *checklist* részben felsorolt nyelvi elemek ismeretét. 

A zárthelyin egy darab A4-es kézzel írott jegyzet használható, azonban nem szerencsés, ha ez a segítség hamis biztonságérzetet ad. Ha valakinek nincs meg a gyakorlata, nem tud elég gyorsan javítani olyan egyszerű hibákat, mint mint egy hiányzó `;` vagy `}`. 

Egy gyakorlati tanács: a ZH solution-jét ne az S: meghajtón hozzátok létre, mert ha ott esetleg elfogy a tárhely, vagy pillanatnyi hálózati hiba lép fel, furcsa jelenségek történhetnek a Visual Studio-ban, melyek nem utalnak a hiba okára. Érdemes az asztalon létrehozni a projektet.

Az ZH jelenléti formában kerül megtartásra. Az osztályzással és a hiányzásokkal kapcsolatban a tantárgyi Moodle oldal tetején találtok bővebb információt. 

## Checklist az első ZH-hoz

1. Windows Form Application típusú projekt létrehozása, majd a teljes projekt tömörítése beadható ZIP állományba. Erről készült egy külön útmutató.

2. Elemi változó típusok : `int`,`bool`,`double`,`string`

3. Űrlap szerkesztő használata, `Button`, `TextBox` és `Label` típusú vezérlők elhelyezése az űrlapon, nevük és alapvető tulajdonságaik beállítása. Eseménykiszolgáló rendelése a gomb kattintás eseményeihez.

4. Eseménykiszolgáló rendelése az űrlap `Load` eseményeihez. (Dupla kattintás tervezőből az űrlap üres részére.)
	
5. Konverzió elemi típusok között, például szöveg számmá alakítása , vagy szám szöveggé alakítása. Emlékeztetőül: másodfokú egyenletet megoldó mintaalkalmazásban a `TextBox` típusú beviteli mező `Text` tulajdonságával kiolvasott értéket kellett `double` típusú változóba olvasni a ` double.Parse()` metódus segítségével. A gyökök kiszámítását követően a szintén`double` típusú eredményt a `.ToString()` metódus segítségével alakítottuk szöveggé.

	Példafeladat: 
	- Az űrlapon helyezz el két beviteli mezőt és egy gombot, majd
	- a második beviteli mező `Enabled` tulajdonságát állítsd `false` értékűre tervezőből. 
	- A gomb kattintás (`Click`) eseményéhez rendelj esemény kiszolgáló függvényt, 
	- az eseménykiszolgáló jelenítse meg az első beviteli mezőbe írt érték kétszeresét a második beviteli mezőben.

6. Vezérlő létrehozása kódból és elhelyezése az űrlapon. Például a `Button` osztály egy példányának létrehozása gomb néven (`Button gomb = new Button();`) alapvető tulajdonságainak, mint szélesség, magasság, pozíció, felirat, szín beállítása; hozzáadás az űrlap vezérlőinek listájához (`Controls.add(gomb);`)

7. `for` ciklusok szervezése. Például tíz gomb kirakása egymás mellé. Előfordulhatnak egymásba ágyazott ciklusok is, mint például 10 x 10 négyzet alakú gomb kirakása.

8. Feltételes elágazások. 

	Mintafeladat: az előző példát egészítsd ki úgy, hogy pepita szerűen csak minden második gomb kerüljön megjelenítésre. Ez a legegyszerűbben úgy érhető el, hogy csak akkor jeleníted meg a gombot ha a sor és az oszlopszám összegének osztási maradéka 0. az osztási maradéka `%`operátorral képezhető. `if((sor + oszlop) % 2 == 0) {...}`

	Fontos odafigyelni arra hogy az ekvivalenciát a `==` operátorral vizsgálhatjuk, míg a `=` értékadásra szolgál.

9. Metódusok. A feladatok között szerepelt metódus a faktoriális kiszámítására, vagy a Fibonacci sor egy elemének meghatározására.

10.   Saját, származtatott osztály létrehozása; az osztály bővítése konstruktorral (ctor-tab-tab); eseménykiszolgáló függvények létrehozása és hozzárendelése olyan eseményekhez, mint `Click` vagy `MouseDown`. Osztály bővítése változóval.
	Mintafeladat: váltógomb
	Származtass `VáltóGomb` néven osztályt a `Button` osztályból, mely kattintásra megváltoztatja a színét, újabb kattintásra viszont visszaáll az eredeti színe! 

Az utolsó mintafeladat megoldása itt szerepel:
```csharp
class ValtoGomb : Button
{
    bool Benyomva = false;
    public ValtoGomb()
    {
        MouseClick += ValtoGomb_MouseClick;
    }

    void ValtoGomb_MouseClick(object sender, MouseEventArgs e)
    {
        if (Benyomva)
        {
            this.BackColor = SystemColors.ButtonFace;
            Benyomva = false;
        }
        else
        {
            this.BackColor = Color.Red;
            Benyomva = true;
        }
    }        
}
```
	
