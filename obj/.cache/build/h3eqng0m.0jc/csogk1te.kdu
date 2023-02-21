<!DOCTYPE html>
<!--[if IE]><![endif]-->
<html>
  
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>&#214;sszefoglal&#225;s </title>
    <meta name="viewport" content="width=device-width">
    <meta name="title" content="&#214;sszefoglal&#225;s ">
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
<h1 id="összefoglalás" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="1">Összefoglalás</h1>

<h2 id="a-select-utasítás-felépítése" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="2">A SELECT utasítás felépítése</h2>
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="3">Az SQL lekérdező utasítása, alapformája a következő:</p>
<pre><code class="lang-sql" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="4">SELECT*…       -- oszlopok kiválasztása
FROM …         -- táblák kiválasztása
WHERE …        -- szűrőfeltétel megadása a sorokra
GROUP BY …     -- csoportosítás
HAVING …       -- szűrőfeltétel a csoportokra
ORDER BY…      -- sorbarendezés
</code></pre>
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="12"><strong sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="12">Kiegészítés:</strong>  Az eredménysorok számát a TOP (n) [PERCENT] záradék megadásával befolyásolhatjuk:
pl:</p>
<pre><code class="lang-sql" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="14">SELECT TOP 5 * FROM Szoba 
</code></pre>
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="17">az első 5 szoba adatait jeleníti meg</p>
<h2 id="kifejezések" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="19">Kifejezések</h2>
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="20">Az egyszerű kifejezések konstansokat, változókat, oszlopneveket és függvényeket tartalmazhatnak, pl:</p>
<ul sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="21">
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="21">'Dr.'              (szöveges konstans)</li>
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="22">Nettóbér           (oszlopnév)</li>
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="23">YEAR('2010.01.011') (függvény, dátum konstans)</li>
</ul>
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="25">Az összetett kifejezések operátorokat is tartalmazhatnak, pl:</p>
<ul sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="26">
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="26">'Dr.' + Vezetéknév + Keresztnév (összefűzés)</li>
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="27">Nettóbér * 1.27                    (szorzás)</li>
</ul>
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="29">A kifejezések mindig egy értéket adnak vissza</p>
<h3 id="case" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="30">CASE</h3>
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="31">Többirányú elágazás megvalósítása, két formája van:</p>
<pre><code class="lang-sql" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="32">CASE 
     WHEN feltétel1 THEN kifjezés1
     WHEN feltétel2 THEN kifejezés2
     …
	WHEN feltételn THEN kifejezésn
      [ELSE kifejezés]
END
</code></pre>
<pre><code class="lang-sql" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="41">CASE kifejezés
     WHEN érték1 THEN kifjezés1
     WHEN érték2 THEN kifejezés2
     …
	WHEN értékn THEN kifejezésn
      [ELSE kifejezés]
