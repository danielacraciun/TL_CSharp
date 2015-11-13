using System;
using System.Collections;

namespace ToyLanguage
{
	public class MyDictionary: IDictionary<String, int>
	{
		private String[] keys;
		private int[] values;
		private int nrElem;

		public MyDictionary ()
		{
			keys = new String[20];
			values = new int[20];
			nrElem = 0;
		}

		public int this[string key]
		{
			get
			{   
				for (int i = 0; i < nrElem; i++) {
					if (keys[i] == key)
						return values[i];
				}

				return 0;
			}

			set
			{
				int i;
				if (this.containsKey (key)) {
					for (i = 0; i < nrElem; i++) {
						if (keys [i] == key)
							values [i] = (int)value;
					}
				} else {
					Add (key, (int)value);
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
				ListStr += this[(string)item].ToString ();
				ListStr += "; ";
			}

			return ListStr;
		}

		public int Count {
			get { return nrElem; }
		}

		public void Add(String key, int value) 
		{
			keys[nrElem] = key;
			values[nrElem++] = value;
		}

		public Boolean containsKey(String key) {
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
			private MyDictionary ad;

			public ALEnumerator(MyDictionary ad) {
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

