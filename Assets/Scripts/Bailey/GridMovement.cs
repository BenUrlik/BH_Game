using UnityEngine;
using UnityEngine.InputSystem;
public class GridMovement : MonoBehaviour
{
    public GameObject grid;
    public InputAction movement;
    public InputAction movementConfirm;
    private float movementTimer = 0;
    public float movementDelay = 2;
    Vector2 moveDirection = Vector2.zero;
    Vector2Int nextMove = Vector2Int.zero;

    private void OnEnable()
    {
        movement.Enable();
    }
    private void OnDisable()
    {
        movement.Disable();
    }


    private void Update()
    {
        moveDirection = movement.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        movementTimer -= Time.fixedDeltaTime;
        if (movementTimer > 0)
            return;
        if (moveDirection.y < 0)
        {
            nextMove = Vector2Int.up;
        }
        else if (moveDirection.y > 0)
        {
            nextMove = Vector2Int.down;
        }
        else if (moveDirection.x > 0)
        {
            nextMove = Vector2Int.right;
        }
        else if (moveDirection.x < 0)
        {
            nextMove = Vector2Int.left;
        }
        Debug.Log(nextMove);

        if (movementConfirm.triggered)
        {
            ExecuteMove(nextMove);
            Debug.Log(movementConfirm.triggered);
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

    public void ExecuteMove(Vector2Int move)
    {
        this.transform.Translate(move.x, move.y, 0);
    }
}
