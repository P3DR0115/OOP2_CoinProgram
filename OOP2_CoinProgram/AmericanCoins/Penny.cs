using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_CoinProgram
{
    public class Penny : USCoin
    {
        public Penny() : this(USCoinMintMark.D) { }

        public Penny(USCoinMintMark mintLocation)
        {
            this.MintMark = mintLocation;
            this.MonetaryValue = 0.01;
            this.Name = "Penny";
            this.Year = DateTime.Now.Year;
        }
    }
}
