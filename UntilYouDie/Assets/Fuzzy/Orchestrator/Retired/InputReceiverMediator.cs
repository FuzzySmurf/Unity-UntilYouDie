using System.Collections;
using System.Collections.Generic;
using Fuzzy.Characters;
using Fuzzy.PlayerController;
using UnityEngine;

namespace Fuzzy.Orchestrator
{
    #region Description & Examples
    /* Description: The purpose of this script is to act as a 'wrapper' or 'mediator'
     * between Input Controlls (Mouse Clicks / keyboard / InteractiveUI)
     * and the characters it is meant to interact with.
     * 
     * Example:
     * I have a joystick for movement. MouseClicks for Movement, and a main character
     * it interacts with. The Mediator will handle overrides for 'who' is the most recent
     * controller, and cancel the previous command, by sending a new command.
     * 
     * */
    #endregion

    public class InputReceiverMediator : MonoBehaviour, IInputReceiverMediator
    {
        public MainCharacter mainCharacter {
            get;
            private set;
        }

        private static InputReceiverMediator _instance;

        public void Start() {
            _instance = this;
            mainCharacter = LevelManager.player.GetComponent<MainCharacter>();
        }

        public static void MoveCharacterToTransform(Vector3 pos) {
            Vector3 nextPos = _instance.mainCharacter.transform.position + pos;

            _instance.mainCharacter.MoveCharacterTo(nextPos);
        }
    }
}