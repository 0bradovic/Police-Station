using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicijskaUprava.Entiteti
{
	public class Skolski : Policajac
	{
	
		public virtual int ID_Skole { get; set; }
        public virtual Skola RadiUSkoli { get; set; }
		public Skolski()
		{

		}
	}
}
