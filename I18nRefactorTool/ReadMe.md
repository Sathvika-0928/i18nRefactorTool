# 🛠️ i18nRefactorTool (.NET CLI Utility)

## 🌍 Objective

A CLI tool to internationalize `.cs` and `.cshtml` files by automatically replacing **hardcoded strings** with **.resx resource keys**.  
It also generates a `refactor-report.json` log for tracking all changes made during refactoring.

---

## 📦 Features

- 🔍 Scans `.cs` and `.cshtml` files for hardcoded strings.
- 🔁 Replaces them with auto-generated `Resources.<Key>` references.
- 🧾 Populates `Resources.resx` file with key-value pairs.
- 📄 Auto-generates `Resources.Designer.cs` for strongly typed access.
- 📝 Generates a `refactor-report.json` summarizing all modifications.
- ✅ Ensures output code still compiles.

---

## 📁 Project Structure

I18nRefactorTool/
├── Program.cs # Main entry point for CLI
├── I18nProcessor.cs # Core logic for parsing and refactoring files
├── ResxManager.cs # Handles .resx resource file generation
├── ReportManager.cs # Handles logging refactor report to JSON
├── Resources/
│ ├── Resources.resx # Resource file containing localized strings
│ └── Resources.Designer.cs 
├── SampleInput/ # Folder with test files containing hardcoded strings
│ └── Hello.cs
├── refactor-report.json # Auto-generated report of changes (after running CLI)
├── I18nRefactorTool.csproj # Project file with correct resx settings
└── README.md # You're here!

## 🚀 How to Run

### 🧰 Prerequisites

- [.NET SDK 6.0 or later](https://dotnet.microsoft.com/download)
- `Resources.resx` must exist at `Resources/Resources.resx`

---

### ▶️ Run the Tool

1. Navigate to the root of the project:

```bash
cd I18nRefactorTool

dotnet run 


### ✅ What It Does
Given this input:

    Console.WriteLine("Hello World");
    Console.WriteLine("Battery: Low");

The tool:

Generates entries in .resx like:

<data name="HelloWorld" xml:space="preserve">
  <value>Hello World</value>
</data>
<data name="BatteryLow" xml:space="preserve">
  <value>Battery: Low</value>
</data>
Refactors the code:

    Console.WriteLine(Resources.HelloWorld);
    Console.WriteLine(Resources.BatteryLow);

### 📒 Rules for Extraction
Ignores strings shorter than 3 characters

Skips strings with {, }, or =

Removes punctuation from keys and limits them to 30 characters

📄 Output Files
✅ Refactored .cs file (original strings replaced)

✅ .resx file at the path you configure

✅ Optional log via ReportManager


### 🧪 Testing
To test, create .cs files in the SampleInput/ folder with hardcoded strings and run the tool.

### 🔍 Future Improvements
Support directory-wide scans

Add duplicate key handling and suffixing

Generate Designer.cs for strongly-typed access

Provide a config file to set key length, ignore patterns, etc.


###🐞 Troubleshooting
Resource Key Not Found:

Ensure Resources.Designer.cs is generated. If not, rebuild the project or right-click Resources.resx → Run Custom Tool in IDE.

Duplicate EmbeddedResource Error:

Add this to .csproj to avoid automatic inclusion:
   
   <EnableDefaultEmbeddedResourceItems>false</EnableDefaultEmbeddedResourceItems>

###👩‍💻 Author
Developed by Sathvika Vasamsetti.

**# 🛠️ i18nRefactorTool (.NET CLI Utility)**
