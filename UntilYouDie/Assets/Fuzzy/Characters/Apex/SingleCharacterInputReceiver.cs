using Apex;
using Apex.Input;
using Apex.Services;
using UnityEngine;
using Fuzzy.Helper.Apex;
using Fuzzy.Orchestrator;

namespace Fuzzy.Characters.Apex
{
    [InputReceiver]
    [ApexComponent("Input")]
    public class SingleCharacterInputReceiver : MonoBehaviour
    {
        private InputControllerHelper _inputController;
        private bool _isCharacterSelected;

        private GameObject mainCharacter;

        //seperate
        private Vector3 _lastDestination;

        private static SingleCharacterInputReceiver _instance;
        public static Vector3 lastDestination {
            get { return _instance._lastDestination; }
        }

        public bool isCharacterSelected {
            get { return _isCharacterSelected; }
        }

        private void Awake() {
            _instance = this;

            _inputController = new InputControllerHelper();
            _isCharacterSelected = false;
        }

        private void Start() {
            mainCharacter = LevelManager.player;
            Select();
        }

        public void Update() {

            Movement();
        }

        /// <summary>
        /// Uses Left Mouse Click for the momvement, once the mouse button has been released.
        /// </summary>
        public void Movement() {
            if (!_isCharacterSelected)
                return;

            bool moveInput = false;
            moveInput = Input.GetMouseButtonUp(1);

            if (moveInput)
            {
                var setWaypoint = Input.GetKey(KeyCode.LeftShift);
                _lastDestination = Input.mousePosition;
                _inputController.SetDestination(_lastDestination, setWaypoint);
            }
        }

        public void Select() {

            if (!_isCharacterSelected) {
                var collider = mainCharacter.GetComponent<Collider>();
                _inputController.SelectUnit(collider, false);
                _isCharacterSelected = true;
            }
        }
    }
}
