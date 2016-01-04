using System;

namespace ToyLanguage
{
	[Serializable] public class PrgState
	{
		static private int id_gen = 0;
		private int state_id;
		private IStack<IStmt> exeStack;
		private IDictionary<String ,int> symTable;
		private IList<int> outList;
		private IHeap<int> h;

		public PrgState(IStack<IStmt> stack, IDictionary<String, int> symbol_table, IList<int> output, IHeap<int> hp) {
			state_id = id_gen++;
			exeStack = stack;
			symTable = symbol_table;
			outList = output;
			h = hp;
		}

		public PrgState(IStack<IStmt> stack, IDictionary<String, int> symbol_table, 
			IList<int> output, IHeap<int> hp, int id) {
			state_id = id;
			exeStack = stack;
			symTable = symbol_table;
			outList = output;
			h = hp;
		}

		public bool NotCompleted() {
			return exeStack.Count != 0;
		}

		public PrgState OneStep() {
			if (exeStack.Count == 0) {
				throw new ModelException();
			} else {
				IStmt crtStmt = exeStack.Pop();
				return crtStmt.execute(this);
			}
		}

		public void setId(int id) {
			state_id = id;
		}

		public int getId(){
			return this.state_id;
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

