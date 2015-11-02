using System;
using System.Collections;

namespace ToyLanguage
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			IStack stk = new ArrayStack ();
			IDictionary d = new ArrayDictionary ();
			IList l = new ArrayList ();

			// The first example
			IStmt prg1 = new CmpStmt (new AssignStmt ("a", new ConstExp (0)), 
						 new AssignStmt ("b", new ArithmExp(new VarExp("a"), 
															new ConstExp(2), '*')));
			IStmt prg2 = new CmpStmt (new AssignStmt ("c", 
						 new ArithmExp(new VarExp("a"), new ConstExp(2), '+')), 
						 new IfStmt (new VarExp("a"), 
						 new PrintStmt(new ArithmExp(new VarExp("b"), new VarExp("c"), '+')), 
						 new PrintStmt(new ArithmExp(new VarExp("b"), new VarExp("c"), '-')))
						 );

			// The second example
			IStmt prg3 = new CmpStmt (new AssignStmt ("x", new ConstExp (8)), 
									  new AssignStmt ("y", new ConstExp (12)));
			
			IStmt prg4 = new CmpStmt (new AssignStmt ("z", 
						 new ArithmExp(new ArithmExp(new VarExp("x"),new VarExp("y"), '+'), 
						 new ArithmExp(new VarExp("x"), new VarExp("y"), '-'), '*')), 
						 new PrintStmt(new VarExp("z")));

			// IStmt fprg = new CmpStmt (prg1, prg2);
			IStmt sprg = new CmpStmt (prg3, prg4);

			stk.Push (sprg);
			PrgState ps = new PrgState (stk, d, l);

			IRepository repo = new MyRepository(new[] {ps});
			MyController ctrl = new MyController(repo);

			ctrl.fullStep ();

		}
	}
}
