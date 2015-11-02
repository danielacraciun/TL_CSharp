using System;

namespace ToyLanguage
{
	public interface IDictionary: System.Collections.IEnumerable
	{
		int Count { get; }
		void Add(Object key, Object value);
		Boolean containsKey(Object key);
		object this[ object key ] { get; set; }
	}
}

