using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicijskaUprava.Entiteti
{
	public class Policajac
	{
		public virtual int ID { get; set; }
		public virtual string Licno_ime { get; set; }
		public virtual int Tip { get; set; }
		public virtual string Ime_roditelja { get; set; }
		public virtual string  Prezime { get; set; }
		public virtual int JMBG { get; set; }
		public virtual char Pol { get; set; }
		public virtual DateTime Datum_rodj { get; set; }
		public virtual string Adresa { get; set; }
		public virtual DateTime Datum_diplomiranja { get; set; }
		public virtual DateTime Datum_unapredjenja { get; set; }
		public virtual int Oblast { get; set; }
		public virtual int ID_Ustanove { get; set; }
		public virtual int ID_Cina { get; set; }
		public virtual int ID_Uprave { get; set; }
		public virtual int ID_Stanice { get; set; }

        public virtual Uprava JeZamenikUprave { get; set; }
        public virtual Ustanova PripadaUstanovi { get; set; }
        public virtual Uprava JeNacelnikUprave { get; set;  }
        public virtual PolicijskaStanica RadiUStanici { get; set; }
        public virtual PolicijskaStanica PolicijskaStanicaZamenika { get; set; }
        public virtual PolicijskaStanica PolicijskaStanicaSefa { get; set; }

        public virtual Cin ImaCin { get; set; }



        public Policajac()
		{

		}

	}
}
