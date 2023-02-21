<!DOCTYPE html>
<!--[if IE]><![endif]-->
<html>
  
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>Adatok valid&#225;l&#225;sa &#369;rlapon </title>
    <meta name="viewport" content="width=device-width">
    <meta name="title" content="Adatok valid&#225;l&#225;sa &#369;rlapon ">
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
<h1 id="adatok-validálása-űrlapon">Adatok validálása űrlapon</h1>

<p><strong>Ez a dokumentum a <code>Validation</code> és <code>Validated</code> események valamint az <code>ErrorProvider</code> magyarázataként szolgál, a megoldást feltölteni nem kell.</strong></p>
<p>A cél egy olyan felugró űrlap készítése, melyen keresztül a felhasználó adatokat vihet fel, majd az <em>OK</em> illetve <em>Mégse</em> gomb megnyomásával dönt a sorsukról - azaz rögzíti az adatbázisban, vagy nem. Az űrlap csak akkor lehet bezárható az <em>OK</em> gombal, ha minden felvitt adat megfelel a formai követelményeknek.</p>
<h2 id="a-ok-és-mégse-gombbal-bezárt-űrlapok-közti-különbségtétel">A &quot;OK&quot; és &quot;Mégse&quot; gombbal bezárt űrlapok közti különbségtétel</h2>
<h3 id="form1">Form1</h3>
<p>(+/-) Hozz létre egy <code>Form</code>-ot <code>newUserForm</code> néven!</p>
<p>(+/-) A <code>Form1</code>-en helyezz el egy gombot, majd a gombhoz rendelj eseménykiszolgálót.</p>
<p>(+/-) Az eseménykiszolgálóban nyisd meg a <code>NewUserForm</code>-ot és attól függően, hogy a felhasználó melyik gombbal zárta be a <code>NewUserForm</code>-ot, jeleníts meg eltérő szöveget. (A bezáró gombok később készülnek majd.)</p>
<pre><code class="lang-csharp">private void button1_Click(object sender, EventArgs e)
{
    NewUserForm newUserForm = new NewUserForm();
    if (newUserForm.ShowDialog() == DialogResult.OK)
    {
        MessageBox.Show(&quot;OK-al zárult&quot;);
    }
    else
    {
        MessageBox.Show(&quot;Nem OK-al zárult&quot;);
    }          
}
</code></pre>
<h3 id="a-newuserform">A <code>newUserForm</code></h3>
<p>(+/-) Az űrlapon helyezd el a képnek megfelelő vezérlőket!</p>
<p><img src="../../images/input_form.png" alt="input_form.png"></p>
<p>(+/-) Húzz az űrlapra még egy <code>ErrorProvider</code> vezérlőt is - ez jelenít majd meg kis piros X-et a hibásan kitöltött vezérlők (jelenleg csak TextBox) mellett.</p>
<p>(+/-) Az <em>Cancel</em> gomb tulajdonságai között állítsd be az alábbiakat a <em>Prpoerties</em> panelen: <code>DialogResult</code>:<code>Cancel</code>. Innentől fogva, ha a felhasználó ezt a gombot nyomja meg, az űrlap automatikusan bezáródik, és a <code>Form1</code>-en a <code>ShowDialog()</code> metódus <code>DialogResult.Cancel</code> értékkel tér vissza. Próbáld ki!</p>
<p>(+/-) Az <em>OK</em> gomb esetén NE állítsd be ugyanezt a tulajdonságot a <code>Properties</code>-ben, mert problémákhoz fog vezetni. Helyette a gomb <em>Click</em> eseménykezelőjében kódból állítsd be az értéket. A beállítás pillanatában is be fog záródni a Form, és hasonló hatást érsz el, mint a Mégse gomb esetén.</p>
<pre><code class="lang-csharp">this.DialogResult = DialogResult.OK;
</code></pre>
<h2 id="űralapon-szereplő-adatok-ellenőrzése">Űralapon szereplő adatok ellenőrzése</h2>
<p>(+/-) Ezután készítsd el az eseménykiszolgálóat mindkét <code>TextBox</code> <code>Validating</code> és <code>Validated</code> eseményeihez, és ellenőrizd, hogy <em>OK</em> gomb <code>CausesValidation</code> tulajdonsága az az alapértelmezett értéknek megfelelően <code>True</code>-e.</p>
<p>A <code>Validating</code> esemény akkor következik be, ha valamilyen oknál fogva az érintett mezőben szereplő adatok érvényességének ellenőrzése szükségessé válik. Ilyen ok, ha a felhasználó egy olyan vezérlőre kattintott, aminek a <code>CausesValidation</code> tulajdonsága <code>True</code>.  Ilyen jelen pillanatban az <em>OK</em> gomb, de mindkét szövegdoboz is, mert  <code>CausesValidation</code> tulajdonságuk alapértelmezetten <code>True</code>.</p>
<p>A <em>Mégse</em> gomb <code>CausesValidation</code> tulajdonságát viszont állítsd <code>False</code>-ra, különben később, amikor megírjuk az ellenőrzésekhez tartozó kódot, nem fogod tudni bezárni az ablakot, ha valamelyik validáció nem sikerül. Ez pedig bosszantó lehet, mert sokszor pont azért akarjuk bezárni az ablakot, mert rájövünk, hogy nincs meg minden adatunk a helyes kitöltéshez.</p>
<p>A <code>Validated</code>  esemény akkor következik be, ha az ellenőrzés sikerrel zárult. Az osztály vélhetően most így néz ki:</p>
<pre><code class="lang-csharp">public Form2()
    {
        InitializeComponent();
    }

    private void nameTextBox_Validating(object sender, CancelEventArgs e)
    {
    }

    private void nameTextBox_Validated(object sender, EventArgs e)
    {
    }

    private void neptunTextBox_Validating(object sender, CancelEventArgs e)
    {
    }

    private void neptunTextBox_Validated(object sender, EventArgs e)
    {
    }
}
</code></pre>
<p>(+/-) Próbáld ki, ha valamelyik <code>Validatig</code> eseményhez tartozó kiszolgálót az alábbiak szerint módosítod, akkor a TextBox-ba való gépelést követően nem elhagyni a TextBox-ot egészen addig míg helyes értéket nem ír be a felhasználó:</p>
<pre><code class="lang-csharp">	private void nameTextBox_Validating(object sender, CancelEventArgs e)
	{
	        e.Cancel = true;
	}
