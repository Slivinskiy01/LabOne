using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SberCAS.DataContext
{
    /// <summary>
    /// Account Model
    /// </summary>
    public class AccountModel
    {
        public int Id { get; set; }

        public string IBAN { get; set; }

        public Curency Curency { get; set; }

        public decimal Amount { get; set; }
    }

    public enum Curency
    {
        MDL,
        EUR,
        USD,
        RUB
    }
}
