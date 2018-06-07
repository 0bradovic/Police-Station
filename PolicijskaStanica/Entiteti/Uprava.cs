using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicijskaUprava.Entiteti
{
	public class Uprava
	{
		public virtual int ID { get; set; }
		public virtual string Grad { get; set; }
		public virtual int ID_Nacelnika { get; set; }
        public virtual Policajac NacelnikUprave { get; set;  }

        public virtual IList<PolicijskaStanica> PolicijskeStanice { get; set; } 
        public virtual IList<Policajac> Policajci { get; set; } 


        public Uprava()
		{
            PolicijskeStanice = new List<PolicijskaStanica>();
            Policajci = new List<Policajac>();

        }
    }
}
