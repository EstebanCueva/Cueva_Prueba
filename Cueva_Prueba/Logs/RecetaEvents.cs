using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cueva_Prueba.Logs
{
    public static class RecetaEvents
    {
        public static event Action? RecetaGuardada;

        public static void OnRecetaGuardada()
        {
            RecetaGuardada?.Invoke();
        }
    }
}