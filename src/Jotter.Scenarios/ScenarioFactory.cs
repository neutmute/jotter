using System;

namespace Jotter.Scenarios
{
    public class ScenarioFactory
    {
        /// <summary>
        /// Should make a new scenario each time
        /// </summary>
        public Func<JwtBuilderParams> GetGoodScenario { get; set; }


        /// <summary>
        /// Certificate that should be rejected by the host
        /// </summary>
        public CertificateParams InvalidSigningCertificate { get; set; }

        public TimeSpan LegalValidWindow { get; set; }

        public IJwtBuilderParams GetParameters(JwtScenario scenario)
        {
            var baseScenario = GetGoodScenario();
            switch(scenario)
            {
                case JwtScenario.Unspecified:
                    throw new NotSupportedException("Pick a valid scenario!");
                case JwtScenario.Good:
                    baseScenario.NotAfter = DateTimeOffset.Now.AddYears(10);
                    break;
                case JwtScenario.GoodLongLife:
                    baseScenario.NotAfter = DateTimeOffset.Now.AddYears(10);
                    break;
                case JwtScenario.Expired:
                    baseScenario.NotBefore = DateTimeOffset.Now.AddMinutes(-10);
                    baseScenario.NotAfter = DateTimeOffset.Now.AddMinutes(-1);
                    break;
                case JwtScenario.NotSigned:
                    baseScenario.Signing.PrivateKey = null;
                    break;
                case JwtScenario.ValidWindowTooLarge:
                    baseScenario.NotBefore = baseScenario.NotBefore - LegalValidWindow;
                    break;
                case JwtScenario.WrongCertificate:
                    baseScenario.Signing = InvalidSigningCertificate;
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
