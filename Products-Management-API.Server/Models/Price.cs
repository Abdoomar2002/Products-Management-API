namespace Products_Management_API.Server.Models
{
    public class Price
    {
        public decimal Value { get;}
        public string Currency { get;}
        public Price(decimal val,string curr) 
        {
            Value = val;
            Currency = curr;
        }
        public  Price()
        {
            Value = 0;
            Currency = "EGP";
        }
    }
}
