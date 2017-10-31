//using Apex.Steering.Components;
using Fuzzy.Characters.Animation;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Fuzzy.PlayerController
{
    /* NOTES: 
     * Virtual Joystick functions indepedently from the playerCharacterController, 
     * but is needed for the left joystick functionality to work.
     * */
     [RequireComponent(typeof(CharacterAnimator))]
    public class PlayerCharacterController : MonoBehaviour
    {
        public void Reset() { }

        private Quaternion _targetRotation;
        public int characterSpeed = 100;
        public float rotationSpeed = 5.0f;

        [HideInInspector]
        public VirtualJoystick_Threshold aimRotationJoystick;
        public IVirtualJoystick movementJoystick;

        private Rigidbody _rigidbody;
        private Vector3 MoveVector { get; set; }
        private CharacterAnimator _characterAnimator;

        private Vector3 velocity = Vector3.zero;
        private float _turnInput;
        public float inputDelay = 0.1f;
        public BaseFirearm Weapon;

        public void Awake() {
            _characterAnimator = this.GetComponent<CharacterAnimator>();
        }

        void Start()
        {
            movementJoystick = Orchestrator.LevelManager.instance.movementJoystick;
            aimRotationJoystick = Orchestrator.LevelManager.instance.aimRotationJoystick;
            _rigidbody = gameObject.GetComponent<Rigidbody>();
            _targetRotation = this.transform.rotation;
            _turnInput = 0.0f;
        }

        void Update()
        {
            //Get the Virtual Movement Joystick values, and store locally for use.
            MoveVector = PoolInput();

            GetInputs();
            Turn();
            InvokeRotationThreshold();
        }

        private void FixedUpdate() {
            Move();
        }

        private void Move()
        {
            _characterAnimator.InvokeMovement(MoveVector.magnitude);
            _rigidbody.AddForce(MoveVector * characterSpeed);
        }

        //Rotate Character to given Angle.
        private void Turn()
        {
            if (Mathf.Abs(_turnInput) > inputDelay) {
                float JoyStickAngleDirection = 0.0f;
                if(aimRotationJoystick.InputDirection != Vector3.zero) {
                    JoyStickAngleDirection = aimRotationJoystick.AngleDirection;
                } else {
                    JoyStickAngleDirection = movementJoystick.AngleDirection;
                }
                _targetRotation = Quaternion.AngleAxis(-JoyStickAngleDirection + 90, Vector3.up);
            }
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, _targetRotation, rotationSpeed * Time.deltaTime);
        }

        private void InvokeRotationThreshold()
        {
            if (aimRotationJoystick.HasPassedThreshold())
            {
                if (Weapon.firearmSettings.IsWeaponEquipped == false) {
                    //Invoke Weapon Equip, and Equip Weapon.
                    _characterAnimator.TriggerEquipWeapon(Weapon.firearmSettings);
                } else
                {
                    //If weapon Is Equipped...
                    Weapon.FireWeapon();
                }   
            }
            else
            {
                if(Weapon.firearmSettings.IsWeaponEquipped)
                {
                    Weapon.firearmSettings.IsWeaponEquipped = false;
                    _characterAnimator.SetWeaponStanceAnimation(0);
                }
            }
        }

        //Store Virtual Movement Joystick values seperately for use.
        private void GetInputs()
        {
            _turnInput = movementJoystick.Horizontal();
            //If the rotation looks to weird, maybe i will remove these 2 lines...?
            if (_turnInput == 0)
                _turnInput = aimRotationJoystick.Horizontal();
        }

        private Vector3 PoolInput()
        {
            Vector3 dir = Vector3.zero;

            dir.x = movementJoystick.Horizontal();
            dir.z = movementJoystick.Vertical();

            if (dir.magnitude > 1)
                dir.Normalize();

            return dir;
        }
    }
}
