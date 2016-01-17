using System;

namespace ToyLanguage
{
	public partial class DeserializeWindow : Gtk.Window
	{
		private MyController ctrl;

		public DeserializeWindow (MyController ctrl) :
			base (Gtk.WindowType.Toplevel)
		{
			this.ctrl = ctrl;
			this.Build ();
		}

		protected void ShowBtnClicked (object sender, EventArgs e)
		{
			ctrl.repoDeser ();
			DesText.Buffer.Text = ctrl.getPrgStates ()[0].ToString ();
		}
	}
}

