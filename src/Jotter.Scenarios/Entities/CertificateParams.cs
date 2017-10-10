using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Jotter.Scenarios
{
    public class CertificateParams 
    {
        public X509Certificate2 Certificate { get; set; }

        /// <summary>
        /// .net standard 1.4 can't access x509Cert private key
        /// </summary>
        public RSACryptoServiceProvider PrivateKey { get; set; }

        public CertificateParams Clone()
        {
            var output = new CertificateParams();
            output.Certificate = Certificate;
            output.PrivateKey = PrivateKey;
            return output;
        }
    }
}
