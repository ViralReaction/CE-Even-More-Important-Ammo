using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using Verse;

namespace CombatExtendedImportantAmmo
{
    // protected override void ThingSetMaker_TraderStock::Generate(ThingSetMakerParams parms, List<Thing> outThings)
    [HarmonyPatch(typeof(ThingSetMaker_TraderStock))]
    [HarmonyPatch("Generate")]
    [HarmonyPatch(new Type[] { typeof(ThingSetMakerParams), typeof(List<Thing>) })]
    public static class ThingSetMaker_TraderStock_Patch
    {
        public static bool Prefix(ThingSetMakerParams parms)
        {
            StockGenerator_Tag_Patch.traderFaction = parms.makingFaction;
            return true;
        }
    }
}