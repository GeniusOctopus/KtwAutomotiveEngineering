using KtwAutomotiveEngineering.V1.Shared.Utils;

namespace KtwAutomotiveEngineering.V1.Shared.Enums.Finance.Invoice
{
    public enum PositionType
    {
        [TextRepresentation(text: "M", tooltipText: "Material")]
        Material,
        [TextRepresentation(text: "L", tooltipText: "Leistung")]
        Service
    }
}
