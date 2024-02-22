using Note_App.ViewModels;

namespace Note_App.Views;

public partial class NoteView : ContentView
{
    private NoteViewModel noteView;
    public NoteView(NoteViewModel noteView)
	{
		InitializeComponent();
        BindingContext = noteView;
        this.noteView = noteView;
    }
    private void LVNotes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        // set data
        noteView.SetData();
    }
}