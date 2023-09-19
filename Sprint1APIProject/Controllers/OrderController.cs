using Microsoft.AspNetCore.Mvc;
using Sprint1ApiProject.Utils;
using Sprint1ApiProject.Models;
using Sprint1ApiProject.Enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sprint1ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        // POST api/<OrderController>
        // Recebe string no formato FIX e salva informações do pedido em arquivo txt
        [HttpPost]
        public void Post([FromBody] string fix)
        {
            //Converte FIX para dicionário e gera um objeto Order a partir dos campos Account(1), Price(44), Symbol(55)
            var fixDict = FixUtils.Converter(fix);

            var account = fixDict[(int)FixEnum.Account];
            var symbol = fixDict[(int)FixEnum.Symbol];
            var price = Convert.ToDecimal(fixDict[(int)FixEnum.Price]);

            var order = new Order(account, symbol, price);

        }
    }
}
