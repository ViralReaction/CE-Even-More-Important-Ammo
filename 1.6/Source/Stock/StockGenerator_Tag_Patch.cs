using RimWorld;
using System.Collections.Generic;
using Verse;
using HarmonyLib;
using RimWorld.Planet;

namespace CombatExtendedImportantAmmo
{
    // public override IEnumerable<Thing> GenerateThings(PlanetTile forTile, Faction faction = null)
    [HarmonyPatch(typeof(StockGenerator_Tag))]
    [HarmonyPatch("GenerateThings")]
    public static class StockGenerator_Tag_Patch
    {
        private static readonly string AMMO_TAG = "CE_Ammo";
        private static bool bonusAdded = false;
        public static Faction traderFaction = null;

        public static void Postfix(StockGenerator_Tag __instance, ref IEnumerable<Thing> __result, PlanetTile forTile, Faction faction)
        {
            if(Traverse.Create(__instance).Field("tradeTag").GetValue<string>() == AMMO_TAG)
            {
                List<Thing> ammoList = new TraderAmmo(__result, forTile, traderFaction).List();
                if(!bonusAdded)
                {
                    bonusAdded = true;
                    ammoList.AddRange(new StockGeneratorBonus(__instance, forTile).List());
                    bonusAdded = false;
                }
                __result = ammoList;
            }
        }
    }
}