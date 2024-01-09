using HarmonyLib;
using System.Reflection;
using Verse;

namespace CombatExtendedImportantAmmo
{
    [StaticConstructorOnStartup]
    static class CombatExtendedImportantAmmoHarmony
    {
        static CombatExtendedImportantAmmoHarmony()
        {
            Harmony harmony = new Harmony("vladlecteur.CombatExtendedImportantAmmo");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}