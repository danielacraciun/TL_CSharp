using System;
using System.Collections.Generic;

namespace ToyLanguage
{
	public class ReadExp: Exp {

		public int eval(IDictionary<String, int> tbl) {
			Console.WriteLine("Input a number: ");
			return Convert.ToInt32(Console.ReadLine());
		}

		public override String ToString() {
			return "read()";
		}
	}
}

