
using System.ComponentModel;
using Cueva_Prueba.Logs;

namespace Cueva_Prueba.ViewModels
{
    public class LogsViewModel : INotifyPropertyChanged
    {
        private string _contenidoLogs;
        public string ContenidoLogs
        {
            get => _contenidoLogs;
            set
            {
                if (_contenidoLogs != value)
                {
                    _contenidoLogs = value;
                    OnPropertyChanged(nameof(ContenidoLogs));
                }
            }
        }

        public LogsViewModel()
        {
            RecargarLogs();
            RecetaEvents.RecetaGuardada += RecargarLogs;
        }

        private void RecargarLogs()
        {
            ContenidoLogs = LogService.LeerLogs();
        }

        ~LogsViewModel()
        {
            RecetaEvents.RecetaGuardada -= RecargarLogs;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
