﻿using FootballTeam.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballTeam.DataContext;
using LiteDB;

namespace FootballTeam.Services
{
    public class Services<T> : ICRUD<T>
    {
        private LiteDatabase DB {get; set;} 
        private LiteCollection<T> LiteCollection { get; set; }

        public Services()
        {
            var db = new DataContext.DataContext();
            DB = db.Init();
        }

        public Services(string collection)
        {
            var db = new DataContext.DataContext();
            DB = db.Init();
            LiteCollection = DB.GetCollection<T>(collection);
        }

        public List<T> GetRows()
        {
            return (List<T>)LiteCollection.FindAll().ToList();
        }

        public T GetByID(Guid guid)
        {
            return (T)LiteCollection.FindById(guid);
        }

        public bool GetNew(T obj)
        {
            LiteCollection.Insert(obj);
            return true;
        }

        public bool Update(T obj, T obj1)
        {
            return LiteCollection.Update(obj);
        }

        public bool Delete(Guid guid)
        {
            return LiteCollection.Delete(guid);
        }
    }
}
