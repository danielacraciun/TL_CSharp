using System;

namespace ToyLanguage
{
	[Serializable] public class ArithmExp: Exp
	{
		private Exp e1;
		private Exp e2;
		private Char op;

		public ArithmExp (Exp e1, Exp e2, Char op)
		{
			this.e1 = e1;
			this.e2 = e2;
			this.op = op;
		}

		public int eval(IDictionary<String, int> tbl, IHeap<int> h) {
			if (op == '+') return (e1.eval(tbl, h) + e2.eval(tbl, h));
			if (op == '-') return (e1.eval(tbl, h) - e2.eval(tbl, h));
			if (op == '*') return (e1.eval(tbl, h) * e2.eval(tbl, h));
			if (op == '/') {
				if (e2.eval (tbl, h) == 0)
					throw new DivisionByZeroException ();
				return (e1.eval (tbl, h) / e2.eval (tbl, h));
			}
			return 0;
		}

		public override String ToString() {
			return e1.ToString() + " " + op + " " + e2.ToString();
		}

		public Exp getE1() {
			return e1;
		}

		public Exp getE2() {
			return e2;
		}

		public Char getOp() {
			return op;
		}
	}
}

