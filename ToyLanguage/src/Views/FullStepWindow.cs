using System;

namespace ToyLanguage
{
	public partial class FullStepWindow : Gtk.Window
	{
		private MyController ctrl;

		public FullStepWindow (MyController ctrl) :
			base (Gtk.WindowType.Toplevel)
		{
			this.ctrl = ctrl;
			this.Build ();
		}

		protected void FullStepClicked (object sender, EventArgs e)
		{
			if (ctrl.getPrgStates ().Count > 0) {
				ctrl.fullStep ();
				FullStepText.Buffer.Text = ctrl.ControllerOutput;
				ShowBtn.Sensitive = false;
			} else {
				ShowBtn.Sensitive = false;
			}
		}
	}
}

