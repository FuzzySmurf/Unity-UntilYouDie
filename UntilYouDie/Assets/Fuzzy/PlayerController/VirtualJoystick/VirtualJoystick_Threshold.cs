using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Fuzzy.PlayerController
{

    public class VirtualJoystick_Threshold : VirtualJoystick
    {
        public Sprite bgThresholdImage;
        public Color thresholdColor;
        private RectTransform _thresholdTransform;
        private GameObject _bgThresholdArea;
        private string gameObjectName {
            get {
                return string.Format("{0}_Threshold", this.name);
            }
        }

        [Range(0, 1)]
        public float thresholdValue = 0.75f;

        public void Reset()
        {
            CreateThreshold();
        }

        public override void Awake()
        {
            base.Awake();

            _bgThresholdArea = GameObject.Find(gameObjectName);
            RenderThreshold();
        }

        /// <summary>
        /// Creates the Image Threshold, and assigns "This" as the parent.
        /// </summary>
        private void CreateThreshold()
        {
            _bgThresholdArea = GameObject.Find(gameObjectName);
            if(_bgThresholdArea == null) {
                _bgThresholdArea = new GameObject(gameObjectName, typeof(RectTransform));
                _bgThresholdArea.AddComponent<CanvasRenderer>();
                _bgThresholdArea.AddComponent<Image>();
                _bgThresholdArea.gameObject.transform.SetParent(this.transform);
                RenderThreshold();
            }
        }

        protected void RenderThreshold()
        {
            RectTransform mainBackground = gameObject.GetComponent<RectTransform>();
            _thresholdTransform = _bgThresholdArea.GetComponent<RectTransform>();
            _bgThresholdArea.GetComponent<Image>().sprite = bgThresholdImage;

            float thresholdWidth = mainBackground.rect.width * thresholdValue;
            float thresholdHeight = mainBackground.rect.height * thresholdValue;

            //Set Anchors and pivots
            _thresholdTransform.pivot = new Vector2(0.5f, 0.5f);
            _thresholdTransform.anchorMin = new Vector2(0.5f, 0.5f);
            _thresholdTransform.anchorMax = new Vector2(0.5f, 0.5f);

            //set position, rotation, width, and height.
            _thresholdTransform.sizeDelta = new Vector2(thresholdWidth, thresholdHeight);
            _thresholdTransform.localScale = mainBackground.localScale;
            _thresholdTransform.localPosition = new Vector3(mainBackground.rect.width/2, mainBackground.rect.height/ 2);
            
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            _joystickImage.color = _originalJoystickColor;
        }

        public bool HasPassedThreshold()
        {
            bool bOk = false;

            if (InputDirection.magnitude >= thresholdValue)
            {
                _joystickImage.color = thresholdColor;
                bOk = true;
            }
            else
            {
                _joystickImage.color = _originalJoystickColor;
            }
            return bOk;
        }
    }
}