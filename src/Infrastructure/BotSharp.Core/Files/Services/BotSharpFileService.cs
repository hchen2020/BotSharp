using Microsoft.AspNetCore.StaticFiles;
using System.IO;

namespace BotSharp.Core.Files.Services;

public partial class BotSharpFileService : IBotSharpFileService
{
    private readonly BotSharpDatabaseSettings _dbSettings;
    private readonly IServiceProvider _services;
    private readonly IUserIdentity _user;
    private readonly ILogger<BotSharpFileService> _logger;
    private readonly string _baseDir;
    private readonly IEnumerable<string> _imageTypes = new List<string>
    {
        MediaTypeNames.Image.Png,
        MediaTypeNames.Image.Jpeg
    };

    private const string CONVERSATION_FOLDER = "conversations";
    private const string FILE_FOLDER = "files";
    private const string USER_FILE_FOLDER = "user";
    private const string SCREENSHOT_FILE_FOLDER = "screenshot";
    private const string BOT_FILE_FOLDER = "bot";
    private const string USERS_FOLDER = "users";
    private const string USER_AVATAR_FOLDER = "avatar";
    private const string SESSION_FOLDER = "sessions";

    private const int MIN_OFFSET = 1;
    private const int MAX_OFFSET = 5;

    public BotSharpFileService(
        BotSharpDatabaseSettings dbSettings,
        IUserIdentity user,
        ILogger<BotSharpFileService> logger,
        IServiceProvider services)
    {
        _dbSettings = dbSettings;
        _user = user;
        _logger = logger;
        _services = services;
        _baseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dbSettings.FileRepository);
    }

    #region Private methods
    private bool ExistDirectory(string? dir)
    {
        return !string.IsNullOrEmpty(dir) && Directory.Exists(dir);
    }
    #endregion
}
