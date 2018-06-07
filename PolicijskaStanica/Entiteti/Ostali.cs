using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicijskaUprava.Entiteti
{
	public class Ostali : Policajac
	{
	
		public virtual int Redni_br_patrole { get; set; }
        public virtual Patrola PatrolaVodje { get; set; }

		public virtual Patrola RadiU { get; set; }
		

		public Ostali()
		{

		}
	}
}
