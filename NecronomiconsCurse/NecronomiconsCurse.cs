using static SML.Mod;
using Game.Interface;
using Witchcraft.Modules;
using Witchcraft.Utils;
using UObject = UnityEngine.Object;
using Game.Chat;
using static SML.ModSettings;

namespace NecronomiconsCurse;

[SalemMod, SalemMenuItem, DynamicSettings]
public class NecronomiconsCurse : BaseMod<NecronomiconsCurse>
{
    public override string Name => "NecrosCurse";

    public override void Start()
    {
        Message("Cursed!", true);
    }

    public CheckboxSetting DisableLogs => new()
    {
        Name = "Disable Chat Logs",
        Description = "Toggles whether you can open the game's chat logs",
        DefaultValue = false,
        AvailableInGame = true,
        OnChanged = ReloadChatLog
    };

    public CheckboxSetting DisableWills => new()
    {
        Name = "Disable Last Wills",
        Description = "Toggles whether you can read others' last wills after it is displayed",
        DefaultValue = false,
        AvailableInGame = true,
        OnChanged = ReloadPlayerPopOuts
    };

    public CheckboxSetting DisableNotes => new()
    {
        Name = "Disable Death Notes",
        Description = "Toggles whether you can read death notes after they have been displayed",
        AvailableInGame = true,
        OnChanged = ReloadPlayerPopOuts
    };

    public CheckboxSetting DisableDeaths => new()
    {
        Name = "Disable Cause Of Death",
        Description = "Toggles whether you can see a player's cause of death",
        AvailableInGame = true,
        OnChanged = ReloadPlayerPopOuts
    };

    public CheckboxSetting DisableChatSrcoller => new()
    {
        Name = "Disable Chat Scroller",
        Description = "Toggles whether you can move up the chat",
        DefaultValue = false,
        AvailableInGame = true,
        OnChanged = ReloadChatScroller,
        Available = Constants.ChatLog()
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

    private static void ReloadChatScroller(bool inactive)
    {
        if (Constants.IsInvalidMode())
            return;

        UObject.FindObjectsOfType<PooledChatController>(true).ForEach(x => x.chatScrollBar.gameObject.SetActive(!inactive));
    }
}