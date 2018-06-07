using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicijskaUprava.Entiteti
{
	public class Ulica
	{
		public virtual int ID_Policajca { get; set; }
		public virtual string Ulica_naziv { get; set; }

		public virtual Policajac PozornikUlice { get; set; }

		public Ulica()
		{

		}
	}
}
