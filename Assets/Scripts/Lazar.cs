using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazar : MonoBehaviour
{
    [SerializeField] private float distanceRay = 100;
    public Transform laserFirePoint;
    public LineRenderer lr;

    void Start() {
        lr = GetComponent<LineRenderer>();
    }

    void Update() {
        ShootLaser();
    }

    void ShootLaser() {
        if(Physics2D.Raycast(transform.position, transform.right)) {
            RaycastHit2D hit = Physics2D.Raycast(laserFirePoint.position, transform.right);
            Draw2DRay(laserFirePoint.position, hit.point);
            Debug.Log("Hit!");
        }
        else Draw2DRay(laserFirePoint.position, laserFirePoint.transform.right * distanceRay);
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos) {
        lr.SetPosition(0, startPos);
        lr.SetPosition(1, endPos);
    }
}
