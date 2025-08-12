using UnityEngine;
using Verse;

namespace CombatExtendedImportantAmmo
{
    public class RecipeOutput
    {
        private readonly RecipeDef recipe;
        private readonly float originalCount;

        public RecipeOutput(RecipeDef recipe, float originalCount)
        {
            this.recipe = recipe;
            this.originalCount = originalCount;
        }

        public void Tweak()
        {
            recipe.products[0].count = Mathf.RoundToInt(Mathf.Max(1f, Count()));
        }

        public float Count()
        {
            float count = originalCount / (1 / CombatExtendedImportantAmmo.settings.recipeProductsMult);
            count = Mathf.Max(count, Mathf.Round(count / 5f) * 5f);
            return count;
        }
    }
}