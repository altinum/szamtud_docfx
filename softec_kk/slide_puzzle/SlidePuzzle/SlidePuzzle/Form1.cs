namespace SlidePuzzle
{
    public partial class Form1 : Form
    {
        Csempe kitüntetettCsempe;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int i = 1;
            for (int s = 0; s < 4; s++)
            {
                for (int o = 0; o < 4; o++)
                {
                    Csempe cs = new Csempe(s, o, i, i == 1);
                    if (cs.Kintűntett) kitüntetettCsempe = cs;
                    Controls.Add(cs);
                    cs.Click += Cs_Click;

                    i++;
                }
            }
        }

        private void Cs_Click(object? sender, EventArgs e)
        {            
            Csempe kattintottCsempe = sender as Csempe;
            if (kattintottCsempe.Kintűntett) return;

            if (
                Math.Abs(kitüntetettCsempe.Sor - kattintottCsempe.Sor) == 1 && kattintottCsempe.Oszlop == kitüntetettCsempe.Oszlop
                ||
                Math.Abs(kitüntetettCsempe.Oszlop - kattintottCsempe.Oszlop) == 1 && kattintottCsempe.Sor == kitüntetettCsempe.Sor 
                )
            {
                //Csere
                int s = kitüntetettCsempe.Sor;
                kitüntetettCsempe.Sor = kattintottCsempe.Sor;
                kattintottCsempe.Sor = s;

                int o = kitüntetettCsempe.Oszlop;
                kitüntetettCsempe.Oszlop = kattintottCsempe.Oszlop;
                kattintottCsempe.Oszlop = o;


                //Ellenőrzés
                bool jó = true;
                foreach (Csempe item in Controls)
                {
                    if (item.Sor != item.EredetiSor || item.Oszlop != item.EredetiOszlop) jó = false;
                }
                if (jó) MessageBox.Show("Gratulálok!");
            }        
        }
    }
}