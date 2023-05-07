using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public GameObject[,] gridArray;
    public GameObject grid;

    [SerializeField] public InputAction movement;
    [SerializeField] public Vector2 moveDirection = Vector2.zero;
    [SerializeField] public Vector2Int gridPos;
    [SerializeField] public Vector2 direction = Vector2.zero;
    [SerializeField] public float travelTime = 0.2f;
    [SerializeField] public bool isMoving = false;
    [SerializeField] float elapsedTime;



    // Movement Variables
    [SerializeField] public int boardSize;
    

    private void OnEnable()
    {
        movement.Enable();
    }
    private void OnDisable()
    {
        movement.Disable();
    }

    private void Start()
    {
        elapsedTime = 0.0f;

        // travelTime = 3f;

        gridArray = grid.GetComponent<Grid>().gridArray;
        gridPos = new Vector2Int(gridArray.GetLength(0)/2, gridArray.GetLength(1)/2);
    }

    private void Update()
    {
        moveDirection = movement.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
       // if (!isMoving)
       //     Time.timeScale = 0.3f;
       // else
       //     Time.timeScale = 1;


    }

    public IEnumerator movePlayer(Vector2Int targetPos)
    {
        Vector2 startingPos;
        Vector2 worldTargetPos = GetWorldPos(targetPos);

        elapsedTime = 0;
        startingPos = new Vector2(transform.position.x, transform.position.y);
        isMoving = true;

        while (elapsedTime < travelTime)
        {
            transform.position = Vector2.Lerp(startingPos, worldTargetPos, elapsedTime / travelTime); ;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = worldTargetPos;
        gridPos = targetPos;

        isMoving = false;
    }

    public bool IsValid(Vector2Int gridPos)
    {
        return !(gridPos.x >= gridArray.GetLength(0) 
                 || gridPos.y >= gridArray.GetLength(1) 
                 || gridPos.x < 0 
                 || gridPos.y < 0);
    }
    //Gets the transform position of the grid tile at gridPos
    public Vector2 GetWorldPos(Vector2Int gridPos)
    {
        GameObject tile = gridArray[gridPos.x, gridPos.y];

        return new Vector2(tile.transform.position.x,tile.transform.position.y);
    }

    public void HandleMovement()
    {
        Vector2Int targetPos;

        if (moveDirection.y > 0 && !isMoving)
        {
            targetPos = gridPos + Vector2Int.up;
            if (IsValid(targetPos))
                StartCoroutine(movePlayer(targetPos));
        }
        if (moveDirection.y < 0 && !isMoving)
        {
            targetPos = gridPos + Vector2Int.down;
            if (IsValid(targetPos))
                StartCoroutine(movePlayer(targetPos));
        }
        if (moveDirection.x < 0 && !isMoving)
        {
            targetPos = gridPos + Vector2Int.left;
            if (IsValid(targetPos))
                StartCoroutine(movePlayer(targetPos));
        }
        if (moveDirection.x > 0 && !isMoving)
        {
            targetPos = gridPos + Vector2Int.right;
            if (IsValid(targetPos))
                StartCoroutine(movePlayer(targetPos));
        }
    }

}
