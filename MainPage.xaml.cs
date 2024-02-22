using Note_App.ViewModels;
namespace Note_App
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            container.Content = new Views.NoteView(new NoteViewModel());
        }
    }

}
