
using CalculationService;

namespace CalculationService
{
    public class SalaryCalculateService
    {

        private static readonly List<TaxRateBand> _taxRateBands = new()
        {
            new TaxRateBand { BandStart = 0.00m, BandFinish = 14000.00m, TaxRatePercentage = 11.5m },
            new TaxRateBand { BandStart = 14000.00m, BandFinish = 48000.00m, TaxRatePercentage = 21.0m },
            new TaxRateBand { BandStart = 48000.00m, BandFinish = 70000.00m, TaxRatePercentage = 31.5m },
            new TaxRateBand { BandStart = 70000.00m, BandFinish = 0.00m, TaxRatePercentage = 35.5m }
        };

        private decimal CalculateTaxForBand(decimal bandStart, decimal bandEnd, decimal taxRatePercentage, decimal salary)
        {
            if (salary <= bandStart)
            {
                return 0.00m;
            }
            // if salary within this tax bracket use salary otherwise use bandEnd 

            var bandEndOrSalary  = Math.Min(salary, bandEnd);
            if (bandEndOrSalary == 0)
            {
                bandEndOrSalary = salary;
            }
            decimal taxableIncome = bandEndOrSalary - bandStart;

            decimal taxCollected = taxableIncome * (taxRatePercentage / 100);
            return Math.Round(taxCollected, 2);
        }

        public List<TaxRateBand>  GetInitialRateBand()
        {
            return _taxRateBands;
        }

        public void CalculateTaxForBands(List<TaxRateBand> TaxRateBands, decimal salary)
        {
            // Calculate tax collected for each band based on the provided salary
            foreach (var band in TaxRateBands)
            {
                band.TaxCollected = CalculateTaxForBand(band.BandStart, band.BandFinish, band.TaxRatePercentage, salary);
            }

            // Calculate total tax collected
            var TotalTaxCollected = CalculateTotalTaxCollected(TaxRateBands);
        }


        public decimal CalculateTotalTaxCollected(List<TaxRateBand> taxRateBands)
        {
            decimal totalTaxCollected = 0;

            foreach (var band in taxRateBands)
            {
                totalTaxCollected += band.TaxCollected;
            }

            return totalTaxCollected;
        }
    }
}
