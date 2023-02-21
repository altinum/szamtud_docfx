﻿<!DOCTYPE html>
<!--[if IE]><![endif]-->
<html>
  
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>Part&#237;ci&#243;k, ablakok, analitikus f&#252;ggv&#233;nyek </title>
    <meta name="viewport" content="width=device-width">
    <meta name="title" content="Part&#237;ci&#243;k, ablakok, analitikus f&#252;ggv&#233;nyek ">
    <meta name="generator" content="docfx 2.59.4.0">
    
    <link rel="shortcut icon" href="../../favicon.ico">
    <link rel="stylesheet" href="../../styles/docfx.vendor.css">
    <link rel="stylesheet" href="../../styles/docfx.css">
    <link rel="stylesheet" href="../../styles/main.css">
    <meta property="docfx:navrel" content="../../toc.html">
    <meta property="docfx:tocrel" content="../toc.html">
    
    
    
  </head>
  <body data-spy="scroll" data-target="#affix" data-offset="120">
    <div id="wrapper">
      <header>
        
        <nav id="autocollapse" class="navbar navbar-inverse ng-scope" role="navigation">
          <div class="container">
            <div class="navbar-header">
              <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#navbar">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
              </button>
              
              <a class="navbar-brand" href="../../index.html">
                <img id="logo" class="svg" src="../../logo.svg" alt="">
              </a>
            </div>
            <div class="collapse navbar-collapse" id="navbar">
              <form class="navbar-form navbar-right" role="search" id="search">
                <div class="form-group">
                  <input type="text" class="form-control" id="search-query" placeholder="Search" autocomplete="off">
                </div>
              </form>
            </div>
          </div>
        </nav>
        
        <div class="subnav navbar navbar-default">
          <div class="container hide-when-search" id="breadcrumb">
            <ul class="breadcrumb">
              <li></li>
            </ul>
          </div>
        </div>
      </header>
      <div role="main" class="container body-content hide-when-search">
        
        <div class="sidenav hide-when-search">
          <a class="btn toc-toggle collapse" data-toggle="collapse" href="#sidetoggle" aria-expanded="false" aria-controls="sidetoggle">Show / Hide Table of Contents</a>
          <div class="sidetoggle collapse" id="sidetoggle">
            <div id="sidetoc"></div>
          </div>
        </div>
        <div class="article row grid-right">
          <div class="col-md-10">
            <article class="content wrap" id="_content" data-uid="">
<h1 id="partíciók-ablakok-analitikus-függvények">Partíciók, ablakok, analitikus függvények</h1>

<p><a href="gyak09_x264.mp4">Összefoglaló videó (18 perc)</a></p>
<h2 id="partíciók">Partíciók</h2>
<p>Azon rekordok csoportja, amelyeken az aggregálást el kell végezni. A GROUP BY egyfajta alternatíváinak is tekinthetjük őket.
Forma:</p>
<pre><code class="lang-sql">OVER(PARTITION BY kifejezés) 
--kiegészíthető rendezéssel:
OVER (PARTITION BY kifejezés  ORDER BY kifejezés)
</code></pre>
<blockquote>
<p>Példa: Jelenítsük meg a termékek kódja és listaára mellett a termékkategória átlagárát is!</p>
</blockquote>
<pre><code class="lang-sql">SELECT TERMEKKOD, LISTAAR,
       AVG(LISTAAR) OVER (PARTITION BY KAT_ID) AS 'Kategória átlagár'
