using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {
    public GameObject titles;
    // size of the map in the terms of numbers of hex tiles.
    int width = 20;
    int height = 20;

    float oddRowXOffSet = 0.886f;
    float zOffset = 0.772f;

    //todo deletethis
   public Unit pradinis;

	// Use this for initialization
	void Start () {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float xPos = x*oddRowXOffSet;
                // Are we on odd row?
                if (y % 2 == 1)
                {
                    xPos += oddRowXOffSet/2;
                }

              GameObject hex_go = (GameObject)Instantiate(titles,new Vector3( xPos, 0, y*zOffset), Quaternion.identity);

                hex_go.transform.Rotate(0, 90, 0);
                hex_go.name = "Hex_" + x + "_" + y;
                //  Making sure the hex is aware of its place on the map
                if (x == 0 && y == 0)
                {
                    hex_go.GetComponent<Hex>().unit = pradinis;
                    pradinis.currentHex = hex_go.GetComponent<Hex>();
                }
                hex_go.GetComponent<Hex>().x = x;
                hex_go.GetComponent<Hex>().y = y;
                // for a cleaner hierachy, parent this hex to the map
                hex_go.transform.SetParent(this.transform);
                hex_go.isStatic = true;
            }

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
