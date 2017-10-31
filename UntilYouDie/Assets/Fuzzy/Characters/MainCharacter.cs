using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fuzzy.Characters
{

    [RequireComponent(typeof(AnimationController))]
    public class MainCharacter : BaseCharacter
    {

        private Vector3 _lastDestination;
        private AnimationController _animationController;

        public override void Reset() {}

        void Awake() {
            _animationController = this.GetComponent<AnimationController>();
        }

        // Update is called once per frame
        void Update() {

        }


        /// <summary>
        /// Rotates, and moves the character to the given transform.
        /// </summary>
        /// <param name="transform"></param>
        public void MoveCharacterTo(Vector3 pos) {

            float dist = Vector3.Distance(this.transform.position, pos);
            _animationController.SetAnimatorMovement(dist);
        }
    }
}