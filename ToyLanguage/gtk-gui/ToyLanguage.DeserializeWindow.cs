
// This file has been generated by the GUI designer. Do not modify.
namespace ToyLanguage
{
	public partial class DeserializeWindow
	{
		private global::Gtk.VBox vbox3;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		
		private global::Gtk.TextView DesText;
		
		private global::Gtk.Button showBtn;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget ToyLanguage.DeserializeWindow
			this.Name = "ToyLanguage.DeserializeWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("DeserializeWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child ToyLanguage.DeserializeWindow.Gtk.Container+ContainerChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.DesText = new global::Gtk.TextView ();
			this.DesText.CanFocus = true;
			this.DesText.Name = "DesText";
			this.DesText.Editable = false;
			this.DesText.WrapMode = ((global::Gtk.WrapMode)(2));
			this.GtkScrolledWindow.Add (this.DesText);
			this.vbox3.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.GtkScrolledWindow]));
			w2.Position = 0;
			// Container child vbox3.Gtk.Box+BoxChild
			this.showBtn = new global::Gtk.Button ();
			this.showBtn.CanFocus = true;
			this.showBtn.Name = "showBtn";
			this.showBtn.UseUnderline = true;
			this.showBtn.Label = global::Mono.Unix.Catalog.GetString ("Deserialize");
			this.vbox3.Add (this.showBtn);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.showBtn]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			this.Add (this.vbox3);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 262;
			this.Show ();
			this.showBtn.Clicked += new global::System.EventHandler (this.ShowBtnClicked);
		}
	}
}