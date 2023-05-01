using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform followTarget;
    public Vector2 offset = Vector2.zero;

    void LateUpdate()
    {
        transform.position = new Vector3(followTarget.position.x + offset.x, followTarget.position.y + offset.y, transform.position.z);
    }
}
