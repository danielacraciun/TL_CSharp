using System;
using System.Collections;
using System.Collections.Generic;

namespace ToyLanguage
{
	[Serializable] public class ArrayDictionary<K, V>: IDictionary<K, V>
	{
		private Dictionary<K, V> elements;

		public ArrayDictionary () {
			elements = new Dictionary<K, V> ();
		}

		public void Add (K key, V value) {
			if(elements.ContainsKey(key)) {
				elements[key] = value;
			} else {
				elements.Add (key, value);
			}
		}

		public bool containsKey (K key) {
			return elements.ContainsKey (key);
		}

		public int Count {
			get {
				return elements.Count;
			}
		}

		public V this [K key] {
			get {
				if(elements.ContainsKey (key))
					return elements [key];
				throw new UndefinedKeyException ();
			}
			set {
				elements [key] = value;
			}
		}

		public IEnumerator GetEnumerator () {
			return elements.GetEnumerator ();
		}

		public override string ToString () {
			string toString = "Variables: ";
			foreach (K key in elements.Keys) {
				toString += key + "=" + elements [key] + "; ";
			}
			return toString;
		}

}
}

