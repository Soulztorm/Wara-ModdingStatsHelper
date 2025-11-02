using BepInEx;
using UnityEngine;

namespace ShowMeTheStats
{
    [BepInPlugin("com.moddingstatshelper.spt", "Modding Stats Helper", "1.0")]
    public class ShowMeTheStatsPlugin : BaseUnityPlugin
    {
        void Awake()
        {
            new ItemShowTooltipPatch().Enable();
            new ShowTooltipPatch().Enable();
            new WeaponUpdatePatch().Enable();
            new DropDownSlotContextPatch().Enable();
            new SlotViewPatch().Enable();
            new ScreenTypePatch().Enable();

            new DropDownSlotContextClosePatch().Enable();
        }



        void Update()
        {
            if (Globals.isWeaponModding)
            {
                bool isKeyDown = Input.GetKey(KeyCode.LeftControl);
                if ((isKeyDown && !Globals.isKeyPressed) || (!isKeyDown && Globals.isKeyPressed))
                {
                    Globals.isKeyPressed = !Globals.isKeyPressed;
                    Globals.simpleTooltip.Show(Globals.lastTooltipText, null, 0.1f, null);
                }
            }
        }
    }
}
