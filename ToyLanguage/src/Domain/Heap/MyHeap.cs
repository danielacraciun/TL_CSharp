using System;
using System.Collections.Generic;

namespace ToyLanguage
{
	[Serializable] public class MyHeap<T> : IHeap<T>
	{
		private Dictionary<int, T> elements;
		private int crtPos;

		public MyHeap() {
			elements = new Dictionary<int, T>();
			crtPos = 1;
		}
			
		public int Add(T e) {
			elements.Add(this.crtPos, e);
			return this.crtPos++;
		}
			
		public void Update(int index, T value) {
			elements[index] = value;
		}

		public T this [int index] {
			get {
				if (index < elements.Count && index >= 0) {
					return elements [index];
				}
				return elements [index];
			}
			set {
				if (index < elements.Count && index >= 0) {
					elements [index] = value;
				} else {
					this.Add (value);
				}
			}
		}			
		public override String ToString() {
			String s = "Heap: ";
			foreach (int pos in elements.Keys) {
				s = s + pos.ToString() + " -> " + elements[pos]  + "   ";
			}
			return s;
		}
	}
}

