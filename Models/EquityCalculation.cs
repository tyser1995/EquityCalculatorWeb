using static EquityCalculatorWeb.Models.EquityPayment;

namespace EquityCalculatorWeb.Models
{
    public class EquityCalculation
    {
        public decimal SellingPrice { get; set; }
        public DateTime ReservationDate { get; set; }
        public int EquityTerm { get; set; }
        public decimal MonthlyAmount { get; set; }
        public List<EquityPayment> Payments { get; set; }
    }
}
