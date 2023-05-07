using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazar : MonoBehaviour
{
    private LineRenderer lr;
    void Start() {
        lr = GetComponent<LineRenderer>();
    }

    void Update() {
        lr.SetPosition(0, transform.position);
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit)) {
            if(hit.collider) {
                Debug.Log("Hit!");
            }
        }
        else lr.SetPosition(1, transform.forward);
    }
}
