using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cueva_Prueba.Logs
{
    public static class LogService
    {
        public static void AppendLog(string nombreReceta)
        {
            string path = Path.Combine(FileSystem.AppDataDirectory, "Logs_Cueva.txt");
            string log = $"Se incluyó el registro {nombreReceta} el {DateTime.Now:dd/MM/yyyy HH:mm}\n";
            File.AppendAllText(path, log);
        }

        public static string LeerLogs()
        {
            string path = Path.Combine(FileSystem.AppDataDirectory, "Logs_Cueva.txt");
            return File.Exists(path) ? File.ReadAllText(path) : "No hay registros.";
        }
    }
}
