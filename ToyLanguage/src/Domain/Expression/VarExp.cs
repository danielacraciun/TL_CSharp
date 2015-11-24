using System;

namespace ToyLanguage
{
	[Serializable] public class VarExp: Exp
	{
		private String id;

		public VarExp (String newid)
		{
			this.id = newid;
		}

		public int eval(IDictionary<String, int> tbl, IHeap<int> h) {
			if (tbl.containsKey(id)) return (int) tbl[id];
			throw new UninitializedVariableException ();
		}

		public override String ToString() {
			return id;
		}

		public String getId() {
			return id;
		}
	}
}

