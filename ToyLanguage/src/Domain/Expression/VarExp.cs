using System;

namespace ToyLanguage
{
	public class VarExp: Exp
	{
		private String id;

		public VarExp (String newid)
		{
			this.id = newid;
		}

		public int eval(IDictionary tbl) {
			if (tbl.containsKey(id)) return (int) tbl[id];
			return 0;
		}

		override public String ToString() {
			return id;
		}

		public String getId() {
			return id;
		}
	}
}

