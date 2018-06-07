using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicijskaUprava.Entiteti
{
	public class VanredneSituacije : Policajac
	{
		
		public virtual string Naziv_vestine { get; set; }
		public virtual string Kurs { get; set; }
		public virtual DateTime Datum_kursa { get; set; }
		public virtual string Sertifikat { get; set; }
		public virtual DateTime Datum_sertifikata { get; set; }

		public VanredneSituacije()
		{

		}

	}
}
