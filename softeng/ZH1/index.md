# Felészülés az 1a ZH-ra



 Az első blokk anyagát két ZH-ban Kérjük számon.  Ennek oka az, hogy az O/RM osztályok  elkészítése _reverse engineering_  megközelítéssel a további feladatok kiindulópontja is. 

Az első ZH nem tartogat meglepetéseket,  gyakorlással tökéletesen fel lehet készülni rá. 



-  Kiinduló adatkét  minden csoport   megkapja egy adatbázis nevét a hozzátartozó jelszóval,  mely a  gyakorlatokon is megszokott bit.uni-corvinus.hu  SQL szerveren érhető el.
-  Első lépésként létre kell hozni egy Windows Forms App-ot .NET 6-os  környezetbe a megadott Solution illetve Projekt elnevezési szabályok szerint.
- `Scaffold-DbContext`  segítségével  a megadott mappába létre kell hozni   az adatbázis leképező O/RM  osztályokat.
- A `Form1`-en `DataGridView`  vezérlőben  meg kell jeleníteni  az adatbázis egy megadott táblájának  rekordjait.
- A `Form1`-en egy `+`  feliratú gombra kattintva  meg kell jeleníteni egy másik űrlapot,  melyen keresztül  új rekord rögzíthető  az adatbázisba.  Az űrlapnak tartalmaznia kell  értelemszerűen működő _OK_ és  _Mégse_ gombokat. 
- Az egyik mező  tartalmának helyességét  a rögzítés előtt ellenőrizni kell,  az esetleges hibáról `ErrorProvider`  segítségével kell értesíteni a felhasználót. 





 A ZH megírásához egy darab A4-es kézzel írott lap felhasználható,  más, mint internetes dokumentáció vagy tananyag nem vehető igénybe.
