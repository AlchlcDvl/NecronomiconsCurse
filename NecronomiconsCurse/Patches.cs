using Game.Interface;
using Home.Shared;

namespace NecronomiconsCurse;

[HarmonyPatch(typeof(PooledChatViewSwitcher), nameof(PooledChatViewSwitcher.SetViewToChatLog))]
public static class PooledChatViewSwitcherSetViewToChatLogPatch
{
    public static bool Prefix()
    {
        NecronomiconsCurse.LogMessage("Patching PooledChatViewSwitcher.SetViewToChatLog");

        if (Constants.IsInvalidMode)
            return true;

        return !Constants.ChatLog;
    }
}

[HarmonyPatch(typeof(PooledChatViewSwitcher), nameof(PooledChatViewSwitcher.Start))]
public static class PooledChatViewSwitcherStartPatch
{
    public static void Postfix(PooledChatViewSwitcher __instance)
    {
        NecronomiconsCurse.LogMessage("Patching PooledChatViewSwitcher.Start");

        if (Constants.IsInvalidMode)
            return;

        if (Constants.ChatLog)
            __instance.ExpandButtonGO.SetActive(false);
    }
}

[HarmonyPatch(typeof(PooledChatViewSwitcher), nameof(PooledChatViewSwitcher.SetChatLogIsVisible))]
public static class PooledChatViewSwitcherSetChatLogIsVisiblePatch
{
    public static bool Prefix(PooledChatViewSwitcher __instance, ref bool isVisible)
    {
        NecronomiconsCurse.LogMessage("Patching PooledChatViewSwitcher.SetChatLogIsVisible");

        if (Constants.IsInvalidMode)
            return true;

        if (Constants.ChatLog && isVisible)
            __instance.ExpandButtonGO.SetActive(false);

        return !Constants.ChatLog || !isVisible;
    }
}

[HarmonyPatch(typeof(PlayerPopupController), nameof(PlayerPopupController.InitializeDeathInfoPanel))]
public static class PlayerPopupControllerInitializeDeathInfoPanelPatch
{
    public static bool Prefix(PlayerPopupController __instance)
    {
        NecronomiconsCurse.LogMessage("Patching PlayerPopupController.InitializeDeathInfoPanel");

        if (Constants.IsInvalidMode)
            return true;

        if (Constants.CausesOfDeath)
            __instance.DeathInfoPanelGO.SetActive(false);

        return !Constants.CausesOfDeath;
    }
}

[HarmonyPatch(typeof(PlayerPopupController), nameof(PlayerPopupController.InitializeKilledByPanel))]
public static class PlayerPopupControllerInitializeKilledByPanelPatch
{
    public static bool Prefix(PlayerPopupController __instance)
    {
        NecronomiconsCurse.LogMessage("Patching PlayerPopupController.InitializeKilledByPanel");

        if (Constants.IsInvalidMode)
            return true;

        if (Constants.CausesOfDeath)
            __instance.KilledByPanelGO.SetActive(false);

        return !Constants.CausesOfDeath;
    }
}

[HarmonyPatch(typeof(PlayerPopupController), nameof(PlayerPopupController.InitializeLastWillPanel))]
public static class PlayerPopupControllerInitializeLastWillPanelPatch
{
    public static bool Prefix(PlayerPopupController __instance)
    {
        NecronomiconsCurse.LogMessage("Patching PlayerPopupController.InitializeLastWillPanel");

        if (Constants.IsInvalidMode)
            return true;

        if (Constants.LastWills)
            __instance.LastWillPanelGO.SetActive(false);

        return !Constants.LastWills;
    }
}

[HarmonyPatch(typeof(PlayerPopupController), nameof(PlayerPopupController.InitializeDeathNotePanel))]
public static class PlayerPopupControllerInitializeDeathNotePanelPatch
{
    public static bool Prefix(PlayerPopupController __instance)
    {
        NecronomiconsCurse.LogMessage("Patching PlayerPopupController.InitializeDeathNotePanel");

        if (Constants.IsInvalidMode)
            return true;

        if (Constants.DeathNotes)
            __instance.DeathNotePanelGO.SetActive(false);

        return !Constants.DeathNotes;
    }
}

[HarmonyPatch(typeof(ApplicationController), nameof(ApplicationController.QuitGame))]
public static class ExitGamePatch
{
    public static void Prefix()
    {
        NecronomiconsCurse.LogMessage("Patching ApplicationController.QuitGame");
        NecronomiconsCurse.SaveLogs();
    }
}