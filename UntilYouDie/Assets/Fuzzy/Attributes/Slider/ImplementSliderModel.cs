using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine.UI;

namespace Fuzzy.Attribute.Model
{
    [System.Serializable]
    public class ImplementSliderModel
    {
        public Slider slider;

        public float regenerateSpeed;

        public float renegerateAmount;

        public int sliderMaxValue;
    }
}