namespace Jotter.Scenarios
{
    public interface IScenarioOutput
    {
        JwtScenario Scenario { get; }
        
        string Token { get; set; }
    }
}
