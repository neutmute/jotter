using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Jotter.Scenarios
{
    public class Claim
    {
        public string Type { get; set; }

        public object Value { get; set; }

        public Claim(string type, object value)
        {
            Type = type;
            Value = value;
        }
    }

    public class JwtBuilderParams : IJwtBuilderParams
    {
        private DateTimeOffset _now;

        public string Audience { get; set; }

        public string Issuer { get; set; }

        public X509Certificate2 SigningCertificate { get; set; }

        public List<Claim> Claims { get; private set; }

        public DateTimeOffset Created { get; set; }

        public DateTimeOffset NotBefore { get; set; }

        public DateTimeOffset NotAfter { get; set; }


        public JwtBuilderParams()
        {
            _now = DateTimeOffset.Now;
            Claims = new List<Claim>();
        }

        public void AddClaim(string type, string value)
        {
            Claims.Add(new Claim(type, value));
        }
    }
}
