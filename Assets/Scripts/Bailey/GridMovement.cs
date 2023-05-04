using UnityEngine;
using UnityEngine.InputSystem;
public class GridMovement : MonoBehaviour
{

    public GameObject gridObject;
    public GameObject[,] movementArray;

    public InputAction movement;
    public InputAction movementConfirm;
    private float movementTimer = 0;
    public float movementDelay = 2;
    Vector2 moveDirection = Vector2.zero;
    Vector2Int nextMove = Vector2Int.zero;

    public int playerGridPosX;
    public int playerGridPosY;

    public int gridWidth;
    public int gridHeight; 

    private void Start()
    {
        //int width = gridObject.GetComponent<Grid>().Width;
        //int height = gridObject.GetComponent<Grid>().Height;
        //movementArray = new GameObject[width, height];
        movementArray = gridObject.GetComponent<Grid>().gridArray;
        Debug.Log(movementArray);
        Debug.Log(movementArray[20, 20] + " " + movementArray[0, 0]);

        playerGridPosX = 10;
        playerGridPosY = 10;

        gridWidth = gridObject.GetComponent<Grid>().Width;
        gridHeight = gridObject.GetComponent<Grid>().Height;
    }

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
        Debug.Log(moveDirection);
    }

    private void FixedUpdate()
    {
        movementTimer -= Time.fixedDeltaTime;
        
        if (movementTimer > 0)
            return;

        if (isValid(nextMove))
        {
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


            if (movementConfirm.triggered)
            {
                ExecuteMove(nextMove);
                //Debug.Log(movementConfirm.triggered);
            }
        }
        else
        {
            Debug.Log("Not a Valid Move");
        }
        

        movementTimer = movementDelay;

        /*
        Debug.Log("\n" +
                  "Move Direction:" + moveDirection + "\n" +
                  "Next Move:" + nextMove + "\n" +
                  "isValid:" + isValid(nextMove));
        */
    }

    public bool isValid(Vector2Int direction)
    {
        if(playerGridPosX + direction.x > gridWidth || playerGridPosX - direction.x < 0 || playerGridPosY + direction.y > gridHeight || playerGridPosY - direction.y < 0)
            return false;


        if (movementArray[playerGridPosX + direction.x, playerGridPosY + direction.y] != null)
        {
            //Debug.Log("true");
            return true;
        }
        
        else
        {
            //Debug.Log("False");
            return false;
        }
    }

    public void ExecuteMove(Vector2Int move)
    {
        this.transform.Translate(move.x, move.y, 0);
        playerGridPosX += move.x;
        playerGridPosY += move.y;
    }}