FROM Termek
</code></pre>
<h2 id="ablakok">Ablakok</h2>
<p>Ablakokat a ROWS és a RANGE segítségével hozhatunk létre. Ezek az ablakot határozzák meg, használatukhoz az ORDER BY rész kötelező.
Forma:</p>
<pre><code class="lang-sql">OVER(PARTITION BY kifejezés ORDER BY kifejezés
ROWS | RANGE 
BETWEEN kezdőpont AND végpont)
/*A kifejezés - itt és az összes többi utasítás/függvény leírásban - 
a gyakorlatban többnyire oszlopnevet vagy oszlopnevek listáját jelenti*/
</code></pre>
<h3 id="rows">ROWS</h3>
<p>A ROWS az ablak méretét <strong>fizikailag</strong> adja meg  (legtöbbször az aktuális sort megelőző és/vagy követő sorok számát konkrétan megadja)
Kezdőpont, végpont lehet:</p>
<ul>
<li>CURRENT ROW,</li>
<li>n PRECEDING,</li>
<li>n FOLLOWING.</li>
</ul>
<p>Speciálisan:</p>
<ul>
<li>UNBOUNDED PRECEDING (kezdőpont),</li>
<li>UNBOUNDED FOLLOWING (végpont)
(A partíció legelső, illetve legutolsó sorát jelenítik meg)</li>
</ul>
<p>Formája:</p>
<pre><code class="lang-sql">OVER(
PARTITION BY kifejezés 
ORDER BY kifejezés
ROWS BETWEEN kezdőpont AND végpont)
</code></pre>
<blockquote>
<p>Példa: Listázzuk az egyes megrendelések dátumát, a termék kódját és mennyiségét, valamint a sorszám szerinti előző 5 megrendelés átlagos mennyiségét is!</p>
</blockquote>
<pre><code class="lang-sql">SELECT rt.TERMEKKOD, r.REND_DATUM,
 	   rt.MENNYISEG, AVG(rt.MENNYISEG) 
       OVER(PARTITION BY rt.TERMEKKOD 
       ORDER BY r.SORSZAM
       ROWS BETWEEN 5 PRECEDING AND 1 PRECEDING) 
       AS 'ELőző 5 rendelés mennyiség átlaga'
FROM Rendeles_tetel rt
     JOIN Rendeles r ON r.SORSZAM = rt.SORSZAM
</code></pre>
<h3 id="range">RANGE</h3>
<p>A RANGE az ablak méretét <strong>logikailag</strong> adja meg: nem a sorok számát, hanem a legelső, legutolsó vagy az aktuális sort, mint az intervallum kezdő- vagy végpontját).
Kezdőpont, végpont lehet:</p>
<ul>
<li>CURRENT ROW,</li>
<li>UNBOUNDED PRECEEDING (kezdőpont)</li>
<li>UNBOUNDED FOLLOWING (végpont)</li>
</ul>
<p>Formája:</p>
<pre><code class="lang-sql">Formája: 
OVER(
PARTITION BY kifejezés 
ORDER BY kifejezés
RANGE BETWEEN kezdőpont AND végpont)
</code></pre>
<blockquote>
<p>Példa: Jelenítsük meg, hogy az egyes ügyfelek az adott rendelési dátumig bezárólag összesen hányszor rendeltek! Megjelenítendő a rendelés dátuma, az ügyfél login-ja és a rendelés darabszáma</p>
</blockquote>
<pre><code class="lang-sql">SELECT DISTINCT REND_DATUM,[LOGIN],
       COUNT(*) OVER(PARTITION BY [LOGIN] ORDER BY REND_DATUM
       RANGE BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) 
       AS 'Eddigi rendeléseinek száma'
FROM Rendeles ORDER BY REND_DATUM, [LOGIN] 
</code></pre>
<h2 id="analitikus-függvények">Analitikus függvények</h2>
<h3 id="row_number">ROW_NUMBER()</h3>
<p>A lekérdezés eredménysoraihoz sorszámokat rendel. Mindig <strong>szigorúan monoton</strong> növekvő számokat ad vissza! Több partíció esetén a sorszámozás minden partíciónál újra kezdődik.</p>
<p>Formája:</p>
<pre><code class="lang-sql">ROW_NUMBER()
OVER (
PARTITION BY kifejezés
ORDER BY kifejezés)
</code></pre>
<blockquote>
<p>Példa: Készítsünk sorszámozott listát nemenként az ügyfelekről! A sorszámozás szempontja az ügyfél email-címe legyen!</p>
</blockquote>
<pre><code class="lang-sql">SELECT ROW_NUMBER() OVER(PARTITION BY nem ORDER BY email) AS 'Nemenkénti sorszám', *
FROM Ugyfel
</code></pre>
<h3 id="rank">RANK()</h3>
<p>Megadja, hogy az adott rekord hányadik a partícióban az adott rendezettség szerint. Mindig  <strong>monoton</strong> növekvő számokat ad vissza!</p>
<ul>
<li>Az azonos értékű sorok ugyanazt a sorszámot kapják.</li>
<li>A következő sorszám az aktuálisnál annyival lesz nagyobb, ahány azonos értékű sor van.</li>
</ul>
<p>Formája:</p>
<pre><code class="lang-sql">RANK()
OVER (
PARTITION BY kifejezés
ORDER BY kifejezés)
</code></pre>
<blockquote>
<p>Példa:Listázzuk a termékek kódját, megnevezését, kategória kódját, készlet mennyiségét és azt, hogy a termék a készlet alapján hányadik a kategóriájában</p>
</blockquote>
<pre><code class="lang-sql">SELECT TERMEKKOD, MEGNEVEZES, KAT_ID, KESZLET,
       RANK() OVER (PARTITION BY KAT_ID 
	    ORDER BY KESZLET DESC)
   AS 'Készlet szerinti helyezés kategóriájában'
