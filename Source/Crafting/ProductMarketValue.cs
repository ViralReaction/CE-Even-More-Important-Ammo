using RimWorld;
using System.Linq;
using Verse;
using UnityEngine;

namespace CombatExtendedImportantAmmo
{
    public class ProductMarketValue
    {
        private readonly RecipeDef recipe;

        public ProductMarketValue(RecipeDef recipe)
        {
            this.recipe = recipe;
        }

        public void Recalculate()
        {
            float cost = (recipe.ingredients.Count * 90f + recipe.workAmount + 90f) * 0.01f;
            cost = cost * 0.35f;
            foreach(IngredientCount ingredient in recipe.ingredients)
            {
                if(ingredient.IsFixedIngredient)
                {
                    cost = cost + ingredient.GetBaseCount() * ingredient.FixedIngredient.BaseMarketValue;
                }
            }
            cost = cost * 0.85f;
            cost = cost * Mathf.Max(1f, (recipe.products[0].thingDef.techLevel - TechLevel.Industrial));
            recipe.products[0].thingDef.BaseMarketValue = cost / recipe.products[0].count;
        }
    }
}