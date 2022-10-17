# Azure SQL adatbázis létrehozása

## Erőforrások létrehozása
### 1. lépés: Bejelentkezés az Azure portálra
Jelentkezz be az Azure portál-ba az egyetemi e-mail címeddel!

![kep1]
### 2. lépés: SQL adatbázis létrehozása 
>Az ingyenes előfizetés elvileg 10 különböző adatbázis létrehozását teszi lehetővé. Egy szerveren több adatbázis is létrehozható, de Azure-ban az adatbázis létrehozásával kell kezdeni, és ha még nincs szerver, menet közben lehet létrehozni szervert is. 

Hozz létre egy új SQL adatbázis erőforrást!  

![kep2]
### 3. lépés: Add meg az adatbázisod paramétereit!
![kep3]
1. Add meg az adatbázisod nevét!
2. Előfizetésből csak az ingyenes Azure for Students opció áll rendelkezésre, de korlátlan számú független előfizetés tartozhat egy felhasználóhoz.
3. Az Erőforráscsoport csak segít rendszerezni az adatbázisainkat, számunkra nincs jelentősége (javasolt érték: BCE).
5. A kiszolgálónál kell megadni az adatbázisszervert. (Egy szerveren több adatbázis is lehet.) Mivel még feltehetőleg nincs szerverünk létre kell hozni egyet az "Új létrehozása" linkre kattintva, az alábbiak szerint. Később ehhez a szerverhez csatlakozva tudjuk majd elérni az adatbázisunkat: ![kep4]
      - A kiszolgálónévnek egyedinek kell lennie, és az URL-ek szabályainak is meg kell felelnie.
      - A kiszolgáló rendszergazdája lesz az a felhasználói fiók, amin keresztül elérjük az adatbázisszerverünket. Van lehetőség új, korlátozottabb jogosultságú felhasználók létrehozására is.
      - A megadott jelszó az adatbázisszerver rendszergazdájához tartozik, teljesen független az Azure-fiók jelszavától.     **Olyan jelszót válasszatok, amit sehol máshol nem használtok, mert ezt a jelszót a beadandó során meg kell majd adnotok a gyakorlatvezetőknek!**
      - A hozzánk legközelebbi szerverközpont Nyugat-Európa, így ezt a helyet érdemes megadni. Az ingyenes előfizetés helyenként egy szerver létrehozását teszi lehetővé. Az észak-európai központ is használható egyéni kísérletezésre.

6. A rugalmas SQL készletre nincs szükségünk.
7. A Számítás+Tárolás részen paraméterezhetjük a felhasználható erőforrást. Ennek komoly jelentősége van, mert ha elmulasztjuk beállítását, az ingyenes kreditjeink gyorsan fogynak. ![kep4_2] 
10. A Rendezés megadja, hogy a szöveges mezők milyen nyelv szerint legyenek sorba rendezve. A gyakorlatok során az alapértelmezettet használjuk, hogy mindenkinek egyforma eredmények jelenjenek meg.
11. Ha mindent beállítottunk, indíhatjuk az adatbázis és a kiszolgáló létrehozását. Ehhez előbb a Felülvizsgálat+Létrehozás, majd a Létrehozás gombra kell kattintani. [!kep4_3]
12. Az adatbázis és a kiszolgáló létrehozása időbe telik, de az értesítési ablakban nyomon követhető a folyamat.
![kep5]
5. Ha elkészültek, akkor az erőforrások megtekinthetők az irányítópultra kattintva.
![kep6]

### 4. lépés: Konfiguráció

Az irányítópulton a szerverünket kiválasztva hozzáférünk a különböző beállításokhoz. A jelszó megváltoztatásához nincs szükség a régi jelszóra, így ha elfelejtettük, egyszerűen felülírható. Ahhoz, hogy az adatbázis távolról elérhető legyen, az alábbi ábra szerinti linken keresztül módosítani kell  a tűzfal beállításokat:

![kep7]

  **Tűzfalbeállítások**
  
  ![kep8]
  
  - A létrehozott szerver alapértelmezetten nem elérhető, mert white-list-et használ, és semmilyen IP tartományt nem enged be.
  - Az Azure-szolgáltatásokhoz való hozzáférés engedélyezése kapcsolót kikapcsolva a hozzáférés black-list jellegűre változtatható. (Nem ajánlott!)
  - A listába felvett szabályok elnevezése csak nekünk szolgál, hogy a jövőben aznosítani tudjuk az egyes tartományokat. Érdemes a hozzáférést az egyetemi IP tartományra korlátozni (146.110.0.0 - 146.110.255.255), de ekkor csak az egyetemről vagy VPN-en lehet majd elérni a szervert.
  - Az otthoni, megbízható IP címeket pedig új szabályként fel lehet venni ezek mellé. Netszolgáltatónként (és szolgáltatási szintenként) eltérő lehet, hogy az otthoni IP-cím milyen gyakran változik, akár a router újraindítása nélkül is.
  - Ne felejtsd el elmenteni a tűzfal beállításainak változtatásait!

 **A szerver tulajdonságai**
- A kapcsolódáskor a szerver teljes nevét kell megadni, amely kimásolható a tulajdonságok közül.
- Ha esetleg elfelejtetted volna, akkor itt a rendszergazda felhasználóneve is megtekinthető.

![kep9]

[kep1]: Azure_2022_home.png
[kep2]: Azure_2022_newdb.png
[kep3]: Azure_2022_configdb.png
[kep4]: Azure_2022_newHost.png
[kep4_2]: Azure_2022_dtu.png
[kep4_3]: Azure_Create.png
[kep5]: Azure_work_in_progress.png
[kep6]: Azure_See_on_ControlPanel.png
[kep7]: azure-settings.png
[kep8]: azure_2022_firewall.png
[kep9]: azure-properties.png
