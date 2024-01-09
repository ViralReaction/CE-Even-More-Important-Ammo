using RimWorld;
using Verse;

namespace CombatExtendedImportantAmmo
{
    public class AmmoRecipes
    {
        public void Tweak()
        {
            if(CombatExtendedImportantAmmo.settings.changeRecipes)
            {
                foreach(RecipeDef recipeDef in DefDatabase<RecipeDef>.AllDefsListForReading)
                {
                    ThingDef productDef = recipeDef.ProducedThingDef;
                    if(productDef != null && productDef.techLevel >= TechLevel.Industrial)
                    {
                        if(IsAmmo(productDef))
                        {
                            new AmmoRecipeDebug(recipeDef).Tweak();
                        }
                    }
                }
            }
        }

        public bool IsAmmo(ThingDef thingDef)
        {
            bool isAmmo = false;
            if(thingDef.IsWeapon && thingDef.Verbs != null)
            {
                foreach(VerbProperties vp in thingDef.Verbs)
                {
                    if(vp.verbClass == typeof(CombatExtended.Verb_ShootCEOneUse))
                    {
                        isAmmo = true;
                    }
                }
            }

            if(thingDef is CombatExtended.AmmoDef)
            {
                if(thingDef.thingCategories != null)
                {
                    isAmmo = true;
                    foreach(ThingCategoryDef cd in thingDef.thingCategories)
                    {
                        if(cd.defName == "Grenades")
                        {
                            isAmmo = false;
                        }
                    }
                }
            }

            return isAmmo;
        }
    }
}