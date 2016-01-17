using System;

namespace ToyLanguage
{
	public partial class TextDialogBox : Gtk.Dialog
	{
		private ProgramInsertWindow source;

		public string MainLbl {
			set {
				MainLabel.Text = value;
			}
		}

		public ProgramInsertWindow Source {
			get {
				return source;
			}
			set {
				source = value;
			}
		}

		public TextDialogBox ()
		{
			this.Build ();
		}

		protected void okBtnClicked (object sender, EventArgs e)
		{
			if (source != null) {
				source.CrtText = TextEntry.Text;
			}
			this.Hide ();
		}
	}
}

