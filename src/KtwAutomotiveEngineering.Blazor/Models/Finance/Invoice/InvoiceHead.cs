using KtwAutomotiveEngineering.Blazor.Models.Shared;
using System;

namespace KtwAutomotiveEngineering.Blazor.Models.Finance.Invoice
{
    public class InvoiceHead
    {
        public Guid LetterheadId { get; set; }
        public string Salutation { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Address Address { get; set; } = new();
        public decimal? Discount { get; set; }
    }
}
