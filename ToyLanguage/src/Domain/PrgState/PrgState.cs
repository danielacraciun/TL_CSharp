using System;

namespace ToyLanguage
{
	public class PrgState
	{
		public IStack exeStack;
		public IDictionary symTable;
		public IList outList;

		public PrgState(IStack stack, IDictionary symbol_table, IList output) {
			exeStack = stack;
			symTable = symbol_table;
			outList = output;
		}

		public IStack getExeStack() {
			return exeStack;
		}

		public IDictionary getSymTable() {
			return symTable;
		}

		public IList getOut() {
			return outList;
		}
	}
}