END
</code></pre>
<h3 id="konstansok-és-típusok" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="50">Konstansok és típusok</h3>
<table sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="51">
<thead>
<tr sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="51">
<th sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="51">Konstans</th>
<th sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="51">Típus</th>
<th sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="51">Példa</th>
</tr>
</thead>
<tbody>
<tr sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="53">
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="53">Szöveges   konstans</td>
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="53">varchar(x)   (x:   a szöveg max.   hossza)</td>
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="53">’Budapest’</td>
</tr>
<tr sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="54">
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="54">Unicode   szöveges konstans</td>
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="54">nvarchar(x)   (x:   a szöveg max.   hossza)</td>
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="54">N’Budapest’</td>
</tr>
<tr sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="55">
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="55">Egész   konstans</td>
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="55">int</td>
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="55">25</td>
</tr>
<tr sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="56">
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="56">Bit   konstans</td>
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="56">bit</td>
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="56">1</td>
</tr>
<tr sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="57">
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="57">Decimális   konstans</td>
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="57">decimal(x,   y)   (x:   a számjegyek száma,    y: a tizedesjegyek száma)</td>
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="57">12.45</td>
</tr>
<tr sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="58">
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="58">Dátum/Idő   konstans</td>
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="58">date,      datetime,      time</td>
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="58">’2012.01.15’   ’2020.02.11   22:11:33’   ’06:12:10’</td>
</tr>
</tbody>
</table>
<h3 id="fontosabb-függvények-operátorok" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="60">Fontosabb függvények, operátorok</h3>
<h4 id="függvények" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="61">Függvények</h4>
<table sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="62">
<thead>
<tr sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="62">
<th sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="62">Függvénytípus</th>
<th sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="62">Függvény</th>
</tr>
</thead>
<tbody>
<tr sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="64">
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="64">DÁTUM/IDŐ</td>
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="64">GETDATE(),   DAY(d), MONTH(d), YEAR(d),       DATEADD(x, y, z), DATEDIFF(x, y, z)</td>
</tr>
<tr sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="65">
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="65">KONVERZIÓS</td>
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="65">CAST(x   AS y), CONVERT(x, y)</td>
</tr>
<tr sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="66">
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="66">MATEMATIKAI</td>
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="66">POWER(x,   y), SQRT(x), ROUND(x, y), ABS(x)</td>
</tr>
<tr sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="67">
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="67">SZÖVEG</td>
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="67">LEN(x),   LEFT(x, y), RIGHT(x, y), LOWER(x), UPPER(x), CHARINDEX(x, y)</td>
</tr>
<tr sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="68">
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="68">EGYÉB</td>
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="68">ISNULL(x,   y), IIF(x, y, z)</td>
</tr>
</tbody>
</table>
<h4 id="operátorok" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="69">Operátorok</h4>
<table sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="70">
<thead>
<tr sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="70">
<th sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="70">Operátor típus</th>
<th sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="70">Operátor</th>
<th sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="70">Megjegyzés</th>
</tr>
</thead>
<tbody>
<tr sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="72">
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="72">Aritmetikai   operátorok</td>
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="72">+,   -, *, /, %</td>
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="72">%:   az egész osztás maradéka</td>
</tr>
<tr sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="73">
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="73">Logikai   operátorok</td>
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="73">NOT,   AND, OR</td>
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="73"></td>
</tr>
<tr sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="74">
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="74">Összehasonlító   operátorok</td>
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="74">&lt;,   &gt;, =, &lt;&gt;, &gt;=, &lt;=</td>
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="74"></td>
</tr>
<tr sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="75">
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="75">Szöveg   operátorok</td>
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="75">+,   %, _</td>
<td sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="75">+:   szövegek összefűzése   %:   helyettesítő operátor (egy vagy több karakter vagy üres)   _:   helyettesítő operátor (egy karakter)</td>
</tr>
</tbody>
</table>
<h2 id="összesítés-aggregálás" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="78">Összesítés (aggregálás)</h2>
<ul sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="79">
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="79">Az összesítő függvények értékek egy halmazán végeznek számítást, és egyetlen értéket adnak vissza.</li>
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="80">Alapesetben a halmaz a tábla összes sorát jelenti</li>
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="81">A számítás egy kifejezés kiértékelését jelenti</li>
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="82">Az összesítő függvények (kivéve: COUNT(*)) nem veszik figyelembe a NULL értékeket</li>
</ul>
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="84">Fontosabb összesítő függvények és szerepük:</p>
<ul sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="85">
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="85">SUM(): egy adott kifejezés értékeit összegét adja vissza</li>
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="86">AVG(): egy adott kifejezés értékeinek átlagát adja vissza</li>
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="87">MIN() és MAX(): egy adott kifejezés értékei közül a legkisebbet, illetve legnagyobbat adja vissza</li>
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="88">COUNT(): egy adott halmaz elemeinek számát adja vissza</li>
</ul>
<h2 id="csoportosítás" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="90">Csoportosítás</h2>
<pre><code class="lang-sql" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="91">SELECT…        -- oszlopok kiválasztása
FROM …         -- táblák kiválasztása
WHERE …        -- szűrőfeltétel megadása a sorokra
GROUP BY …     --  csoportosítás
HAVING …       -- szűrőfeltétel a csoportokra
ORDER BY…          -- sorbarendezés
</code></pre>
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="99">A GROUP BY részben felsorolt mezők vagy kifejezések szerint csoportokat képezhetünk, és a SELECT részben alkalmazott számításokat ezekre a csoportokra alkalmazhatjuk. A HAVING részben a csoportokra adhatunk meg szűrőfeltételt.
Csoportosítás esetén a SELECT részben lévő oszlopoknak szerepelniük kell a GROUP BY felsorolásában, vagy egy összesítésben (mint az összesítő függvény paramétere)</p>
<h2 id="táblák-összekapcsolása--join-típusok" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="102">Táblák összekapcsolása – JOIN típusok</h2>
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="103"><img src="../../images/1587964457825.png" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="103" alt="1587964457825.png"></p>
<ul sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="104">
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="104">(INNER) JOIN: Az A tábla idegen kulcsa megegyezik a B tábla kulcsával</li>
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="105">LEFT (OUTER) JOIN: Az INNER JOIN eredményéhez hozzá veszi az A tábla minden további sorát is</li>
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="106">RIGHT (OUTER) JOIN: Az INNER JOIN eredményéhez hozzá veszi az B tábla minden további sorát is</li>
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="107">FULL (OUTER) JOINT: Az INNER JOIN eredményéhez hozzá veszi az A és B tábla minden további sorait is</li>
</ul>
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="109">Az OUTER szó használata nem kötelező</p>
<h2 id="halmazműveletek" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="110">Halmazműveletek</h2>
<h3 id="lekérdezések-uniója-sql-ben" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="111">Lekérdezések uniója SQL-ben:</h3>
<pre><code class="lang-sql" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="112">SELECT oszlopnevek
FROM ….
UNION (ALL)
SELECT oszlopnevek
FROM …
</code></pre>
<blockquote sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="119">
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="119">UNION esetén az eredményhalmazban a duplikált (mindegyik lekérdezésben előforduló) sorok csak egyszer szerepelnek, UNION ALL esetén pedig annyiszor, ahányszor előfordulnak</p>
</blockquote>
<h3 id="lekérdezések-metszete-sql-ben" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="120">Lekérdezések metszete SQL-ben:</h3>
<pre><code class="lang-sql" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="121">SELECT oszlopnevek
FROM ……
INTERSECT
SELECT oszlopnevek
FROM …….
</code></pre>
<h3 id="lekérdezések-különbsége-sql-ben" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="128">Lekérdezések különbsége SQL-ben:</h3>
<pre><code class="lang-sql" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="129">SELECT oszlopnevek
FROM ……
EXCEPT
SELECT oszlopnevek
FROM ……
</code></pre>
<h2 id="adatdefiníciós-parancsok" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="136">Adatdefiníciós parancsok</h2>
<h3 id="tábla-létrehozása" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="137">Tábla létrehozása</h3>
<pre><code class="lang-sql" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="138">CREATE TABLE táblanév* 
(
 oszlopnév1  típusnév1 [oszlopkényszerek1],
 oszlopnév2  típusnév2 [oszlopkényszerek2],

   …    oszlopnévn  típusnévn [oszlopkényszerekn]
    [, táblakényszerek]
)
</code></pre>
<blockquote sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="148">
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="148">Ha a táblanév # karakterrel kezdődik, akkor un. Ideiglenes tábla jön létre. Ez csak az adott kapcsolat (munkamenet, session) időtartalma alatt létezik. Ha a táblanév ## karakterekkel kezdődik, akkor több egyidejű kapcsolat esetén az ideiglenes tábla mindegyikben elérhető lesz.</p>
</blockquote>
<h3 id="oszlop-hozzáadása-módosítása-törlése" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="150">Oszlop hozzáadása, módosítása, törlése</h3>
<pre><code class="lang-sql" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="151">ALTER TABLE táblanév 
ADD oszlopnév típus
</code></pre>
<pre><code class="lang-sql" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="155">
ALTER TABLE táblanév
ALTER COLUMN 
oszlopnév típus
</code></pre>
<pre><code class="lang-sql" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="161">ALTER TABLE táblanév
DROP COLUMN oszlopnév
</code></pre>
<h3 id="kényszer-törlése" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="165">Kényszer törlése</h3>
<pre><code class="lang-sql" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="166">ALTER TABLE táblanév
DROP CONSTRAINT kényszernév
</code></pre>
<h3 id="az-egész-tábla-törlése" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="170">Az egész tábla törlése</h3>
<pre><code class="lang-sql" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="171">DROP TABLE táblanév
</code></pre>
<blockquote sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="174">
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="174">A tábla törlése a szerkezet meghagyásával</p>
</blockquote>
<pre><code class="lang-sql" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="175">TRUNCATE TABLE táblanév
</code></pre>
<h2 id="kényszerek" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="178">Kényszerek</h2>
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="179">A kényszerek a lehetséges adatok halmazát leíró, korlátozó szabályok.
A kényszerek (a NULL/NOT NULL és a Default kivételével) megadhatók oszlop, illetve tábla szinten is (oszlopkényszerek, táblakényszerek)</p>
<ul sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="181">
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="181">Not Null Constraint: kötelező-e kitölteni az adott oszlopot?</li>
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="182">Check Constraint: teljesül-e az adott logikai feltétel?</li>
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="183">Default Constraint: mi legyen az adott oszlop alapértelmezett értéke?</li>
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="184">Unique Constraint: az adott oszlop vagy oszlopok értékei egyediek legyenek</li>
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="185">Primary Key Constraint: az adott oszlop vagy több oszlop együtt elsődleges kulcs legyen</li>
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="186">Foreign Key Constraint: az adott oszlop vagy több oszlop együtt idegen kulcs legyen</li>
</ul>
<h2 id="adatmanipulációs-parancsok" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="188">Adatmanipulációs parancsok</h2>
<h3 id="új-sor-beszúrása" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="189">Új sor beszúrása</h3>
<pre><code class="lang-sql" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="190">INSERT INTO táblanév 
(
   oszlopnév lista
)
VALUES
(
  értéklista
)
</code></pre>
<blockquote sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="200">
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="200">Ha egy SELECT eredménysorait egy új táblába szeretnénk menteni, akkor használhatjuk a
SELECT oszlopnév lista INTO táblanév FROM … parancsot is.</p>
</blockquote>
<h3 id="sorok-törlése" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="202">Sorok törlése</h3>
<pre><code class="lang-sql" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="203">DELETE FROM táblanév 
WHERE feltétel
</code></pre>
<h3 id="értékek-módosítása" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="207">Értékek módosítása</h3>
<pre><code class="lang-sql" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="208">UPDATE táblanév 
SET   oszlop1 = érték1,
        oszlop2 = érték2,
        ….
