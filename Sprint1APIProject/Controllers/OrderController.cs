using Microsoft.AspNetCore.Mvc;
using Sprint1ApiProject.Utils;
using Sprint1ApiProject.Models;
using Sprint1ApiProject.Enums;
using System.Web;
using System.Globalization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sprint1ApiProject.Controllers
{
    [Route("order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        // POST /order
        // Recebe string no formato FIX e salva informações do pedido em arquivo txt
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public void Post([FromBody]Fix fix)
        {
            try
            {
                //Converte FIX para dicionário e gera um objeto Order a partir dos campos Account(1), Price(44), Symbol(55)
                var decodedFix = HttpUtility.UrlDecode(fix.Code);
                var fixDict = FixUtils.Converter(decodedFix);

                var account = fixDict[(int)FixEnum.Account];
                var symbol = fixDict[(int)FixEnum.Symbol];
                var price = Convert.ToDecimal(fixDict[(int)FixEnum.Price], CultureInfo.InvariantCulture);

                //Grava dados do objeto order em um arquivo
                var order = new Order(account, symbol, price);
                var path = order.LogInfo();
                Created(path, new {
                    Success = true,
                    Key = "Created",
                });
            }
            catch
            {
                BadRequest();
            }
        }
    }
}
