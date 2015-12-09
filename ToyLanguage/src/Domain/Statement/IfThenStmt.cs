using System;

namespace ToyLanguage
{
	[Serializable] public class IfThenStmt: IStmt {
		private Exp exp;
		private IStmt thenStmt;

		public IfThenStmt(Exp e, IStmt then) {
			exp = e;
			thenStmt = then;
		}

		public override String ToString() {
			return "IF(" + exp.ToString() + ") THEN(" + 
					thenStmt.ToString() + ")";
		}

		public PrgState execute(PrgState state) {
			state.getExeStack().Push(new IfStmt(exp, thenStmt, new SkipStmt()));
			return state;
		}

		public Exp getExp() {
			return exp;
		}

		public IStmt getThenStmt() {
			return thenStmt;
		}
	}
}

