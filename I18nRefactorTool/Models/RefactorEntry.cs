namespace I18nRefactorTool.Models
{
    public class RefactorEntry
    {
        public string FilePath { get; set; } = string.Empty;
        public int LineNumber { get; set; }
        public string OriginalString { get; set; } = string.Empty;
        public string ResourceKey { get; set; } = string.Empty;
    }
}
