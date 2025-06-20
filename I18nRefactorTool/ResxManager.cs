using System.Xml.Linq;
using System.Text.RegularExpressions;


namespace I18nRefactorTool
{
    public class ResxManager
    {
        private readonly string _resxPath;
        private readonly Dictionary<string, string> _resources;

        public ResxManager(string resxPath)
        {
            _resxPath = resxPath;
            _resources = new Dictionary<string, string>();
        }

        public void AddResource(string key, string value)
        {
            if (!_resources.ContainsKey(key))
                _resources[key] = value;
        }

       public void Save()
        {
            var doc = new XDocument(
                new XElement("root",
                    _resources.Select(kvp =>
                    {
                        var cleanKey = SanitizeKey(kvp.Key);
                        return new XElement("data",
                            new XAttribute("name", cleanKey),
                            new XAttribute(XNamespace.Xml + "space", "preserve"),
                            new XElement("value", kvp.Value)
                        );
                    })
                )
            );

            doc.Save(_resxPath);
        }
        private string SanitizeKey(string key)
{
    // Replace invalid XML characters with underscore
    var sanitized = Regex.Replace(key, @"[^a-zA-Z0-9_]", "_");

    // Key must start with a letter
    if (!char.IsLetter(sanitized, 0))
        sanitized = "Key_" + sanitized;

    // Trim to max 50 chars
    return sanitized.Length > 50 ? sanitized.Substring(0, 50) : sanitized;
}

    }
}
