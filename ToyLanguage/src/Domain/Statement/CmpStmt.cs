﻿using System;

namespace ToyLanguage
{
	public class CmpStmt: IStmt
	{
		
		private IStmt first;
		private IStmt second;

		public CmpStmt (IStmt first, IStmt second)
		{
			this.first = first;
			this.second = second;
		}

		public IStmt getFirst() {
			return first;
		}

		public IStmt getSecond() {
			return second;
		}

		public override String ToString() {
			return "(" + first.ToString() + ";" + second.ToString() + ")";
		}
	}
}
