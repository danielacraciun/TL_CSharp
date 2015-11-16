using System;

namespace ToyLanguage
{
	[Serializable] public class WhileStmt: IStmt {
		private Exp exp;
		private IStmt stmt;

		public WhileStmt(Exp e, IStmt stmt) {
			this.exp = e;
			this.stmt = stmt;
		}

		public Exp getExp() {
			return exp;
		}

		public IStmt getStmt() {
			return stmt;
		}
			
		public override String ToString() {
			return "While( " + exp.ToString() + ") { " 
					+ stmt.ToString() + " }";
		}
	}
}

