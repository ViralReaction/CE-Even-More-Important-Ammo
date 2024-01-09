using HarmonyLib;
using RimWorld;

namespace CombatExtendedImportantAmmo
{
    // private void Tradeable::InitPriceDataIfNeeded()
    [HarmonyPatch(typeof(Tradeable))]
    [HarmonyPatch("InitPriceDataIfNeeded")]
    public static class Tradeable_InitPriceDataIfNeeded_Patch
    {

        public static void Postfix(ref Tradeable __instance, float ___priceGain_PlayerNegotiator, ref float ___pricePlayerBuy, ref float ___pricePlayerSell)
        {
            if(CombatExtendedImportantAmmo.settings.ammoIsCurrency)
            {
                if(__instance.ThingDef.thingClass == typeof(CombatExtended.AmmoThing))
                {
                    AmmoPrice price = new AmmoPrice(__instance, ___priceGain_PlayerNegotiator);
                    ___pricePlayerBuy = price.Buying();
                    ___pricePlayerSell = price.Selling();
                }
            }
        }
    }
}