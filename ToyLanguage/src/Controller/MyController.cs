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
		private String controllerOutput;
		private String filename;
		private bool logFlag;

		public MyController(IRepository r) {
			repo = r;
			controllerOutput = "";
			filename = "data.txt";
			logFlag = false;
		}

		public String ControllerOutput {
			get { return controllerOutput; }
			set { controllerOutput = value; }
		}

		public bool LogFlag {
			get {
				return logFlag;
			}
			set {
				logFlag = value;
			}
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

		public void oneStepForAllPrg(List<PrgState> prgList) {

			List<Task<PrgState>> taskList = 
				(from prg in prgList
					select Task<PrgState>.Factory.StartNew(() => prg.OneStep())).ToList();

			List<PrgState> newPrgList = (from tsk in taskList
				where tsk.Result != null
				select tsk.Result).ToList();
			
			newPrgList.AddRange (prgList.Where (p => !newPrgList.Any (q => q.getId() == p.getId())).ToList ());
			repo.setPrgList(newPrgList);

			foreach (PrgState p in prgList) {
				controllerOutput += p.ToString (); 
				controllerOutput += "\n";
			}

			if(logFlag) {
				this.repo.writeToFile(filename);
			}
		}

		public void fullStep() {
			while(true){
				List<PrgState> prgList = removeCompletedPrg(repo.getPrgList());
				if(prgList.Count == 0) return;
				else oneStepForAllPrg(prgList);
			}
		}

		public bool allCompleted () {
			foreach (PrgState p in this.getPrgStates()) {
				if (p.NotCompleted()) {
					return false;
				}
			}
			return true;
		}

		public void repoSer() {
			repo.serialize ();
		}

		public void repoDeser() {
			repo.deserialize ();
		}
	}
}

