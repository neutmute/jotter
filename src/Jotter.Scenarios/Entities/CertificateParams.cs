using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Jotter.Scenarios
{
    public class CertificateParams 
    {
        public X509Certificate2 Certificate { get; set; }
        
        public RSACryptoServiceProvider PrivateKey => FixCsp3(Certificate);

        public CertificateParams Clone()
        {
            var output = new CertificateParams();
            output.Certificate = Certificate;
            return output;
        }


        /// <summary>
        /// http://clrsecurity.codeplex.com/discussions/243156
        /// </summary>
        private static RSACryptoServiceProvider FixCsp3(X509Certificate2 cert)
        {
            var rsa = cert.PrivateKey as RSACryptoServiceProvider;
            var privateKeyBlob = rsa.ExportCspBlob(true);
            var rsa2 = new RSACryptoServiceProvider();
            rsa2.ImportCspBlob(privateKeyBlob);
            return rsa2;
        }
    }
}
