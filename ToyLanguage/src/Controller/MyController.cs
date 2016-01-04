using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToyLanguage
{
	public class MyController
	{
		private IRepository repo;

		public MyController(IRepository r) {
			repo = r;
		}

		public void addPrgState(PrgState p) {
			repo.add(p);
		}

		public List<PrgState> getPrgStates() {
			return repo.getPrgList ();
		}

		public List<PrgState> removeCompletedPrg(List<PrgState> inPrgList) {
			return inPrgList.Where (p => p.NotCompleted ()).ToList();
		}

		public void oneStepForAllPrg(List<PrgState> prgList, Boolean printFlag, Boolean logFlag, String filename) {

			List<Task<PrgState>> taskList = 
				(from prg in prgList
					select Task<PrgState>.Factory.StartNew(() => prg.OneStep())).ToList();

			List<PrgState> newPrgList = (from tsk in taskList
				where tsk.Result != null
				select tsk.Result).ToList();
			
			newPrgList.AddRange (prgList.Where (p => !newPrgList.Any (q => q.getId() == p.getId())).ToList ());
			repo.setPrgList(newPrgList);

			if(printFlag) {
				foreach (PrgState p in prgList)
					Console.WriteLine(p);
			}

			if(logFlag) {
				this.repo.writeToFile(filename);
			}
		}

		public void fullStep(Boolean printFlag, Boolean logFlag, String filename) {
			while(true){
				List<PrgState> prgList = removeCompletedPrg(repo.getPrgList());
				if(prgList.Count == 0) return;
				else oneStepForAllPrg(prgList, printFlag, logFlag, filename);
			}
		}

		public void repoSer() {
			repo.serialize ();
		}

		public PrgState repoDeser() {
			return repo.deserialize ();
		}
	}
}

