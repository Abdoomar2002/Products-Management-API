namespace Products_Management_API.Server.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Price Price { get; set; } 
        public Guid CategoryId { get; set; }
        public Product(string name, Price price, Guid categoryId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            CategoryId = categoryId;
        }
        public Product()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            Price = new Price();
            CategoryId = Guid.Empty;
        }
    }
}
