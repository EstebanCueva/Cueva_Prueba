using Cueva_Prueba.ViewModels;
using Cueva_Prueba.Services;


namespace Cueva_Prueba.Views;

public partial class ListaPage : ContentPage
{
    public ListaPage(RecetaDatabase database)
    {
        InitializeComponent();
        BindingContext = new RecetaListViewModel(database);
    }
}