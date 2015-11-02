using System;

namespace ToyLanguage
{
	public interface IRepository
	{
		PrgState getCrtPrg();
		void add(PrgState o);
	}
}

