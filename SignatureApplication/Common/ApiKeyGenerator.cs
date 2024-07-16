using System.Security.Cryptography;
using System.Text;

namespace SignatureApplication.Common
{
    public static class ApiKeyGenerator
    {
        public static string GenerateApiKey(int length = 32 )
        {
            const string validCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

            return GenerateString(validCharacters, length);
        }
        
        public static string GeneratePassword(int length = 16 )
        {
            const string validCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890[]{}()'/,.@#$%^&*!?+_=-\\|`~";

            return GenerateString(validCharacters, length);
        }

        private static string GenerateString(string validCharacters, int length)
        {
            StringBuilder apiKey = new StringBuilder();
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] buffer = new byte[128];
                while (apiKey.Length < length)
                {
                    rng.GetBytes(buffer);
                    for (int i = 0; i < buffer.Length && apiKey.Length < length; i++)
                    {
                        // Use modulo to get a valid character index and append to the apiKey
                        apiKey.Append(validCharacters[buffer[i] % validCharacters.Length]);
                    }
                }
            }
            return apiKey.ToString();
        }
    }
}
