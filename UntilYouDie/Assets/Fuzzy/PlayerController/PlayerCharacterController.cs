using Apex.Steering.Components;
using Fuzzy.Characters.Animation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public float drag = 0.5f;
        public float rotationSpeed = 75.0f;
        private Quaternion _targetRotation;

        public IVirtualJoystick movementJoystick;
        public IVirtualJoystick aimRotationJoystick;
        private HumanoidSpeedComponent _humanoidSpeedComponent;
        private Rigidbody _rigidbody;
        private Vector3 MoveVector { get; set; }
        private CharacterAnimator _characterAnimator;

        private Vector3 velocity = Vector3.zero;
        private float _turnInput;
        public float inputDelay = 0.1f;
        private float _forwardInput;

        public void Awake() {
            _humanoidSpeedComponent = this.GetComponent<HumanoidSpeedComponent>();
            _characterAnimator = this.GetComponent<CharacterAnimator>();
        }

        void Start()
        {
            movementJoystick = Orchestrator.LevelManager.instance.movementJoystick;
            aimRotationJoystick = Orchestrator.LevelManager.instance.aimRotationJoystick;
            _rigidbody = gameObject.GetComponent<Rigidbody>();
            _rigidbody.maxAngularVelocity = _humanoidSpeedComponent.maxAngularAcceleration;
            _rigidbody.drag = drag;
            _targetRotation = this.transform.rotation;
            _turnInput = _forwardInput = 0.0f;
        }

        void Update()
        {
            //Get the Virtual Movement Joystick values, and store locally for use.
            MoveVector = PoolInput();

            GetInputs();
            Turn();
        }

        private void FixedUpdate() {
            Move();
        }

        private void Move()
        {
            _characterAnimator.InvokeMovement(MoveVector.magnitude);
            _rigidbody.AddForce(MoveVector * (_humanoidSpeedComponent.GetPreferredSpeed(movementJoystick.InputDirection) * 10));
        }

        //Rotate Character to given Angle.
        private void Turn()
        {
            if (Mathf.Abs(_turnInput) > inputDelay) {
                float JoyStickAngleDirection;
                if(aimRotationJoystick.InputDirection != Vector3.zero) {
                    JoyStickAngleDirection = aimRotationJoystick.AngleDirection;
                } else {
                    JoyStickAngleDirection = movementJoystick.AngleDirection;
                }
                _targetRotation = Quaternion.AngleAxis(-JoyStickAngleDirection + 90, Vector3.up);
            }
            //this.transform.rotation = Quaternion.FromToRotation(this.transform.position, new Vector3(_targetRotation.x, _targetRotation.y, _targetRotation.z));
            this.transform.rotation = _targetRotation;
        }

        //Store Virtual Movement Joystick values seperately for use.
        private void GetInputs()
        {
            _turnInput = movementJoystick.Horizontal();
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
