namespace Jotter.Scenarios
{
    /// <summary>
    /// System.Identity doesn't seem available in .NET Standard 1.6
    /// </summary>
    public class Claim
    {
        public string Type { get; set; }

        public string Value { get; set; }

        public Claim(string type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}
