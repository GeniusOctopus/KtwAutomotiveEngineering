using KtwAutomotiveEngineering.V1.Shared.Enums.Finance.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KtwAutomotiveEngineering.Blazor.Models.Finance.Invoice
{
    public class Invoice
    {
        public InvoiceHead Head { get; set; } = new();
        public List<InvoicePosition> Positions { get; set; } = [];

        public decimal CalculateTotalBeforeDiscountAndTaxes()
        {
            return Positions.Sum(x => x.Quantity * x.PricePerUnit);
        }

        public decimal CalculateDiscount()
        {
            if (Head.Discount is null)
            {
                return decimal.Zero;
            }
            return Positions.Where(x => x.PositionType == PositionType.Material).Sum(x => x.Quantity * x.PricePerUnit) * (Head.Discount.Value / 100m);
        }

        public decimal CalculateTotalAfterDiscountAndBeforeTaxes()
        {
            return CalculateTotalBeforeDiscountAndTaxes() - CalculateDiscount();
        }

        public decimal CalculateTaxes()
        {
            return CalculateTotalAfterDiscountAndBeforeTaxes() * 0.19m;
        }

        public decimal CalculateTotal()
        {
            return CalculateTotalAfterDiscountAndBeforeTaxes() * 1.19m;
        }

        public decimal CalculateMaterialTotal()
        {
            return Positions.Where(x => x.PositionType == PositionType.Material).Sum(x => x.Quantity * x.PricePerUnit);
        }

        public decimal CalculateServiceTotal()
        {
            return Positions.Where(x => x.PositionType == PositionType.Service).Sum(x => x.Quantity * x.PricePerUnit);
        }
    }
}
