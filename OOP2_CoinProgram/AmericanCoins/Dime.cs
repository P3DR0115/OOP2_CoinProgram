using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_CoinProgram
{
    public class Dime : USCoin
    {
        public Dime() : this(USCoinMintMark.D)
        {

        }

        public Dime(USCoinMintMark mintLocation)
        {
            this.MintMark = mintLocation;
            this.MonetaryValue = 0.10;
            this.Name = "Dime";
            this.Year = DateTime.Now.Year;
        }
    }
}
