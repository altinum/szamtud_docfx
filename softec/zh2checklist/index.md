# Checklist az második ZH-hoz

## Témakörök

Az elmúlt három gyakorlaton a következő témakörök kerültek elő:

### `try-catch`

A fájlkezelés kockázatos művelet, legfeljebb remélhetjük hogy sikerül. Ezért minden fájlműveletet `try`-`catch` blokkba kell tenni. Érdemes a `try`-`tab`-`tab` code snipettet használni! A hibaüzenet megjelenítése is fontos:

```csharp
try
{
	//veszélyes művelet
}
catch (Exception ex) 
{
    MessageBox.Show(ex.Message);
}
```

### `OpenFileDialog` / `SaveFileDialog`

Az`OpenFileDialog` és a  `SaveFileDialog` között az a fő különbség, hogy mentésnél még nem létező fájlt is választhatunk:

```c#
SaveFileDialog sfd = new SaveFileDialog();

if (sfd.ShowDialog()==DialogResult.OK)
{
    StreamWriter sw = new StreamWriter(sfd.FileName);
	.....
    sw.Close();
}
```

### CSV fájlok beolvasása / írása

Erre ZH-ban használhatjátó a `CsvHelper` csomag, és a hajós feladatnál bemutatott megoldás is. 

### Adatkötött vezédlők használata

### Törlés `BindingSource` -on keresztül

### Rekord módosítása `BindingSource` -on keresztül

### Új rekord felvétele `BindingSource` -on keresztül

