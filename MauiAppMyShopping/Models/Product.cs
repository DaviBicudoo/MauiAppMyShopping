using SQLite;

namespace MauiAppMyShopping.Models
{
    public class Product
    {
        string _description; 

        [PrimaryKey, AutoIncrement]
        // Product ID
        public int Id { get; set; } 

        // Product description
        public string? Description { 
            get => _description;
            set
            {
                if(value == null) // If there isn't any description, throw an exception
                {
                    throw new Exception("Please, fill the fields");
                }

                _description = value;
            }
        }
        
        public int Amount { get; set; } // Product amount
        public double Price { get; set; } // Product price
        public double Total { get => Convert.ToDouble(Amount) * Price; } // Product total price
    }
}
