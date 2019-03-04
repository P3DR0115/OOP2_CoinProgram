using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_CoinProgram
{
    public abstract class Coin : ICoin
    {
        public double MonetaryValue { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        public Coin()
        {

        }

        public virtual string About()
        {
            return "";
        }
    }
}
