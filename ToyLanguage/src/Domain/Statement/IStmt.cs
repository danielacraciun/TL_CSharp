using System;

namespace ToyLanguage
{
	public interface IStmt
	{
		String ToString();
		PrgState execute (PrgState state);
	}
}

