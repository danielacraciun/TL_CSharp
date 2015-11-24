using System;

namespace ToyLanguage
{
	[Serializable] public class WriteHeapStmt: IStmt
	{
		private String id;
		private Exp exp;

		public WriteHeapStmt(String id, Exp exp) {
			this.id = id;
			this.exp = exp;
		}

		public String getId() {
			return id;
		}

		public void setId(String id) {
			this.id = id;
		}

		public Exp getExp() {
			return exp;
		}

		public void setExp(Exp exp) {
			this.exp = exp;
		}
		public override String ToString() {
			return "writeHeap( " + id + ", " + exp.ToString() + ")";
		}
			
		public PrgState execute(PrgState state) {
			state.getHeap().Update(state.getSymTable()[id], exp.eval(state.getSymTable(), state.getHeap()));
			return state;
		}
	}
}

