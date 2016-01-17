using System;

namespace ToyLanguage
{
	public partial class ProgramInsertWindow : Gtk.Window
	{
		private MyController ctrl;
		private int crtChoice;
		private String crtText;

		public ProgramInsertWindow (MyController ctrl) :
		base (Gtk.WindowType.Toplevel)
		{
			this.ctrl = ctrl;
			this.Build ();
		}

		public int CrtChoice {
			get {
				return crtChoice;
			}
			set {
				crtChoice = value;
			}
		}

		public String CrtText {
			get {
				return crtText;
			}
			set {
				crtText = value;
			}
		}

		private String newString(String content) {
			TextDialogBox textDialog = new TextDialogBox();
			textDialog.MainLbl = content;
			textDialog.Source = this;
			textDialog.Run ();
			return CrtText;
		}

		private Exp newExpression(String content) {
			String[] expMenu = {"Arithmetic Expression", 
				"Constant Expression", "Variable Expression", 
				"Binary Logical Expression", "Not Expression", 
				"Relational Expression", "Read value", "Read Heap"};
			ChoiceDialogBox expDialog = new ChoiceDialogBox ();
			expDialog.MainLabel = content;
			expDialog.Source = this;
			expDialog.Choices = expMenu;
			expDialog.Run ();
			int selected = crtChoice;
			switch (selected) {
			case 0:
				String op = newString("Enter operator (+, -, *): ");
				Exp left = newExpression("Left Expression: ");
				Exp right = newExpression("Right Expression: ");
				return new ArithmExp(left, right, op[0]);
			case 1:
				int value = Convert.ToInt32 (newString ("Enter constant value: "));
				return new ConstExp(value);
			case 2:
				String name = newString("Name: ");
				return new VarExp(name);
			case 3:
				String logicOp = newString ("Enter operator (&&, ||): ");
				Exp lleft = newExpression ("Left Expression: ");
				Exp lright = newExpression("Right Expression: ");
				return new LogicExp(lleft, lright,logicOp);
			case 4:
				Exp notExp = newExpression("Expression: ");
				return new LogicExp(notExp, "!");
			case 5:
				String compOp = newString("Enter operator (<, <=, !=, ==, >=, >): ");
				Exp cleft = newExpression("Left Expression: ");
				Exp cright = newExpression("Right Expression: ");
				return new CompExp(cleft, cright, compOp);
			case 6:
				return new ReadExp();
			case 7:
				String rhname = newString("Name: ");
				return new ReadHeapExp(rhname);
			default:
				break;
			}
			return null;
		}

		private IStmt newStatement(String content) {
			String[] stmtMenu = {"Compound Statement", 
				"Assign Statement", "Print Statement",
				"If Statement", "While Statement", 
				"IfThen Statement", "Switch Statement", "Skip Statement",
				"New Statement", "Write Heap", "Fork"
			};
			ChoiceDialogBox stmtDialog = new ChoiceDialogBox();
			stmtDialog.Source = this;
			stmtDialog.MainLabel = content;
			stmtDialog.Choices = stmtMenu;
			stmtDialog.Run ();
			int selected = CrtChoice;
			switch (selected) {
			case 0:
				IStmt first = newStatement("First Statement:");
				IStmt second = newStatement("Second Statement:");
				return new CmpStmt(first, second);

			case 1:
				String varName = newString("Name: ");
				Exp varValue = newExpression("Assigned value: ");
				return new AssignStmt(varName, varValue);

			case 2:
				Exp expression = newExpression("Expression: ");
				return new PrintStmt(expression);

			case 3:
				Exp condition = newExpression("Condition: ");
				IStmt thenStatement = newStatement("Then branch: ");
				IStmt elseStatement = newStatement("Else branch: ");
				return new IfStmt(condition, thenStatement, elseStatement);

			case 4:
				Exp wcondition = newExpression("Condition: ");
				IStmt body = newStatement("Body: ");
				return new WhileStmt(wcondition, body);
			case 5:
				Exp ifcondition = newExpression("Condition: ");
				IStmt ifthenStatement = newStatement("Then branch: ");
				return new IfThenStmt(ifcondition, ifthenStatement);
			case 6:
				Exp scondition = newExpression("Condition: ");
				Exp case1Expression = newExpression("Case 1 Expression:");
				IStmt case1Statement = newStatement("Case 1 Statement:");
				Exp case2Expression = newExpression("Case 2 Expression:");
				IStmt case2Statement = newStatement("Case 2 Statement:");
				IStmt defaultStatement = newStatement("Default Statement:");
				return new SwitchStmt(scondition, case1Expression, 
					case1Statement, case2Expression, 
					case2Statement, defaultStatement);
			case 7:
				return new SkipStmt();
			case 8:
				String newName = newString("Name: ");
				Exp newExp = newExpression("Expression: ");
				return new NewStmt(newName, newExp);
			case 9:
				String writeHpName = newString("Name: ");
				Exp writeHpExp = newExpression("Expression: ");
				return new WriteHeapStmt(writeHpName, writeHpExp);
			case 10:
				return new ForkStmt(newStatement("Statement: "));	
			default:
				break;
			}
			return null;
		}

		protected void StartInsertClicked (object sender, EventArgs e) {
			IStmt prgStmt = newStatement("Input a program: ");
			IStack<IStmt> exeStk = new ArrayStack<IStmt>();
			IDictionary<String, int> tbl = new ArrayDictionary<String, int>();
			IList<int> outl = new ArrayList<int>();
			IHeap<int> h = new MyHeap<int>();
			exeStk.Push(prgStmt);
			PrgState crtPrg = new PrgState(exeStk, tbl, outl, h);
			ctrl.addPrgState(crtPrg);
			prgText.Buffer.Text = prgStmt.ToString();
			StartBtn.Sensitive = false;
		}
	}
}

