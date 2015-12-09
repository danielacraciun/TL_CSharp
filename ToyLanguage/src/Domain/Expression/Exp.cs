using System;

namespace ToyLanguage
{
	public interface Exp
	{
		int eval (IDictionary<String, int> tbl, IHeap<int> h);

		String ToString ();
	}
}

