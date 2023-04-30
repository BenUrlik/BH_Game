using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject square;
    public int Width = 21;
    public int Height = 21;
    void Start()
    {
        for(int x = -Width/2; x < Width/2f; x++)
        {
            for (int y = -Height/2; y < Height/2f; y++)
            {
                var myNewSquare = Instantiate(square, new Vector3(x, y, 0), Quaternion.identity);
                myNewSquare.transform.parent = gameObject.transform;
                myNewSquare.name = x + " " + y;
            }
        }
    }
}