WHERE feltétel
</code></pre>
<h2 id="beágyazott-lekérdezések" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="215">Beágyazott lekérdezések</h2>
<pre><code class="lang-sql" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="216">SELECT select_list  
FROM table  
WHERE expr operator  
(SELECT select_list FROM table)
</code></pre>
<pre><code class="lang-sql" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="222">SELECT ProductID, Name, ListPrice  
FROM production.Product  
WHERE ListPrice &gt; (SELECT AVG(ListPrice)  FROM Production.Product) --subquery 
</code></pre>
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="227">Tipikus használat</p>
<ul sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="228">
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="228">Ha szeretnénk összehasonlítani egy kifejezés értékét a beágyazott lekérdezés eredményével (legtöbbször &lt;, &gt;, = )</li>
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="229">Ha szeretnénk eldönteni, hogy egy kifejezés eredménye benne van-e a beágyazott lekérdezés eredményhalmazában (IN)-</li>
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="230">Ha szeretnénk eldönteni, hogy a beágyazott lekérdezés eredményhalmaza üres-e (EXISTS)</li>
</ul>
<h2 id="részösszegek" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="232">Részösszegek</h2>
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="233">Az oszlopneveket és a NULL értéket kombinálva csoportosít, és  megjeleníti a  részösszegeket valamint végösszeget. ROLLUP esetén a nem NULL oszlopok száma jobbról balra csökken, CUBE esetén a csoportosítás minden lehetséges kombinációt tartalmaz</p>
<pre><code class="lang-sql" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="234">SELECT oszlopkifejezések*, 
             aggregálás
