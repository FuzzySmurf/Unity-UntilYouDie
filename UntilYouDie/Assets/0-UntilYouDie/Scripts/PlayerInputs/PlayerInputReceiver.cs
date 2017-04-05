using Apex;
using Apex.Input;
using Apex.Services;
using UnityEngine;
using Fuzzy.Helper.Apex;

namespace Fuzzy.Characters.Apex
{
    [InputReceiver]
    [ApexComponent("Input")]
    public class PlayerInputReceiver : MonoBehaviour
    {
        private InputControllerHelper _inputController;
        private bool _isCharacterSelected;

        public GameObject character;

        public bool isCharacterSelected {
            get { return _isCharacterSelected; }
        }

        private void Awake() {
            _inputController = new InputControllerHelper();
            _isCharacterSelected = false;
        }

        private void Start() {
            Select();
        }

        public void Update() {

            Movement();
        }

        public void Movement() {
            if (!_isCharacterSelected)
                return;

            bool moveInput = false;
            moveInput = Input.GetMouseButtonUp(1);

            if (moveInput)
            {
                var setWaypoint = Input.GetKey(KeyCode.LeftShift);
                _inputController.SetDestination(Input.mousePosition, setWaypoint);
            }
        }

        public void Select() {

            if (!_isCharacterSelected) {
                var collider = character.GetComponent<Collider>();
                _inputController.SelectUnit(collider, false);
                _isCharacterSelected = true;
            }
        }
    }
}
