using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyForecast.SymEngine.Json
{
    public static class CustomFunctions
    {
        public static double Pow(int a)
        {
            return a*=a;
        }

        public static double LotofPow(int a)
        {
             return a*a*a*a*a*a*a ;
        }

    }
}
