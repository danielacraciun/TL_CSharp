using System;
using Gtk;
using System.Collections.Generic;

namespace ToyLanguage
{
	public partial class MainWindow: Gtk.Window
	{
		private MyController ctrl;

		public MyController Ctrl {
			set {
				ctrl = value;
			}
		}

		public MainWindow () : base (Gtk.WindowType.Toplevel)
		{
			Build ();
		}

		protected void OnDeleteEvent (object sender, DeleteEventArgs a) {
			Application.Quit ();
			a.RetVal = true;
		}

		protected void LogCheckTouched (object sender, EventArgs e)
		{
			if (LogCheck.Active) {
				LogCheck.Label = "Writing to file";
				ctrl.LogFlag = true;
			} else {
				LogCheck.Label = "Not writing to file";
				ctrl.LogFlag = false;
			}
		}

		protected void DeserializeBtnClick (object sender, EventArgs e)
		{
			FullStepBtn.Sensitive = true;
			OneStep.Sensitive = true;
			DeserializeWindow win = new DeserializeWindow (ctrl);
			win.Show ();
		}

		protected void SerializeBtnClicked (object sender, EventArgs e)
		{
			if (ctrl.getPrgStates ().Count > 0) {
				ctrl.repoSer ();	
			}
		}

		protected void FullBtnClicked (object sender, EventArgs e)
		{
			if (ctrl.allCompleted()) {
				FullStepBtn.Sensitive = false;
			} else {
				FullStepWindow win = new FullStepWindow (ctrl);
				win.Show ();
			}
		}

		protected void OneBtnClicked (object sender, EventArgs e)
		{
			if (ctrl.allCompleted ()) {
				OneStep.Sensitive = false;
			} else {
				OneStepWindow win = new OneStepWindow (ctrl);
				win.Show ();
			}
		}

		protected void InsertBtnClicked (object sender, EventArgs e)
		{
			ProgramInsertWindow win = new ProgramInsertWindow (ctrl);
			win.Show ();
		}
	}
}