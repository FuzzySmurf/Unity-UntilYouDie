using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private GameObject _player;
    private static LevelManager _instance;

    public static LevelManager instance {
        get { return _instance; }
    }

    public static GameObject player { get { return instance._player; } }
    public void Awake() {
        _instance = this;
        Initialize();
    }

    private void Initialize() {
        if(_player == null)
            _player = GameObject.FindWithTag("Player");


    }
}
