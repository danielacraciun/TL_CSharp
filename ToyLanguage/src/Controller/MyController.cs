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

		public void oneStepEval(Boolean printFlag) {
			try {
			PrgState state = repo.getCrtPrg();

			IStack<IStmt> stk = state.getExeStack();
			IDictionary<String, int> symtbl = state.getSymTable();
			IList<int> l = state.getOut();

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

			} else if (crtStmt is WhileStmt) {

				WhileStmt stmt5 = (WhileStmt) crtStmt;
				if (stmt5.getExp().eval(symtbl) != 0) {
					stk.Push(stmt5);
					stk.Push(stmt5.getStmt());
				}

			} else if (crtStmt is IfThenStmt) {

				IfThenStmt stmt6 = (IfThenStmt) crtStmt;
				stk.Push(new IfStmt(stmt6.getExp(), stmt6.getThenStmt(), new SkipStmt()));

			} else if (crtStmt is SwitchStmt) {
				SwitchStmt stmt7 = (SwitchStmt) crtStmt;
				Exp difSwitch = new ArithmExp(stmt7.getOp(), stmt7.getOpCase2(), '-');
				Exp difSwitch2 = new ArithmExp(stmt7.getOp(), stmt7.getOpCase1(), '-');
				IStmt ifSwitch = new IfStmt(difSwitch2, stmt7.getDefaultCase(), stmt7.getCase1());
				IStmt switchStmt = new IfStmt(difSwitch, ifSwitch, stmt7.getCase2());
				stk.Push(switchStmt);
			}
			if(printFlag) {
				Console.WriteLine(stk);
				Console.WriteLine(symtbl);
				Console.WriteLine(l);
			}
			} catch (RepositoryException) {
				throw new ControllerException ();
			}
		}

		public void fullStep(Boolean printFlag) {
			try {
			PrgState state = repo.getCrtPrg();
			IStack<IStmt> stk = state.getExeStack ();
			while (stk.Count != 0) {
				oneStepEval (printFlag);
			}
			} catch (RepositoryException) {
				throw new ControllerException ();
			}

		}
	}
}

