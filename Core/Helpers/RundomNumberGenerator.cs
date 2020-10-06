using System;
namespace University.Core.Helpers
{
    public class RandomNumberGenerator
    {
        public static int GenerateVerificationCode()
        {
            return new Random().Next(100000, 999999);
        }
    }
}
