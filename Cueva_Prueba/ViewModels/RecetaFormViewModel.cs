using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private int _tiempoPreparacion;
        public int TiempoPreparacion
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

        public RecetaFormViewModel(RecetaDatabase database)
        {
            db = database;
        }

        public async Task GuardarRecetaAsync()
        {
            if (!EsVegetariana && TiempoPreparacion > 180)
            {
                await Shell.Current.DisplayAlert("Error", "Tiempo excesivo para receta no vegetariana", "OK");
                return;
            }

            var receta = new Receta
            {
                Nombre = Nombre,
                Ingredientes = Ingredientes,
                TiempoPreparacionMinutos = TiempoPreparacion,
                EsVegetariana = EsVegetariana
            };

            await db.SaveRecetaAsync(receta);
            LogService.AppendLog(receta.Nombre);

            RecetaEvents.OnRecetaGuardada();

            await Shell.Current.DisplayAlert("Éxito", "Receta guardada", "OK");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
