using System;
using System.Collections;

namespace ToyLanguage
{
	public class MyList: IList<String>
	{
		private Object[] elem;
		private int nrElem;

		public MyList()
		{
			elem = new Object[20];
			nrElem = 0;
		}


		public void Add(Object o) {
			elem [nrElem++] = o;
		}

		public Boolean Contains(Object o) {
			for (int i = 0; i < nrElem; i++)
				if (elem [i] == o)
					return true;
			return false;
		}

		public int Length {
			get { return nrElem; }
		}

		public override String ToString ()
		{
			String ListStr = "Output: ";
			foreach (var item in this)
			{
				ListStr += item;
				ListStr += "; ";
			}
			return ListStr;
		}

		public Object this[int index] {
			get { 
				if (index < nrElem && index >= 0)
					return elem [index];
				return null;
			}
			set { 				
				if (index < nrElem && index >= 0)
					elem [index] = value;
			}
		}

		public IEnumerator GetEnumerator() {
			return new ALEnumerator (this);
		}

		private class ALEnumerator : IEnumerator {
			private int cursor;
			private MyList al;

			public ALEnumerator(MyList al) {
				this.al = al;
				cursor = -1;
			}

			public bool MoveNext() {
				cursor++;
				return cursor < al.nrElem;
			}

			public Object Current {
				get { return al.elem [cursor]; }
			}

			public void Reset() {
				cursor = -1;
			}


		}
	}
}

