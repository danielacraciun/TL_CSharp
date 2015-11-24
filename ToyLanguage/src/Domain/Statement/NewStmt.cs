using System;

namespace ToyLanguage
{
	[Serializable] public class NewStmt: IStmt
	{
		private String id;
		private Exp exp;

		public NewStmt(String id, Exp exp) {
			this.exp = exp;
			this.id = id;
		}

		public void setId(String id) {
			this.id = id;
		}

		public String getId() {
			return id;
		}

		public Exp getExp() {
			return exp;
		}

		public void setExp(Exp exp) {
			this.exp = exp;
		}
			
		public override String ToString() {
			return "new(" + id + ", " + exp.ToString() + ")";
		}
			
		public PrgState execute(PrgState state) {
			int value = exp.eval(state.getSymTable(), state.getHeap());
			state.getSymTable().Add(id, state.getHeap().Add(value));
			return state;
		}
	}
}

