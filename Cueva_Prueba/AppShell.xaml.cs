    using Cueva_Prueba.Services;
    using Cueva_Prueba.Views;

namespace Cueva_Prueba
{
    public partial class AppShell : Shell
    {
        private static RecetaDatabase database;

        public AppShell()
        {
            InitializeComponent();

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "recetas.db3");
            database = new RecetaDatabase(dbPath);

            Items.Clear();
            Items.Add(new ShellContent
            {
                Title = "Formulario",
                Content = new FormularioPage(database)
            });
            Items.Add(new ShellContent
            {
                Title = "Recetas",
                Content = new ListaPage(database)
            });
            Items.Add(new ShellContent
            {
                Title = "Logs",
                Content = new LogsPage()
            });
        }
    }
}