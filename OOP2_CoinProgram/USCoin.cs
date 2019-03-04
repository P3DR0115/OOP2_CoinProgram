using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_CoinProgram
{
    public enum USCoinMintMark
    {
        P,  // Philidelphia
        D, // Denver
        S, // San Francisco
        W // West Point 
    }

    public abstract class USCoin : Coin
    {
        public USCoinMintMark MintMark;

        public override string About()
        {
            return "US " + Name + " is from " + Year + ". It is worth $" + MonetaryValue + ". It was made in " + GetMintNameFromMark(MintMark);
        }

        public static string GetMintNameFromMark(USCoinMintMark CoinsMintMark)
        {
            switch(CoinsMintMark)
            {
                case USCoinMintMark.P:
                    {
                        return "Philadelphia";
                    }
                case USCoinMintMark.D:
                    {
                        return "Denver";
                    }
                case USCoinMintMark.S:
                    {
                        return "San Francisco";
                    }
                case USCoinMintMark.W:
                    {
                        return "West Point";
                    }
                default:
                    {
                        return "Denver";
                    }
            }
        }        

        public USCoin() : this(USCoinMintMark.D) { }

        public USCoin(USCoinMintMark MintLocation)
        {
            MintMark = MintLocation;
        }
    }
}
