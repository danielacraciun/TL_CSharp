using System;
using System.Linq;

namespace ToyLanguage
{
	public interface IList: System.Collections.IEnumerable
	{
		void Add(Object o);
		bool Contains (Object o);
		int Length { get; }
		Object this [ int index ] { get; set; }
	}
}

