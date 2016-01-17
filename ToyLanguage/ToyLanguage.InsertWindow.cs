using System;

namespace ToyLanguage
{
	public partial class ToyLanguage : Gtk.Window
	{
		public ToyLanguage () :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
	}
}

