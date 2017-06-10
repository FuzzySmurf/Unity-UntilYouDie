using Apex;
using UnityEngine;
using Apex.Input;
using Apex.Services;
using Apex.Units;

namespace Fuzzy.Helper.Apex
{
    public class InputControllerHelper : InputController
    {
        public void SelectUnit(Collider obj, bool append)
        {
            IUnitFacade unit = null;
            if (obj != null) {
                unit = obj.GetUnitFacade();
            }

            if (unit != null && unit.isSelectable) {
                GameServices.gameStateManager.unitSelection.ToggleSelected(unit, append);
            } else if (!append) {
                GameServices.gameStateManager.unitSelection.DeselectAll();
            }
        }
    }
}