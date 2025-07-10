using Cueva_Prueba.ViewModels;
using Cueva_Prueba.Services;
namespace Cueva_Prueba.Views;

public partial class FormularioPage : ContentPage
{
    public FormularioPage(RecetaDatabase database)
    {
        InitializeComponent();
        BindingContext = new RecetaFormViewModel(database);
    }
}