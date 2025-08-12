using RimWorld;
using System.Collections.Generic;
using Verse;

namespace CombatExtendedImportantAmmo
{
    public class TraderAmmo
    {
        private readonly IEnumerable<Thing> ammoList;
        private readonly int tile;
        private readonly Faction traderFaction;

        public TraderAmmo(IEnumerable<Thing> list, int tile, Faction traderFaction)
        {
            this.ammoList = list;
            this.tile = tile;
            this.traderFaction = traderFaction;
        }

        public List<Thing> List()
        {
            List<Thing> result = new List<Thing>();

            float traderBonusMult = 1f;
            if(CombatExtendedImportantAmmo.settings.changeTradersStock)
            {
                if(traderFaction != null)
                {
                    traderBonusMult = traderBonusMult + (traderFaction.GoodwillWith(Faction.OfPlayer) / 100f);

                    if(traderFaction.def.techLevel < TechLevel.Industrial)
                    {
                        traderBonusMult = traderBonusMult * 3;
                    }
                }

                if(!isFactionBase())
                {
                    traderBonusMult = traderBonusMult * 0.5f;
                }
            }

            foreach(Thing thing in ammoList)
            {
                if(canAmmoBeAdded(thing))
                {
                    result.Add(new AmmoStack(thing, traderBonusMult).Thing());
                }
            }

            return result;
        }

        private bool canAmmoBeAdded(Thing ammo)
        {
            if(CombatExtendedImportantAmmo.settings.caravansHaveExplosives)
            {
                if(!isFactionBase() && isExplosive(ammo))
                {
                    return false;
                }
            }
            return true;
        }

        private bool isFactionBase()
        {
            if(Find.WorldObjects.SettlementBaseAt(tile) == null || Find.WorldObjects.SettlementBaseAt(tile).Faction.IsPlayer)
            {
                return false;
            }
            return true;
        }

        private bool isExplosive(Thing ammo)
        {
            foreach(CompProperties cp in ammo.def.comps)
            {
                if(cp is CombatExtended.CompProperties_ExplosiveCE)
                {
                    return true;
                }
            }
            return false;
        }
    }
}