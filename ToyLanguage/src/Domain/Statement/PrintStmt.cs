﻿using System;

namespace ToyLanguage
{
	[Serializable] public class PrintStmt: IStmt
	{
		private Exp exp;

		public PrintStmt (Exp exp)
		{
			this.exp = exp;
		}

		public Exp getExp() {
			return exp;
		}

		public override String ToString() {
			return "print(" + exp.ToString() + ")";
		}

		public PrgState execute(PrgState state) {
			state.getOut().Add(exp.eval(state.getSymTable(), state.getHeap()));
			return state;
		}
	}
}

