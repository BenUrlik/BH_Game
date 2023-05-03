using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] public Vector2 startingPos, targetPos;
    [SerializeField] public Vector2 direction = Vector2.zero;
    [SerializeField] public float travelTime = 0.2f;
    [SerializeField] public bool isMoving;

    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        
    }

    public void movePlayer(Vector2 direction)
    {
        isMoving = true;

        float elapsedTime = 0.0f;

        while(elapsedTime < travelTime)
        {
            transform.position = Vector2.Lerp(startingPos, targetPos, (elapsedTime / travelTime));
            elapsedTime += Time.deltaTime;
        }

        isMoving = false;
    }

}
