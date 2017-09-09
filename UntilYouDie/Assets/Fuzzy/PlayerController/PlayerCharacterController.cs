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

            ////If the character is moving, invoke animation
            //if(movementJoystick.InputDirection != Vector3.zero) {
            //    _characterAnimator.InvokeRun(true);
            //} else {
            //    _characterAnimator.InvokeRun(false);
            //}

        }

        //Rotate Character to given Angle.
        private void Turn()
        {
            if (Mathf.Abs(_turnInput) > inputDelay) {
                VirtualJoystick m = movementJoystick as VirtualJoystick;
                _targetRotation = Quaternion.AngleAxis(-m.AngleDirection + 90, Vector3.up);
            }
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
