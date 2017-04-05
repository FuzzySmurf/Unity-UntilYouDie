using System.Collections;
using System.Collections.Generic;
using Apex;
using Apex.LoadBalancing;
using Apex.Steering;
using Apex.Units;
using Fuzzy.Helper.Apex;
using UnityEngine;

public class BaseZombie : BaseCharacter
{
    public GameObject other;
    private IMovable _unitMovable;
    private ILoadBalancedHandle _followHandle;
    private IUnitFacade _unit;
	// Use this for initialization

	void Awake () {
	    _unitMovable = this.As<IMovable>();
	    _unit = this.GetUnitFacade();
	    other = GameObject.FindGameObjectWithTag("Player");
	}

    void OnEnable() {
        _followHandle = _unit.Follow(other.transform);
    }

    void OnDisable() {
        _unit.Stop();
        _followHandle.Stop();
    }

	void Update () {

    }
}
