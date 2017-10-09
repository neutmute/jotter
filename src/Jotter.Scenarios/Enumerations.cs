using System.Text;

namespace Jotter.Scenarios
{
    public enum JwtScenario
    {
        Unspecified = 0,
        Good,
        GoodLongLife,
        Expired,
        TooEarly,
        WrongCertificate,
        NotSigned,
        ValidWindowTooLarge
    }
}
