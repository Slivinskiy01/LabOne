using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SberCAS.DataContext
{
    /// <summary>
    /// Person Model
    /// </summary>
    public class PersonModel
    {
        [BsonId]
        public Guid Guid { get; set; }

        public string IDNP { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public int Age { get; set; }

        public List<AccountModel> Accounts { get; set; }
    }
}
