using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicijskaUprava.Entiteti
{
	public abstract class AlarmniSistem
	{
		
        
        public virtual int Serijski_br { get; set; }
		public virtual int Godina_proizvodnje { get; set; }
		public virtual string Proizvodjac { get; set; }
		public virtual string Model { get; set; }
		public virtual string Opis_servisiranja { get; set; }
        public virtual string Tip { get; set; }
		public virtual DateTime Datum_Atesta { get; set; }
		public virtual DateTime Datum_Poslednjeg_Atesta { get; set; }
        public virtual Objekat ObjekatInstaliran { get; set; }
        public virtual TehnickoLice TehnickoLice { get; set; }
        


        public AlarmniSistem()
		{

		}
	}

	public class Toplotni : AlarmniSistem
	{
		public virtual int Horizontalna_rez { get; set; }
		public virtual int Vertikalna_rez { get; set; }

		public Toplotni()
		{

		}
	}

	public class Pokretni : AlarmniSistem
	{
		public virtual int Tezina { get; set; }

		public Pokretni()
		{

		}
	}

	public class Ultrazvucni : AlarmniSistem
	{
		public virtual int Frekvencija { get; set; }

		public Ultrazvucni()
		{

		}
	}



}
