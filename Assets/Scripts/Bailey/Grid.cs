using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject square;
    
    public int Width = 21;
    public int Height = 21;

    public GameObject[,] gridArray;
    
    void Awake()
    {
        gridArray = new GameObject[Width, Height];
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                var myNewSquare = Instantiate(square, new Vector3(x-Width/2, y-Height/2, 0), Quaternion.identity);
                myNewSquare.transform.parent = gameObject.transform;
                myNewSquare.name = x + " " + y;
                gridArray[x,y] = myNewSquare;
            }
        }
    }
}
