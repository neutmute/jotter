using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Jotter.Scenarios
{
    public interface IJwtBuildOptions
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
}
