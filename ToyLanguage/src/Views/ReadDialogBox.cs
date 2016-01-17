using System;

namespace ToyLanguage
{
	public partial class ReadDialogBox : Gtk.Dialog
	{
		private ReadExp source;

		public ReadExp Source {
			get {
				return source;
			}
			set {
				source = value;
			}
		}

		public ReadDialogBox ()
		{
			this.Build ();
		}

		protected void okBtnClicked (object sender, EventArgs e)
		{
			if (source != null) {
				source.ReadVal = TextEntry.Text;
			} else 
				this.Hide ();
		}
	}
}

