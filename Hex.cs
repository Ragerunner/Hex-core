using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour
{
    // our coordinates in the map array
    public int x;
    public int y;
    public Unit unit;
    public Hex[] GetNeighbours()
    {// neighbours at sides.
        List<Hex> neibors = new List<Hex>();
        GameObject leftNeighbour = GameObject.Find("Hex_" + (x - 1) + "_" + y);
        if (leftNeighbour != null) neibors.Add(leftNeighbour.GetComponent<Hex>());
        GameObject rightNeighbour = GameObject.Find("Hex_" + (x + 1) + "_" + y);
        if (rightNeighbour != null) neibors.Add(rightNeighbour.GetComponent<Hex>());

        // The problem is that our neighbours to our upper-left and upper-right
        // might be at x-1 and x, Or they might be at x and x+1, depending on whether we our 
        //on an even or odd row. if y % 2 is 1 or 0
        GameObject upperLeftNeighbour = GameObject.Find("Hex_" + (x - (y % 2 == 0 ? 1 : 0)) + "_" + (y - 1));
        GameObject upperRightNeighbour = GameObject.Find("Hex_" + (x + (y % 2 == 0 ? 0 : 1)) + "_" + (y - 1));
        GameObject lowerRightNeighbour = GameObject.Find("Hex_" + (x - (y % 2 == 0 ? 1 : 0)) + "_" + (y + 1));
        GameObject lowerLeftNeighbour = GameObject.Find("Hex_" + (x + (y % 2 == 0 ? 0 : 1)) + "_" + (y + 1));
        if (upperLeftNeighbour != null) neibors.Add(upperLeftNeighbour.GetComponent<Hex>());
        if (upperRightNeighbour != null) neibors.Add(upperRightNeighbour.GetComponent<Hex>());
        if (lowerRightNeighbour != null) neibors.Add(lowerRightNeighbour.GetComponent<Hex>());
        if (lowerLeftNeighbour != null) neibors.Add(lowerLeftNeighbour.GetComponent<Hex>());

        return neibors.ToArray();
    }

}
