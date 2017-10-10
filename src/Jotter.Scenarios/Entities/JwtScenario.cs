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
        
        [Description("JWT whose not before is in the future")]
        TooSoon,

        [Description("JWT that is unsigned")]
        NotSigned,

        [Description("JWT whose lifetime is slightly too long")]
        ValidWindowTooLarge,

        /// <summary>
        /// This is a legal token really - allows for clock skew
        /// </summary>
        [Description("JWT created in the near future")]
        FutureIssuedAt,

        [Description("JWT missing the subject claim")]
        MissingSubject,

        [Description("JWT missing kid header")]
        MissingKid,

        [Description("JWT with incorrect issuer")]
        BadIssuer,

        [Description("JWT with incorrect audience")]
        BadAudience
    }
}
