using System;
using System.Collections.Generic;

namespace ToyLanguage
{
	public class MyConsole {
		private MyController ctrl;
		private Boolean printFlag;
		private Boolean logFlag;
		private String filename;

		public MyConsole(MyController ctrl) {
			this.ctrl = ctrl;
			this.printFlag = true;
			this.logFlag = true;
			this.filename = "default.txt";
		}

		private void mainMenu () {
			Console.WriteLine("1. Input program");
			Console.WriteLine("2. One Step");
			Console.WriteLine("3. All Step");
			Console.WriteLine("4. Set print and log flags");
			Console.WriteLine("5. Get initial program state");
			Console.WriteLine("Exit by pressing 0.");

				Console.WriteLine("Option: ");
				int opt = Convert.ToInt32(Console.ReadLine());
					switch (opt) {
					case 1:
						addProgram ();
						break;
					case 2:
						oneStep ();
						break;
					case 3:
						fullStep ();
						break;
					case 4:
						setFlag ();
						break;
					case 5:
						getInitPrg ();
						break;
					case 0:
						Console.WriteLine ("Goodbye.");
						return;
						break;
					}
				mainMenu ();
		}

		public void getInitPrg () {
			Console.WriteLine (ctrl.repoDeser());
		}

		public void run () {
			mainMenu ();
		}

		private void setFlag(){
			Console.WriteLine("1. Change print flag\n2. Change log flag\n0 to return. ");
			Console.WriteLine("Option: ");
			int opt = Convert.ToInt32(Console.ReadLine());
			switch (opt) {
			case 1:
				this.printFlag = !this.printFlag;
				Console.WriteLine("Flag changed. It is now " + this.printFlag.ToString() + ".");
				break;
			case 2:
				this.logFlag = !this.logFlag;
				Console.WriteLine ("Flag changed. It is now " + this.logFlag.ToString () + ".");
				if (logFlag) {
					Console.WriteLine ("File to print log to:");
					this.filename = Console.ReadLine ();
				}
				break;
			case 0:
				mainMenu ();
				break;
			}
		}

		private void fullStep(){
			try {
				ctrl.fullStep(printFlag, logFlag, this.filename);
				mainMenu();
			} catch (ControllerException) {
				Console.WriteLine("Step evaluation error.");
			} catch (RepositoryException) {
				Console.WriteLine("Program state error.");
			} catch (DivisionByZeroException) {
				Console.WriteLine("Tried to divide by 0.");
			} catch (ConsoleException) {
				Console.WriteLine ("Wrong option. Try again.");
			}
		}

		private void oneStep() {
			try {
				ctrl.oneStepEval(printFlag, logFlag, this.filename);
				mainMenu();
			} catch (ControllerException) {
				Console.WriteLine("Step evaluation error.");
			} catch (RepositoryException) {
				Console.WriteLine("Program state error.");
			} catch (DivisionByZeroException) {
				Console.WriteLine("Tried to divide by 0.");
			} catch (ConsoleException) {
				Console.WriteLine("Wrong option. Try again.");
			}
		}

		private void addProgram(){
			IStmt prgStmt = addNewStmt();
			IStack<IStmt> exeStk = new ArrayStack<IStmt>();
			IDictionary<String, int> tbl = new ArrayDictionary<String, int>();
			IList<int> outl = new ArrayList<int>();
			exeStk.Push(prgStmt);

			PrgState crtPrg = new PrgState(exeStk, tbl, outl);
			ctrl.addPrgState(crtPrg);
			ctrl.repoSer ();

			try {
				mainMenu();
			} catch (ControllerException) {
				Console.WriteLine("Step evaluation error.");
			} catch (RepositoryException) {
				Console.WriteLine("Program state error.");
			} catch (ConsoleException) {
				Console.WriteLine("Wrong option. Try again.");
			}
		}

