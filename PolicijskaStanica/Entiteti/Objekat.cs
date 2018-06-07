using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicijskaUprava.Entiteti
{
	public class Objekat
	{
		public virtual int ID { get; set; }
		public virtual string Tip { get; set; }
		public virtual string Adresa { get; set; }
		public virtual int Povrsina { get; set; }
		public virtual string Ime { get; set; }
		public virtual string Prezime { get; set; }
		public virtual int Br_telefona { get; set; }
		public virtual int Serijski_br_alarma { get; set; }
		public virtual DateTime Datum_instalacije { get; set; }
		public virtual int ID_Stanice { get; set; }
        public virtual AlarmniSistem InstaliranAlarmniSis { get; set; }

        public virtual PolicijskaStanica NadzireStanica { get; set; }

        public virtual IList<Patrola> Patrole { get; set; } //proveritiiiii



        public Objekat()
		{
            Patrole = new List<Patrola>();

        }

    }
}
