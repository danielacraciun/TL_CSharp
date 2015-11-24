using System;

namespace ToyLanguage
{
	public class ReadHeapExp: Exp
	{
		private String id;

		public ReadHeapExp(String id) {
			this.id = id;
		}

		public int eval(IDictionary<String, int> tbl, IHeap<int> heap) {
			int address = tbl[id];
			return heap[address];
		}

		public String getId() {
			return id;
		}

		public override String ToString() {
			return "readHeap( " + id + ")";
		}
	}
}

