using System.Collections;
using System.Collections.Generic;
using Fuzzy.Characters.Apex;
using UnityEngine;

[RequireComponent(typeof(AnimationController))]
public class MainCharacter : BaseCharacter {

    private Vector3 _lastDestination;
    private AnimationController _animationController;

    public override void Reset() {
    }

    void Awake() {
        _animationController = this.GetComponent<AnimationController>();
    }

	// Update is called once per frame
	void Update () {

        DistanceCheck();
    }

    private void DistanceCheck() {
        if (SingleCharacterInputReceiver.lastDestination != null && SingleCharacterInputReceiver.lastDestination != transform.position)
        {
            float dist = Vector3.Distance(this.transform.position, SingleCharacterInputReceiver.lastDestination);
            _animationController.SetAnimatorMovement(dist);
        }
    }
}