		private IStmt addNewStmt() {
			Console.WriteLine("Choose a type of statement:");
			Console.WriteLine("1. Compound statement");
			Console.WriteLine("2. Assignment statement");
			Console.WriteLine("3. If/then/else statement");
			Console.WriteLine("4. Print statement");
			Console.WriteLine("5. While statement");
			Console.WriteLine("6. Skip statement");
			Console.WriteLine("7. If/then statement");
			Console.WriteLine("8. Switch statement");


			int opt = Convert.ToInt32(Console.ReadLine());

			IStmt st;
			switch (opt) {
			case 1:
				Console.WriteLine("First statement:");
				IStmt st1 = addNewStmt();
				Console.WriteLine("Second statement:");
				IStmt st2 = addNewStmt();
				st = new CmpStmt(st1, st2);
				break;
			case 2:
				Console.WriteLine("Variable name:");
				String varName = Console.ReadLine();
				Console.WriteLine("Right side expression:");
				Exp exp = addNewExp();
				st = new AssignStmt(varName, exp);
				break;
			case 3:
				Console.WriteLine("Expression to evaluate:");
				Exp expr = addNewExp();
				Console.WriteLine("Then Statement:");
				IStmt then = addNewStmt();
				Console.WriteLine("Else Statement:");
				IStmt el = addNewStmt();
				st = new IfStmt(expr, then, el);
				break;
			case 4:
				Exp e = addNewExp();
				st = new PrintStmt(e);
				break;
			case 5:
				Console.WriteLine("Expression to evaluate:");
				Exp expression = addNewExp();
				Console.WriteLine("Statement:");
				IStmt statement = addNewStmt();
				st = new WhileStmt(expression, statement);
				break;
			case 6:
				st = new SkipStmt();
				break;
			case 7:
				Console.WriteLine("Expression to evaluate:");
				Exp exp1 = addNewExp();
				Console.WriteLine("Then Statement:");
				IStmt then1 = addNewStmt();
				st = new IfThenStmt(exp1, then1);
				break;
			case 8:
				Console.WriteLine("Switch operator:");
				String variableName = Console.ReadLine();
				expr = new VarExp(variableName);

				Console.WriteLine("Case 1 expression:");
				Exp expCase1 = addNewExp();
				Console.WriteLine("Case 1 Statement:");
				IStmt case1 = addNewStmt();

				Console.WriteLine("Case 2 expression:");
				Exp expCase2 = addNewExp();
				Console.WriteLine("Case 2 Statement:");
				IStmt case2 = addNewStmt();

				Console.WriteLine("Default case Statement:");
				IStmt caseDefault = addNewStmt();

				st = new SwitchStmt(expr, expCase1, case1, expCase2, case2, caseDefault);
				break;
			default:
				Console.WriteLine ("Please try one of the options above.");
				st = addNewStmt ();
				break;
			}

			return st;
		}

		private Exp addNewExp() {
			Console.WriteLine("Choose a type of expression:");
			Console.WriteLine("1. Arithmetical expression");
			Console.WriteLine("2. Constant expression");
			Console.WriteLine("3. Variable expression");
			Console.WriteLine("4. Comparison expression");
			Console.WriteLine("5. Logical expression");
			Console.WriteLine("6. Read expression");

			int opt = Convert.ToInt32(Console.ReadLine());

			Exp expr;
			switch (opt) {
			case 1:
				Console.WriteLine ("Choose operation: +, -, *, /");
				String op = Console.ReadLine ();
				List<string> optionList = new List<string> 
										{ "+", "-", "*", "/"};
				if (optionList.Contains(op)) {
					Console.WriteLine("Left hand side:");
					Exp left = addNewExp();
					Console.WriteLine("Right hand side:");
					Exp right = addNewExp();
					expr = new ArithmExp(left, right, op[0]);
				} else {
					Console.WriteLine("Operand MUST be +, -, *, /. Try again");
					expr = addNewExp();
				}
				break;
			case 2:
				Console.WriteLine("Give a number:");
				int no = Convert.ToInt32(Console.ReadLine());
				expr = new ConstExp(no);
				break;
			case 3:
				Console.WriteLine("Variable name:");
				String varName = Console.ReadLine ();
				expr = new VarExp(varName);
				break;
			case 4:
				Console.WriteLine("Choose comp. operand: <, <=, ==, !=, >=, >");
				String op1 = Console.ReadLine ();
				List<string> optsList = new List<string> 
				{"<", "<=", "==", "!=", ">=", ">"};
				if (optsList.Contains(op1)) {
					Console.WriteLine("Left hand side:");
					Exp left = addNewExp();
					Console.WriteLine("Right hand side:");
					Exp right = addNewExp();
					expr = new CompExp(left, right, op1);
				} else {
					Console.WriteLine("Operand MUST be a comp. operator. Try again");
					expr = addNewExp();
				}
				break;
			case 5:
				Console.WriteLine("Choose logical operand: && (and), ||(or), !(not)");
				String op2 = Console.ReadLine ();
				List<string> optionsList = new List<string> 
				{"&&", "||"};
				if (optionsList.Contains(op2)) {
					Console.WriteLine("Left hand side:");
					Exp left = addNewExp();
					Console.WriteLine("Right hand side:");
					Exp right = addNewExp();
					expr = new LogicExp(left, right, op2);
				} else if(op2 == "!") {
					Console.WriteLine("Expression:");
					Exp singleExp = addNewExp();
					expr = new LogicExp(singleExp, op2);
				} else {
					Console.WriteLine("Operand MUST be a logical operator. Try again");
					expr = addNewExp();
				}
				break;
			case 6:
				expr = new ReadExp();
				break;
			default:
				Console.WriteLine("Please try one of the options above.");
				expr = addNewExp();
				break;
			}
			return expr;
		}
	}
}

