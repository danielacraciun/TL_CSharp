using System;
using System.Collections.Generic;

namespace ToyLanguage
{
	[Serializable] public class ArrayStack<T>: IStack<T>
	{
		private Stack<T> elements;

		public ArrayStack () {
			elements = new Stack<T>();
		}

		public T Pop () {
			if (elements.Count > 0) {
				return  elements. Pop();
			}
			throw new EmptyArrayException ();
		}

		public T Peek () {
			if (elements.Count > 0) {
				return  elements. Peek();
			}
			throw new EmptyArrayException ();
		}

		public void Push (T obj) {
			elements.Push (obj);
		}

		public int Count {
			get {
				return elements.Count;
			}
		}

		public override string ToString () {
			return "Execution Stack: " + string.Join(";", elements) + " ";
		}
			
	}
}

