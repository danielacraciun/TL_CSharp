using System;

namespace ToyLanguage
{
	public class MyStack: IStack<IStmt>
	{
		private Object[] elem;
		private int nrElem;

		public MyStack ()
		{
			elem = new Object[20];
			nrElem = 0;
		}

		public void Push(Object o) {
			elem[nrElem++] = o;
		}

		public Object Pop() {
			if (nrElem > 0)
				return elem[--nrElem];
			return null;
		}

		public Boolean isEmpty() {
			return nrElem == 0;
		}

		public Object Top() {
			if (nrElem > 0)
				return elem[nrElem - 1];
			return null;
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

