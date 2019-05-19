using System.Collections.Generic;
using System.Linq;
using BattleTech;
using BattleTech.UI;
using Harmony;
using UnityEngine;
using static Logger;

public class Patches
{
    [HarmonyPatch(typeof(CombatHUDWeaponPanel), "Update")]
    public class CombatHUDWeaponPanel_Update_Patch
    {
        private static bool energyState;
        private static bool ballisticState;
        private static bool missileState;
        private static bool supportState;
        private static bool closeRangeState;
        private static bool standardRangeState;
        private static bool longRangeState;
        private static bool veryLongRangeState;
        private static bool extremeRangeState;

        public static void Postfix(CombatHUDWeaponPanel __instance, List<CombatHUDWeaponSlot> ___WeaponSlots, List<Weapon> ___sortedWeaponsList)
        {
            foreach (var weapon in ___sortedWeaponsList)
            {
                LogDebug($"{weapon.UIName}: {weapon.RangeDescription}");
            }

            var hotkeyF1 = Input.GetKeyDown(KeyCode.F1);
            if (hotkeyF1)
            {
                switch (ballisticState)
                {
                    case true:
                        ___sortedWeaponsList.Where(w => w.Category == WeaponCategory.Ballistic).Do(w => w.DisableWeapon());
                        break;
                    case false:
                        ___sortedWeaponsList.Where(w => w.Category == WeaponCategory.Ballistic).Do(w => w.EnableWeapon());
                        break;
                }

                __instance.RefreshDisplayedWeapons();
                ballisticState = !ballisticState;
            }

            var hotkeyF2 = Input.GetKeyDown(KeyCode.F2);
            if (hotkeyF2)
            {
                switch (energyState)
                {
                    case true:
                        ___sortedWeaponsList.Where(w => w.Category == WeaponCategory.Energy).Do(w => w.DisableWeapon());
                        break;
                    case false:
                        ___sortedWeaponsList.Where(w => w.Category == WeaponCategory.Energy).Do(w => w.EnableWeapon());
                        break;
                }

                __instance.RefreshDisplayedWeapons();
                energyState = !energyState;
            }

            var hotkeyF3 = Input.GetKeyDown(KeyCode.F3);
            if (hotkeyF3)
            {
                switch (missileState)
                {
                    case true:
                        ___sortedWeaponsList.Where(w => w.Category == WeaponCategory.Missile).Do(w => w.DisableWeapon());
                        break;
                    case false:
                        ___sortedWeaponsList.Where(w => w.Category == WeaponCategory.Missile).Do(w => w.EnableWeapon());
                        break;
                }

                __instance.RefreshDisplayedWeapons();
                missileState = !missileState;
            }

            var hotkeyF4 = Input.GetKeyDown(KeyCode.F4);
            if (hotkeyF4)
            {
                switch (supportState)
                {
                    case true:
                        ___sortedWeaponsList.Where(w => w.Category == WeaponCategory.AntiPersonnel).Do(w => w.DisableWeapon());
                        break;
                    case false:
                        ___sortedWeaponsList.Where(w => w.Category == WeaponCategory.AntiPersonnel).Do(w => w.EnableWeapon());
                        break;
                }

                __instance.RefreshDisplayedWeapons();
                supportState = !supportState;
            }

            var hotkeyF5 = Core.ModSettings.enableRangeSettings && Input.GetKeyDown(KeyCode.F5);
            if (hotkeyF5)
            {
                switch (closeRangeState)
                {
                    case true:
                        ___sortedWeaponsList.Where(w => w.RangeDescription == "Close").Do(w => w.DisableWeapon());
                        break;
                    case false:
                        ___sortedWeaponsList.Where(w => w.RangeDescription == "Close").Do(w => w.EnableWeapon());
                        break;
                }

                __instance.RefreshDisplayedWeapons();
                closeRangeState = !closeRangeState;
            }

            var hotkeyF6 = Core.ModSettings.enableRangeSettings && Input.GetKeyDown(KeyCode.F6);
            if (hotkeyF6)
            {
                switch (standardRangeState)
                {
                    case true:
                        ___sortedWeaponsList.Where(w => w.RangeDescription == "Standard").Do(w => w.DisableWeapon());
                        break;
                    case false:
                        ___sortedWeaponsList.Where(w => w.RangeDescription == "Standard").Do(w => w.EnableWeapon());
                        break;
                }

                __instance.RefreshDisplayedWeapons();
                standardRangeState = !standardRangeState;
            }

            var hotkeyF7 = Core.ModSettings.enableRangeSettings && Input.GetKeyDown(KeyCode.F7);
            if (hotkeyF7)
            {
                switch (longRangeState)
                {
                    case true:
                        ___sortedWeaponsList.Where(w => w.RangeDescription == "Very Long").Do(w => w.DisableWeapon());
                        break;
                    case false:
                        ___sortedWeaponsList.Where(w => w.RangeDescription == "Very Long").Do(w => w.EnableWeapon());
                        break;
                }

                __instance.RefreshDisplayedWeapons();
                longRangeState = !longRangeState;
            }

            var hotkeyF8 = Core.ModSettings.enableRangeSettings && Input.GetKeyDown(KeyCode.F8);
            if (hotkeyF8)
            {
                switch (veryLongRangeState)
                {
                    case true:
                        ___sortedWeaponsList.Where(w => w.RangeDescription == "Very Long").Do(w => w.DisableWeapon());
                        break;
                    case false:
                        ___sortedWeaponsList.Where(w => w.RangeDescription == "Very Long").Do(w => w.EnableWeapon());
                        break;
                }

                __instance.RefreshDisplayedWeapons();
                veryLongRangeState = !veryLongRangeState;
            }

            var hotkeyF9 = Core.ModSettings.enableRangeSettings && Input.GetKeyDown(KeyCode.F9);
            if (hotkeyF9)
            {
                switch (extremeRangeState)
                {
                    case true:
                        ___sortedWeaponsList.Where(w => w.RangeDescription == "Extreme").Do(w => w.DisableWeapon());
                        break;
                    case false:
                        ___sortedWeaponsList.Where(w => w.RangeDescription == "Extreme").Do(w => w.EnableWeapon());
                        break;
                }

                __instance.RefreshDisplayedWeapons();
                extremeRangeState = !extremeRangeState;
            }
        }
    }
}