using System;
using System.Collections;

namespace ToyLanguage
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			IRepository repo = new MyRepository();
			MyController ctrl = new MyController(repo);
			MyConsole console = new MyConsole(ctrl);
			console.run();

//			IStack<IStmt> stk = new ArrayStack<IStmt> ();
//			IDictionary<String ,int> d = new ArrayDictionary<String, int> ();
//			IList<int> l = new ArrayList<int> ();
//
			// The first example
//			IStmt prg1 = new CmpStmt (new AssignStmt ("a", new ConstExp (0)), 
//						 new AssignStmt ("b", new ArithmExp(new VarExp("a"), 
//															new ConstExp(2), '*')));
//			IStmt prg2 = new CmpStmt (new AssignStmt ("c", 
//						 new ArithmExp(new VarExp("a"), new ConstExp(2), '+')), 
//						 new IfStmt (new VarExp("a"), 
//						 new PrintStmt(new ArithmExp(new VarExp("b"), new VarExp("c"), '+')), 
//						 new PrintStmt(new ArithmExp(new VarExp("b"), new VarExp("c"), '-')))
//						 );

			// The second example
//			IStmt prg3 = new CmpStmt (new AssignStmt ("x", new ConstExp (8)), 
//									  new AssignStmt ("y", new ConstExp (12)));
//			
//			IStmt prg4 = new CmpStmt (new AssignStmt ("z", 
//						 new ArithmExp(new ArithmExp(new VarExp("x"),new VarExp("y"), '+'), 
//						 new ArithmExp(new VarExp("x"), new VarExp("y"), '-'), '*')), 
//						 new PrintStmt(new VarExp("z")));
//			//IStmt fprg = new CmpStmt (prg1, prg2);
//			IStmt sprg = new CmpStmt (prg3, prg4);

//			IStmt st1 = new AssignStmt("a", new ConstExp(2));
//			IStmt st2 = new AssignStmt("c", new ConstExp(5));
//			Exp ex1 = new ArithmExp(new VarExp("a"), new ConstExp(12), '-');
//			Exp ex2 = new ArithmExp(new VarExp("c"), new ConstExp(3), '*');
//			IStmt st3 = new AssignStmt("b", new ArithmExp(new VarExp("c"), new ConstExp(3), '+'));
//			IStmt st4 = new AssignStmt("b", new ConstExp(10));
//
//			IStmt st5 = new IfStmt(new CompExp(ex1, ex2, "<"), st3, st4);
//
//			IStmt st6 = new PrintStmt(new VarExp("b"));
//
//			IStmt testprg = new CmpStmt (new CmpStmt(st1, st2), new CmpStmt(st5, st6));
//			IStmt prg1 = new CmpStmt(new AssignStmt("a", new ConstExp(0)),
//				new IfThenStmt(new LogicExp(new VarExp("a"), "!"), new PrintStmt(new VarExp("a"))));
//			IStmt prg2 = new CmpStmt (new AssignStmt ("a", new ConstExp(2)),
//				new WhileStmt(new LogicExp(new VarExp("a"), new ConstExp(2), "&&"),
//					new AssignStmt("a", new ArithmExp(new VarExp("a"), new ConstExp(1), '-'))));
//			IStmt swprg = new CmpStmt (new AssignStmt ("a", new ConstExp(1)),
//				new SwitchStmt(new VarExp("a"), new ConstExp(1), new PrintStmt(new ReadExp()),
//					new ConstExp(2), new PrintStmt(new ArithmExp(new VarExp("a"), new ConstExp(2), '/')),
//					new PrintStmt(new ConstExp(10))));
//			
//			stk.Push (swprg);
//			PrgState ps = new PrgState (stk, d, l);
//
//			IRepository repo = new MyRepository(new[] {ps});
//			MyController ctrl = new MyController(repo);
//			try {
//				ctrl.fullStep ();
//			} catch (UndefinedKeyException) {
//				Console.WriteLine("Cannot find variable.");
//			} catch (UninitializedVariableException) {
//				Console.WriteLine("A variable is not initialized.");
//			} catch (DivisionByZeroException) {
//				Console.WriteLine("Division by zero.");
//			} catch (RepositoryException) {
//				Console.WriteLine("Program state error.");
//			} catch (ControllerException) {
//				Console.WriteLine ("Empty state or error in stepping over program state.");
//			}
		}
	}
}
