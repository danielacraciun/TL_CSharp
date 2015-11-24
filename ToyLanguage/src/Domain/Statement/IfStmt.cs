using System;

namespace ToyLanguage
{
	[Serializable] public class IfStmt: IStmt
	{
		private Exp exp;
		private IStmt thenStmt;
		private IStmt elseStmt;

		public IfStmt(Exp e, IStmt then, IStmt otherwise) {
			this.exp = e;
			this.thenStmt = then;
			this.elseStmt = otherwise;
		}

		public override String ToString() {
			return "IF(" + exp.ToString() + ") THEN(" + thenStmt.ToString()
					+ ")ELSE(" + elseStmt.ToString() + ")";
		}

		public PrgState execute(PrgState state) {
			int result = exp.eval(state.getSymTable(), state.getHeap());
			if (result != 0)
				state.getExeStack().Push(thenStmt);
			else
				state.getExeStack().Push(elseStmt);
			return state;
		}

		public Exp getExp() {
			return exp;
		}

		public IStmt getThenStmt() {
			return thenStmt;
		}

		public IStmt getElseStmt() {
			return elseStmt;
		}
	}
}

