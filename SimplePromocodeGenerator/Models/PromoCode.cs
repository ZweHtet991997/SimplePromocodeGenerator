using System;

namespace SimplePromocodeGenerator.Models
{
    public class PromoCode
    {
        public string Code { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal DiscountAmount { get; set; }
    }

    public class PromoCodeGenerationRequest
    {
        public int CodeLength { get; set; }
        public int ValidityPeriod { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}
