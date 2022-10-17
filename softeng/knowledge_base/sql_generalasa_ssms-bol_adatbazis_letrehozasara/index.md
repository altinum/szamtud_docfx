# Adatbázist létrehozázó SQL generálása SSMS segítségével
Többen kérdeztétek, hogy hogyan lehet olyan SQL-t generálni SQL Server Management Studio segítségével, ami nem csak az adatbázis struktúráját építi fel `CREATE TABLE` parancsok segítségével, hanem `INSERT` parancsokkal az adatokat is feltölti. 

(+/-) Első lépéjben jobb egér a kiválasztott adatbázison:



![1619343517825.png](../../images/1619343517825.png)

A megjelenő varázslóban minden egyértelmű, de ahhoz, hogy az `INSERT`-ek is elkészüljenek, az `ADVANCED` beállítások közt ezt külön be kell kapcsolni:

![1619343711506.png](../../images/1619343711506.png)



![1619343810349.png](../../images/1619343810349.png)

