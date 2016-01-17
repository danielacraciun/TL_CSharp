using System;

namespace ToyLanguage
{
	public partial class OneStepWindow : Gtk.Window
	{
		private MyController ctrl;
		public OneStepWindow (MyController ctrl) :
			base (Gtk.WindowType.Toplevel)
		{
			this.ctrl = ctrl;
			this.Build ();
		}

		protected void OneStepClicked (object sender, EventArgs e)
		{
			if (ctrl.getPrgStates ().Count > 0) {
				ctrl.oneStepForAllPrg (ctrl.getPrgStates ());
				String stepAreaOutput = "";
				foreach (PrgState p in ctrl.getPrgStates()) {
					stepAreaOutput += p.ToString (); 
					stepAreaOutput += "\n";
				}
				OneStepText.Buffer.Text = stepAreaOutput;
				OneStepBtn.Sensitive = false;
			} else {
				OneStepBtn.Sensitive = false;
			}
		}
	}
}

