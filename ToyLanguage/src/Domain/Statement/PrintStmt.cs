using System;

namespace ToyLanguage
{
	public class PrintStmt: IStmt
	{
		private Exp exp;

		public PrintStmt (Exp exp)
		{
			this.exp = exp;
		}

		public Exp getExp() {
			return exp;
		}

		public override String ToString() {
			return "print(" + exp.ToString() + ")";
		}
	}
}

