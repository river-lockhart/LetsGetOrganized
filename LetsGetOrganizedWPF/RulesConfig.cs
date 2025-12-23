namespace LetsGetOrganizedWPF
{
    public class RulesConfig
    {
        private string rulesMode = string.Empty;
        public int SchemaVersion { get; set; } = 1;
        public RuleSet Ruleset { get; set; } = new();

        public sealed class RuleSet
        {
            public List<Rule> Rules { get; set; } = new();
        }

        public sealed class Rule
        {
            public string RuleId { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public Dictionary<string, object?> Params { get; set; } = new();
        }

        public void setRulesMode(string mode)
        {
            this.rulesMode = mode;
        }

        public string getRulesMode()
        {
            return this.rulesMode;
        }

    }
}
