using Game.Interface;
using HarmonyLib;

namespace NecronomiconsCurse;

[HarmonyPatch(typeof(PooledChatViewSwitcher), nameof(PooledChatViewSwitcher.SetViewToChatLog))]
public static class PooledChatViewSwitcherSetViewToChatLogPatch
{
    public static bool Prefix()
    {
        if (Constants.IsInvalidMode())
            return true;

        return !Constants.ChatLog();
    }
}

[HarmonyPatch(typeof(PooledChatViewSwitcher), nameof(PooledChatViewSwitcher.Start))]
public static class PooledChatViewSwitcherStartPatch
{
    public static void Postfix(PooledChatViewSwitcher __instance)
    {
        if (Constants.IsInvalidMode())
            return;

        if (Constants.ChatLog())
            __instance.ExpandButtonGO.SetActive(false);
    }
}

[HarmonyPatch(typeof(PooledChatViewSwitcher), nameof(PooledChatViewSwitcher.SetChatLogIsVisible))]
public static class PooledChatViewSwitcherSetChatLogIsVisiblePatch
{
    public static bool Prefix(PooledChatViewSwitcher __instance, bool isVisible)
    {
        if (Constants.IsInvalidMode())
            return true;

        if (Constants.ChatLog() && isVisible)
            __instance.ExpandButtonGO.SetActive(false);

        return !Constants.ChatLog() || !isVisible;
    }
}

[HarmonyPatch(typeof(PlayerPopupController), nameof(PlayerPopupController.InitializeDeathInfoPanel))]
public static class PlayerPopupControllerInitializeDeathInfoPanelPatch
{
    public static bool Prefix(PlayerPopupController __instance)
    {
        if (Constants.IsInvalidMode())
            return true;

        if (Constants.CausesOfDeath())
            __instance.DeathInfoPanelGO.SetActive(false);

        return !Constants.CausesOfDeath();
    }
}

[HarmonyPatch(typeof(PlayerPopupController), nameof(PlayerPopupController.InitializeKilledByPanel))]
public static class PlayerPopupControllerInitializeKilledByPanelPatch
{
    public static bool Prefix(PlayerPopupController __instance)
    {
        if (Constants.IsInvalidMode())
            return true;

        if (Constants.CausesOfDeath())
            __instance.KilledByPanelGO.SetActive(false);

        return !Constants.CausesOfDeath();
    }
}

[HarmonyPatch(typeof(PlayerPopupController), nameof(PlayerPopupController.InitializeLastWillPanel))]
public static class PlayerPopupControllerInitializeLastWillPanelPatch
{
    public static bool Prefix(PlayerPopupController __instance)
    {
        if (Constants.IsInvalidMode())
            return true;

        if (Constants.LastWills())
            __instance.LastWillPanelGO.SetActive(false);

        return !Constants.LastWills();
    }
}

[HarmonyPatch(typeof(PlayerPopupController), nameof(PlayerPopupController.InitializeDeathNotePanel))]
public static class PlayerPopupControllerInitializeDeathNotePanelPatch
{
    public static bool Prefix(PlayerPopupController __instance)
    {
        if (Constants.IsInvalidMode())
            return true;

        if (Constants.DeathNotes())
            __instance.DeathNotePanelGO.SetActive(false);

        return !Constants.DeathNotes();
    }
}