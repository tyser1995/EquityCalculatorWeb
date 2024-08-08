using static EquityCalculatorWeb.Models.PaymentInfo;

namespace EquityCalculatorWeb.Models
{
    public class EquityPayment
    {
        public decimal Balance { get; set; }
        public DateTime DueDate { get; set; }
        public int Term { get; set; }
        public PaymentInfo PaymentInfo { get; set; }
    }
}
