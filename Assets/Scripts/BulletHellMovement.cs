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
    // x, y are half of world width and height.
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

    // Update is called once per frame
    private void Update()
    {
        horizontalMovement();
    }

    private void FixedUpdate() {
        rotationalMovement();
    }

    private void horizontalMovement() {
        // Compute the sin position.
        // float xValue = Mathf.Sin(timeValue * moveSpeed);

        // Now compute the Clamp value.
        // float xPos = Mathf.Clamp(xValue, -8.0f, 8.0f);

        // Update the position of the cube.
        // transform.position = new Vector3(xPos, 0.0f, 0.0f);

        // Increase animation time.
        // timeValue += Time.deltaTime;

        // Reset the animation time if it is greater than the planned time.
        // if (xValue > Mathf.PI * 3.0f) { timeValue = 0.0f; }

        Vector3 pos = transform.position;
        float lengthX = boundaryX; // Desired length of the ping-pong
        float bottomFloorX = -boundaryX; // The low position of the ping-pong
        float lengthY = boundaryY;
        float bottomFloorY = -boundaryY;
        pos.x = Mathf.PingPong(Time.time,  2 * lengthX) + bottomFloorX;
        pos.y = Mathf.PingPong(Time.time,  2 * lengthY) + bottomFloorY;
        transform.position = pos;
    }

    private void rotationalMovement() {
        spawning.time += Time.fixedDeltaTime;
        spawning.transform.rotation = Quaternion.Euler(0, 0, spawning.time * spawning.spin_speed);
    }
}
