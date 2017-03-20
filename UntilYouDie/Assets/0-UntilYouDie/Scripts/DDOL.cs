using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOL : MonoBehaviour {

    public void Awake() {
        DontDestroyOnLoad(this.gameObject);
        Debug.Log("DDOL " + this.gameObject.name);
    }
}
