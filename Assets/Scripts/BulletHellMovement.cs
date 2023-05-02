using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHellMovement : MonoBehaviour
{
    public BulletHellSpawning spawning;
    private float xMin, xMax;
    public float moveSpeed;
    public float timeValue = 0.0f;

    public static Vector2 worldBoundary;
    public float boundaryX;
    public float boundaryY;

    // Start is called before the first frame update
    private void Start()
    {
        worldBoundary = Camera.main.ScreenToWorldPoint( new Vector2( Screen.width, Screen.height ));
        boundaryX = worldBoundary.x;
        boundaryY = worldBoundary.y;
        moveSpeed = 2.0f;
    }

    private void FixedUpdate() {
        // rotationalMovement();
        // horizontalPingPong();
    }

    private void horizontalPingPong() {
        Vector3 pos = transform.position;
        float lengthX = boundaryX; // Desired length of the ping-pong
        float bottomFloorX = -boundaryX; // The low position of the ping-pong
        pos.x = Mathf.PingPong(Time.time,  2 * lengthX) + bottomFloorX;
        transform.position = pos;
    }

    private void verticalPingPong() {
        Vector3 pos = transform.position;
        float lengthY = boundaryY;
        float bottomFloorY = -boundaryY;
        pos.y = Mathf.PingPong(Time.time,  2 * lengthY) + bottomFloorY;
        transform.position = pos;
    }

    private void rotationalMovement() {
        spawning.time += Time.fixedDeltaTime;
        spawning.transform.rotation = Quaternion.Euler(0, 0, spawning.time * spawning.spin_speed);
    }
}
