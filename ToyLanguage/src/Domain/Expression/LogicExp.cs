using System;
using System.Collections.Generic;

namespace ToyLanguage
{
	public class LogicExp: Exp {
		private Exp e1;
		private Exp e2;
		private String cmp;

		public LogicExp(Exp e1, String cmp) {
			this.e1 = e1;
			this.e2 = new ConstExp(0);
			this.cmp = cmp;
		}

		public LogicExp(Exp e1, Exp e2, String cmp) {
			this.e1 = e1;
			this.e2 = e2;
			this.cmp = cmp;
		}

		public int eval(IDictionary<String, int> tbl) {
			switch (cmp) {
			case "&&":
				if (e1.eval(tbl) != 0 && e2.eval(tbl) != 0)
					return 1;
				else
					return 0;
			case "||":
				if (e1.eval(tbl) != 0 || e2.eval(tbl) != 0)
					return 1;
				else
					return 0;
			case "!":
				if (e1.eval(tbl) == 0)
					return 1;
				else
					return 0;
			}
			return 0;
		}

		public String toString() {
			if(! (cmp == "!")) {
				return e1.ToString() + " " + cmp + " " + e2.ToString();
			} else {
				return cmp + e1.ToString();
			}
		}
	}
}

