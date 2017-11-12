using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Fuzzy.Weapon;

namespace Fuzzy.Characters.Animation
{

    public class CharacterAnimator : MonoBehaviour
    {
        private Animator _animator;

        public void Awake()
        {
            _animator = this.GetComponent<Animator>();
        }

        public void InvokeRun(bool isIdle)
        {
            if (!isIdle)
                _animator.SetFloat("velocity", 0.0f);
            else
                _animator.SetFloat("velocity", 1.0f);
        }

        /// <summary>
        /// Feed the Character the normalized (1-0) value to invoke either the run, or walk animation
        /// </summary>
        /// <param name="value"></param>
        public void InvokeMovement(float value)
        {
            _animator.SetFloat("velocity", value);
        }

        public void IsShooting(bool isShooting)
        {
            _animator.SetBool("shooting", isShooting);
        }

        public void SetWeaponStanceAnimation(int weaponStanceId)
        {
            _animator.SetInteger("WeaponId", weaponStanceId);

            if (weaponStanceId == 0)
            {
                IsTriggerEquipWeapon = false;
            }
        }

        private bool IsTriggerEquipWeapon = false;

        public void TriggerEquipWeapon(FirearmSettings firearmSettings)
        {
            if (IsTriggerEquipWeapon == false)
            {
                IsTriggerEquipWeapon = true;
                StartCoroutine(EquipWeapon(firearmSettings));
            }
        }

        public IEnumerator EquipWeapon(FirearmSettings firearmSettings)
        {
            Debug.Log("Weapon is being equipped!! " + firearmSettings.WeaponId);
            SetWeaponStanceAnimation(firearmSettings.WeaponId);
            yield return new WaitForSeconds(firearmSettings.Anim_EquipWeapon);
            firearmSettings.IsWeaponEquipped = true;
        }
    }
}