using BepInEx.Logging;

namespace NecronomiconsCurse;

[SalemMod]
[SalemMenuItem]
public class NecronomiconsCurse
{
    private static readonly ManualLogSource Log = BepInEx.Logging.Logger.CreateLogSource("NecrosCurse");
    public static string SavedLogs = "";

    public static string ModPath => Path.Combine(Path.GetDirectoryName(Application.dataPath), "SalemModLoader", "ModFolders", "NecronomiconsCurse");

    public void Start()
    {
        if (!Directory.Exists(ModPath))
            Directory.CreateDirectory(ModPath);

        LogMessage("Cursed!", true);
    }

    private static void LogSomething(object message, LogLevel type, bool logIt)
    {
        logIt = logIt || Constants.Debug;
        message = $"[{DateTime.UtcNow}] {message}";

        if (logIt)
            Log?.Log(type, message);

        SavedLogs += $"[{type, -7}] {message}\n";
    }

    public static void LogError(object message) => LogSomething(message, LogLevel.Error, true);

    public static void LogMessage(object message, bool logIt = false) => LogSomething(message, LogLevel.Message, logIt);

    public static void LogFatal(object message) => LogSomething(message, LogLevel.Fatal, true);

    public static void LogInfo(object message, bool logIt = false) => LogSomething(message, LogLevel.Info, logIt);

    public static void LogWarning(object message, bool logIt = false) => LogSomething(message, LogLevel.Warning, logIt);

    public static void LogDebug(object message, bool logIt = false) => LogSomething(message, LogLevel.Debug, logIt);

    public static void LogNone(object message, bool logIt = false) => LogSomething(message, LogLevel.None, logIt);

    public static void LogAll(object message, bool logIt = false) => LogSomething(message, LogLevel.All, logIt);

    public static void SaveLogs()
    {
        try
        {
            File.WriteAllText(Path.Combine(ModPath, "NecrosCurse.txt"), SavedLogs);
        }
        catch
        {
            LogError("Unable to save logs");
        }
    }
}
