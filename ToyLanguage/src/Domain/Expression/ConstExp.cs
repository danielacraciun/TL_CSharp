using System;

namespace ToyLanguage
{
	public class ConstExp: Exp
	{
		private int nr;

		public ConstExp (int newnr)
		{
			this.nr = newnr;
		}

		public int eval(IDictionary tbl) {
			return nr;
		}

		override public String ToString() {
			return nr.ToString ();
		}

		public int getNr() {
			return nr;
		}
	}
}

