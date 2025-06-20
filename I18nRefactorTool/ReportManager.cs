using System.Text.Json;

namespace I18nRefactorTool
{
    public class ReportManager
    {
        private readonly List<ChangeLog> _changes = new();
        private readonly string _reportPath;

        public ReportManager(string reportPath)
        {
            _reportPath = reportPath;
        }

        public void LogChange(string filePath, string key, string originalValue)
        {
            _changes.Add(new ChangeLog
            {
                File = filePath,
                Key = key,
                Value = originalValue
            });
        }

        public void Save()
        {
            var json = JsonSerializer.Serialize(_changes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_reportPath, json);
        }

        private class ChangeLog
        {
            public string File { get; set; }
            public string Key { get; set; }
            public string Value { get; set; }
        }
    }
}
