using System;

namespace ToyLanguage
{
	[Serializable] public class PrgState
	{
		private int state_id;
		private IStack<IStmt> exeStack;
		private IDictionary<String ,int> symTable;
		private IList<int> outList;
		private IHeap<int> h;

		public PrgState(IStack<IStmt> stack, IDictionary<String, int> symbol_table, IList<int> output, IHeap<int> hp) {
			exeStack = stack;
			symTable = symbol_table;
			outList = output;
			h = hp;
		}

		public void setId(int id) {
			state_id = id;
		}

		public IStack<IStmt> getExeStack() {
			return exeStack;
		}

		public IDictionary<String, int> getSymTable() {
			return symTable;
		}

		public IList<int> getOut() {
			return outList;
		}

		public IHeap<int> getHeap() {
			return h;
		}

		public override string ToString() {
			return this.state_id.ToString() + ". " + this.exeStack.ToString() + "\n" + 
				this.symTable.ToString() + "\n" + this.outList.ToString() + "\n" +
				this.h.ToString();
		}
	}
}

