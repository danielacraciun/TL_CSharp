using System;

namespace ToyLanguage
{
	public class ArithmExp: Exp
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

		public int eval(IDictionary tbl) {
			if (op == '+') return (e1.eval(tbl) + e2.eval(tbl));
			if (op == '-') return (e1.eval(tbl) - e2.eval(tbl));
			if (op == '*') return (e1.eval(tbl) * e2.eval(tbl));
			if (op == '/') return (e1.eval(tbl) / e2.eval(tbl));
			return 0;
		}

		override public String ToString() {
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

