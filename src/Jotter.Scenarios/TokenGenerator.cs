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

        public static string Generate(IJwtBuilderParams scenario)
        {
            var payload = GetPayload(scenario);

            var privateKey = scenario.Signing.PrivateKey;
            
            var output = JWT.Encode(
                payload
                , privateKey
                , JwsAlgorithm.RS256
                , scenario.ExtraHeaders);

            return output;
        }

        private static Dictionary<string, object> GetPayload(IJwtBuilderParams scenario)
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
