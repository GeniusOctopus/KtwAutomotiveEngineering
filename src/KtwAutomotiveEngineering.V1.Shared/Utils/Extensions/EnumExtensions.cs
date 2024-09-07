using System.Reflection;

namespace KtwAutomotiveEngineering.V1.Shared.Utils.Extensions
{
    public static class EnumExtensions
    {
        public static EnumTextRepresentation GetTextRepresentation(this Enum e)
        {
            FieldInfo fi = e.GetType().GetField(e.ToString())
                ?? throw new MissingFieldException($"The field {e} of type {e.GetType()} could not be found");

            TextRepresentationAttribute attr = (TextRepresentationAttribute?)Attribute.GetCustomAttribute(fi, typeof(TextRepresentationAttribute))
                ?? throw new TextRepresentationAttributeNotFoundException($"The attribute {nameof(TextRepresentationAttribute)} was not found on field the {fi.Name} of type {e.GetType()}. Please attach the attribute.");

            return new EnumTextRepresentation(attr.Text, attr.TooltipText);
        }
    }
}
