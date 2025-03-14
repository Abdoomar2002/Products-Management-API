namespace Products_Management_API.Server.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int ProductCount { get; set; }
        public Category(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
