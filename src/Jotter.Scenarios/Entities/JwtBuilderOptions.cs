using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace Jotter.Scenarios
{
    public class JwtBuilderOptions : JwtBuilderOptionsUnsigned, IJwtBuildOptions
    {
        public CertificateParams Signing { get; set; }

        public JwtBuilderOptions()
        {
            Signing = new CertificateParams();
        }
    }
    
    public class JwtBuilderOptionsUnsigned : IJwtBuildOptionsUnsigned
    {
        private DateTimeOffset _now;

        public string Audience { get; set; }

        public string Issuer { get; set; }
        
        public X509Certificate2 SigningCertificate { get; set; }

        public List<Claim> Claims { get; private set; }

        public DateTimeOffset Created { get; set; }

        public DateTimeOffset NotBefore { get; set; }

        public DateTimeOffset NotAfter { get; set; }


        public Dictionary<string, object> ExtraHeaders { get; private set; }

        public JwtBuilderOptionsUnsigned()
        {
            _now = DateTimeOffset.Now;
            Claims = new List<Claim>();
            ExtraHeaders = new Dictionary<string, object>();
        }

        public void AddClaim(string type, string value)
        {
            Claims.Add(new Claim(type, value));
        }
    }
}
