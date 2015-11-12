using System;
using System.Collections;
using System.Collections.Generic;

namespace ToyLanguage
{
	public class ArrayList<T>: IList<T>
	{
		private List<T> elements;

		public ArrayList () {
			elements = new List<T> ();
		}

		public void Add (T e) {
			elements.Add (e);
		}

		public bool Contains (T e) {
			return elements.Contains (e);
		}

		public int Count {
			get {
				return elements.Count;
			}
		}

		public T this [int index] {
			get {
				if (index < elements.Count && index >= 0) {
					return elements [index];
				}
				throw new Exception();
			}
			set {
				if (index < elements.Count && index >= 0) {
					elements [index] = value;
				} else {
					elements.Add (value);
				}
			}
		}

		public IEnumerator GetEnumerator() {
			return new ALEnumerator (this);
		}

		public override string ToString () {
			return "Print list: " + string.Join(", ", elements);
		}

		private class ALEnumerator : IEnumerator {
			private int cursor;
			private ArrayList<T> al;

			public ALEnumerator(ArrayList<T> al) {
				this.al = al;
				cursor = -1;
			}

			public bool MoveNext() {
				cursor++;
				return cursor < al.Count;
			}

			public Object Current {
				get { return al[cursor]; }
			}

			public void Reset() {
				cursor = -1;
			}


		}
	}
}

