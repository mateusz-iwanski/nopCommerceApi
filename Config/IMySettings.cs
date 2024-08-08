using Config.Net;

namespace nopCommerceApi.Config
{
    /// <summary>
    /// Custom settings interface
    /// 
    /// Respresent structure of the settings file
    /// <example>
    /// For example:
    /// If yout want to use it in code
    /// <code>
    /// IMySettings settings = new ConfigurationBuilder<IMySettings>()
    ///     .UseIniFile(filePath)
    ///     .Build();
    /// 
    /// settings.UsersPath
    /// </code>
    ///
    /// If you want to use DI
    /// <code>
    /// var settings = new ConfigurationBuilder<IMySettings>()
    ///     .UseIniFile("appsettings.ini")
    ///     .Build();
    /// builder.Services.AddSingleton<IMySettings>(settings);
    /// </code>
    /// </example>
    /// </summary>
    public interface IMySettings
    {
        /// <summary>
        /// Element of the structure settings file
        /// <example>
        /// Structure Ini file on this example:
        ///     [AuthenticationUsersAccountList]
        ///     FilePath=users.json
        /// </example>
        /// </summary>
        [Option(Alias = "AuthenticationUsersAccountList.FilePath")]
        string UsersFilePath { get; }

        [Option(Alias = "CustomerPassword.Format")]
        string CustomerPasswordFormat { get; }

        [Option(Alias = "CustomerPassword.EncryptionKeyLength")]
        int PasswordEncryptionKeyLength { get; }

        [Option(Alias = "CustomerPassword.HoneypotInputName")]
        string HoneypotInputName { get; }

        [Option(Alias = "CustomerPassword.PasswordFormat")]
        int PasswordFormat { get; }

        [Option(Alias = "CustomerPassword.PasswordSaltKeySize")]
        int PasswordSaltKeySize { get; }

        // nopCommerce file path
        [Option(Alias = "NopCommerceFilePath.ThumbsPath")]
        string ThumbsPath { get; }

        // nopCommerce enum type available id 
        [Option(Alias = "NopCommerceEnum.ProductType_AvailableId")]
        string ProductTypeAvailableId { get; }

        [Option(Alias = "NopCommerceEnum.GiftCardType_AvailableId")]
        string GiftCardTypeAvailableId { get; }

        [Option(Alias = "NopCommerceEnum.DownloadActivationType_AvailableId")]
        string DownloadActivationTypeAvailableId { get; }

        [Option(Alias = "NopCommerceEnum.RecurringProductCyclePeriod_AvailableId")]
        int RecurringProductCyclePeriodAvailableId { get; }

        [Option(Alias = "NopCommerceEnum.RentalPricePeriod_AvailableId")]
        int RentalPricePeriodAvailableId { get; }

        [Option(Alias = "NopCommerceEnum.ManageInventoryMethod_AvailableId")]
        string ManageInventoryMethodAvailableId { get; }

        [Option(Alias = "NopCommerceEnum.LowStockActivity_AvailableId")]
        string LowStockActivityAvailableId { get; }

        [Option(Alias = "NopCommerceEnum.BackorderMode_AvailableId")]
        string BackorderModeAvailableId { get; }

        [Option(Alias = "NopCommerceEnum.AttributeValueType_AvailableId")]
        string AttributeValueTypeAvailableId { get; }

        [Option(Alias = "NopCommerceEnum.AttributeControlType_AvailableId")]
        string AttributeControlTypeAvailableId { get; }
    }
}
