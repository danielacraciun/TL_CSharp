using System;
using System.Linq;
using System.Collections;

namespace ToyLanguage
{
	public interface IList<T>: IEnumerable {
		void Add (T e);

		bool Contains (T e);

		int Count{ get; }

		T this [int index]{ get; set; }
	}
}

