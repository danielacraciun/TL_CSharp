using System;

namespace ToyLanguage
{
	public interface Exp
	{
		int eval (IDictionary<String, int> tbl);

		String ToString ();
	}
}

