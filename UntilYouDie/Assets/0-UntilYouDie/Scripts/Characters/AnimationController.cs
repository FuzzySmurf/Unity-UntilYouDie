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

    private Vector3 lastPosition;
    void Update()
    {
        float velocity = (transform.position - lastPosition).magnitude/Time.deltaTime;

        animator.SetFloat(velocityParameter, velocity);
        lastPosition = transform.position;
    }

    public void SetTrigger(string parameter)
    {
        animator.SetTrigger(parameter);
    }

    public void SetBoolean(string parameter, bool value)
    {
        animator.SetBool(parameter, value);
    }
}
