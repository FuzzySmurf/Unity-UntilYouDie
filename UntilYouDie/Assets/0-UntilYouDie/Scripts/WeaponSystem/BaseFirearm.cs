using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFirearm : MonoBehaviour
{

    private int _currentAmmo;
    private int _maxAmmo;

    //public int maxMagazines;
    //public int curMagazines;

    public int currentAmmo { get { return _currentAmmo; } }
    public int maxAmmo { get { return _maxAmmo; } }

    public ParticleSystem muzzleFlash;
    public GameObject projectile;

    public void Start() {
        
    }

    /// <summary>
    /// Trigger to Fire the Weapon.
    /// </summary>
    /// NOTE: its possible I may need to get the direction of the weapon to determine the direction of the bullet as well.
    public void FireWeapon() {

        if (DoWeHaveAmmo()) {
            //Trigger muzzle Flash.
            
            //Spawn Projectile.
            //Decrement currentAmmo.
        } else {
            //Display GUI Image : "Reload Weapon!"
        }
    }

    public bool DoWeHaveAmmo() {
        bool bOk = _currentAmmo > 0;
        return bOk;
    }


}
