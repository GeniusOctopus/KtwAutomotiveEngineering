using KtwAutomotiveEngineering.V1.Shared.Enums.Finance.Invoice;

namespace KtwAutomotiveEngineering.Blazor.Models.Finance.Invoice
{
    public class InvoicePosition(PositionType positionType, int quantity, string unitOfMeasurement, string description, decimal pricePerUnit)
    {
        public PositionType PositionType { get; set; } = positionType;
        public decimal Quantity { get; set; } = quantity;
        public string UnitOfMeasurement { get; set; } = unitOfMeasurement;
        public string Description { get; set; } = description;
        public decimal PricePerUnit { get; set; } = pricePerUnit;
    }
}
