
// This file has been generated by the GUI designer. Do not modify.
namespace ToyLanguage
{
	public partial class FullStepWindow
	{
		private global::Gtk.VBox vbox4;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		
		private global::Gtk.TextView FullStepText;
		
		private global::Gtk.Button ShowBtn;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget ToyLanguage.FullStepWindow
			this.Name = "ToyLanguage.FullStepWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("FullStepWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child ToyLanguage.FullStepWindow.Gtk.Container+ContainerChild
			this.vbox4 = new global::Gtk.VBox ();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.FullStepText = new global::Gtk.TextView ();
			this.FullStepText.CanFocus = true;
			this.FullStepText.Name = "FullStepText";
			this.FullStepText.WrapMode = ((global::Gtk.WrapMode)(2));
			this.GtkScrolledWindow.Add (this.FullStepText);
			this.vbox4.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.GtkScrolledWindow]));
			w2.Position = 0;
			// Container child vbox4.Gtk.Box+BoxChild
			this.ShowBtn = new global::Gtk.Button ();
			this.ShowBtn.CanFocus = true;
			this.ShowBtn.Name = "ShowBtn";
			this.ShowBtn.UseUnderline = true;
			this.ShowBtn.Label = global::Mono.Unix.Catalog.GetString ("Full Step");
			this.vbox4.Add (this.ShowBtn);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.ShowBtn]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			this.Add (this.vbox4);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 300;
			this.Show ();
			this.ShowBtn.Clicked += new global::System.EventHandler (this.FullStepClicked);
		}
	}
}
