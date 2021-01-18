using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

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

        private ILiteCollection<T> GetCollection<T>()
        {
            return _db.GetCollection<T>();
        }
    }
}
