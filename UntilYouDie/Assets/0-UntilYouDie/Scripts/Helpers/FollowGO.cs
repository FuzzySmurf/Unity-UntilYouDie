using UnityEngine;

/// <summary>
/// FollowGO is used to follow the target gameObject.
/// </summary>
public class FollowGO : MonoBehaviour
{
    private Vector3 offset;

    public GameObject target;

    public void Awake() {
        offset = transform.position - target.transform.position;
    }

    void Update() {
        transform.position = target.transform.position + offset;
    }

}
