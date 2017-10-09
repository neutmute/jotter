using System;
using System.Collections.Generic;
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

        X509Certificate2 SigningCertificate { get; set; }
    }
}
