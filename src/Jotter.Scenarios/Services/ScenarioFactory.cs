using System;

namespace Jotter.Scenarios
{
    public delegate JwtBuilderOptions GenerateScenarioDelegate(string certificateThumbprint);

    public class ScenarioFactory
    {
        /// <summary>
        /// Should make a new scenario each time
        /// </summary>
        public GenerateScenarioDelegate GetGoodScenario { get; set; }
        
        public TimeSpan LegalValidWindow { get; set; }
        
        internal IJwtBuildOptions Generate(JwtScenario scenario, string certificateThumbprint)
        {
            var baseScenario = GetGoodScenario(certificateThumbprint);
            switch(scenario)
            {
                case JwtScenario.Unspecified:
                    throw new NotSupportedException("Pick a valid scenario!");
                case JwtScenario.Good:
                    // NOOP
                    break;
                case JwtScenario.GoodLongLife:
                    baseScenario.NotAfter = DateTimeOffset.Now.AddYears(10);
                    break;
                case JwtScenario.Expired:
                    baseScenario.NotBefore = DateTimeOffset.Now.AddMinutes(-10);
                    baseScenario.NotAfter = DateTimeOffset.Now.AddMinutes(-1);
                    break;
                case JwtScenario.FutureIssuedAt:
                    baseScenario.Created = DateTimeOffset.Now.AddMinutes(1);
                    break;
                case JwtScenario.NotSigned:
                    baseScenario.Signing = baseScenario.Signing.Clone();
                    baseScenario.Signing = null;
                    break;
                case JwtScenario.ValidWindowTooLarge:
                    baseScenario.NotBefore = baseScenario.NotBefore - LegalValidWindow;
                    break;
                case JwtScenario.MissingSubject:
                    baseScenario.Claims.RemoveAll(c => c.Type.ToLower().Equals("subject"));
                    break;
                case JwtScenario.MissingKid:
                    var headers = baseScenario.ExtraHeaders;
                    const string kidKey = "kid";
                    if (headers.ContainsKey(kidKey))
                    {
                        baseScenario.ExtraHeaders.Remove(kidKey);
                    }
                    break;
                case JwtScenario.BadAudience:
                    baseScenario.Audience = "http://not-your-expected-audience";
                    break;
                case JwtScenario.BadIssuer:
                    baseScenario.Issuer = "http://not-your-expected-issuer";
                    break;
                default:
                    throw new NotImplementedException("Write more code here");

            }
            return baseScenario;
        }

        public ScenarioFactory()
        {
            LegalValidWindow = TimeSpan.FromMinutes(5);
        }
    }
}
