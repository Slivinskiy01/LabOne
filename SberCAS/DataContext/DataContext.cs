using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SberCAS.DataContext
{
    public class DataContext
    {
        public string ConnectionString => @"MyData.db";

        public LiteDatabase Init()
        {
            return new LiteDatabase(ConnectionString);
        }
    }
}
