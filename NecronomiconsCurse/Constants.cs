namespace NecronomiconsCurse;

public static class Constants
{
    public static bool Debug => ModSettings.GetBool("Enable Debugging", "alchlcsystm.cursed");
    public static bool ChatLog => ModSettings.GetBool("Disable Chat Logs", "alchlcsystm.cursed");
    public static bool LastWills => ModSettings.GetBool("Disable Last Wills", "alchlcsystm.cursed");
    public static bool DeathNotes => ModSettings.GetBool("Disable Death Notes", "alchlcsystm.cursed");
    public static bool CausesOfDeath => ModSettings.GetBool("Disable Cause Of Death", "alchlcsystm.cursed");
}