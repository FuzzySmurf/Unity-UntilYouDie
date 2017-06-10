using System.Collections;
using System.Collections.Generic;
using Fuzzy;
using Fuzzy.Attribute.Model;
using Fuzzy.Attribute.UI;
using Fuzzy.Damage;
using Sirenix.Serialization;
using UnityEngine;


#region README
/* HAM Utility
 * Description:
 * HAM Stands for Health Armor Mana.
 * The purpose of this HAM Utility is to be a ready-made component that can be attached to
 * a GameObject, and is ready to use, using ONLY the Fuzzy.Scripts, and NOT dependant on any
 * external library. The purpose of this utility is to create a simple Utility that receives
 * incoming DAMAGE (using OnTrigger(s)), and apply the adjustments given to the character.
 * 
 * v 1.0.0 (05/7/2017)
 * */
#endregion

[RequireComponent(typeof(Collider))]
public class HAMUtility : DamageListener
{
    public ImplementSlider mana { get; set; }

    [OdinSerialize]
    public ImplementSliderModel initialManaSlider { get; set; }

    public override void Reset() {
        base.Reset();
        initialManaSlider = new ImplementSliderModel();
    }
}