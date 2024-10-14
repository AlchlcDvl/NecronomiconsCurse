using static SML.Mod;
using Game.Interface;
using Witchcraft.Modules;
using Witchcraft.Utils;
using UObject = UnityEngine.Object;

namespace NecronomiconsCurse;

[SalemMod]
[SalemMenuItem]
[DynamicSettings]
[WitchcraftMod(typeof(NecronomiconsCurse), "NecrosCurse")]
public class NecronomiconsCurse
{
    public static WitchcraftModAttribute? Instance { get; private set; }

    public void Start()
    {
        Instance = ModSingleton<NecronomiconsCurse>.Instance!;
        Instance.Message("Cursed!", true);
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

    private static void ReloadChatLog(bool inactive)
    {
        if (Constants.IsInvalidMode())
            return;

        UObject.FindObjectsOfType<PooledChatViewSwitcher>(true).ForEach(x => x.ExpandButtonGO.SetActive(!inactive));
    }

    private static void ReloadPlayerPopOuts(bool _)
    {
        if (Constants.IsInvalidMode())
            return;

        UObject.FindObjectsOfType<PlayerPopupController>(true).ForEach(x => x.Validate());
    }
}