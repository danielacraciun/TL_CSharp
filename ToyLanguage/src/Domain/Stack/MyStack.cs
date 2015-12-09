using System;

namespace ToyLanguage
{
	public class MyStack: IStack<IStmt>
	{
		private IStmt[] elem;
		private int nrElem;

		public MyStack ()
		{
			elem = new IStmt[20];
			nrElem = 0;
		}

		public void Push(IStmt o) {
			elem[nrElem++] = o;
		}

		public IStmt Pop() {
			if (nrElem > 0)
				return elem[--nrElem];
			return null;
		}

		public Boolean isEmpty() {
			return nrElem == 0;
		}

		public IStmt Peek() {
			if (nrElem > 0)
				return elem[nrElem - 1];
			return null;
		}

		public int Count {
			get {
				return nrElem;
			}
		}
		public override String ToString ()
		{
			String ListStr = "Execution Stack: ";

			for (int i = nrElem - 1; i >= 0; i--) {
				ListStr += elem[i].ToString ();
				ListStr += "; ";
			}

			return ListStr;
		}

	}
}

