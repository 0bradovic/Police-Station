using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicijskaUprava.Entiteti
{
	public class Skola
	{
		public virtual int ID { get; set; }
		public virtual string Tip_skole { get; set; }
		public virtual string Naziv { get; set; }
		public virtual int Br_telefona { get; set; }
		public virtual string Adresa { get; set; }
		public virtual string Ime { get; set; }
		public virtual string Prezime { get; set; }
        public virtual IList<Skolski> Skolski { get; set; }


        public Skola()
		{
            Skolski = new List<Skolski>();


        }

    }
}
