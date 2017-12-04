using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCtrl : MonoBehaviour {

	public int xSize, ySize;
	public int spacing = 12;
	public GameObject tile;
	
	void Start () 
	{
		Generate();
	}

	private void Generate()
    {
        for (int i = 0, y = 0; y <= ySize; y++)
        {
            for (int x = 0; x <= xSize; x++, i++)
            {
                //var vertices[i] = new Vector2(x, y);
				if (x % 2 == 0 && y % 2 != 0)
				{
					Instantiate(tile, new Vector2(transform.position.x + (x * spacing), transform.position.y + (y * spacing)), transform.rotation, transform);
				}
				else if(x % 2 != 0 && y % 2 == 0)
				{
                    Instantiate(tile, new Vector2(transform.position.x + (x * spacing), transform.position.y + (y * spacing)), transform.rotation, transform);
                }
            }
        }
    }
}
