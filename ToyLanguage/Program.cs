using System;
using Gtk;
using System.Collections.Generic;

namespace ToyLanguage
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();

			IRepository repo = new MyRepository ();
			MyController ctrl = new MyController (repo);
			win.Ctrl = ctrl;

			win.Show ();
			Application.Run ();
		}
	}
}
