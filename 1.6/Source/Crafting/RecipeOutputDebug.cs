using Verse;
using HarmonyLib;

namespace CombatExtendedImportantAmmo
{
    public class RecipeOutputDebug
    {
        private readonly RecipeDef recipe;
        private readonly float originalCount;

        public RecipeOutputDebug(RecipeDef recipe, float originalCount)
        {
            this.recipe = recipe;
            this.originalCount = originalCount;
        }

        public void Tweak()
        {
            new RecipeOutput(recipe, originalCount).Tweak();
            if(CombatExtendedImportantAmmo.settings.debugMode)
            {
                string ds = "[DEBUG]     Output: " + originalCount + " to " + new RecipeOutput(recipe, originalCount).Count();
                FileLog.Log(ds);
                Log.Message(ds);
            }
        }
    }
}