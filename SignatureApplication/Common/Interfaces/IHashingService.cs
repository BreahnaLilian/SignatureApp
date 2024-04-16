using System.Security.Cryptography;

namespace SignatureApplication.Common.Interfaces
{
    public interface IHashingService
    {
        public string GetHashSHA256(string input);

        public bool VerifyHashSHA256(string input, string hash);
    }
}
