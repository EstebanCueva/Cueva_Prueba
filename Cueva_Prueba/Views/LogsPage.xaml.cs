using Cueva_Prueba.ViewModels;
using Microsoft.Maui.Storage;
using System.Diagnostics;

namespace Cueva_Prueba.Views;

public partial class LogsPage : ContentPage
{
    public LogsPage()
    {
        InitializeComponent();
        BindingContext = new LogsViewModel();
    }

    private void AbrirCarpetaLogs_Clicked(object sender, EventArgs e)
    {
        // Abre la carpeta de logs en el explorador de archivos
        //Este código usa FileSystem.Current.AppDataDirectory de .NET MAUI para obtener una ruta segura donde almacenar datos de la app.
        //https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/storage/file-system-helpers?view=net-maui-9.0&utm_source=chatgpt.com&tabs=windows

#if WINDOWS
        try
        {
            string path = FileSystem.AppDataDirectory;
            Process.Start("explorer.exe", path);
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", $"No se pudo abrir la carpeta: {ex.Message}", "OK");
        }
#endif
    }
}
