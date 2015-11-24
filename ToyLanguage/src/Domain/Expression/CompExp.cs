using System;

namespace ToyLanguage
{
	[Serializable] public class CompExp: Exp
	{
		private Exp e1;
		private Exp e2;
		private String cmp;

		public CompExp (Exp e1, Exp e2, String cmp)
		{
			this.e1 = e1;
			this.e2 = e2;
			this.cmp = cmp;
		}

		public int eval(IDictionary<String, int> tbl, IHeap<int> h) {
			if (cmp == "<") {
				if (e1.eval(tbl, h) < e2.eval(tbl, h))
					return 1;
				else
					return 0;
			} else if (cmp == "<="){
				if(e1.eval(tbl, h) <= e2.eval(tbl, h))
					return 1;
				else
					return 0;
			} else if (cmp == "=="){
				if(e1.eval(tbl, h) == e2.eval(tbl, h))
					return 1;
				else
					return 0;
			} else if (cmp == "!="){
				if(e1.eval(tbl, h) != e2.eval(tbl, h))
					return 1;
				else
					return 0;
			} else if (cmp == ">"){
				if(e1.eval(tbl, h) > e2.eval(tbl, h))
					return 1;
				else
					return 0;
			} else if (cmp == ">="){
				if(e1.eval(tbl, h) <= e2.eval(tbl, h))
					return 1;
				else
					return 0;
			}

			return 0;
		}

		public override String ToString() {
			return e1.ToString() + " " + cmp + " " + e2.ToString();
		}
			
	}
}

