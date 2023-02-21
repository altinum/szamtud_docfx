<!DOCTYPE html>
<!--[if IE]><![endif]-->
<html>
  
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>K&#243;dol&#243;s feladatok </title>
    <meta name="viewport" content="width=device-width">
    <meta name="title" content="K&#243;dol&#243;s feladatok ">
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

<p>}</p>
<pre><code>
(+/-) Hogyan lehet elindítani illetve leállítani egy `Timer` típusú objektumot?

(+/-) Milyen mértékegységben méri `Timer` osztály  `Interval` tulajdonsága az időt?

(+/-) Mi a hiba az alábbi kódrészletben?

```csharp
int a = 13;
Messagebox.show(a+1);
</code></pre>
<p>(+/-) Mi a hiba az alábbi kódrészletben?</p>
<pre><code class="lang-csharp">Buttom[,] t = new Button[5,5]();
t[1,5] = new Button();
</code></pre>
<p>(+/-) Mi a hiba az alábbi kódrészletben?</p>
<pre><code class="lang-csharp">int(,) t = new int(5,5)();
t(0,0) = 13;
</code></pre>
<p>(+/-) A <code>StreamReader</code> osztály mely tulajdonságából tudható meg, hogy tudunk-e még olvasni a fájlból?</p>
<p>(+/-) Hol keresi a fájlrendszerben a program azokat a fájlokat, melyekhez nincs elérési útvonal megadva? Pl:</p>
<pre><code class="lang-csharp">StreamReader sr = new StreamReader(&quot;minta.txt&quot;);
</code></pre>
<p>(+/-) Hogyan lehet megszakítani a <code>Form</code> <code>Closing</code> eseményéhez rendelt esemény kiszolgálóból az űrlap tulajdonságát?</p>
<p>(+/-) Mi történik akkor, ha egy tömb nem létező elemére hivatkozol?</p>
<h3 id="kódolós-feladatok">Kódolós feladatok</h3>
<p>(+/-) Hogy cseréled fel <code>a</code> és <code>b</code> változók értékét?</p>
<p>(+/-) Generálj egy véletlen számot 0 és 10 között!</p>
<p>(+/-) Írd le azt a kódrészletet, mely ciklusból kirak egy űrlapra egymás alá 10 gombot!</p>
<p>(+/-) Származtass egy osztályt a Button osztályból, mely automatikusan átmétetezi magát 30x30 pixelesre!</p>
<p>(+/-) Hogyan lehet int típust string-é konvertálni? (Írj példát!)</p>
<p>(+/-) Hogyan lehet az űrlap Contrlos listájának egy meghatároztt sorszámú elemét törölni? (Írj példát!)</p>
<p>(+/-) Írd le azt a kódrészletet, mely egy számról eldönti, hogy páros-e!</p>
<p>(+/-) Írd le azt a kódrészletet, ami létrehoz egy 2x2-es egészekből álló tömböt!</p>
<p>(+/-) Írd le azt a kódrészletet, ami létrehoz egy string-ekből álló tömböt, majd hozzáad egy elemet!</p>
<p>(+/-) Írd le azt a néhány kódsort, mely létrehozza a <code>Button</code> osztály egy példányát, majd elhelyezi az űrlapon!</p>
<p>(+/-) Írd le azt a néhány kódsort, mely generál egy véletlen számot 0 és 10 között!</p>
<p>(+/-) Tegyük fél, hogy az űrlapon csak a <code>Button</code> osztály példányai vannak. Írd le azt a <code>foreach</code> ciklust, mely bejárja az űrlap <code>Controls</code> listáját és minden gomb <code>Visible</code> tulajdonságát hamis értékűre állítja!</p>
<h2 id="egyéb-témák">Egyéb témák</h2>
<ul>
<li><p>UserControl</p>
</li>
<li><p>Random</p>
</li>
<li><p>… létrehoz egy 10x10 bool típusú elemből álló tömböt</p>
</li>
<li><p>Írd le azt a néhány kódsort, mely SajátGomb néven származtat egy osztályt a Button osztályból!</p>
</li>
<li><p>Írj példát for ciklusra!</p>
</li>
<li><p>Hány közvetlen őse lehet C#-ban egy osztálynak?</p>
</li>
<li><p>Hol lehet átírni, hogy melyik űrlappal induljon az alkalmazás?</p>
</li>
<li><p>Írd le azt a kódrésztelet, amit 10x10 gombot kirak az űrlapra!</p>
</li>
<li><p>Melyik osztálytól ötököl a Példa osztály?<br>
class Példa {...}</p>
</li>
<li><p>Írd le azt a kódrészletet, mely megnyit egy tetszőleges szövegfájlt olvasásra, majd soronként beolvassa a tartalmát!</p>
</li>
<li><p>Unicode-dal kapcsolatos tudnivalók</p>
</li>
</ul>
</article>
          </div>
          
          <div class="hidden-sm col-md-2" role="complementary">
            <div class="sideaffix">
              <div class="contribution">
                <ul class="nav">
                  <li>
                    <a href="https://github.com/altinum/szamtud_docfx/blob/main/softec/villamkerdesek/index.md/#L1" class="contribution-link">Improve this Doc</a>
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
