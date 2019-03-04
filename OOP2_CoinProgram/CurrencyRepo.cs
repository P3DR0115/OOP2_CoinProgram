using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_CoinProgram
{
    public class CurrencyRepo : ICurrencyRepo
    {
        public List<ICoin> Coins { get; set; }

        public CurrencyRepo()
        {
            Coins = new List<ICoin>();
        }
        public string About()
        {
            return ""; // Don't know what to return yet?
        }

        public void AddCoin(ICoin c)
        {
            Coins.Add(c);
        }

        public ICurrencyRepo CreateChange(double Amount)
        {
            CurrencyRepo change = new CurrencyRepo();
            while(Amount > 0)
            {
                /* Used Math.Round() because for some reason, during the 11 cents test, 
                 0.11 - 0.10 = 0.00999999999995 which != 0.01. So my program would break. :( */
                Amount = Math.Round(Amount, 2);

                if(Amount - 1 >= 0)
                {
                    Amount -= 1.00;
                    DollarCoin c = new DollarCoin();
                    change.AddCoin(c);
                }
                else if(Amount - 0.5 >= 0)
                {
                    Amount -= 0.5;
                    HalfDollar c = new HalfDollar();
                    change.AddCoin(c);
                }
                else if (Amount - 0.25 >= 0)
                {
                    Amount -= 0.25;
                    Quarter c = new Quarter();
                    change.AddCoin(c);
                }
                else if (Amount - 0.1 >= 0)
                {
                    Amount -= 0.10;
                    Dime c = new Dime();
                    change.AddCoin(c);
                }
                else if (Amount - 0.05 >= 0)
                {
                    Amount -= 0.05;
                    Nickel c = new Nickel();
                    change.AddCoin(c);
                }
                else if (Amount - 0.01 >= 0)
                {
                    Amount -= 0.01;
                    Penny c = new Penny();
                    change.AddCoin(c);
                }
                else
                {
                    // Change made
                }
            }

            return change;
        }

        public ICurrencyRepo CreateChange(double AmountTendered, double TotalCost)
        {
            if(TotalCost > AmountTendered)
            {
                // Customer didn't pay enough
                return CreateChange(AmountTendered);
            }
            else
            {
                // Customer did pay enough
                AmountTendered -= TotalCost;
                return CreateChange(AmountTendered);
            }
        }

        public int GetCoinCount()
        {
            return Coins.Count;
        }

        public ICurrencyRepo MakeChange(double Amount)
        {
            return CreateChange(Amount);
        }

        public ICurrencyRepo MakeChange(double AmountTendered, double TotalCost)
        {
            return CreateChange(AmountTendered, TotalCost);
        }

        public ICoin RemoveCoin(ICoin c)
        {
            if(Coins.Contains(c))
            {
                Coins.Remove(c);
            }
            else
            {
                // Do nothing? No coin of that type to remove.
            }

            return c;
        }

        public double TotalValue()
        {
            double aggregateValue = 0;
            foreach(Coin c in Coins)
            {
                aggregateValue += c.MonetaryValue;
            }
            return aggregateValue;
        }
    }
}
