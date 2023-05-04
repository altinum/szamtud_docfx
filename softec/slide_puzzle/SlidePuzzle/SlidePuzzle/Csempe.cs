using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidePuzzle
{
    internal class Csempe : Button  
    {

		public static int Métert = 90;

		private int _sor;
public int Sor
{
	get { return _sor; }
	set { 
		_sor = value;
		Top = Métert * Sor;
	}
}

		private int _oszlop;

		public int Oszlop
		{
			get { return _oszlop; }
			set { 
				_oszlop = value;
				Left = Métert* _oszlop;
			}
		}

		public int EredetiSor { get; set; }

        public int EredetiOszlop { get; set; }

		public bool	Kintűntett { get;  }


        public Csempe(int sor, int oszlop, int szám,bool kitűntett)
		{
			Height = Métert;
			Width = Métert;
			EredetiSor = sor;
			EredetiOszlop = oszlop;
			Sor = sor;
			Oszlop= oszlop;
			Kintűntett = kitűntett;
			if (!kitűntett)
			{
				Text = szám.ToString();
				FlatStyle = FlatStyle.Flat;
			}			
		}
    }
}
