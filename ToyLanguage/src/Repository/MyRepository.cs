using System;

namespace ToyLanguage
{
	public class MyRepository: IRepository
	{
		private PrgState[] prgStates;
		private int nrPrg;

		public MyRepository(PrgState[] states) {
			prgStates = states;
			nrPrg = states.Length;
		}

		public MyRepository() {
			prgStates = new PrgState[20];
			nrPrg = 0;
		}

		public PrgState getCrtPrg() {
			if (nrPrg > 0)
				return prgStates[0];
			return null;
		}

		public void add(PrgState ps) {
			prgStates[nrPrg++] = ps;
		}
	}
}

