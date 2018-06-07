using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicijskaUprava.Entiteti
{
	public class Vozilo
	{
        public virtual string Reg_oznaka { get; set; } //isto
        public virtual string Boja { get; set; }
		public virtual string Tip { get; set; }
        public virtual string Model { get; set; } //ne znam sto niste nap
        public virtual string Proizvodjac { get; set; } //isto


        public virtual Patrola VoziVozilo { get; set; }

        public virtual PolicijskaStanica PosedujeStanica { get; set; }


        public Vozilo()
		{

		}
	}
}