</code></pre>
<p>(+/-) Az ellenőrzés megvalósításához készíts egy-egy függvényt a kétféle érték ellenőrzéséhez:</p>
<pre><code class="lang-csharp">    private bool CheckName(string név)
    {
        return !string.IsNullOrEmpty(név);
    }

    private bool CheckNeptun(string neptun)
    {
        Regex r = new Regex(&quot;^[A-Z0-9]{6}$&quot;);
        return r.IsMatch(neptun);
    }
</code></pre>
<p>(+/-) Majd a <code>Validating</code> eseményekhez tartozó kiszolgálókban ellenőrizd az értékeket:</p>
<pre><code class="lang-csharp">public partial class NewUserForm : Form
{
    public NewUserForm()
    {
        InitializeComponent();
    }

    private bool CheckName(string név)
    {
        return !string.IsNullOrEmpty(név);
    }

    private bool CheckNeptun(string neptun)
    {
        Regex r = new Regex(&quot;^[A-Z0-9]{6}$&quot;);
        return r.IsMatch(neptun);
    }
    private void nameTextBox_Validating(object sender, CancelEventArgs e)
    {
        if (!CheckName(nameTextBox.Text))
        {
            e.Cancel = true;
            errorProvider1.SetError(nameTextBox, &quot;A név nem lehet üres&quot;);
        }
    }

    private void nameTextBox_Validated(object sender, EventArgs e)
    {
        errorProvider1.SetError(nameTextBox, &quot;&quot;);
    }


    private void neptunTextBox_Validating(object sender, CancelEventArgs e)
    {
        //Ha kell, megnézzük, érvényes-e a tartalom
        if (!CheckNeptun(neptunTextBox.Text))
        {
            e.Cancel = true;
            errorProvider1.SetError(neptunTextBox, &quot;Érvénytelen Neptun kód&quot;);
        }
    }

    private void neptunTextBox_Validated(object sender, EventArgs e)
    {
        errorProvider1.SetError(neptunTextBox, &quot;&quot;);
    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (this.ValidateChildren())
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
</code></pre>
<p>A fenti megoldással még van egy kis probléma. Ha ugyanis egyáltalán nem írunk semmi a cellákba, akkor nem indul el a validálási folyamat, így semmi nem akadályozza meg a belőlük való kikattintást. Gond nélkül rá tudunk nyomni az OK gombra, és be tudjuk zárni az ablakot.</p>
<p>Ezért szükség van egy végső ellenőrző lépésre, amivel a bezárás előtt megbizonyosodhatunk arról, hogy valóban minden beviteli mezőben helyes érték szerepel. Ehhez a <code>Form</code> összes vezérlőjét egyszerre kell validálnunk. A <code>this.ValidateChildren()</code> függvény ezt teszi meg helyettünk, és csak akkor tér vissza igaz értékkel, ha minden validálás rendben megtörtént (nem volt <code>e.Cancel = true</code>).</p>
<p>(+/-) Írd meg az ennek megfelelő feltételt az OK gomb Click eseménykezelőjébe.</p>
<p>Érdemes továbbá átállítani az ErrorProvider <code>BlinkStyle</code> tulajdonságát <code>NeverBlink</code>-re. A vezérlők ugyanis nem teljesen egyező pillanatban kezdenek villogni, és emiatt ilyenkor hibás működés hatását keltik (úgy tűnik, mintha felváltva villognának).</p>
<pre><code class="lang-csharp">private void button1_Click(object sender, EventArgs e)    
{
    // Bezárás előtt minden vezérlőt újra validálunk
    if (this.ValidateChildren())
        this.DialogResult = DialogResult.OK;
}
</code></pre>
<h2 id="tooltip">ToolTip</h2>
<p>A <code>ToolTip</code> segítségével a felhasználót segítő üzenetet lehet rendelni a vezérlőkhöz.</p>
<p><img src="../../images/1615051267868.png" alt="1615051267868.png"></p>
<p>(+/-) Az űrlapon egyetlen <code>ToolTip</code> típusú objektumot érdemes elhelyezni, ez fogja kezelni az összes vezérlőhöz tartozó szöveget. A <em>Properties</em> panelben a megjelenés késleltetését, időtartamát, méretét, stb. egységesen a <code>toolTip1</code> tulajdonsági között lehet beállítani.</p>
<p><img src="../../images/1615051616183.png" alt="1615051616183.png"></p>
<p>(+/-) Ha van <code>ToolTip</code> az űrlapon, minden vezérlőhöz be lehet állítani a szöveget:</p>
<p><img src="../../images/1615051851465.png" alt="1615051851465.png"></p>
<p>Érdemes a Label-ekre is beállítani a ToolTip-eket, mert a TextBox-ok esetén elég nehéz egérrel eltaláni azt a pontot, amikor feljönnek.</p>
</article>
          </div>
          
          <div class="hidden-sm col-md-2" role="complementary">
            <div class="sideaffix">
              <div class="contribution">
                <ul class="nav">
                  <li>
                    <a href="https://github.com/altinum/szamtud_docfx/blob/main/softeng/3_gyak_adatok_validalasa_urlapon/index.md/#L1" class="contribution-link">Improve this Doc</a>
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
