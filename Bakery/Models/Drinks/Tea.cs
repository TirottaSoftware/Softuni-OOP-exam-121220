using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Drinks
{
    public class Tea : Drink
    {
        private const decimal _teaPrice = 2.50m;
        public Tea(string name, int portion, string brand) : base(name, portion, _teaPrice, brand)
        {
        }
    }
}
