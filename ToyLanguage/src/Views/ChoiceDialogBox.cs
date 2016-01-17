using System;

namespace ToyLanguage
{
	public partial class ChoiceDialogBox : Gtk.Dialog
	{
		private String[] choices;
		private ProgramInsertWindow source;
		int selectedItem;

		public string[] Choices {
			get {
				return choices;
			}
			set {
				choices = value;
				foreach (String s in choices) {
					ComboBox.AppendText (s);
				}
			}
		}
			
		public string MainLabel {
			set {
				DialogLabel.Text = value;
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

		public int SelectedItem {
			get {
				return selectedItem;
			}
			set {
				selectedItem = value;
			}
		}

		public ChoiceDialogBox ()
		{
			this.Build ();
		}

		protected void okBtnClicked (object sender, EventArgs e)
		{
			source.CrtChoice = selectedItem;
			this.Hide ();
		}

		protected void ComboChangedValue (object sender, EventArgs e)
		{
			selectedItem = ComboBox.Active;
		}
	}
}

