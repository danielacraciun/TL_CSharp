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

		public int eval(IDictionary<String, int> tbl) {
			return nr;
		}

		public override String ToString() {
			return nr.ToString ();
		}

		public int getNr() {
			return nr;
		}
	}
}

