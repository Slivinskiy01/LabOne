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
    public class PlayerModel
    {
        [BsonId]
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string BrithDay { get; set; }
        
        public string NrInTeam { get; set; }
        
        public decimal Salary { get; set; }

        public int CountGame { get; set; }

        public int CountGoal { get; set; }

        public int Growth { get; set; }

        public int Weight { get; set; }

        public decimal TransferCost { get; set; }
    }
}
