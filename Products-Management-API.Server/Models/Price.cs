namespace Products_Management_API.Server.Models
{
    public class Price
    {
        public decimal Value { get; set; }
        public string Currency { get; set; }
        public Price(decimal val,string curr) 
        {
            Value = val;
            Currency = curr;
        }
        public  Price()
        {

        }
    }
}
