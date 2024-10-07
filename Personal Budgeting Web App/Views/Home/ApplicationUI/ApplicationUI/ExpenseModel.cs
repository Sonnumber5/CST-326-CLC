using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationUI
{
    public class ExpenseModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }

        public ExpenseModel(string name, double price, string category, string date, string description)
        {
            this.Name = name;
            this.Price = price;
            this.Category = category;
            this.Date = date;
            this.Description = description;
        }

        public override string ToString()
        {
            return $"{Name} - {Price} - {Date} - {Description}";
        }
    }
}
