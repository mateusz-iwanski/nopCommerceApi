using nopCommerceApi.Config;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Services.Customer
{
    public class CustomerPasswordManager
    {
        public static CustomerPassword CreatePassword(Entities.Usable.Customer customer, string password, IMySettings settings)
        {
            PasswordEncryptionService _encryptionService = new PasswordEncryptionService(
                new SecuritySettings
                {
                    EncryptionKey = GenerateRandomDigitCode(settings.PasswordEncryptionKeyLength),
                    AdminAreaAllowedIpAddresses = null,
                    HoneypotEnabled = false,
                    HoneypotInputName = settings.HoneypotInputName,
                    AllowNonAsciiCharactersInHeaders = true,
                    UseAesEncryptionAlgorithm = true,
                    AllowStoreOwnerExportImportCustomersWithHashedPassword = true
                });

            var customerPassword = new CustomerPassword
            {
                CustomerId = customer.Id,
                CreatedOnUtc = DateTime.UtcNow
            };

            switch ((PasswordFormat)settings.PasswordFormat)
            {
                case PasswordFormat.Clear:
                    customerPassword.Password = password;
                    break;
                case PasswordFormat.Encrypted:
                    customerPassword.Password = _encryptionService.EncryptText(password);
                    break;
                case PasswordFormat.Hashed:
                    var saltKey = _encryptionService.CreateSaltKey(settings.PasswordSaltKeySize);
                    customerPassword.PasswordSalt = saltKey;
                    customerPassword.Password = _encryptionService.CreatePasswordHash(password, saltKey, settings.CustomerPasswordFormat);
                    break;
            }

            return customerPassword;
        }

        /// <summary>
        /// Generate random digit code
        /// </summary>
        /// <param name="length">Length</param>
        /// <returns>Result string</returns>
        public static string GenerateRandomDigitCode(int length)
        {
            using var random = new SecureRandomNumberGenerator();
            var str = string.Empty;
            for (var i = 0; i < length; i++)
                str = string.Concat(str, random.Next(10).ToString());
            return str;
        }
    }
}
