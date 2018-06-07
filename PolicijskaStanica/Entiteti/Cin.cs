using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicijskaUprava.Entiteti
{
	public class Cin
	{
		public virtual int ID { get; set; }
		public virtual string Naziv_cina { get; set; }
        public virtual IList<Policajac> Policajci { get; set; }


        public Cin()
		{
            Policajci = new List<Policajac>();


        }
    }
}
