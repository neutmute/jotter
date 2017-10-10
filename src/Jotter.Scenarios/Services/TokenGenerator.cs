using Jose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Jotter.Scenarios
{
    public class TokenGenerator
    {
        internal static DateTimeOffset UnixEpoch = new DateTimeOffset(1970, 1, 1, 0, 0, 0, 0, TimeSpan.Zero);

        public List<ScenarioOutput> GenerateAll(ScenarioFactory factory, string certificateThumbprint)
        {
            var scenarios = ((JwtScenario[]) Enum.GetValues(typeof(JwtScenario))).ToList();
            scenarios.Remove(JwtScenario.Unspecified);
            
            var output = scenarios
                            .Select(scenario => Generate(factory, scenario, certificateThumbprint))
                            .ToList();
            
            return output;
        }

        public ScenarioOutput Generate(ScenarioFactory factory, JwtScenario scenario, string certificateThumbprint)
        {
            var options = factory.Generate(scenario, certificateThumbprint);
            return Generate(scenario, options);
        }

        public ScenarioOutput Generate(JwtScenario scenario, IJwtBuildOptions jwtOptions)
        {
            var payload = GetPayload(jwtOptions);

            var privateKey = jwtOptions.Signing?.PrivateKey;

            var output = new ScenarioOutput();
            output.Scenario = scenario;
            output.BuildOptions = jwtOptions;

            try
            {
                var algorithm = privateKey == null ? JwsAlgorithm.none : JwsAlgorithm.RS256;

                output.Token = JWT.Encode(
                    payload
                    , privateKey
                    , algorithm
                    , jwtOptions.ExtraHeaders);
            }
            catch(Exception e)
            {
                throw new Exception($"Failed to encode {scenario}", e);
            }
            
            return output;
        }

        private static Dictionary<string, object> GetPayload(IJwtBuildOptions scenario)
        {
            var payload = scenario.Claims.ToDictionary(c => c.Type, c => (object)c.Value);

            Func<DateTimeOffset, string> timeToJwt = time =>
            {
                var timeSpan = time - UnixEpoch;
                return Convert.ToInt64(Math.Round(timeSpan.TotalSeconds, 0)).ToString();
            };

            payload.Add("nbf", timeToJwt(scenario.NotBefore));
            payload.Add("iat", timeToJwt(scenario.Created));
            payload.Add("exp", timeToJwt(scenario.NotAfter));
            payload.Add("iss", scenario.Issuer);
            payload.Add("aud", scenario.Audience);

            return payload;
        }
    }
}
