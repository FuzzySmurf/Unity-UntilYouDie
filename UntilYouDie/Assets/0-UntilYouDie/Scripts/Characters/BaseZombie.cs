using System.Collections;
using System.Collections.Generic;
using Apex;
using Apex.LoadBalancing;
using Apex.Steering;
using Apex.Units;
using Fuzzy.Characters;
using Fuzzy.Helper.Apex;
using UnityEngine;

public class BaseZombie : BaseCharacter
{
    public GameObject other;
    //private IMovable _unitMovable;
    private ILoadBalancedHandle _followHandle;
    private IUnitFacade _unit;
    private bool _ignoreApexFirstTime;
    

	void Awake () {
	    //_unitMovable = this.As<IMovable>();
	    _unit = this.GetUnitFacade();
	    other = GameObject.FindGameObjectWithTag("Player");
	    _ignoreApexFirstTime = true;

	}

    void Start() {
    }

    void OnEnable() {
        if (_ignoreApexFirstTime)
            _ignoreApexFirstTime = false;
        else
            _followHandle = _unit.Follow(other.transform);
    }

    void OnDisable() {
        _unit.Stop();
        if(_followHandle != null)
            _followHandle.Stop();
    }

	void Update () {

    }
}
