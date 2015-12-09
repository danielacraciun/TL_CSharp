using System;
using System.Collections;

namespace ToyLanguage
{
	public interface IHeap<T>
	{
		int Add (T e);
		void Update(int index, T value);
		T this [int index] { get; set; }
	}
}

