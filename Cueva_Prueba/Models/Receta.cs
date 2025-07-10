using SQLite;

namespace Cueva_Prueba.Models
{
    public class Receta
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Ingredientes { get; set; }
        public int TiempoPreparacionMinutos { get; set; }
        public bool EsVegetariana { get; set; }
    }
}
