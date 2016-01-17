using System;
using System.Collections.Generic;

namespace ToyLanguage
{
	[Serializable] public class ReadExp: Exp {

		public int eval(IDictionary<String, int> tbl, IHeap<int> h) {
			return Convert.ToInt32(Console.ReadLine());
		}

		public override String ToString() {
			return "read()";
		}
	}
}

