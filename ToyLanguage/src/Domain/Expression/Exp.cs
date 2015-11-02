using System;

namespace ToyLanguage
{
	public interface Exp
	{
		int eval(IDictionary tbl);
		String ToString();
	}
}

