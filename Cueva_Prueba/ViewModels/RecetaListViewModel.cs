using Cueva_Prueba.Logs;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Cueva_Prueba.Models;
using Cueva_Prueba.Services;
namespace Cueva_Prueba.ViewModels
{
    public class RecetaListViewModel : INotifyPropertyChanged
    {
        private RecetaDatabase db;

        public ObservableCollection<Receta> Recetas { get; } = new();

        public RecetaListViewModel(RecetaDatabase database)
        {
            db = database;

            CargarRecetas();

            RecetaEvents.RecetaGuardada += CargarRecetas;
        }

        public async void CargarRecetas()
        {
            Recetas.Clear();
            var recetas = await db.GetRecetasAsync();
            foreach (var r in recetas)
            {
                Recetas.Add(r);
            }

            OnPropertyChanged(nameof(Recetas));
        }

        ~RecetaListViewModel()
        {
            RecetaEvents.RecetaGuardada -= CargarRecetas;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}