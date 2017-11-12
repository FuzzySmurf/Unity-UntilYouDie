using UnityEngine;
using System.Collections;

namespace Fuzzy.Weapon
{
    [System.Serializable]
    public class FirearmSettings
    {
        public int WeaponId = 1;

        public bool IsWeaponEquipped = false;

        public float Anim_EquipWeapon = 0.5f;
    }
}