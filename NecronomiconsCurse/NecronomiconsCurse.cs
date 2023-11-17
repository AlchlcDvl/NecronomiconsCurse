using BepInEx.Logging;

namespace NecronomiconsCurse;

[SalemMod]
[SalemMenuItem]
public class NecronomiconsCurse
{
    private static readonly ManualLogSource Log = Logger.CreateLogSource("NecrosCurse");
    public static string SavedLogs = "";

    public void Start()
    {
        LogMessage("Cursed!", true);
    }

    private static void LogSomething(object message, LogLevel type, bool logIt)
    {
        logIt = logIt || Constants.Debug;

        if (logIt)
            Log?.Log(type, message);

        SavedLogs += $"[{type, -7}] {message}\n";
    }

    public static void LogError(object message, bool logIt = false) => LogSomething(message, LogLevel.Error, logIt);

    public static void LogMessage(object message, bool logIt = false) => LogSomething(message, LogLevel.Message, logIt);

    public static void LogFatal(object message, bool logIt = false) => LogSomething(message, LogLevel.Fatal, logIt);

    public static void LogInfo(object message, bool logIt = false) => LogSomething(message, LogLevel.Info, logIt);

    public static void LogWarning(object message, bool logIt = false) => LogSomething(message, LogLevel.Warning, logIt);

    public static void LogDebug(object message, bool logIt = false) => LogSomething(message, LogLevel.Debug, logIt);

    public static void LogNone(object message, bool logIt = false) => LogSomething(message, LogLevel.None, logIt);

    public static void LogAll(object message, bool logIt = false) => LogSomething(message, LogLevel.All, logIt);
}
