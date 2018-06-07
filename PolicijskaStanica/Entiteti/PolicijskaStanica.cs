using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicijskaUprava.Entiteti
{
	public class PolicijskaStanica
	{
		public virtual int ID { get; set; }
		public virtual string Adresa { get; set; }
		public virtual string Opstina { get; set; }
		public virtual string Naziv { get; set; }
		public virtual DateTime Datum_osnivanja { get; set; }
		public virtual int ID_Sefa { get; set; }
        public virtual Policajac SefStanice { get; set; }
        public virtual Policajac ZamenikStanice { get; set; }
		public virtual int ID_Zamenika { get; set; }
		public virtual int ID_Uprave { get; set; }

        public virtual IList<Objekat> Objekti { get; set; } 
        public virtual IList<Policajac> Policajci { get; set; } 
        public virtual Uprava PripadaUpravi { get; set; }
        public virtual IList<Vozilo> Vozila { get; set; } 




        public PolicijskaStanica()
		{
            Objekti = new List<Objekat>();
            Policajci = new List<Policajac>();
            Vozila = new List<Vozilo>();




        }

    }
}
