using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Jotter.Scenarios
{
    public interface IJwtBuilderParams
    {
        string Audience { get; set; }

        List<Claim> Claims { get; }

        DateTimeOffset Created { get; set; }

        string Issuer { get; set; }

        DateTimeOffset NotAfter { get; set; }

        DateTimeOffset NotBefore { get; set; }

        CertificateParams Signing { get; set; }

        Dictionary<string, object> ExtraHeaders { get;  }
    }


    public class CertificateParams
    {
        public X509Certificate2 Certificate { get; set; }

        /// <summary>
        /// .net standard 1.4 can't access x509Cert private key
        /// </summary>
        public RSACryptoServiceProvider PrivateKey { get; set; }
    }
}
