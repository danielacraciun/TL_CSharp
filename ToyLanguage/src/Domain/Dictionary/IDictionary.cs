using System;

namespace ToyLanguage
{
	public interface IDictionary<K, V>: System.Collections.IEnumerable
	{
		int Count { get; }

		void Add (K key, V value);

		bool containsKey (K key);

		V this [K key] { get; set; }
	}
}

