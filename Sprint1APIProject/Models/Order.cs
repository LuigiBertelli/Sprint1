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

        public void LogInfo() {
            var txt = $"Account: {Account} - Symbol: {Symbol} - Price: {Price}" + Environment.NewLine;
            var fh = new FileHandler(@"C:\\Users\\berte\\My Projects\\Intelitrader\\Teste\\Sprint1\\Sprint1APIProject\\bin\\Debug\\teste.txt");

            fh.Append(txt);
        }
    }
}
