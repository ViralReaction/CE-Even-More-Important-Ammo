using RimWorld;
using UnityEngine;
using Verse;

namespace CombatExtendedImportantAmmo
{
    public class RecipeInput
    {
        private static readonly ThingDef CHEMFUEL = ThingDefOf.Chemfuel;

        private readonly RecipeDef recipe;

        public RecipeInput(RecipeDef recipe)
        {
            this.recipe = recipe;
        }

        public void Tweak(float productCount)
        {
            bool hasChemfuel = false;
            float totalIngredientsCount = 0;
            int i = 0;
            foreach(IngredientCount ingredient in recipe.ingredients)
            {
                float count = ingredient.GetBaseCount() / (7 * Mathf.Min(1f, productCount * 1.1f));
                if(i > 0)
                {
                    count = count * 0.5f;
                }
                count = Mathf.Max(1, count + ingredient.GetBaseCount() / (0.5f / CombatExtendedImportantAmmo.settings.recipeProductsMult));
                ingredient.SetBaseCount(Mathf.RoundToInt(count));
                i = i + 1;
                if(recipe.ProducedThingDef.techLevel == TechLevel.Industrial)
                {
                    if(ingredient.IsFixedIngredient && ingredient.FixedIngredient == CHEMFUEL)
                    {
                        hasChemfuel = true;
                    }
                }
                totalIngredientsCount = totalIngredientsCount + count;
            }

            if(CombatExtendedImportantAmmo.settings.chemfuelRequired)
            {
                if(recipe.ProducedThingDef.techLevel == TechLevel.Industrial)
                {
                    if(!hasChemfuel)
                    {
                        IngredientCount ic = new IngredientCount();
                        ic.SetBaseCount(Mathf.Floor(1 + totalIngredientsCount / 7));
                        ic.filter.SetAllow(CHEMFUEL, true);
                        recipe.ingredients.Add(ic);
                        recipe.defaultIngredientFilter.SetAllow(CHEMFUEL, true);
                        recipe.fixedIngredientFilter.SetAllow(CHEMFUEL, true);
                    }
                }
            }
        }
    }
}