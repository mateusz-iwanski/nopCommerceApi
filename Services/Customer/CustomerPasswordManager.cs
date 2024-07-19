using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Services.Customer
{
    public class CustomerPasswordManager
    {
        public static CustomerPassword CreatePassword(PasswordFormat passwordFormat, Entities.Usable.Customer customer, string password)
        {
            PasswordEncryptionService _encryptionService = new PasswordEncryptionService(
                new SecuritySettings
                {
                    EncryptionKey = GenerateRandomDigitCode(16),
                    AdminAreaAllowedIpAddresses = null,
                    HoneypotEnabled = false,
                    HoneypotInputName = "hpinput",
                    AllowNonAsciiCharactersInHeaders = true,
                    UseAesEncryptionAlgorithm = true,
                    AllowStoreOwnerExportImportCustomersWithHashedPassword = true
                });

            var customerPassword = new CustomerPassword
            {
                CustomerId = customer.Id,
                PasswordFormatId = (int)passwordFormat,
                CreatedOnUtc = DateTime.UtcNow
            };

            switch (passwordFormat)
            {
                case PasswordFormat.Clear:
                    customerPassword.Password = password;
                    break;
                case PasswordFormat.Encrypted:
                    customerPassword.Password = _encryptionService.EncryptText(password);
                    break;
                case PasswordFormat.Hashed:
                    // default from nopcommerce class NopCustomerServicesDefaults
                    // Gets a password salt key size
                    //public static int PasswordSaltKeySize => 5;
                    //public static string DefaultHashedPasswordFormat => "SHA512"; - Gets or sets a customer password format (SHA1, MD5) when passwords are hashed (DO NOT edit in production environment)

                    var saltKey = _encryptionService.CreateSaltKey(5);
                    customerPassword.PasswordSalt = saltKey;
                    customerPassword.Password = _encryptionService.CreatePasswordHash(password, saltKey, "SHA512");
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
