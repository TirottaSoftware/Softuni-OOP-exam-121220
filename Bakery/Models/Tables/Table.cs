using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private List<IBakedFood> foodOrders;
        private List<IDrink> drinks;
        public int TableNumber { get; set; }

        private int capacity;
        private int numberOfPeople;

        public int NumberOfPeople
        {
            get { return numberOfPeople; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Cannot place zero or less people!");
                }
                numberOfPeople = value;
            }
        }


        public int Capacity
        {
            get { return capacity; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }
                capacity = value;
            }
        }

        public decimal PricePerPerson { get; set; }

        public bool IsReserved { get; set; }

        public decimal Price => this.NumberOfPeople * this.PricePerPerson;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.foodOrders = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
        }
        public void Clear()
        {
            this.foodOrders = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.NumberOfPeople = 0;
        }

        public decimal GetBill() => this.foodOrders.Sum(f => f.Price) + this.drinks.Sum(d => d.Price) + this.Price;
        

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson}");
            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            drinks.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
            this.IsReserved = true;
        }
    }
}
