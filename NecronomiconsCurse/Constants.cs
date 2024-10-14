using Server.Shared.Info;

namespace NecronomiconsCurse;

public static class Constants
{
    public static bool ChatLog() => ModSettings.GetBool("Disable Chat Logs", "alchlcsystm.cursed");

    public static bool LastWills() => ModSettings.GetBool("Disable Last Wills", "alchlcsystm.cursed");

    public static bool DeathNotes() => ModSettings.GetBool("Disable Death Notes", "alchlcsystm.cursed");

    public static bool CausesOfDeath() => ModSettings.GetBool("Disable Cause Of Death", "alchlcsystm.cursed");

    public static bool DisableRanked() => ModSettings.GetBool("Active In Ranked", "alchlcsystm.cursed");

    public static bool DisableRankedP() => ModSettings.GetBool("Active In Ranked Practice", "alchlcsystm.cursed");

    public static bool DisableClassic() => ModSettings.GetBool("Active In Classic", "alchlcsystm.cursed");

    public static bool IsInvalidMode()
    {
        try
        {
            return Pepper.GetCurrentGameMode().gameType switch
            {
                GameType.Ranked => DisableRanked(),
                GameType.Classic or GameType.NewPlayerClassic => DisableClassic(),
                GameType.RankedPractice => DisableRankedP(),
                GameType.Tutorial => true,
                _ => false
            };
        }
        catch
        {
            return false;
        }
    }
}