FROM Termek
</code></pre>
<h3 id="dense_rank">DENSE_RANK()</h3>
<p>Megadja, hogy az adott rekord hányadik a partícióban az adott rendezettség szerint.  A DENSE_RANK() mindig <strong>monoton növekvő</strong> számokat ad vissza.</p>
<ul>
<li>Az azonos értékű sorok ugyanazt a sorszámot kapják</li>
<li>A következő sorszám az aktuálisnál eggyel nagyobb lesz</li>
</ul>
<p>Formája:</p>
<pre><code class="lang-sql">ROW_NUMBER()
OVER (PARTITION BY kifejezés
ORDER BY kifejezés)
</code></pre>
<blockquote>
<p>Példa: Az előző példa DENSE_RANK() függvénnyel</p>
</blockquote>
<pre><code class="lang-sql">SELECT TERMEKKOD, MEGNEVEZES, KAT_ID, KESZLET,
       DENSE_RANK() OVER (PARTITION BY KAT_ID 
	    ORDER BY KESZLET DESC)
    AS 'Készlet szerinti helyezés kategóriájában'
FROM Termek
</code></pre>
<h3 id="lag">LAG()</h3>
<p>Megadja egy adott sorhoz képest x-sorral korábbi oszlop értékét partíciónként egy adott rendezési szempont  szerint.</p>
<ul>
<li>A default érték akkor jelenik meg, ha nincs x sorral korábbi elem</li>
<li>Ha x és default érték elmarad, akkor 1 sorral ugrik vissza</li>
</ul>
<p>Formája:</p>
<pre><code class="lang-sql">LAG(kifejezés, x, default érték) 
OVER (PARTITION BY kifejezés ORDER BY kifejezés)
</code></pre>
<blockquote>
<p>Példa: Listázzuk minden rendelési tétel sorszámát, a termék kódját és mennyiségét, valamint az adott termék előző rendelésének mennyiségét!</p>
</blockquote>
<pre><code class="lang-sql">SELECT SORSZAM, TERMEKKOD, MENNYISEG,
       LAG(MENNYISEG,1,0) OVER(PARTITION BY TERMEKKOD ORDER BY SORSZAM)
       AS 'Előző rendelési mennyiség'
FROM Rendeles_tetel
</code></pre>
<h3 id="lead">LEAD()</h3>
<p>Megadja egy adott sorhoz képest x-sorral későbbi oszlop értékét partíciónként egy adott rendezési szempont  szerint. Ha x és default érték elmarad, akkor 1 sort lép előre.
Formája:</p>
<pre><code class="lang-sql">LEAD(kifejezés, x, default) 
OVER (PARTITION BY kifejezés ORDER BY kifejezés)
</code></pre>
<blockquote>
<p>Példa: Listázzuk minden rendelési tétel sorszámát, a termék kódját és mennyiségét, valamint az adott termék kettővel későbbi rendelésének mennyiségét!</p>
</blockquote>
<pre><code class="lang-sql">SELECT SORSZAM, TERMEKKOD, MENNYISEG,
       LEAD(MENNYISEG,2,0) OVER(PARTITION BY TERMEKKOD ORDER BY SORSZAM)
   AS 'Két rendeléssel későbbi rendelési mennyiség'
