using System;

namespace Jotter.Scenarios
{
    public class ScenarioFactory
    {
        public static Func<JwtBuilderParams> GetGoodScenario { get; set; }

        public static IJwtBuilderParams GetParameters(JwtScenario scenario)
        {
            var baseScenario = GetGoodScenario();
            switch(scenario)
            {
                case JwtScenario.GoodLongLife:
                    baseScenario.NotAfter = DateTimeOffset.Now.AddYears(10);
                    break;
                case JwtScenario.Expired:
                    baseScenario.NotBefore = DateTimeOffset.Now.AddMinutes(-10);
                    baseScenario.NotAfter = DateTimeOffset.Now.AddMinutes(-1);
                    break;
            }
            return baseScenario;
        }
    }
}
