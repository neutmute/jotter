using System;
using System.Collections.Generic;
using System.Text;

namespace Jotter.Scenarios
{

    //public class GoodDefaultScenario : JwtBuilderParams, IScenarioParams
    //{
    //    public virtual JwtScenario Scenario => JwtScenario.Good;

    //    public string TokenOutput { get; set; }

    //    public GoodDefaultScenario()
    //    {
    //        Audience = "https://stagingservices.chasdf.com.au";
    //        Issuer = "http://tenant-supplied-value";
    //        AddClaim("sub", "individual-user-name");
    //        Created = DateTimeOffset.Now;
    //        NotBefore = DateTimeOffset.Now;
    //        NotAfter = DateTimeOffset.Now.AddMinutes(5);
    //        SigningCertificate = TokenData.GetSigningCertificate();
    //    }
    //}

    //public class GoodLongLifeScenario : GoodDefaultScenario
    //{
    //    public override JwtScenario Scenario => JwtScenario.GoodLongLife;

    //    public GoodLongLifeScenario()
    //    {
    //        NotAfter = DateTimeOffset.Now.AddYears(10);
    //    }
    //}

    //public class ExpiredScenario : GoodDefaultScenario
    //{
    //    public override JwtScenario Scenario => JwtScenario.Expired;

    //    public ExpiredScenario()
    //    {
    //        NotBefore = DateTimeOffset.Now.AddMinutes(-10);
    //        NotAfter = DateTimeOffset.Now.AddMinutes(-1);
    //    }
    //}
}
