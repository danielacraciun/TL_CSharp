using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

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
				return this.prgStates [nrPrg];
			throw new RepositoryException ();
		}

		public void add(PrgState ps) {
			ps.setId (++nrPrg);
			prgStates[nrPrg] = ps;
		}

		public void serialize() {
			IFormatter formatter = new BinaryFormatter( );
			using (FileStream s = File.Create ("serialize.bin")) {
				formatter.Serialize (s, this.getCrtPrg ());
			}
		}

		public PrgState deserialize() {
			IFormatter formatter = new BinaryFormatter( );
			using (FileStream s = File.OpenRead ("serialize.bin")) {
				return (PrgState)formatter.Deserialize (s);
			}
		}

		public void writeToFile(String filename) {
			using (StreamWriter w = File.AppendText(filename)) {
				w.WriteLine(this.getCrtPrg());
			}
		}
	}
}

