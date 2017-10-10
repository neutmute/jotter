using System;
using System.Collections.Generic;
using System.Text;

namespace Jotter.Scenarios
{
    public class ScenarioOutput : IScenarioOutput
    {
        public IJwtBuildOptions BuildOptions { get; set; }

        public JwtScenario Scenario { get; set; }

        public string Token { get; set; }
    }
}
