# SQL Express telepítése

## 1. Telepítőkészletek letöltése // Downloading installation media

- Az SQL Szerver különböző változatai letölthetők [innét](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Ha valaki még nem telepítette volna az *SQL Server Management Studio*-t, [innét](https://docs.microsoft.com/en-us/sql/ssms) letöltheti.

## 2. SQL Express telepítése // Installing SQL Express
### 2.1 Telepítési mód // Installation type

 ![](../../images/sqlexp01.png)
![](../../images/sqlexp02.png)

### 2.2 Letöltések helye // Download location
 ![](../../images/sqlexp03.png)

### 2.3 Fájlok letöltése folyamatban // Downloading install package

![](../../images/sqlexp04.png) 

### 2.4 A telepítő elindult // Installation Center is launched
 ![](../../images/sqlexp05.png)

### 2.5 Licenszfeltételek // License terms	

![](../../images/sqlexp06.png)
 
### 2.6 Frissítések // Updates

Megjegyzés: eleve a legfrissebb telepítőkészletet töltöttük le. // Note: an already up-to-date installation package was downloaded.

![](../../images/sqlexp07.png)

### 2.7 Telepítési szabályok ellenőrzése // Install rules

![](../../images/sqlexp08.png)
 
### 2.8 Telepítendő komponensek // Feature selection

 ![](../../images/sqlexp09.png)

A komponensekről bővebben lásd: // Feature details:
https://docs.microsoft.com/en-us/sql/sql-server/install/feature-selection?view=sql-server-2014&viewFallbackFrom=sql-server-ver15

### 2.9 Azonosító // Instance ID
 ![](../../images/sqlexp10.png)

Megjegyzés: a képen látható telepítési környezetben már van más SQL Server kiadás telepítve, emiatt itt egyedi azonosítót használtunk. Más esetben az alapértelmezett azonosító is választható. // Note: the screenshot was taken with another SQL Server instance already installed, therefore a named instance was chosen. Otherwise using a default instance is acceptable.

### 2.10 Automatikus indítás // Automatic startup

![](../../images/sqlexp11.png)

Megjegyzés: a szolgáltatás indítása kézi üzemmódra is állítható, és ez a beállítás később igény szerint megváltoztatható. // Note: the service startup type may be set to manual and changed later as needed.

### 2.11 Azonosítás // Authentication

![](../../images/sqlexp12.png)
 
### 2.12 A telepítés befejeződött // Installation completed successfully
 ![](../../images/sqlexp13.png)

### 2.13 Kézi indítás // Manual startup
 ![](../../images/sqlexp14.png)
Megjegyzés: lásd a 2.10-es pont beállításait. // Note: see settings at section 2.10.
 
### 3. SQL Server Management Studio

A lokális gépen futó SQL szerver az *Server Management Studio* segítségével adminisztrálható. 

![](../../images/sqlexp15.png)

Kezdődhet az adatbázisok létrehozása és a táblák felépítése!

![](../../images/sqlexp16.png)
