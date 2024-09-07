using KtwAutomotiveEngineering.Blazor.Models.Finance.Invoice;
using KtwAutomotiveEngineering.V1.Shared.Enums.Finance.Invoice;
using Microsoft.AspNetCore.Components.Web;
using System.Threading.Tasks;

namespace KtwAutomotiveEngineering.Blazor.Pages.Finance.InvoiceManagement
{
    public partial class CreateInvoice
    {
        public Invoice Invoice { get; set; } = new();

        private void OnAddRowClicked(MouseEventArgs args)
        {
            Invoice.Positions.Add(new(PositionType.Material, 0, string.Empty, string.Empty, decimal.Zero));
        }

        private async Task RemoveInvoicePosition(InvoicePosition position)
        {
            bool? result = await DialogService.ShowMessageBox(
            "Position wirklich entfernen?",
            string.Empty,
            yesText: "Ja", cancelText: "Nein");

            if (result == null)
                return;

            Invoice.Positions.Remove(position);
        }
    }
}
