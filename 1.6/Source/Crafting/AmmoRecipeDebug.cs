using Verse;
using HarmonyLib;

namespace CombatExtendedImportantAmmo
{
    public class AmmoRecipeDebug
    {
        private readonly RecipeDef recipe;

        public AmmoRecipeDebug(RecipeDef recipe)
        {
            this.recipe = recipe;
        }

        public void Tweak()
        {
            if(CombatExtendedImportantAmmo.settings.debugMode)
            {
                FileLog.Log("[DEBUG] Tweaking recipe: " + recipe);
                Log.Message("[DEBUG] Tweaking recipe: " + recipe);
            }
            new AmmoRecipe(recipe).Tweak();
        }
    }
}