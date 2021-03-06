using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppCRUD.Shared {
    public class Ingredient {

        public string? Name { get; set; }

        public int Quantity { get; set; } = 0;

        public string? Unit { get; set; }

        public Ingredient(string name, int quantity, string unit) {
            Name = name;
            Quantity = quantity;
            Unit = unit;
        }
    }
}
