namespace Jotter.Scenarios
{
    public interface IScenarioOutput
    {
        JwtScenario Scenario { get; }

        string Description { get; set; }

        IJwtBuildOptions BuildOptions { get; set; }

        string Token { get; set; }
    }
}
