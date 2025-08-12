using CombatExtended;
using HarmonyLib;

namespace CombatExtendedImportantAmmo
{
    [HarmonyPatch(typeof(BoundsInjector))]
    [HarmonyPatch("Inject")]
    public static class BoundsInjector_Patch
    {
        public static void Postfix()
        {
            new AmmoRecipesDebug().Tweak();
        }
    }
}