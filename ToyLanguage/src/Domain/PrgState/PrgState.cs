using System;

namespace ToyLanguage
{
	[Serializable] public class PrgState
	{
		public IStack<IStmt> exeStack;
		public IDictionary<String ,int> symTable;
		public IList<int> outList;

		public PrgState(IStack<IStmt> stack, IDictionary<String, int> symbol_table, IList<int> output) {
			exeStack = stack;
			symTable = symbol_table;
			outList = output;
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

		public override string ToString() {
			return this.exeStack.ToString() + "\n" + this.symTable.ToString() + "\n" +
				this.outList.ToString();
		}
	}
}

