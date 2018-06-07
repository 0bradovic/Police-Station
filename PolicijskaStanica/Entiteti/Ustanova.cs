using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicijskaUprava.Entiteti
{
	public class Ustanova
	{
		public virtual int ID { get; set; }
		public virtual string Naziv_ustanove { get; set; }
		public virtual string Tip { get; set; }
        public virtual IList<Policajac> Policajci { get; set; }


        public Ustanova()
		{
            Policajci = new List<Policajac>();

        }
    }
}
