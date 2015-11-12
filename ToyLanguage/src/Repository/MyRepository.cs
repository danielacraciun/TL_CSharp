using System;

namespace ToyLanguage
{
	public class MyRepository: IRepository
	{
		private PrgState[] prgStates;
		private int nrPrg;

		public MyRepository(PrgState[] states) {
			prgStates = states;
			nrPrg = 1;
		}

		public MyRepository() {
			prgStates = new PrgState[20];
			nrPrg = 0;
		}

		public PrgState getCrtPrg() {
			if (nrPrg > 0)
				return this.prgStates [0];
			throw new RepositoryException ();
		}

		public void add(PrgState ps) {
			prgStates[nrPrg++] = ps;
		}
	}
}

