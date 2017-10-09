using System;
using System.Collections.Generic;
using System.Text;

namespace Jotter.Scenarios
{
    public class ScenarioOutput : IScenarioOutput
    {
        public DateTimeOffset Created { get; set; }

        public JwtScenario Scenario { get; set; }

        public string Token { get; set; }

        public ScenarioOutput()
        {
            Created = DateTimeOffset.Now;
        }
    }
}
