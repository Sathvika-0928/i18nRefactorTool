using System;
using System.IO;

namespace I18nRefactorTool
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define paths
            string baseDir = Directory.GetCurrentDirectory();
            string inputDir = Path.Combine(baseDir, "SampleInput");
            string resxPath = Path.Combine(baseDir, "Resources", "Resources.resx");
            string reportPath = Path.Combine(baseDir, "Reports", "refactor-report.json");

            // Ensure directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(resxPath)!);
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath)!);

            // Initialize processors
            var resxManager = new ResxManager(resxPath);
            var reportManager = new ReportManager(reportPath);
            var processor = new I18nProcessor(resxManager, reportManager);

            // Process each .cs or .cshtml file
            foreach (string file in Directory.GetFiles(inputDir, "*.*", SearchOption.AllDirectories))
            {
                if (file.EndsWith(".cs") || file.EndsWith(".cshtml"))
                {
                    Console.WriteLine($"Processing: {file}");
                    processor.ProcessFile(file);
                }
            }

            // Save outputs
            resxManager.Save();
            reportManager.Save();

            Console.WriteLine("✅ Refactoring complete!");
        }
    }
}
