using RimWorld;
using UnityEngine;
using Verse;

namespace CombatExtendedImportantAmmo
{
    public class AmmoStack
    {
        private readonly Thing ammo;
        private readonly float traderBonusMult;

        public AmmoStack(Thing ammo, float traderBonusMult)
        {
            this.ammo = ammo;
            this.traderBonusMult = traderBonusMult;
        }

        public Thing Thing()
        {
            if(CombatExtendedImportantAmmo.settings.changeTradersStock)
            {
                int stackSize = Mathf.Max(1, Mathf.RoundToInt(traderBonusMult * (ammo.def.stackLimit * 0.005f * explosiveMultiplier() + massBonus())));
                stackSize = Mathf.RoundToInt(Rand.Range(Mathf.Max(1f, traderBonusMult * 0.6f) * stackSize, stackSize * (1f + traderBonusMult)));
                ammo.stackCount = stackSize;
            }
            return ammo;
        }

        private float explosiveMultiplier()
        {
            float mult = 1f;

            foreach(CompProperties cp in ammo.def.comps)
            {
                if(cp is CombatExtended.CompProperties_ExplosiveCE)
                {
                    mult = 0.3f;
                }
            }

            return mult;
        }

        private float massBonus()
        {
            float bonus = 0f;

            foreach(StatModifier sb in ammo.def.statBases)
            {
                if(sb.stat == StatDefOf.Mass)
                {
                    bonus = 2 / sb.value;
                }
            }

            return bonus;
        }
    }
}