using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

namespace ToyLanguage
{
	public class MyRepository: IRepository
	{
		private List<PrgState> prgStates;
		private int nrPrg;

		public MyRepository() {
			prgStates = new List<PrgState> ();
			nrPrg = 0;
		}

		public List<PrgState> getPrgList() {
			return this.prgStates;
		}

		public void setPrgList(List<PrgState> states) {
			prgStates = states;
			nrPrg = states.Count;		
		}

		public void add(PrgState ps) {
			ps.setId (nrPrg++);
			prgStates.Add (ps);
		}

		public void serialize() {
			IFormatter formatter = new BinaryFormatter( );
			using (FileStream s = File.Create ("serialize.bin")) {
				formatter.Serialize (s, this.getPrgList()[0]);
			}
		}

		public void deserialize() {
			IFormatter formatter = new BinaryFormatter( );
			using (FileStream s = File.OpenRead ("serialize.bin")) {
				this.prgStates = new List<PrgState> ();
				this.prgStates.Add((PrgState)formatter.Deserialize (s));
			}
		}

		public void writeToFile(String filename) {
			using (StreamWriter w = File.AppendText(filename)) {
				w.WriteLine(this.prgStates);
			}
		}
	}
}

