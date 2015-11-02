using System;
using System.Linq;

namespace ToyLanguage
{
	public interface IStack
	{
		Boolean isEmpty();
		void Push(Object element);
		Object Pop();
		Object Top();
	}
}

