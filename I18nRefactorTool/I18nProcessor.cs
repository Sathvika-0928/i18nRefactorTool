using System.Text.RegularExpressions;

namespace I18nRefactorTool
{
    public class I18nProcessor
    {
        private readonly ResxManager _resxManager;
        private readonly ReportManager _reportManager;

        public I18nProcessor(ResxManager resxManager, ReportManager reportManager)
        {
            _resxManager = resxManager;
            _reportManager = reportManager;
        }

        public void ProcessFile(string filePath)
        {
            var code = File.ReadAllText(filePath);
            var pattern = @"(?<!@)""([^""\\]*(?:\\.[^""\\]*)*)""";
            var matches = Regex.Matches(code, pattern);

            int count = 0;
            foreach (Match match in matches)
            {
                var value = match.Groups[1].Value;
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3 || Regex.IsMatch(value, @"[{}=]"))
                    continue;

                var key = GenerateKey(value);
                code = code.Replace($"\"{value}\"", $"Resources.{key}");

                _resxManager.AddResource(key, value);
                _reportManager.LogChange(filePath, key, value);

                count++;
            }

            if (count > 0)
                File.WriteAllText(filePath, code);
        }

       private string GenerateKey(string value)
        {
            var key = Regex.Replace(value.Trim(), @"[^a-zA-Z0-9_]", "_");

            if (!char.IsLetter(key, 0))
            {
                key = "Key_" + key;
            }

            if (key.Length > 50)
            {
                key = key.Substring(0, 50);
            }

            return key;
        }
    }
}
