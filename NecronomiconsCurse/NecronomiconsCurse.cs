using BepInEx.Logging;
using Game.Interface;
using UObject = UnityEngine.Object;

namespace NecronomiconsCurse;

[SalemMod]
[SalemMenuItem]
[DynamicSettings]
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

    public ModSettings.CheckboxSetting DisableLogs => new()
    {
        Name = "Disable Chat Logs",
        Description = "Toggles whether you can open the game's chat logs",
        DefaultValue = false,
        AvailableInGame = true,
        OnChanged = ReloadChatLog
    };

    public ModSettings.CheckboxSetting DisableWills => new()
    {
        Name = "Disable Last Wills",
        Description = "Toggles whether you can read others' last wills after it is displayed",
        DefaultValue = false,
        AvailableInGame = true,
        OnChanged = ReloadPlayerPopOuts
    };

    public ModSettings.CheckboxSetting DisableNotes => new()
    {
        Name = "Disable Death Notes",
        Description = "Toggles whether you can read death notes after they have been displayed",
        DefaultValue = false,
        AvailableInGame = true,
        OnChanged = ReloadPlayerPopOuts
    };

    public ModSettings.CheckboxSetting DisableDeaths => new()
    {
        Name = "Disable Cause Of Death",
        Description = "Toggles whether you can see a player's cause of death",
        DefaultValue = false,
        AvailableInGame = true,
        OnChanged = ReloadPlayerPopOuts
    };

    private static void ReloadChatLog(bool active)
    {
        if (Constants.IsInvalidMode)
            return;

        UObject.FindObjectsOfType<PooledChatViewSwitcher>(true).ForEach(x => x.ExpandButtonGO.SetActive(active));
    }

    private static void ReloadPlayerPopOuts(bool _)
    {
        if (Constants.IsInvalidMode)
            return;

        UObject.FindObjectsOfType<PlayerPopupController>(true).ForEach(x => x.Validate());
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
