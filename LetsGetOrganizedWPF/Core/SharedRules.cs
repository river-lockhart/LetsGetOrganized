using System;
using System.Collections.Generic;
using System.Text;

namespace LetsGetOrganizedWPF.Core
{
    public class SharedRules
    {
        public bool AllExtensions { get; init; } = true;
        public List<string> CustomExtensions { get; init; } = new();
        public bool IncludeSubfolders { get; init; }
        public bool IncludeHiddenFiles { get; init; }
    }
}
