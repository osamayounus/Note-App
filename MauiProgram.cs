using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Note_App.ViewModels;
using Note_App.Views;
using Note_App.Data;

namespace Note_App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            // Create Database
            DBContext dbContext = new DBContext();
            dbContext.Database.EnsureCreated();

            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).UseMauiCommunityToolkit();
            //Singleton
            builder.Services.AddSingleton<NoteView>();
            builder.Services.AddSingleton<NoteViewModel>();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}