namespace Jotter.Scenarios
{
    public interface IScenarioOutput
    {
        JwtScenario Scenario { get; }

        IJwtBuildOptions BuildOptions { get; set; }

        string Token { get; set; }
    }
}
