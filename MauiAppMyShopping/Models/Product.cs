using SQLite;

namespace MauiAppMyShopping.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? Description { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
    }
}
