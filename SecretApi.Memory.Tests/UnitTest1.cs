using System;
using System.Security.Cryptography;
using Xunit;

namespace SecretApi.Memory.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            using (var rnd = new RNGCryptoServiceProvider())
            {
                var key = new byte[64];
                rnd.GetBytes(key);

                var keyValue = Convert.ToBase64String(key);
            }
        }
    }
}
