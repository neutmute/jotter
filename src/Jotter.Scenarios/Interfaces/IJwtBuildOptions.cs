﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Jotter.Scenarios
{
    public interface IJwtBuildOptions : IJwtBuildOptionsUnsigned
    {
        CertificateParams Signing { get; set; }
    }

    public interface IJwtBuildOptionsUnsigned
    {
        string Audience { get; set; }

        List<Claim> Claims { get; }

        DateTimeOffset Created { get; set; }

        string Issuer { get; set; }

        DateTimeOffset NotAfter { get; set; }

        DateTimeOffset NotBefore { get; set; }

        Dictionary<string, object> ExtraHeaders { get;  }
    }
}
