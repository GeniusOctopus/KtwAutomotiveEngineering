namespace KtwAutomotiveEngineering.V1.Shared.Utils
{
    [AttributeUsage(AttributeTargets.Field)]
    public class TextRepresentationAttribute : Attribute
    {
        public string Text;
        public string? TooltipText;
        
        public TextRepresentationAttribute(string text)
        {
            Text = text;
        }

        public TextRepresentationAttribute(string text, string tooltipText)
        {
            Text = text;
            TooltipText = tooltipText;
        }
    }
}
