using UnityEngine;
using UnityEngine.InputSystem;
public class GridMovement : MonoBehaviour
{
    public GameObject grid;
    public InputAction playerAction;
    private float movementTimer = 0;
    public float movementDelay = 2;
    Vector2 moveDirection = Vector2.zero;

    private void OnEnable()
    {
        playerAction.Enable();
    }
    private void OnDisable()
    {
        playerAction.Disable();
    }


    private void Update()
    {
        moveDirection = playerAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        movementTimer -= Time.fixedDeltaTime;
        if (movementTimer > 0)
            return;
        if (moveDirection.y < 0)
        {
            this.transform.Translate(0, -1, 0);
        }
        else if (moveDirection.y > 0)
        {
            this.transform.Translate(0, 1, 0);
        }
        else if (moveDirection.x > 0)
        {
            this.transform.Translate(1, 0, 0);
        }
        else if (moveDirection.x < 0)
        {
            this.transform.Translate(-1, 0, 0);
        }
        movementTimer = movementDelay;
    }

    public bool isValid(Vector2 direction)
    {

        if (grid.transform.Find(direction.x + " " + direction.y))
            return true;
        else
            return false;
    }
}
