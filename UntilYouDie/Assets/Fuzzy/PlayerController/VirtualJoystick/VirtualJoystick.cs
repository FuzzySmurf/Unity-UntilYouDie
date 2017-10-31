using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

namespace Fuzzy.PlayerController
{

    public class VirtualJoystick : MonoBehaviour, IVirtualJoystick
    {
        protected Image _bgImage;
        protected Image _joystickImage;
        protected Color _originalJoystickColor;


        public Vector3 InputDirection { get; set; }

        public float AngleDirection {
            get { return Mathf.Atan2(InputDirection.z, InputDirection.x) * Mathf.Rad2Deg; }
        }

        public virtual void Awake() {
            _bgImage = GetComponent<Image>();
            _joystickImage = transform.GetChild(0).GetComponent<Image>();
            _originalJoystickColor = _joystickImage.color;
            InputDirection = Vector3.zero;
        }

        public virtual void OnDrag(PointerEventData eventData) {
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

        public virtual void OnPointerUp(PointerEventData eventData) {
            InputDirection = Vector3.zero;
            _joystickImage.rectTransform.anchoredPosition = Vector3.zero;
        }

        public void OnPointerDown(PointerEventData eventData) {
            OnDrag(eventData);
        }

        public float Horizontal() {
            if (InputDirection.x != 0)
                return InputDirection.x;
            else
                return Input.GetAxis(Orchestrator.LevelInputSettings.instance.HORIZONTAL_AXIS);
        }

        public float Vertical()
        {
            if (InputDirection.z != 0)
                return InputDirection.z;
            else
                return Input.GetAxis(Orchestrator.LevelInputSettings.instance.VERTICAL_AXIS);
        }
    }
}