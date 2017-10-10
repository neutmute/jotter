using System.ComponentModel;
using System.Text;

namespace Jotter.Scenarios
{
    public enum JwtScenario
    {
        Unspecified = 0,
        
        [Description("A valid JWT")]
        Good,

        [Description("JWT that doesn't expire until the far future")]
        GoodLongLife,

        [Description("JWT whose expiry is in the past")]
        Expired,

        [Description("An unsigned JWT")]
        NotSigned,

        [Description("JWT whose lifetime is slightly too long")]
        ValidWindowTooLarge,

        [Description("JWT created in the near future")]
        FutureIssuedAt,

        [Description("JWT missing the subject claim")]
        MissingSubject,

        [Description("Missing kid header")]
        MissingKid,

        [Description("JWT with incorrect issuer")]
        BadIssuer,

        [Description("JWT with incorrect audience")]
        BadAudience
    }
}
