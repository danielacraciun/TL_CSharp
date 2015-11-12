using System;

namespace ToyLanguage
{
	public class MyDictionary: IDictionary<String, int>
	{
		private Object[] keys;
		private Object[] values;
		private int nrElem;

		public MyDictionary ()
		{
			keys = new Object[20];
			values = new Object[20];
			nrElem = 0;
		}

		public object this[object key]
		{
			get
			{   
				for (int i = 0; i < nrElem; i++) {
					if (keys[i] == key)
						return values[i];
				}

				return null;
			}

			set
			{
				int i;
				if (this.containsKey (key)) {
					for (i = 0; i < nrElem; i++) {
						if (keys [i] == key)
							values [i] = value;
					}
				} else {
					Add (key, value);
				}	
			}
		}

		public override String ToString ()
		{
			String ListStr = "Variables: ";

			foreach (var item in this)
			{
				ListStr += item.ToString ();
				ListStr += ": ";
				ListStr += this[item].ToString ();
				ListStr += "; ";
			}

			return ListStr;
		}

		public int Count {
			get { return nrElem; }
		}

		public void Add(object key, object value) 
		{
			keys[nrElem] = key;
			values[nrElem++] = value;
		}

		public Boolean containsKey(Object key) {
			for (int i = 0; i < nrElem; i++) {
				if (keys [i] == key)
					return true;
			}
			return false;
		}

		public IEnumerator GetEnumerator() {
			return new ALEnumerator (this);
		}

		private class ALEnumerator : IEnumerator {
			private int cursor;
			private ArrayDictionary ad;

			public ALEnumerator(ArrayDictionary ad) {
				this.ad = ad;
				cursor = -1;
			}

			public bool MoveNext() {
				cursor++;
				return cursor < ad.nrElem;
			}

			public Object Current {
				get { return ad.keys [cursor]; }
			}

			public void Reset() {
				cursor = -1;
			}

		}
	}
}

