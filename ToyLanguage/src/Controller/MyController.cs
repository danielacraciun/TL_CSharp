using System;
using System.IO;

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

		public PrgState getCrtPrgState() { return repo.getCrtPrg(); }

		public PrgState oneStepEval(PrgState state, Boolean printFlag, Boolean logFlag, String filename) {
			try {
				if(printFlag) {
					Console.WriteLine(state);
				}

				if(logFlag) {
					this.repo.writeToFile(filename);
				}

				if (state.getExeStack().Count == 0) {
					Console.WriteLine("Program has finished execution.");
				} else {
					IStack<IStmt> stk = state.getExeStack();
					IStmt crtStmt = stk.Pop();
					return crtStmt.execute(state);
				}

			} catch (RepositoryException) {
				throw new ControllerException ();
			} catch (SystemException) {
				throw new ControllerException ();
			}
			return state;
		}

		public void fullStep(PrgState state, Boolean printFlag, Boolean logFlag, String filename) {
			try {
				IStack<IStmt> stk = state.getExeStack ();
				while (stk.Count != 0) {
					oneStepEval (state, printFlag, logFlag, filename);
				}
			} catch (RepositoryException) {
				throw new ControllerException ();
			}
			if(printFlag) {
				Console.WriteLine(state);
			}

			if(logFlag) {
				this.repo.writeToFile(filename);
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

