using HarmonyLib;
using RimWorld;

namespace CombatExtendedImportantAmmo
{
    // public string Tradeable::GetPriceTooltip(TradeAction action)
    [HarmonyPatch(typeof(Tradeable))]
    [HarmonyPatch("GetPriceTooltip")]
    public static class Tradeable_GetPriceTooltip_Patch
    {

        public static void Postfix(Tradeable __instance, ref string __result, float ___priceGain_PlayerNegotiator, TradeAction action)
        {
            if(CombatExtendedImportantAmmo.settings.ammoIsCurrency)
            {
                if(__instance.ThingDef.thingClass == typeof(CombatExtended.AmmoThing))
                {
                    __result = new AmmoPrice(__instance, ___priceGain_PlayerNegotiator).Tooltip(action);
                }
            }
        }
    }
}