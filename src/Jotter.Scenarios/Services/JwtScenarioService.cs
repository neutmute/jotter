using System;
using System.Collections.Generic;
using System.Text;

namespace Jotter.Scenarios.Services
{
    public class JwtScenarioService
    {
        /// <summary>
        /// System.Components.DescriptionAttribute not available in .NET Standard 1.6
        /// </summary>
        public Dictionary<JwtScenario, string> GetDescriptions()
        {
            return new Dictionary<JwtScenario, string>
            {
                {JwtScenario.Good, "A valid JWT" }
               ,{JwtScenario.GoodLongLife, "JWT that doesn't expire until the far future" }
               ,{JwtScenario.NotSigned, "An unsigned JWT" }
               ,{JwtScenario.ValidWindowTooLarge, "JWT whose lifetime is slightly too long" }
               ,{JwtScenario.WrongCertificate, "JWT signed with invalid certificate" }
            };
        }
    }
}
