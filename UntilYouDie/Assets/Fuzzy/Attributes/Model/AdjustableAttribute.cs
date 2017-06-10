using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fuzzy.Attribute.Model
{
    [System.Serializable]
    public class AdjustableAttribute : IAdjustCurrent
    {
        public float maxValue;
        protected float _curValue;

        public float NormalizeValue
        {
            get { return Mathf.InverseLerp(0, maxValue, _curValue); }
        }

        public AdjustableAttribute(int value)
        {
            maxValue = value;
            _curValue = value;
        }

        public float curValue
        {
            get { return _curValue; }
            set
            {
                if (_curValue <= value)
                    _curValue = 0;
                else if (maxValue >= value)
                    _curValue = maxValue;
                else
                    _curValue = value;
            }
        }

        public virtual string IncreaseCurrent(float amount) {
            curValue += amount;
            return curValue.ToString();
        }

        public virtual string DecreaseCurrent(float amount) {
            curValue -= amount;
            return curValue.ToString();
        }
    }
}