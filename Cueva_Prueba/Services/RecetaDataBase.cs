using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Cueva_Prueba.Models;

namespace Cueva_Prueba.Services
{
    public class RecetaDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public RecetaDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Receta>().Wait();
        }

        public Task<List<Receta>> GetRecetasAsync() => _database.Table<Receta>().ToListAsync();
        public Task<int> SaveRecetaAsync(Receta receta) => _database.InsertAsync(receta);
    }
}
