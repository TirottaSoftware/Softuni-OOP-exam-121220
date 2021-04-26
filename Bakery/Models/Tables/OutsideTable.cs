﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    public class OutsideTable : Table
    {
        private const decimal _initialPricePerPerson = 3.50m;
        public OutsideTable(int tableNumber, int capacity) : base(tableNumber, capacity, _initialPricePerPerson)
        {
        }
    }
}
