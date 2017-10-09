namespace Jotter.Scenarios
{
    public interface IScenarioOutput
    {
        JwtScenario Scenario { get; }

        IJwtBuilderParams Parameters { get; set; }

        string TokenOutput { get; set; }
    }
}
