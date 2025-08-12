using RimWorld;
using UnityEngine;
using Verse;

namespace CombatExtendedImportantAmmo
{
    public class AmmoPrice
    {
        private readonly Tradeable ammo;
        private readonly float negotiatorBonus;

        public AmmoPrice(Tradeable ammo, float negotiatorBonus)
        {
            this.ammo = ammo;
            this.negotiatorBonus = negotiatorBonus;
        }

        public string Tooltip(TradeAction action)
        {
            string text;
            // Action description
            if(action == TradeAction.PlayerBuys)
            {
                text = "BuyPriceDesc".Translate();
            }
            else
            {
                text = "SellPriceDesc".Translate();
            }
            text = text + "\n\n";
            // MarketValue and modifiers
            text = text + StatDefOf.MarketValue.LabelCap + ": " + ammo.BaseMarketValue.ToStringMoney("F2");
            text = text + "\n";
            if(action == TradeAction.PlayerBuys)
            {
                text = text + " x 1.15 (" + "Buying".Translate() + ")";
            }
            else
            {
                text = text + " x 0.85 (" + "Selling".Translate() + ")";
            }
            text = text + "\n\n";
            // Negotiator bonus
            text = text + "YourNegotiatorBonus".Translate() + ": ";
            if(action == TradeAction.PlayerBuys)
            {
                text = text + "-";
            }
            text = text + (negotiatorBonus * 0.5f).ToStringPercent();
            text = text + "\n\n";
            // Final Value
            text = text + "FinalPrice".Translate() + ": $";
            if(action == TradeAction.PlayerBuys)
            {
                text = text + Buying().ToString("F2");
            }
            else
            {
                text = text + Selling().ToString("F2");
            }

            return text;
        }

        public float Buying()
        {
            return ammo.BaseMarketValue * 1.15f * (1f - (negotiatorBonus * 0.5f));
        }

        public float Selling()
        {
            return Mathf.Min(Buying(), ammo.BaseMarketValue * 0.85f * (1f + (negotiatorBonus * 0.5f)));
        }
    }
}