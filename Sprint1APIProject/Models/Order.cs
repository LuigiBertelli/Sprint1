namespace Sprint1ApiProject.Models
{
    public class Order
    {
        private string Account { get; set; }
        private string Symbol { get; set; }
        private decimal Price { get; set; }

        public Order(string account, string symbol, decimal price)
        {
            Account = account;
            Symbol = symbol;
            Price = price;
        }
    }
}
