using RimWorld;
using System.Linq;
using System.Collections.Generic;
using Verse;

namespace CombatExtendedImportantAmmo
{
    public class StockGeneratorBonus
    {
        private readonly StockGenerator_Tag generator;
        private readonly int tile;

        public StockGeneratorBonus(StockGenerator_Tag generator, int tile)
        {
            this.generator = generator;
            this.tile = tile;
        }

        public List<Thing> List()
        {
            List<Thing> bonusAmmoList = new List<Thing>(0);
            if(CombatExtendedImportantAmmo.settings.changeTradersStock)
            {
                if(Find.WorldObjects.SettlementBaseAt(tile) != null && !Find.WorldObjects.SettlementBaseAt(tile).Faction.IsPlayer)
                {
                    bonusAmmoList = generator.GenerateThings(tile).ToList();
                }
            }

            return bonusAmmoList;
        }
    }
}