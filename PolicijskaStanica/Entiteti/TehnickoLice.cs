using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicijskaUprava.Entiteti
{
	public class TehnickoLice
	{
		
		public virtual AlarmniSistem Serijski_br_alarma { get; set; }
		public virtual string Ime { get; set; }


		public override bool Equals(object Object)
		{

		

		return false;
		}
		public override int GetHashCode()
        {
            return base.GetHashCode();
       }
    }
}