FROM Rendeles_tetel
</code></pre>
<h3 id="first_value">FIRST_VALUE()</h3>
<p>Megadja egy adott sorrendben lévő csoport(partíció) legelső elemét.
Formája:</p>
<pre><code class="lang-sql">FIRST_VALUE(kifejezés) 
OVER (ORDER BY kifejezés
PARTITION BY kifejezés)
</code></pre>
<blockquote>
<p>Példa: Listázzuk az egyes ügyfelek adatait és első rendelésük dátumát! A lista ne tartalmazzon duplikált sorokat!</p>
</blockquote>
<pre><code class="lang-sql">SELECT DISTINCT u.*, 
 	   FIRST_VALUE(r.REND_DATUM) 
       OVER (Partition BY u.LOGIN ORDER BY r.REND_DATUM) 
   		AS 'Első rendelés'
FROM Ugyfel u JOIN Rendeles r 
	 ON u.LOGIN = r.LOGIN
</code></pre>
<h3 id="last_value">LAST_VALUE()</h3>
<p>Megadja egy adott sorrendben lévő csoport(partíció) legutolsó elemét.</p>
<blockquote>
<p>A LAST_VALUE esetén vigyázni kell, mivel futtatáskor a partíció legutolsó eleme alapértelmezés szerint az aktuális sor! Megoldás lehet a RANGE vagy helyette fordított sorrend és FIRST_VALUE()</p>
</blockquote>
<p>Formája:</p>
<pre><code class="lang-sql">LAST_VALUE(kifejezés) 
OVER (ORDER BY kifejezés
PARTITION BY kifejezés)
</code></pre>
<blockquote>
<p>Példa: Listázzuk az ügyfelek adatai és azt, hogy melyik ügyfél utoljára milyen módon legelőször, illetve legutoljára! A lista ne tartalmazzon duplikált sorokat!</p>
</blockquote>
<pre><code class="lang-sql"> SELECT DISTINCT u.*, FIRST_VALUE(r.FIZ_MOD) 
       OVER (Partition BY u.LOGIN ORDER BY r.SORSZAM) 
   		AS 'Fizetési mód legelső rendeléskor',
   		LAST_VALUE(r.FIZ_MOD) 
       OVER (Partition BY u.LOGIN ORDER BY r.SORSZAM 
       RANGE BETWEEN UNBOUNDED PRECEDING AND UNBOUNDED FOLLOWING) 
       AS 'Fizetési mód legutolsó rendeléskor'
FROM Ugyfel u
JOIN Rendeles r ON u.LOGIN = r.LOGIN
</code></pre>
<h3 id="ntile">NTILE()</h3>
<p>A partíció elemeit adott számú osztályba sorolja a megadott sorrend alapján.
Formája:</p>
<pre><code class="lang-sql">NTILE(osztályok száma) 
OVER (ORDER BY kifejezés
PARTITION BY kifejezés)
</code></pre>
<p>Példa: Soroljuk be a termékeket kategóriájukban a listaáruk alapján 5 osztályba!</p>
<pre><code class="lang-sql">SELECT *, 
      NTILE(5) OVER(PARTITION BY KAT_ID 
      ORDER BY LISTAAR) 
      AS 'Osztály'
