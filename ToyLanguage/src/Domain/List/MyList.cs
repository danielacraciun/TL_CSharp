using System;
using System.Collections;

namespace ToyLanguage
{
	public class MyList: IList<int>
	{
		private int[] elem;
		private int nrElem;

		public MyList()
		{
			elem = new int[20];
			nrElem = 0;
		}


		public void Add(int o) {
			elem [nrElem++] = o;
		}

		public Boolean Contains(int o) {
			for (int i = 0; i < nrElem; i++)
				if (elem [i] == o)
					return true;
			return false;
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

		public int this[int index] {
			get { 
				if (index < nrElem && index >= 0)
					return elem [index];
				return 0;
			}
			set { 				
				if (index < nrElem && index >= 0)
					elem [index] = value;
			}
		}

		public int Count {
			get {
				return elem.Length;
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