FROM …
GROUP BY ROLLUP(oszlopkifejezések*)
</code></pre>
<pre><code class="lang-sql" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="240">SELECT oszlopkifejezések, 
             aggregálás
FROM …
GROUP BY CUBE(oszlopkifejezések)
</code></pre>
<h2 id="grouping-sets" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="246">GROUPING SETS</h2>
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="247">A GROUP BY parancs kiegészítve a GROUPING SETS taggal lehetővé teszi, hogy többféle csoportosítást is megadjunk.
A csoportosításokat leíró oszlopkifejezéseket egymás után, zárójelek között , vesszővel elválasztva kell megadni.</p>
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="250">Pl:</p>
<pre><code class="lang-sql" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="251">SELECT oszlop1, oszlop2, SUM(oszlop3)
FROM table
GROUP BY GROUPING SETS(( oszlop1, oszlop2), (oszlop1)
)
</code></pre>
<h2 id="ablakok-partíciók-analitikus-függvények" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="257">Ablakok, partíciók, analitikus függvények</h2>
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="258">Formája:</p>
<pre><code class="lang-sql" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="259">Függvény()*
OVER(
[PARTITION BY kifejezés] 
[ORDER BY kifejezés]
[ROWS | RANGE BETWEEN kezdőpont AND végpont])
</code></pre>
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="266">A függvény lehet</p>
<ul sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="267">
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="267">Aggregáló függvény (SUM, AVG, MIN, MAX, COUNT)</li>
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="268">Analitikus függvény (LAG, LEAD, FIRST_VALUE, LAST_VALUE)</li>
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="269">Ranking függvény (RANK, DENS_RANK, NTILE, ROW_NUMBER)</li>
</ul>
<h2 id="nézetek-tárolt-eljárások-függvények" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="271">Nézetek, tárolt eljárások, függvények</h2>
<pre><code class="lang-sql" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="272">CREATE VIEW view_név
[(oszlopnevek listája)] [WITH view_attribútumok]
AS SELECT_utasítás
[WITH CHECK OPTION]*
</code></pre>
<pre><code class="lang-sql" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="278">CREATE PROCEDURE eljárás_név
[paraméterek listája][WITH eljárás_opciók]
AS 
[BEGIN]
Utasítások
[END]
</code></pre>
<pre><code class="lang-sql" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="286">CREATE FUNCTION fv_név
([paraméterek listája])RETURNS adattípus_név
[WITH fv_opciók]
[AS]
BEGIN
Utasítások
RETURN skalár_kifejezés
END
</code></pre>
<pre><code class="lang-sql" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="296">CREATE FUNCTION fv_név
([paraméterek listája])RETURNS TABLE
[WITH fv_opciók]
[AS] 
RETURN select_kifejezés
</code></pre>
<h1 id="hogyan-tovább--az-sql-tudás-bővítése" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="303">Hogyan tovább? – Az SQL tudás bővítése</h1>
<ul sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="304">
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="304">A tanult témakörök elmélyítése (pl: függvények esetén opcionális paraméterek kipróbálása és/vagy újabb függvények megismerése)</li>
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="305">Ismerkedés újabb témákkal (pl: dinamikus SQL, triggerek, rekurzió stb.)</li>
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="306">Más relációs adatbázis rendszerek megismerése(elsősorban Oracle, DB2, MySQL)</li>
<li sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="307">Tapasztalat szerzés a gyakorlatban (Junior szint: 1-3 év, Medior szint: 3-5 év, Senior szint: &gt;5 év)</li>
</ul>
<h1 id="feladatok" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="308">Feladatok</h1>
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="309">A feladatok a szallashely adatbázishoz készültek,  létrehozásához szükséges script elérhető itt:
<a href="szallas.sql" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="310">szallas.sql</a></p>
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="312">(+/-)	Készítsen tárolt eljárást NEPTUNKÓD_SPFEROHELYEK néven, amely paraméterként kap egy egész számot, és listázza azon szobák adatait, ahol a férőhelyek száma (pótággyal együtt!) megegyezik a paraméter értékével!
a)	Teszteljük a tárolt eljárás működését, pl: EXEC UJAENB_FEROHELYEK 4
<a href="gy11_01.mp4" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="314">Megoldás</a></p>
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="316">(+/-)	Készítsen függvényt NEPTUNKÓD_UDFFoglalasszam néven, amely a paraméterként megadott ügyfél azonosítót felhasználva visszaadja, hogy az adott ügyfél eddig hányszor foglalt!
a)	Teszteljük a fv. működését, pl: SELECT dbo.UJAENB_UDFFoglalasszam('kata')
<a href="gy11_02.mp4" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="318">Megoldás</a></p>
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="320">(+/-)	Készítsen nézetet NEPTUNKÓD_VVendeghazSzobak néven, amely azon szobák adatait jeleníti meg, amelyek vendégházban vannak!
a)	Egy új oszlopban jelenjen meg a szálláshely neve és zárójelben a helye is, pl: Gold Hotel (Budapest)!
b)	Teszteljük a nézet működését, pl: SELECT * FROM UJAENB_VVendeghazSzobak
<a href="gy11_03.mp4" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="323">Megoldás</a></p>
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="325">(+/-)	Készítsen nézetet NEPTUNKÓD_VHaviFoglalasszam néven, amely évenkénti, azon belül havi bontásban listázza a foglalások számát!
a)	A foglalás dátumánál a METTOL oszlop értékét vegyük alapul!
b)	Az oszlopokat nevezzük el értelemszerűen!
c)	Teszteljük a nézet működését, pl: SELECT * FROM UJAENB_VHaviFoglalaszszam
<a href="gy11_04.mp4" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="329">Megoldás</a></p>
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="331">(+/-)	Készítsen tárolt eljárást NEPTUNKÓD_SPPotagyasUGyfelek néven, amely azon vendégek adatait listázza, akik MINDIG pótágyas foglalást adtak le!
a)	Az eredménylista ne tartalmazzon duplikált sorokat!
b)	Teszteljük a tárolt eljárás működését, pl: EXEC UJAENB_SPPotagyasUgyfelek
<a href="gy11_05.mp4" sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="334">Megoldás</a></p>
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="336">(+/-)	<strong sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="336">Készítsen lekérdezést, amely listázza a foglalások azonosítóját, a foglalások időtartamát napokban, valamint a felnőttek és gyermekek számát!</strong>
a)	A listát szűrjük azokra az ügyfelekre, akik azonosítója 'a' vagy 'b' betűvel kezdődik!
b)	Az oszlopokat nevezzük el értelemszerűen!</p>
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="340">(+/-)	<strong sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="340">Készítsen lekérdezést, amely típusonként, azon belül csillagok száma szerinti bontásban megjeleníti a szálláshelyek számát!</strong>
a)	A listát szűrjük azokra a rekordokra, ahol a szálláshelyek száma 4-nél kisebb!
b)	A listából hagyjuk ki a budapesti szálláshelyeket!</p>
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="344">(+/-)	<strong sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="344">Listázzuk a foglalások adatait! A gyermekkel érkezők külön ajándékot kapnak.</strong>
a)	Ezért egy új oszlopban jelenítsük meg, hogy az adott foglaláshoz jár-e ajándék (Igen-Nem).
b)	A listát szűrjük a 3 csillagos szállásokra!</p>
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="348">(+/-)	<strong sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="348">Melyek azok a vendégek, akiknek már volt gyermekes és gyermek nélküli foglalásuk is?</strong>
a)	Csak az ügyfelek azonosítója és neve jelenjen meg!
b)	Az oszlopok neve legyen 'Azonosító' és 'Ügyfél'
c)	A listát rendezzük név szerint növekvő sorrendbe!</p>
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="353">(+/-)	<strong sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="353">Melyek azok a szálláshelyek, ahol a legtöbb főre foglaltak?</strong>
a)	Csak a szálláshelyek azonosítója, neve és helye jelenjen meg!
b)	A lista ne tartalmazzon ismétlődő sorokat!</p>
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="357">(+/-)	<strong sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="357">Készítsünk lekérdezést, amely a szállás helye szerint, azon belül a foglalás éve szerint megjeleníti, hogy hány foglalás történt! (A foglalás időpontjánál a METTOL dátummal számoljunk).</strong>
a)	A lista jelenítse meg a részösszegeket és a végösszeget is!
b)	A végösszeget jelöljük megfelelően!
c)	Az oszlopokat nevezzük el értelemszerűen!</p>
<p sourcefile="adatb/gyak11/index.md" sourcestartlinenumber="362">(+/-)	Listázzuk a szálláshelyek adatait a rögzítési idejének sorrendjében!
a)	Egy-egy új oszlopban jelenjen meg az eddig rögzített szálláshelyek minimális és maximális csillagszáma is (az aktuálisat is beleértve) a szálláshely helyén belül!</p>
</article>
          </div>
          
          <div class="hidden-sm col-md-2" role="complementary">
            <div class="sideaffix">
              <div class="contribution">
                <ul class="nav">
                  <li>
                    <a href="https://github.com/altinum/szamtud_docfx/blob/main/adatb/gyak11/index.md/#L1" class="contribution-link">Improve this Doc</a>
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
