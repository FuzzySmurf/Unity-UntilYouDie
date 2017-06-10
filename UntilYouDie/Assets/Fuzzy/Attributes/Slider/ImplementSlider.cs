using System.Collections;
using Fuzzy.Attribute.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Fuzzy.Attribute.UI
{
    public class ImplementSlider : AdjustableAttribute
    {

        public float regenerateSpeed { get; private set; }
        public float renegerateAmount { get; private set; }

        private Slider _slider;

        //public ImplementSlider(int value, Slider slider) : base(value) {
        //    _slider = slider;
        //}

        public ImplementSlider(ImplementSliderModel model) 
            : base(model.sliderMaxValue) {
            _slider = model.slider;
            regenerateSpeed = model.regenerateSpeed;
            renegerateAmount = model.renegerateAmount;
        }

        public override string IncreaseCurrent(float amount) {
            string ret = base.IncreaseCurrent(amount);
            _slider.value = NormalizeValue;
            return ret;
        }

        public override string DecreaseCurrent(float amount) {
            string ret = base.DecreaseCurrent(amount);
            _slider.value = NormalizeValue;
            return ret;
        }

        /// <summary>
        /// In charge of regenerating the current Value in the <typeparam name="T" />.
        /// In order to adjust the values, simply set the regenerateSpeed,
        /// and the regenerateAmount.
        /// </summary>
        public IEnumerator Regenerate() {
            while (curValue < maxValue) {
                IncreaseCurrent(renegerateAmount);
                yield return new WaitForSeconds(regenerateSpeed);
            }
        }
    }
}
