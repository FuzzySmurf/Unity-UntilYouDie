using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

namespace Fuzzy.PlayerController
{

    public class VirtualJoystick : MonoBehaviour, IVirtualJoystick
    {
        private Image _bgImage;
        private Image _joystickImage;

        public Vector3 InputDirection { get; set; }

        void Awake() {
            _bgImage = GetComponent<Image>();
            _joystickImage = transform.GetChild(0).GetComponent<Image>();
            InputDirection = Vector3.zero;
        }

        public void OnDrag(PointerEventData eventData) {
            Vector2 pos = Vector2.zero;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _bgImage.rectTransform, eventData.position, eventData.pressEventCamera, out pos)) {
                pos.x = (pos.x/_bgImage.rectTransform.sizeDelta.x);
                pos.y = (pos.y/_bgImage.rectTransform.sizeDelta.y);

                float x = (_bgImage.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2 - 1;
                float y = (_bgImage.rectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y * 2 - 1;

                InputDirection = new Vector3(x, 0, y);
                //constricts the image within the necessary bounds of the BG Image.
                InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;

                //Move the image within the bounds. of the background image
                _joystickImage.rectTransform.anchoredPosition = new Vector3(InputDirection.x * (_bgImage.rectTransform.sizeDelta.x / 3)
                                                                    ,InputDirection.z * (_bgImage.rectTransform.sizeDelta.y / 3));
            }
        }

        public void OnPointerUp(PointerEventData eventData) {
            OnDrag(eventData);
        }

        public void OnPointerDown(PointerEventData eventData) {
            InputDirection = Vector3.zero;
            _joystickImage.rectTransform.anchoredPosition = Vector3.zero;
        }

        public void InvokeMovement() {
            Vector3 dir = Vector3.zero;
            if(InputDirection != Vector3.zero)

        }
    }
}