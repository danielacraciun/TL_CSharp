using System;

namespace ToyLanguage
{
	[Serializable] public class ForkStmt: IStmt
	{
		private IStmt forkStmt;

		public ForkStmt(IStmt forkStmt) {
			this.forkStmt = forkStmt;
		}

		public IStmt getForkStmt() {
			return forkStmt;
		}
			
		public override String ToString() {
			return "fork(" + forkStmt.ToString() + ")";
		}
			
		public PrgState execute(PrgState state) {
			IStack<IStmt> newStk = new ArrayStack<IStmt>();
			newStk.Push(forkStmt);
			IDictionary<String, int> newDict = new ArrayDictionary<String, int>(
				(ArrayDictionary<String, int>) state.getSymTable()
			);
			return new PrgState(newStk, newDict, state.getOut(), state.getHeap(), (state.getId() + 1) * 10);
		}
	}
}

