# Heatmap

## Projekt célja

A projekt a weboldalon szereplő HTML elemek nézettségi idejét ábrázolja hőtérkép segítségével.

## Konfiguráció

- Adatbázis:  
  Az adatbázisba futtatás előtt a htmlelementtypes táblába fel kell venni a megfigyelni kívánt HTML elemek típusát (pl.: p, tr, div)  
  A subjects táblában rögzíteni kell a tantárgyak nevét futtatás előtt

- Domain név:  
  Az oldalak domain neveinek legfelső szintjében szerepelnie kell annak a tantárgynak a nevének, amihez az oldal tartozik

- config.js:  
  applicationUrl: a backend szerver elérhetőségének címe  
  observedRegion = annak a HTML szekciónak az osztálya, melyen belül az elemeket vizsgálni kell. Ennek minden oldalon szerepelnie kell  
  heatmapPrecedingClass = annak a HTML elemnek az osztálya, ami elé a hőtérképet tartalmazó DIV-et kerül

## Funkciók

- Idő mérés:  
  Abban az esetben, ha a "heatmap" query paraméter nem szerepel vagy false értéket vesz fel  
  Az alkalmazás a nézetsségi időt az oldal betöltődésének pillanatától kezdve méri  
  A futást csak az API hívások jelzik, az oldal eredeti megjelenítésén nem történik változás

- Hőtérkép ábrázolása:  
  Abban az esetben, ha a "heatmap" query paraméter true értéket vesz fel  
  Az alkalmazás az nézettségi időt nem méri  
  A hőtérkép az adatbázisban szereplő adatok alapján rajzolódik ki
