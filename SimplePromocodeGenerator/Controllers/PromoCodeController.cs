using Microsoft.AspNetCore.Mvc;
using SimplePromocodeGenerator.Models;
using System;
using System.Text;

namespace SimplePromocodeGenerator.Controllers
{
    public class PromoCodeController : Controller
    {
        [HttpPost("generate")]
        public IActionResult GeneratePromoCode([FromBody] PromoCodeGenerationRequest request)
        {
            var code = GenerateCode(request.CodeLength);
            var expirationDate = DateTime.Now.AddDays(request.ValidityPeriod);
            var promoCode = new PromoCode { Code = code, ExpirationDate = expirationDate, DiscountAmount = request.DiscountAmount };
            return Ok(promoCode);
        }

        public string GenerateCode(int codeLength)
        {
            string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder sb = new StringBuilder();
            Random random = new Random();
            while (codeLength-- > 0)
            {
                sb.Append(validChars[random.Next(validChars.Length)]);
            }
            return sb.ToString();
        }
    }
}
