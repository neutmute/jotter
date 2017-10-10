using System;

namespace Jotter.Scenarios
{
    public delegate JwtBuildOptions GenerateScenarioDelegate(string certificateThumbprint);

    internal class ScenarioFactory
    {
        internal IJwtBuildOptions Generate(JwtScenario scenario, ScenarioOptions options, string certificateThumbprint)
        {
            var baseScenario = options.GetGoodScenario(certificateThumbprint);
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
                case JwtScenario.TooSoon:
                    baseScenario.NotBefore = DateTimeOffset.Now.AddMinutes(10);
                    baseScenario.NotAfter = baseScenario.NotBefore.Add(options.LegalValidWindow);
                    break;
                case JwtScenario.FutureIssuedAt:
                    baseScenario.Created = DateTimeOffset.Now.AddMinutes(1);
                    break;
                case JwtScenario.NotSigned:
                    baseScenario.Signing = baseScenario.Signing.Clone();
                    baseScenario.Signing = null;
                    break;
                case JwtScenario.ValidWindowTooLarge:
                    baseScenario.NotAfter = baseScenario.NotBefore + options.LegalValidWindow + TimeSpan.FromMinutes(1);
                    break;
                case JwtScenario.MissingSubject:
                    baseScenario.Claims.RemoveAll(c => c.Type.ToLower().Equals("sub"));
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
    }
}
