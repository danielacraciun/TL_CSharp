using System;

namespace ToyLanguage
{
	public class MyConsole {
//		private MyController ctrl;
//		private PrgState currentProgram;
//		private Boolean printFlag;
//
//		public MyConsole () {
//		}
//
//		private void oneStep () {
//			try {
//				ctrl.oneStepEval();
//			} catch (UninitializedVariableException) {
//				Console.WriteLine("A variable is not initialized.");
//			} catch (DivisionByZeroException) {
//				Console.WriteLine("Division by zero.");
//			} catch (RepositoryException) {
//				Console.WriteLine("Program state error.");
//			}
//		}
//
//		private void allStep () {
//			try {
//				ctrl.fullStep();
//			} catch (UndefinedKeyException) {
//				Console.WriteLine("Cannot find variable.");
//			} catch (UninitializedVariableException) {
//				Console.WriteLine("A variable is not initialized.");
//			} catch (DivisionByZeroException) {
//				Console.WriteLine("Division by zero.");
//			} catch (RepositoryException) {
//				Console.WriteLine("Program state error.");
//			}
//		}
//
//		private void setPrintFlag () {
//			this.printFlag = !this.printFlag;
//			Console.WriteLine("Flag changed. It is now " + this.printFlag.ToString() + ".");
//			Console.WriteLine("Press Enter to go back.");
//
//			try {
//				mainMenu();
//			} catch (ControllerException e) {
//				Console.WriteLine("Step evaluation error.");
//			} catch (RepositoryException e) {
//				Console.WriteLine("Program state error.");
//			} catch (ConsoleException e) {
//				Console.WriteLine("Wrong option. Try again.");
//			}
//
//		}
//
//		private ArithExp arithmeticalExpression () {
//			print ("Available operands: +, -, *, /");
//			String opperand = readString ("Operand: ");
//			List<String> elements = new List<String> ();
//			elements.Add ("+");
//			elements.Add ("-");
//			elements.Add ("*");
//			elements.Add ("/");
//
//			if (elements.Contains (opperand)) {
//				print ("Left:");
//				Exp left = inputExpression ();
//				print ("Right:");
//				Exp right = inputExpression ();
//				return new ArithExp (left, opperand, right);
//			}
//			print ("invalid operand");
//			return arithmeticalExpression ();
//
//		}
//
//		private ConstExp constantExpression () {
//			int number = readInteger ("Number: ");
//			return new ConstExp (number);
//		}
//
//		private VarExp variableExpression () {
//			String id = readString ("Variable id: ");
//			return new VarExp (id);
//		}
//
//
//		private Exp inputExpression () {
//			print ("1. Arithmetical expression");
//			print ("2. Constant expression");
//			print ("3. Var expression");
//			try {
//				Exp expr;
//				int opt = readInteger ("Option: ");
//				switch (opt) {
//				case 1:
//					expr = arithmeticalExpression ();
//					break;
//				case 2:
//					expr = constantExpression ();
//					break;
//				case 3:
//					expr = variableExpression ();
//					break;
//				default:
//					print ("Invalid option, please try again");
//					expr = inputExpression ();
//					break;
//
//				}
//				return expr;
//			} catch (UnexpectedTypeException) {
//				print ("Invalid option, please try again");
//				return inputExpression ();
//			}
//		}
//
//		private CompStmt compoundStatement () {
//			print ("Left side:");
//			IStmt left = inputStatement ();
//			print ("Right side:");
//			IStmt right = inputStatement ();
//			return new CompStmt (left, right);
//		}
//
//		private AssignStmt assignmentStatement () {
//			String name = readString ("Var name:");
//			print ("Right side:");
//			Exp exp = inputExpression ();
//			return new AssignStmt (name, exp);
//		}
//
//		private IfStmt ifStatement () {
//			print ("Expression:");
//			Exp expression = inputExpression ();
//			print ("Then Statement:");
//			IStmt thenS = inputStatement ();
//			print ("Else Statement:");
//			IStmt elseS = inputStatement ();
//			return new IfStmt (expression, thenS, elseS);
//		}
//
//		private PrintStmt printStatement () {
//			print ("Expression:");
//			Exp expression = inputExpression ();
//			return new PrintStmt (expression);
//		}
//
//		private IStmt inputStatement () {
//			print ("1. Compound statement");
//			print ("2. Assignment statement");
//			print ("3. If statement");
//			print ("4. Print statement");
//			try {
//				int opt = readInteger ("Option: ");
//				IStmt prg;
//				switch (opt) {
//				case 1:
//					prg = compoundStatement ();
//					break;
//				case 2:
//					prg = assignmentStatement ();
//					break;
//				case 3:
//					prg = ifStatement ();
//					break;
//				case 4:
//					prg = printStatement ();
//					break;
//				default:
//					print ("Invalid option, please try again");
//					prg = inputStatement ();
//					break;
//				}
//				return prg;
//			} catch (UnexpectedTypeException) {
//				print ("Invalid option, please try again");
//				return inputStatement ();
//			}
//		}
//
//		private void inputProgram () {
//			IStmt prgStatement = new CompStmt (new AssignStmt ("a", new ArithExp (new ConstExp (2), "-", new ConstExp (2))), new CompStmt (new IfStmt (new VarExp ("a"), new AssignStmt ("v", new ConstExp (2)), new AssignStmt ("v", new ConstExp (3))), new PrintStmt (new VarExp ("v"))));
//			//new CompStmt(new AssignStmt("a", new ArithExp(new ConstExp(2), "-", new ConstExp(2))),new CompStmt(new IfStmt(new VarExp("a"),new AssignStmt("v",new ConstExp(2)), new AssignStmt("v", new ConstExp(3))), new PrintStmt(new VarExp("v"))));
//			currentProgram = new PrgState (new MyLibraryStack<IStmt> (), new MyLibraryDictionary<String, int> (), new MyLibraryList<int> (), prgStatement);
//			PrgState[] programs = { currentProgram };
//			print (currentProgram.printState ());
//			ctrl = new Controller (new MyRepository (programs));
//		}
//
//		private void mainMenu () {
//			print ("1. Input program");
//			print ("2. One Step");
//			print ("3. All Step");
//			print ("4. Set printFlag");
//			try {
//				int opt = readInteger ("Option: ");
//				if (opt != 1 && currentProgram == null) {
//					print ("There is no program, please insert a program");
//				} else {
//					switch (opt) {
//					case 1:
//						inputProgram ();
//						break;
//					case 2:
//						oneStep ();
//						break;
//					case 3:
//						allStep ();
//						break;
//					case 4:
//						setPrintFlag ();
//						break;
//					default:
//						print ("Invalid option, please try again");
//						break;
//					}
//				}
//				firstMenu ();
//			} catch (UnexpectedTypeException) {
//				print ("Invalid option, please insert a number");
//				firstMenu ();
//			} catch (EmptyRepositoryException) {
//				print ("No program added");
//			}
//		}
//
//		public void run () {
//			firstMenu ();
//		}
	}
}

