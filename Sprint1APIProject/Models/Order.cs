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

        public string LogInfo() {
            var txt = $"Account: {Account} - Symbol: {Symbol} - Price: {Price}" + Environment.NewLine;
            var path = @"C:\\Users\\berte\\My Projects\\Intelitrader\\Teste\\Sprint1\\Sprint1APIProject\\bin\\Debug\\teste.txt";
            var fh = new FileHandler(path);

            fh.Append(txt);
            return path;
        }
    }
}
