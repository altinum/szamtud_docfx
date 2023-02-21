﻿<!DOCTYPE html>
<!--[if IE]><![endif]-->
<html>
  
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>Halmazm&#369;veletek </title>
    <meta name="viewport" content="width=device-width">
    <meta name="title" content="Halmazm&#369;veletek ">
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
<h1 id="halmazműveletek">Halmazműveletek</h1>

<p><a href="gyak05_prez_x264.mp4">Összefoglaló videó</a></p>
<p>Az alábbiakban ismertetésre kerül halmazműveletek két vagy több lekérdezéssel végeznek műveleteket.</p>
<ul>
<li>Általános szabály, hogy a lekérdezéseknek azonos szerkezetűeknek kell lenniük (oszlopok száma, sorrendje, típusa azonos, illetve kompatibilis).</li>
<li>Az oszlopok neveinek nem kell megegyezniük. Ha a halmazműveletekben résztvevő lekérdezések oszlopnevei nem egyformák, abban az esetben az eredményhalmaz oszlopainak nevei az első lekérdezés oszlopnevei lesznek</li>
<li>Amennyiben a halmazműveletek eredményének sorait rendezni szeretnénk, akkor a rendezést (ORDER BY) mindig a legutolsó lekérdezés végén kell definiálni A rendezésnél alias nevek is használhatók.</li>
<li>A halmazműveletek helyett többnyire van más megoldási lehetőség is (Pl: összetett WHERE –feltétel, JOIN)</li>
<li>Több halmazművelet esetén a kiértékelési sorrend:
<ol>
<li>Zárójelben lévő műveletek</li>
<li>Metszet</li>
<li>Különbség és Unió (balról jobbra)</li>
</ol>
</li>
</ul>
<h2 id="unió">Unió</h2>
<p>Két vagy több lekérdezés eredménysorait fűzi össze egyetlen eredményhalmazzá.
A lekérdezéseknek azonos szerkezetűeknek kell lenniük (oszlopok száma, sorrendje, típusa azonos, illetve kompatibilis)</p>
<pre><code class="lang-sql">SELECT oszlopnevek
FROM ….
UNION (ALL)
SELECT oszlopnevek
FROM …
</code></pre>
<h2 id="metszet">Metszet</h2>
<p>Két vagy több lekérdezés eredményhalmazainak közös sorait adja meg.</p>
<pre><code class="lang-sql">SELECT oszlopnevek
FROM ……
INTERSECT
SELECT oszlopnevek
FROM …….
</code></pre>
<h2 id="különbség">Különbség</h2>
<p>Két lekérdezés különbsége azokat a sorokat adja vissza, amelyek az első lekérdezés eredményhalmazában benne vannak, de a másodikéban nincsenek.</p>
<pre><code class="lang-sql">SELECT oszlopnevek
FROM ……
EXCEPT
SELECT oszlopnevek
FROM …….
</code></pre>
<h2 id="feladatok">Feladatok</h2>
<p>A feladatok a <em>tanulmanyi</em> adatbázishoz készültek.  Készen elérhető a tanszéki kiszolgálón az alábbi kapcsolati adatokkal:</p>
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
<td>tanulmanyi</td>
</tr>
</tbody>
</table>
<p>(+/-)Hány kreditet érnek átlagosan azok a tantárgyak, amelyek nevében az 'ürge' szó szerepel?
a.	Az átlag nem egész szám, ezért tizedes törtként jelenjen meg!
b.	Ha lehet, az eredmény ne tartalmazzon felesleges 0-kat a tizedes jegyek között!
c.	ÖTLET: konvertáljuk a kredit értékét float típusúvá</p>
<p><a href="Gy05_01.mp4">Megoldás</a></p>
<p>(+/-)Hány óra van összesen a 120-as teremben?</p>
<p><a href="Gy05_02.mp4">Megoldás</a></p>
<p>(+/-)Listázzuk, hogy melyik tanárnak hány órája van napi bontásban!
a. A lista jelenítse meg a tanár és a nap azonosítóját, valamint az óraszámot!
b.	A listából hagyjuk el azokat a sorokat, ahol ez az óraszám kisebb, mint 3!</p>
<p><a href="Gy05_03.mp4">Megoldás</a></p>
<p>(+/-)Hány órájuk van a tanároknak státuszonkénti bontásban?
a.	Jelenítsük meg a státusz kódját, nevét és az óraszámot!</p>
<p><a href="Gy05_04.mp4">Megoldás</a></p>
<p>(+/-)Listázzuk az egyes oktatók kódját és nevét, valamint egy új oszlopban, hogy az adott oktató tantárgyfelelős-e!
a.	Rendezzük a listát név szerint!
b.	Egy oktató neve és azonosítója csak egyszer jelenjen meg!</p>
<p><a href="Gy05_05.mp4">Megoldás</a></p>
<p><strong>A 6.-10 feladatokat halmazműveletek segítségével megoldandóak!</strong></p>
<p>(+/-)<strong>Jelenítsük meg azon tanárok azonosítóját és nevét, akik hétfői vagy keddi napokon tanítanak!</strong></p>
<p><a href="Gy05_06.mp4">Megoldás</a></p>
<p>(+/-)<strong>Melyek azok a tantárgyak, amelyek esetén van óra a 8.00-kor kezdődő sávban, de nincs a 12.30-kor kezdődő sávban?</strong></p>
<p><a href="Gy05_07.mp4">Megoldás</a></p>
<p>(+/-)<strong>Listázzuk azokat a termeket, amelyekben oktat Kovács László és van olyan tanóra a teremben, ahol a tantárgy nevében nem szerepel az 'ürge' szó!</strong>
a.	A termeknél elég a nevet megjeleníteni.</p>
<p><a href="Gy05_08.mp4">Megoldás</a></p>
<p>(+/-)<strong>Készítsünk listát arról, hogy melyik tanárnak hány órája van a (munka) hét elején (hétfőn), hét közben (kedd, szerda és csütörtök), illetve a hét végén (péntek)!</strong>
a.	Jelenítsük meg a tanár azonosítóját, nevét, az időszakot (hét eleje - hét közben - hét vége), valamint az óraszámot!
b.	A három megjelölt időszakot külön kérdezzük le, majd fűzzük össze a lekérdezések eredményeit!
c.	Rendezzük a listát az oktató neve, azon belül időszak szerint!</p>
<p><a href="Gy05_09.mp4">Megoldás</a></p>
<p>(+/-)<strong>Melyik napokon nincs órája Pelikán Józsefnek?</strong></p>
<p><a href="Gy05_10.mp4">Megoldás</a></p>
<p>(+/-)<em>Készítsünk listát az oktatók adatairól!</em>
a.	Az oktatók titulusa és neve összefűzve jelenjen meg, közöttük szóközzel!
b.	Ha valakinek nincs titulusa, akkor csak a neve jelenjen meg, szóköz nélkül!
c.	A listát rendezzük a beosztás kódja, azon belül a státusz kódja szerint növekvő sorrendbe!
d.	Az oszlopokat nevezzük el értelemszerűen!</p>
<p><a href="Gy05_11.mp4">Megoldás</a></p>
<p>(+/-)<em>Készítsünk listát, amely megmutatja, hogy összesen hány tantárgy van kreditenkénti csoportosításban!</em>
a.	A listából hagyjuk ki azokat a tételeket, ahol ez a darabszám 1!
b.	A Folyami gáttan tantárgyat ne vegyük figyelembe!
c.	A listát rendezzük darabszám szerint csökkenő sorrendbe!
d.	Az oszlopokat nevezzük el értelemszerűen!</p>
<p><a href="Gy05_12.mp4">Megoldás</a></p>
<p>(+/-)<em>Készítsünk listát az oktatók nevéről, a beosztásuk alapján elvárt és a tényleges óraszámukról!</em>
a.	Az oszlopok neve legyen 'Oktató neve', 'Elvárt óraszám' és 'Tényleges óraszám'
b.	Szűrjük a listát azokra az oktatókra, ahol az elvárt és a tényleges óraszám azonos</p>
<p><a href="Gy05_13.mp4">Megoldás</a></p>
<p>(+/-)<em>Készítsünk listát, amely megmutatja, hogy mely tantárgyból nincs óra egyáltalán!</em>
a.	Csak a tantárgy neve jelenjen meg!</p>
<p><a href="Gy05_14.mp4">Megoldás</a></p>
<p>(+/-)<em>Hány órájuk van az óraadóknak napi bontásban?</em>
a.	Csak a napok nevét és az óraszámot jelenítsük meg!
b.	Rendezzük a listát óraszám szerint növekvő sorrendbe!</p>
<p><a href="Gy05_15.mp4">Megoldás</a></p>
</article>
          </div>
          
          <div class="hidden-sm col-md-2" role="complementary">
            <div class="sideaffix">
              <div class="contribution">
                <ul class="nav">
                  <li>
                    <a href="https://github.com/altinum/szamtud_docfx/blob/main/adatb/gyak5/index.md/#L1" class="contribution-link">Improve this Doc</a>
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