FROM Termek
</code></pre>
<h3 id="megjegyzések">Megjegyzések</h3>
<ul>
<li>Az analitikus függvények segítségével sok feladat egyszerűbben megoldható, mint „hagyományos” módon, viszont ilyenkor a lekérdezés többnyire lassúbb lesz</li>
<li>Bizonyos feladatok a RANGE és a ROWS segítségével is megoldhatók, viszont duplikált sorok esetén a RANGE és a ROWS különböző eredményt adhat</li>
<li>Egy lekérdezésben több ablak-függvény is szerepelhet</li>
<li>Ha ROWS/RANGE esetén a végpont elhagyható, ez esetben alapértelmezés szerint a CURRENT ROW lesz</li>
<li>Ha a PARTITION BY kimarad, akkor csak egy csoport lesz, amely minden rekordot tartalmaz</li>
</ul>
<h1 id="feladatok">Feladatok</h1>
<p>A feladatok a <em>webshop</em> adatbázishoz készültek.  Készen elérhető a tanszéki kiszolgálón az alábbi kapcsolati adatokkal:</p>
<table>
<thead>
<tr>
<th></th>
<th></th>
</tr>
</thead>
<tbody>
<tr>
<td>Szerver</td>
<td>bit.uni-corvinus.hu</td>
</tr>
<tr>
<td>Felhasználónév</td>
<td>hallgato</td>
</tr>
<tr>
<td>Jelszó</td>
<td>Password123</td>
</tr>
<tr>
<td>Adatbázis</td>
<td>webshop</td>
</tr>
</tbody>
</table>
<p>(+/-) Készítsünk listát arról, hogy melyik ügyfél (LOGIN) hányszor rendelt összesen.
a.	A lista tartalmazza a végösszeget is.
b.	 A listát rendezzük a rendelések száma szerint növekvő sorrendbe!
<a href="Gy09_01.mp4">Megoldás</a></p>
<p>(+/-) Átlagosan hány termék van készleten kategóriánként (KAT_ID), raktáranként (RAKTAR_KOD), illetve mennyiségi egységenként? (szempontonként külön-külön)
a.	Az átlagot kerekítsük egészre!
<a href="Gy09_02.mp4">Megoldás</a></p>
<p>(+/-) Készítsünk listát a megrendelt termékek legkisebb és legnagyobb egységáráról szállítási dátum, azon belül szállítási mód szerinti bontásban!
a.	A lista csak a 2015 májusi szállításokat tartalmazza!
b.	Jelenítsük meg a részösszegeket és a végösszeget is!
<a href="Gy09_03.mp4">Megoldás</a></p>
<p>(+/-) Készítsünk csoportot a termékek listaára alapján a következők szerint: Az &quot;olcsó&quot; termékek legyenek azok, amelyek listaára 3000 alatt van. A &quot;drága&quot; termékek legyenek az 5000 felettiek, a többi legyen &quot;közepes&quot;.
a.	Listázzuk az egyes csoportokat, és a csoportokba tartozó termékek darabszámát!
b.	A lista jelenítse meg a végösszeget is!
<a href="Gy09_04.mp4">Megoldás</a></p>
<p>(+/-) Listázzuk a rendelési tételek számát raktáranként éves bontásban!
a.	A listában a raktár neve, az év és a darabszám jelenjen meg!
b.	A lista jelenítse meg a részösszegeket és a végösszeget is!
c.	A végösszeget megfelelően jelöljük!
d.	Az oszlopokat nevezzük el értelemszerűen!
<a href="Gy09_05.mp4">Megoldás</a></p>
<p>(+/-) <strong>Készítsünk listát az ügyfelek adatairól név szerinti sorrendben.</strong>
a.	Minden sorban jelenjen meg a sorrend szerint előző, illetve következő ügyfél neve is.
b.	Ha nincs előző vagy következő ügyfél, akkor a 'Nincs' jelenjen meg!
<a href="Gy09_06.mp4">Megoldás</a></p>
<p>(+/-) <strong>Készítsünk lekérdezést, amely megmutatja, hogy melyik termékkategóriába hány termék tartozik. A lista a kategória nevét és a darabszámot jelenítse meg.</strong>
a.	A lista ne tartalmazzon duplikált sorokat.
b.	A feladatot partíciók segítségével oldjuk meg!
<a href="Gy09_07.mp4">Megoldás</a></p>
<p>(+/-) <strong>Készítsünk listát a rendelési tételekről. Az egyes rendelési tételeket termékenként soroljuk be 4 osztályba a rendelés mennyisége alapján. Jelenítsük meg ezt az információt is egy új oszlopban, az oszlop neve legyen 'Mennyiségi kategória'.</strong>
a.	A lista csak a 100 Ft feletti egységárú rendelési tételeket vegye figyelembe!
<a href="Gy09_08.mp4">Megoldás</a></p>
<p>(+/-) <strong>Listázzuk a termékek kódját, megnevezését, kategóriájának nevét, és listaárát.</strong>
a.	A listát egészítsük ki két új oszloppal, amelyek a kategória legolcsóbb, illetve legdrágább termékének árát tartalmazzák.
b.	A két új oszlop létrehozásánál partíciókkal dolgozzunk!
<a href="Gy09_09.mp4">Megoldás</a></p>
<p>(+/-) <strong>Készítsünk listát a rendelésekről. A lista legyen rendezve ügyfelenként (LOGIN), azon belül a rendelés dátuma szerint. A listához készítsünk sorszámozást is. A sorszám a következő formában jelenjen meg: sorszám_év_login. Pl: 1_2015_adam1</strong>
a.	A számozás login-onként, azon belül rendelési évenként kezdődjön újra.
b.	A sorszám oszlop neve legyen Azonosító.
<a href="Gy09_10.mp4">Megoldás</a></p>
<p>(+/-) Készítsünk listát a termékek adatairól listaár szerint növekvő sorrendben! A lista jelenítse meg két új oszlopban a sorrend szerint előző, illetve következő termék listaárát is a termék saját kategóriájában és raktárában!
a.	Ahol nincs előző vagy következő érték, ott 0 jelenjen meg!
b.	Az oszlopokat nevezzük el értelemszerűen!
<a href="Gy09_11.mp4">Megoldás</a></p>
<p>(+/-) Listázzuk a termékek kódját, nevét és listaárát listaár szerinti sorrendben!
a.	Vegyünk fel egy új oszlopot Mozgóátlag néven, amely minden esetben az aktuális termék, az előző, és a következő termék átlagárát tartalmazza!
b.	A mozgóátlagot kerekítsük két tizedesre!
<a href="Gy09_12.mp4">Megoldás</a></p>
<p>(+/-) Készítsünk listát, amely a rendelések sorszámát és a rendelés értékét tartalmazza. A listát egészítsük ki egy új oszloppal, amely minden rendelés esetén addigi rendelések összegét tartalmazza (az aktuálisat is beleértve)!
a.	A listát rendezzük sorszám szerint növekvő sorrendbe.
b.	A lista ne tartalmazzon duplikált sorokat!
c.	Nevezzük el az oszlopokat értelemszerűen!
<a href="Gy09_13.mp4">Megoldás</a></p>
<p>(+/-) Készítsünk listát a termékek kódjáról, nevéről, kategória azonosítójáról, raktár azonosítójáról és listaáráról, valamint a termék adott szempontok szerinti rangsorokban elfoglalt helyezéseiről. (Szempontonként külön oszlopban, a helyezéseknél növekvő sorrendet feltételezve). A szempontok a következők legyenek: listaár, kategória szerinti listaár, és raktárkód szerinti listaár.
a.	Az oszlopokat nevezzük el értelemszerűen.
b.	A helyezések egyenlőség esetén &quot;sűrűn&quot; kövessék egymást.
c.	A lista legyen rendezett kategória azonosító, azon belül listaár szerint!
<a href="Gy09_14.mp4">Megoldás</a></p>
<p>(+/-) Készítsünk listát a rendelési tételekről, amely minden sor esetén göngyölítve tartalmazza az ügyfél adott rendelési tételig meglévő rendelési tételeinek összértékét!
a.	Az új oszlop neve legyen Eddigi rendelési tételek összértéke!
b.	Az ügyfél neve is jelenjen meg!
<a href="Gy09_15.mp4">Megoldás</a></p>
</article>
          </div>
          
          <div class="hidden-sm col-md-2" role="complementary">
            <div class="sideaffix">
              <div class="contribution">
                <ul class="nav">
                  <li>
                    <a href="https://github.com/altinum/szamtud_docfx/blob/main/adatb/gyak9/index.md/#L1" class="contribution-link">Improve this Doc</a>
                  </li>
                </ul>
              </div>
              <nav class="bs-docs-sidebar hidden-print hidden-xs hidden-sm affix" id="affix">
                <h5>In This Article</h5>
                <div></div>
              </nav>
            </div>
          </div>
        </div>
      </div>
      
      <footer>
        <div class="grad-bottom"></div>
        <div class="footer">
          <div class="container">
            <span class="pull-right">
              <a href="#top">Back to top</a>
            </span>
            
            <span>Generated by <strong>DocFX</strong></span>
          </div>
        </div>
      </footer>
    </div>
    
    <script type="text/javascript" src="../../styles/docfx.vendor.js"></script>
    <script type="text/javascript" src="../../styles/docfx.js"></script>
    <script type="text/javascript" src="../../styles/main.js"></script>
  </body>
</html>
