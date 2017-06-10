using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor {

    private float _armorAvg;

    public static float MaxPossibleArmor = 100.0f;

    public float armorAvg {
        get { return _armorAvg; }
        private set { _armorAvg = value; }
    }

    public void CalculateNewArmorAdjustment(float armorAdd) {
        var val = NormalizeValue(armorAdd);
        float curVal = 1 - armorAvg;
        _armorAvg = (curVal*val) + _armorAvg;
    }

    private float NormalizeValue(float value) {
        float ret = value/100.00f;

        return ret;
    }
}
