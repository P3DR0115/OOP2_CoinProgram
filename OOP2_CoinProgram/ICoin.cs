using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_CoinProgram
{
    public interface ICoin : ICurrency
    {
        int Year { get; }
    }
}
