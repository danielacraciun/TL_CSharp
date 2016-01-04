using System;
using System.Collections;

namespace ToyLanguage
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			IRepository repo = new MyRepository();
			MyController ctrl = new MyController(repo);
			MyConsole console = new MyConsole(ctrl);
			console.run();
		}
	}
}
