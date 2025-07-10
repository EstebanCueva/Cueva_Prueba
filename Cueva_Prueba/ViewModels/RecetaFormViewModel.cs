using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Cueva_Prueba.Models;
using Cueva_Prueba.Services;
using Cueva_Prueba.Logs;

namespace Cueva_Prueba.ViewModels
{
    public class RecetaFormViewModel : INotifyPropertyChanged
    {
        private string _nombre;
        public string Nombre
        {
            get => _nombre;
            set
            {
                if (_nombre != value)
                {
                    _nombre = value;
                    OnPropertyChanged(nameof(Nombre));
                }
            }
        }

        private string _ingredientes;
        public string Ingredientes
        {
            get => _ingredientes;
            set
            {
                if (_ingredientes != value)
                {
                    _ingredientes = value;
                    OnPropertyChanged(nameof(Ingredientes));
                }
            }
        }

        private string _tiempoPreparacion;
        public string TiempoPreparacion
        {
            get => _tiempoPreparacion;
            set
            {
                if (_tiempoPreparacion != value)
                {
                    _tiempoPreparacion = value;
                    OnPropertyChanged(nameof(TiempoPreparacion));
                }
            }
        }

        private bool _esVegetariana;
        public bool EsVegetariana
        {
            get => _esVegetariana;
            set
            {
                if (_esVegetariana != value)
                {
                    _esVegetariana = value;
                    OnPropertyChanged(nameof(EsVegetariana));
                }
            }
        }

        private RecetaDatabase db;

        public ICommand GuardarRecetaCommand { get; }

        public RecetaFormViewModel(RecetaDatabase database)
        {
            db = database;

            GuardarRecetaCommand = new Command(async () => await GuardarRecetaAsync());
        }

        public async Task GuardarRecetaAsync()
        {
            if (!int.TryParse(TiempoPreparacion, out int tiempo))
            {
                await Shell.Current.DisplayAlert("Error", "Tiempo inválido", "OK");
                return;
            }

            if (!EsVegetariana && tiempo > 180)
            {
                await Shell.Current.DisplayAlert("Error", "Tiempo excesivo para receta no vegetariana", "OK");
                return;
            }

            var receta = new Receta
            {
                Nombre = Nombre,
                Ingredientes = Ingredientes,
                TiempoPreparacionMinutos = tiempo,
                EsVegetariana = EsVegetariana
            };

            await db.SaveRecetaAsync(receta);
            LogService.AppendLog(receta.Nombre);
            RecetaEvents.OnRecetaGuardada();

            await Shell.Current.DisplayAlert("Éxito", "Receta guardada", "OK");

            Nombre = string.Empty;
            Ingredientes = string.Empty;
            TiempoPreparacion = string.Empty;
            EsVegetariana = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
