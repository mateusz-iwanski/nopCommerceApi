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
    }
}
