using UnityEngine;
using Verse;

namespace CombatExtendedImportantAmmo
{
    class CombatExtendedImportantAmmo : Mod
    {
        public static Settings settings;

        public CombatExtendedImportantAmmo(ModContentPack content) : base(content)
        {
            settings = GetSettings<Settings>();
        }

        public override string SettingsCategory()
        {
            return "Combat Extended Important Ammo";
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            settings.DoWindowContents(inRect);
        }
    }
}