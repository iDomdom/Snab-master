using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using static SnabBashka.Models.SupplyDpt;

namespace SnabBashka.Services
{
    public class Repository
    {
        private readonly LiteDatabase _db;

        public Repository(LiteDatabase db)
        {
            _db = db;
        }

        public IEnumerable<T> Find<T>()
        {
            return GetCollection<T>().FindAll();
        }

        public void Save<T> (T item)
        {
            GetCollection<T>().Upsert(item);
        }

        public ILiteCollection<T> GetCollection<T>()
        {
            return _db.GetCollection<T>();
        }

        public void Edit<T> (T item)
        {

        }

        public void DropDB()
        {
            _db.DropCollection("SnabDB");
        }
    }
}
