using System;

namespace ToyLanguage
{
	public interface IRepository
	{
		PrgState getCrtPrg();
		void add(PrgState o);
		void serialize();
		PrgState deserialize();
		void writeToFile(String filename);
	}
}

