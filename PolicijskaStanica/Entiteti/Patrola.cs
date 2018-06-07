using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicijskaUprava.Entiteti
{
	public class Patrola
	{
		// id ili redni_br?
		public virtual int Redni_br { get; set; }
		public virtual int ID_Vodje { get; set; }
        public virtual Ostali Vodja { get; set; }
		public virtual int Reg_oznaka_vozila { get; set; }
        public virtual Vozilo VoziloPatrole { get; set; }
		public virtual int ID_Objekta { get; set; }
		public virtual DateTime Vreme { get; set; }
		public virtual string Opis { get; set; }

        public virtual Objekat InterveniseObjekat { get; set; }

		public virtual IList<Ostali> Radnici { get; set; }


        public Patrola()
		{

		}

	}
}
