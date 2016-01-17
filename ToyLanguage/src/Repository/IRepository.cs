using System;
using System.Collections.Generic;

namespace ToyLanguage
{
	public interface IRepository
	{
		List<PrgState> getPrgList();
		void setPrgList(List<PrgState> states);
		void add(PrgState o);
		void serialize();
		void deserialize();
		void writeToFile(String filename);
	}
}

