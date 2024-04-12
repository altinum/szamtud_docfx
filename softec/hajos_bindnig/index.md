# Gyakorló sor - hajós vizsgakérdések

> [!WARNING]
>
> Gyakorlás közben ne másoljátok be a kódmintákat! Építsétek fel, mint ZH-n! Az automatikus kódkiegészítő veled van :)

Adott az alábbi vesszővel tagolt szöveges állomány:

[hajozasi_szabalyzat_coma.txt](hajozasi_szabalyzat_coma.txt)

Készíts alkalamazást, amely

- Tartalmazza az állományt a projektben (`Copy to output directory`-t ne feledd!)

- Tartalmaz egy oszályt, amely keképezi az állomány egy sorát

- Képes megnyitni az állományt és a sorait felolvasni egy `BindingList` típusú, `Form1` osztály szintjén létrehozott listába

  - Megnyitás közben kezeld a hibákat (`try`-`catch`)!

- Képes menteni a `Form1` oszrályban lévő listát 

  - A mentés helye `SaveFileDialog`-ban legyen kiválasztható
  - Mentésközben kezeld a hibákat (`try`-`catch`)!

- `BindingSource`-on keresztül megjeleníti a lista tartalmát egy `DataGridView`-ban

- Taralamaz egy gombot, melynek segítségével a rácsban az éppen kiválasztott sor törölhető

  - A törlés csak megerősítő kérdés után történjen meg
  - Ellenőrizd, hogy van-e kiválasztott sor

- Felugró abalakon keresztül legyen lehetőség új sor rögzítésére

  



### NuGet csomag telepítése

(!Vid) 1. videó: NuGet csomag telepítése

> [!Video https://storage.altinum.hu/szoft1/binding/1_Nuget.m4v]

### CSV fájl beolvasása

(!Vid) 2. videó: CSV fájl beolvasása

> [!Video https://storage.altinum.hu/szoft1/binding/2_Csvread.m4v]

Videóban szereplő kódminta:

```c#
private void buttonOpen_Click(object sender, EventArgs e)
{
    try
    {
        StreamReader sr = new StreamReader("hajozasi_szabalyzat_coma.txt");
        var csv = new CsvReader(sr, CultureInfo.InvariantCulture);
        var tömb = csv.GetRecords<VizsgaKérdés>();

        foreach (var item in tömb)
        {
            kérdések.Add(item);
        }

        sr.Close();
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
}
```

Bukatatók:

- Nincs beállítva a `Copy to output directory`
- A `VizsgaKérdés` osztány tulajdonságai nem felelnek meg karakter szinten a fájl feljécének

### CSV fájl mentése

(!Vid) 3. videó: CSV fájl mentése

> [!Video https://storage.altinum.hu/szoft1/binding/3_Csvwrite.m4v]

Videóban szereplő kódminta:

```c#
try
{
    SaveFileDialog saveFileDialog = new SaveFileDialog();

    if (saveFileDialog.ShowDialog() == DialogResult.OK)
    {
        StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
        var csv = new CsvWriter(sw, CultureInfo.InvariantCulture);
        csv.WriteRecords(kérdések);
        sw.Close();
    }
}
catch (Exception ex)
{
    MessageBox.Show(ex.Message);
}
```

### Adatkötés

(!Vid) 4. videó: adatkötés

> [!Video https://storage.altinum.hu/szoft1/binding/4_Databinding.m4v]

Bukatatók:

- Több `BindingSource`-t hozol létre, a vezérlők nem ugyanoda vannak kötve.

- A `DataGridView` adatforrását kódból felülírjuk:
  ```c#
  private void Form1_Load(object sender, EventArgs e)
  {
      dataGridView1.DataSource = kérdések;
  }
  ```

  Ha tervezőből bekötöttük a rácsot a `vizsgaKérdésBindingSource`-ba, akkor így kell kötni:

  ```c#
  private void Form1_Load(object sender, EventArgs e)
  {
      vizsgaKérdésBindingSource.DataSource = kérdések;
  }
  ```

  

### Sor törlése

(!Vid) 5. videó: sor törlése

> [!Video https://storage.altinum.hu/szoft1/binding/5_Delete.m4v]

```c#
private void buttonDelete_Click(object sender, EventArgs e)
{
    if (vizsgaKérdésBindingSource.Current == null) return;

    if (MessageBox.Show("A", "B", MessageBoxButtons.YesNo) == DialogResult.Yes)
    {
        vizsgaKérdésBindingSource.RemoveCurrent();
    }
}
```



### Új sor rögzítése felugró ablakon keresztül

(!Vid) 6. videó: új sor rögzítése felugró ablakon keresztül

> [!Video https://storage.altinum.hu/szoft1/binding/6_Newform.m4v]

### Sor szerkesztése felugró ablakon keresztül

(!Vid) 7. videó: Sor szerkesztése felugró ablakon keresztül

> [!Video https://storage.altinum.hu/szoft1/binding/7_Edit.m4v]