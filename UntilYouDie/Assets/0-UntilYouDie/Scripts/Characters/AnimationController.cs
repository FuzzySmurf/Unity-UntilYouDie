using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    private Animator animator;

    //public Rigidbody rigidbody;

    public string velocityParameter;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetTrigger(string parameter)
    {
        animator.SetTrigger(parameter);
    }

    public void SetBoolean(string parameter, bool value)
    {
        animator.SetBool(parameter, value);
    }


    public void SetAnimatorMovement(float distance) {
        animator.SetFloat(velocityParameter, distance);
    }
}
