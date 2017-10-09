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


        public static List<ScenarioOutput> GenerateAll(ScenarioFactory factory)
        {
            var scenarios = ((JwtScenario[]) Enum.GetValues(typeof(JwtScenario))).ToList();
            scenarios.Remove(JwtScenario.Unspecified);
            
            var output = scenarios
                            .Select(s => Generate(factory, s))
                            .ToList();
            
            return output;
        }

        public static ScenarioOutput Generate(ScenarioFactory factory, JwtScenario scenario)
        {
            var options = factory.BuildOptions(scenario);
            return Generate(scenario, options);
        }

        public static ScenarioOutput Generate(JwtScenario scenario, IJwtBuildOptions jwtOptions)
        {
            var payload = GetPayload(jwtOptions);

            var privateKey = jwtOptions.Signing.PrivateKey;

            var output = new ScenarioOutput();
            output.Scenario = scenario;
            output.Token = JWT.Encode(
                payload
                , privateKey
                , JwsAlgorithm.RS256
                , jwtOptions.ExtraHeaders);
            
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

        /// <summary>
        /// http://clrsecurity.codeplex.com/discussions/243156
        /// </summary>
        //public static RSACryptoServiceProvider FixCsp3(X509Certificate2 cert)
        //{
        //    var rsa = cert.PrivateKey as RSACryptoServiceProvider;
        //    var privateKeyBlob = rsa.ExportCspBlob(true);
        //    var rsa2 = new RSACryptoServiceProvider();
        //    rsa2.ImportCspBlob(privateKeyBlob);
        //    return rsa2;
        //}
    }
}
