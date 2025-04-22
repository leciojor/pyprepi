using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using PYPREPI.Core;

namespace PYPREPI.Tests
{
    public static class PythonImportParser
    {
        public static List<string> GetImportedModules(string pythonCode)
        {
            var importedModules = new HashSet<string>();
            
            var importPattern = new Regex(@"^\s*import\s+([a-zA-Z_][\w\.]*)", RegexOptions.Multiline);

            var fromImportPattern = new Regex(@"^\s*from\s+([a-zA-Z_][\w\.]*)\s+import", RegexOptions.Multiline);

            foreach (Match match in importPattern.Matches(pythonCode))
            {
                var moduleName = match.Groups[1].Value.Split('.')[0];
                importedModules.Add(moduleName);
            }

            foreach (Match match in fromImportPattern.Matches(pythonCode))
            {
                var moduleName = match.Groups[1].Value.Split('.')[0];
                importedModules.Add(moduleName);
            }

            return new List<string>(importedModules);
        }
    }

}
