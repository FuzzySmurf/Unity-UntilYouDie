using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazine : MonoBehaviour
{
    public int maxCapacity;
    public int curCapacity;

    private void Start() {
        maxCapacity = 30;
        curCapacity = 30;
    }

    /// <summary>
    /// Use this to decrement the ammo capacity by one.
    /// </summary>
    public void DecrementAmmo() {
        curCapacity -= 1;
    }

    public bool CheckForAmmo() {
        return (curCapacity > 0) ? true : false;
    }
}
