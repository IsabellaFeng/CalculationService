
namespace CalculationService
{
    public class TaxRateBand
    {
        public decimal BandStart { get; set; }
        public decimal BandFinish { get; set; }
        public decimal TaxRatePercentage { get; set; }
        public decimal TaxCollected { get; set; }
    }
}
