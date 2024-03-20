# Projektfeladat: Szótanító játék

## A feladat leírása

A feladat egy szótanító program 	írása, melyben a képernyőre véletlenszerű sorrendben kipakolt magyar és idegen nyelvű szópárokat egérrel kell egymásra húzni. Az egymásra húzott szópárok eltűnnek a képernyőről. Ha minden szópár eltűnt, újabb 10 szó kerül ki. A szótárt pontosvesszővel tagolt fájlból kell olvasni, melynek minden sora egy-egy szópárt tartalmaz. A szótárt tartalmazó fájl előállítása is a feladat része.

- A szavakat tartalmazó fájlt fájlmegnyitó ablakból lehessen kiválasztani.
- A kiválasztott fájl tartalmát egy kérdésekből álló listába kell olvasni.
- A fájl megnyitásakor és olvasásakor keletkező esetleges kivételeket le kell kezelni.
- A játék indulás után rakjon ki 10 véletlenszerűen kiválasztott szópárt (20 szókártya) összekeverve a képernyőre.  Lehet két oszlopba is rakni őket.  


> Teams-en várjuk a feladattal kapcsolatban kérdéseket, és igyekszünk mihamarabb válaszolni.

## Tippek a megvalósításhoz

Érdemes a lovas képkirakós mintapéldát alapul venni, csak most szavakat mozgatunk, nem képeket. 

Érdemes létrehozni egy szókártya osztályt, mely megvalósítja a vonszolhatóságot, valamint publikus változóban tárolja a kártya párján lévő szöveget. De úgy is lehet, hogy minden szókártya egy sorszámot tárol, és az összetartozó szavakhoz ugyan az a szám tartozik. 

A szavakat tartalmazó elemek kipakolásánál a fő űrlapon érdemes közös eseménykiszolgálót rendelni a `MouseUp` eseményhez, és ebben vizsgálni, hogy az az elem, aminek a vonszolását befejeztük, másik elem fölött van-e, és ha igen, párban van-e a másik elemmel. 

### Segítség a fájlmegnyitó ablak használatához

```csharp
private void button1_Click(object sender, EventArgs e)
{
    OpenFileDialog ofd = new OpenFileDialog();
    if (ofd.ShowDialog() == DialogResult.OK)
    {
        StreamReader sr = new StreamReader(ofd.FileName);
        // file olvasása 
        sr.Close();
    }
}

```

Az  `ofd.ShowDialog()`  metódushívás jeleníti meg a fájlmegnyitó ablakot. Ha a felhasználó választott fájlt, a  `ShowDialog()`  `DialogResult.OK`  eredménnyel tér vissza, egyébként  `DialogResult.Cancel`  lesz a visszatérési érték. Csak  
`DialogResult.OK`  után van értelme a fájlt megnyitását megkísérelni.

### `try`  `catch`  blokkok

A fájlmegnyitás, illetve olvasás nem biztos hogy sikerül,  `try`  `catch`  blokk használata indokolt.

```csharp
            OpenFileDialog ofd = new OpenFileDialog();
            try
            {
                StreamReader sr = new StreamReader("Eheti lottó nyerőszámok.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
```
