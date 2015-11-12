using System;

namespace ToyLanguage
{
	public class DecStmt: IStmt
	{
		String id;

		public DecStmt (String id)
		{
			this.id = id;
		}

		public String getId() {
			return id;
		}

		public override String ToString() {
			return "dec(" + id + ")";
		}
			
	}
}

