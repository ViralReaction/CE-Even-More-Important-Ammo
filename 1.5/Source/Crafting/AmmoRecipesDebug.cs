using RimWorld;
using Verse;
using HarmonyLib;

namespace CombatExtendedImportantAmmo
{
    public class AmmoRecipesDebug
    {
        public void Tweak()
        {
            if(CombatExtendedImportantAmmo.settings.debugMode)
            {
                FileLog.Log("[DEBUG] Tweaking recipes: " + CombatExtendedImportantAmmo.settings.changeRecipes + " mult: " + CombatExtendedImportantAmmo.settings.recipeProductsMult);
                Log.Message("[DEBUG] Tweaking recipes: " + CombatExtendedImportantAmmo.settings.changeRecipes + " mult: " + CombatExtendedImportantAmmo.settings.recipeProductsMult);
                LogShit();
            }
            new AmmoRecipes().Tweak();
        }

        private void LogShit()
        {
            FileLog.Log("[DEBUG] ===========");
            AmmoRecipes ar = new AmmoRecipes();
            foreach(RecipeDef recipeDef in DefDatabase<RecipeDef>.AllDefsListForReading)
            {
                ThingDef productDef = recipeDef.ProducedThingDef;
                if(productDef != null && productDef.techLevel >= TechLevel.Industrial)
                {
                    FileLog.Log("[DEBUG] Ammo: " + ar.IsAmmo(productDef) + " " + recipeDef);
                }
            }
            FileLog.Log("[DEBUG] =========== End of shit ===========");
        }
    }
}