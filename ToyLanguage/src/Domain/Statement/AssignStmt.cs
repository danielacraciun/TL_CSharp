using System;

namespace ToyLanguage
{
	public class AssignStmt : IStmt
	{
		private String id;
		private Exp exp;

		public AssignStmt (String id, Exp exp)
		{
			this.id = id;
			this.exp = exp;
		}

		public String getId() {
			return id;
		}

		public Exp getExp() {
			return exp;
		}

		public override String ToString() {
			return id + " = " + exp.ToString();
		}
	}
}
