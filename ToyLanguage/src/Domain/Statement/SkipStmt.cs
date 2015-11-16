using System;

namespace ToyLanguage
{
	[Serializable] public class SkipStmt: IStmt{
		
		public override String ToString() {
			return "skip";
		}
	}
}

