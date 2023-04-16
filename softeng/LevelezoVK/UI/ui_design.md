# Felhasználói felület tervezés

A következő néhány videó olyan adatbázis frontendek megvalósításához nyújt segítséget, ahol a tartalom nem fér ki egy képernyőre. Lehetőség van többablakos alkalmazás készítésére,  de a mostani  trendek  inkább az egyablakos megoldásokat részesítik előnyben.

(!Vid) Felhasználói felület felugró ablakokkal

> [!Video https://storage.altinum.hu/softeng_lev/tobbablakos_1_gomb.m4v]



(!Vid) Egyablakos felület

> [!Video https://storage.altinum.hu/softeng_lev/tobbablakos_1_panel.m4v]



#### **Kódminták a videókból:**



``` csharp
private void button1_Click(object sender, EventArgs e)
{
      FormA fc = new FormA();
      fc.ShowDialog();
}
```

​	

``` csharp
private void button1_Click(object sender, EventArgs e)
{
      UserControlA uca = new UserControlA();
      panel1.Controls.Clear();
      panel1.Controls.Add(uca);
      uca.Dock = DockStyle.Fill;
}
```

