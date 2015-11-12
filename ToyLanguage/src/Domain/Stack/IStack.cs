using System;
using System.Linq;

namespace ToyLanguage
{
	public interface IStack<T> {
		int Count { get; }
		T Pop();
		T Peek();
		void Push (T obj);
	}
}

