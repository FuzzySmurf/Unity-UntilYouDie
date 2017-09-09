using System.Collections;
using System.Collections.Generic;
using Fuzzy.Characters;
using Fuzzy.PlayerController;
using UnityEngine;

public interface IInputReceiverMediator {
    //IVirtualJoystick characterMovementJoyStick { get; set; }

    MainCharacter mainCharacter { get; }
}
