using Fuzzy.PlayerController;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Fuzzy.Orchestrator
{

    public class LevelManager : MonoBehaviour
    {
        private GameObject _player;
        private static LevelManager _instance;
        public VirtualJoystick movementJoystick;
        public VirtualJoystick_Threshold aimRotationJoystick;

        public static LevelManager instance
        {
            get { return _instance; }
        }

        public static GameObject player
        {
            get {
                if(instance._player == null)
                    instance._player = GameObject.FindWithTag(LevelInputSettings.instance.PLAYER);
                return instance._player;
            }
        }

        public void Awake() {
            _instance = this;
        }

        private void Initialize() {
        }
    }
}