namespace HajosQuiz
{
    public partial class Form1 : Form
    {
List<Kérdés> ÖsszesKérdés;
List<Kérdés> AktívKérdések;
        int AktívKérdés=5;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ÖsszesKérdés = KérdésBeolvasás();
            AktívKérdések = new List<Kérdés>();
            for (int i = 0; i < 7; i++)
            {
                AktívKérdések.Add(ÖsszesKérdés[0]);
                ÖsszesKérdés.RemoveAt(0);
            }

            dataGridView1.DataSource = AktívKérdések;

            KérdésMegjelenítés(AktívKérdések[AktívKérdés]);

        }


void KérdésMegjelenítés(Kérdés kérdés)
{
    labelKérdés.Text = kérdés.KérdésSzöveg;
    textBox1.Text = kérdés.Válasz1;
    textBox2.Text = kérdés.Válasz2;
    textBox3.Text = kérdés.Válasz3;
    if (!string.IsNullOrEmpty(kérdés.URL))
    {
        pictureBox1.Load("https://storage.altinum.hu/hajo/" + kérdés.URL);
        pictureBox1.Visible = true;
    }
    else
    {
        pictureBox1.Visible = false;
    }            
}

List<Kérdés> KérdésBeolvasás()
{
    List<Kérdés> kérdések = new List<Kérdés>();

    StreamReader sr = new StreamReader("hajozasi_szabalyzat_kerdessor_BOM.txt", true);

    while (!sr.EndOfStream)
    {
        string sor = sr.ReadLine() ?? string.Empty; //A ?? azt jelenti, hogy ha az sr.ReadLine() null értékkel jön vissza, akkor legyen üres string a sor változó értéke
        string[] tömb = sor.Split("\t");
        if (tömb.Length != 7) continue; //Ha nem 6 részre hasítja a sort a TAB, akkor ez egy rossz sor, megyünk a következőre

        Kérdés k = new Kérdés();
        k.KérdésSzöveg = tömb[1].Trim('"');
        k.Válasz1 = tömb[2].Trim('"');
        k.Válasz2 = tömb[3].Trim('"');
        k.Válasz3 = tömb[4].Trim('"');
        k.URL = tömb[5];
        int.TryParse(tömb[6], out int jóválasz); //Ez a best practice
        k.HelyesVálasz = jóválasz;

        kérdések.Add(k);
    }

    return kérdések;
}
    }

}