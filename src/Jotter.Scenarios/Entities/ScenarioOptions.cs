using System;

namespace Jotter.Scenarios
{
    public class ScenarioOptions
    {
        /// <summary>
        /// Should make a new scenario each time
        /// </summary>
        public GenerateScenarioDelegate GetGoodScenario { get; set; }

        public TimeSpan LegalValidWindow { get; set; }

        public ScenarioOptions()
        {
            LegalValidWindow = TimeSpan.FromMinutes(5); // default
        }
    }
}
