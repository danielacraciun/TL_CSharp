using System;

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

		public void oneStepEval() {
			PrgState state = repo.getCrtPrg();

			IStack stk = state.getExeStack();
			IDictionary symtbl = state.getSymTable();
			IList l = state.getOut();

			IStmt crtStmt = (IStmt)stk.Pop ();
			if (crtStmt is CmpStmt) {
				
				CmpStmt stmt1 = (CmpStmt) crtStmt;
				stk.Push(stmt1.getSecond());
				stk.Push(stmt1.getFirst());

			} else if (crtStmt is AssignStmt) {
				
				AssignStmt stmt2 = (AssignStmt) crtStmt;
				symtbl.Add(stmt2.getId(), stmt2.getExp().eval(symtbl));

			} else if (crtStmt is IfStmt) {
				
				IfStmt stmt4 = (IfStmt) crtStmt;
				int result = stmt4.getExp().eval(symtbl);
				if (result != 0)
					stk.Push(stmt4.getThenStmt());
				else
					stk.Push(stmt4.getElseStmt());

			} else if (crtStmt is PrintStmt) {

				PrintStmt stmt3 = (PrintStmt) crtStmt;
				l.Add(stmt3.getExp().eval(symtbl));
			}
			Console.WriteLine(stk);
			Console.WriteLine(symtbl);
			Console.WriteLine(l);
		}

		public void fullStep() {
			PrgState state = repo.getCrtPrg();
			IStack stk = state.getExeStack ();
			while (!stk.isEmpty ()) {
				oneStepEval ();
			}

		}
	}
}

