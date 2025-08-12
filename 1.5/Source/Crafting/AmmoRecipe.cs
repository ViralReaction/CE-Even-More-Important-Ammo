using Verse;

namespace CombatExtendedImportantAmmo
{
    public class AmmoRecipe
    {
        private readonly RecipeDef recipe;
        private readonly float origOutputCount;

        public AmmoRecipe(RecipeDef recipe)
        {
            this.recipe = recipe;
            this.origOutputCount = recipe.products[0].count;
        }

        public void Tweak()
        {
            new RecipeOutputDebug(recipe, origOutputCount).Tweak();
            new RecipeInput(recipe).Tweak(new RecipeOutput(recipe, origOutputCount).Count());
            new ProductMarketValue(recipe).Recalculate();
            ChangeLabel();
            ChangeDescription();
        }

        private void ChangeLabel()
        {
            recipe.label = StringWithReplacedOutput(recipe.label);
        }

        private void ChangeDescription()
        {
            recipe.description = StringWithReplacedOutput(recipe.description);
        }

        private string StringWithReplacedOutput(string original)
        {
            string result = original;
            if(result != null && result.Contains(origOutputCount.ToString()))
            {
                result = result.Replace(origOutputCount.ToString(), recipe.products[0].count.ToString());
            }
            return result;
        }
    }
}