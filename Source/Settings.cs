using System;
using RimWorld;
using UnityEngine;
using Verse;

namespace CombatExtendedImportantAmmo
{
    public class Settings : ModSettings
    {
        // Economy
        public bool ammoIsCurrency = true;

        // Recipes
        public bool changeRecipes = true;
        public bool chemfuelRequired = true;
        public float recipeProductsMult = 0.1f;

        // Traders stock
        public bool changeTradersStock = true;
        public bool caravansHaveExplosives = true;

        // DEBUG
        public bool debugMode = false;

        public override void ExposeData()
        {
            base.ExposeData();
            // Economy
            Scribe_Values.Look<bool>(ref ammoIsCurrency, "ammoIsCurrency", true);
            // Recipes
            Scribe_Values.Look<bool>(ref changeRecipes, "changeRecipes", true);
            Scribe_Values.Look<bool>(ref chemfuelRequired, "chemfuelRequired", true);
            Scribe_Values.Look<float>(ref recipeProductsMult, "recipeProductsMult", 0.1f);
            // Traders stock
            Scribe_Values.Look<bool>(ref changeTradersStock, "changeTradersStock", true);
            Scribe_Values.Look<bool>(ref caravansHaveExplosives, "caravansHaveExplosives", true);
            // DEBUG
            Scribe_Values.Look<bool>(ref debugMode, "debugMode", false);
        }

        public void DoWindowContents(Rect canvas)
        {
            Listing_Standard list = new Listing_Standard();
            list.ColumnWidth = canvas.width;
            list.Begin(canvas);

            // Production
            // Category(list, "Production");
            list.CheckboxLabeled(
                    "Ammo is harder to produce",
                    ref changeRecipes,
                    "Change ammo recipes: decrease output amount, add chemfuel as ingredient. Somewhat balanced by reducing ingredients input."
            );
            if(changeRecipes)
            {
                // Text.Font = GameFont.Tiny;
                if(recipeProductsMult == 1)
                {
                    list.Label("Recipe output is not decreased");
                }
                else
                {
                    list.Label("Recipe output decreased " + Math.Round(1 / recipeProductsMult, 2) + "x times");
                }
                list.verticalSpacing = 0f;
                recipeProductsMult = 1 / list.Slider(Mathf.Round(1 / recipeProductsMult), 1, 100);
                // list.verticalSpacing = 2f;
                // Text.Font = GameFont.Small;
                list.CheckboxLabeled(
                        "Ammo requires chemfuel",
                        ref chemfuelRequired,
                        "Some of the ammunition require chemfuel as propellant for crafting.\n\nCan be unchecked, if another mod adds this (i.e. Combat Extended Propellant)."
                );
            }
            Text.Font = GameFont.Tiny;
            list.Label("Recipe changes require a restart");
            Text.Font = GameFont.Small;
            list.Gap(24f);

            // Traders
            // Category(list, "Traders");
            list.CheckboxLabeled(
                    "Traders have less ammo and relations impact ammo stock",
                    ref changeTradersStock,
                    "Traders have significantly less ammo for sale. Also, ammo stock depends on relations with trader faction and " +
                    "on commonality of the specified ammo."
            );
            list.CheckboxLabeled(
                    "Traders do not carry explosive ammo",
                    ref caravansHaveExplosives,
                    "Caravans and orbital traders do not bring mortar shells and other explosive ammo. Faction bases still have it in stock."
            );
            list.Gap(24f);
            list.CheckboxLabeled(
                    "Ammo is almost a currency",
                    ref ammoIsCurrency,
                    "Normally, everything costs 40% more when buying and 40% less when selling. Check this to change it to 15% for ammo, to make its trade price closer to its market value.\n\nThis will make you care more about ammo."
            );
            // DEBUG
            list.Gap(24f);
            if (Prefs.DevMode || debugMode)
            {
                list.CheckboxLabeled(
                    "DEBUG MODE",
                    ref debugMode,
                    "Debug mode. Switch on if you need it."
                );
            }
            list.End();
        }

        private void Category(Listing_Standard list, string title)
        {
            Text.Font = GameFont.Medium;
            list.Label(title);
            Text.Font = GameFont.Small;
            list.GapLine(2f);
        }
    }
}