using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject square;
    public int width = 25;
    public int height = 25;
    void Start()
    {
        for(int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Instantiate(square, new Vector3(x-width/2, y-height/2, 0), Quaternion.identity);
            }
        }
    }
}
