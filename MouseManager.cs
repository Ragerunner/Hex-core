using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Assets;

public class MouseManager : MonoBehaviour
{
    Unit selectedUnit;
    bool clicked = false;
    public GameObject Map;
    List<offSetCords> potencialiosKordinates;

    int N = 6;
    void Start()
    {

    }


    void Update()
    {


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Input.GetMouseButtonUp(0)) clicked = false;
        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject ourHitObject = hitInfo.collider.transform.gameObject;
            Debug.Log("Raycast hit: " + hitInfo.collider.transform.name);

            if (Input.GetMouseButton(0) && !clicked)
            {
                clicked = true;
                var hex = ourHitObject.GetComponentInChildren<Hex>();
                if (hex != null)
                {
                    if (selectedUnit != null)
                    {
                        if (potencialiosKordinates.Contains(new offSetCords(hex.x, hex.y)))
                        {
                            selectedUnit.destination = ourHitObject.transform.position;
                            selectedUnit.currentHex.unit = null;
                            selectedUnit.currentHex = hex;
                            hex.unit = selectedUnit;
                            selectedUnit.GetComponent<MeshRenderer>().material.color = Color.white;
                            selectedUnit = null;
                            potencialiosKordinates.ForEach(c => Map.transform.GetComponentsInChildren<Hex>().First(h => h.x == c.x && h.y == c.y).GetComponent<MeshRenderer>().material.color = Color.white);

                        }
                    }
                    else if (hex.unit != null)
                    {
                        selectedUnit = hex.unit;
                        selectedUnit.GetComponent<MeshRenderer>().material.color = Color.yellow;
                        var potencialiaiGalimi = Range(new offSetCords(hex.x, hex.y), N);
       
                        potencialiosKordinates = potencialiaiGalimi.Where(c => c.x >= 0 && c.x < 20 && c.y >= 0 && c.y < 20).ToList();
                        potencialiosKordinates.ForEach(c => Map.transform.GetComponentsInChildren<Hex>().First(h => h.x == c.x && h.y == c.y).GetComponent<MeshRenderer>().material.color = Color.yellow);
                    }
                }
            }

        }

    }
    // offset coordinates
    offSetCords cube_to_oddr(cubeCords cc)
    {
        return cube_to_oddr(cc.x, cc.y, cc.z);
    }

    offSetCords cube_to_oddr(int x, int y, int z)
    {
        var col = x + (z - (z & 1)) / 2;
        var row = z;
        return new offSetCords(col, row);
    }

    cubeCords oddr_to_cube(int col, int row)
    {
        var x = col - (row - (row & 1)) / 2;
        var z = row;
        var y = -x - z;
        return new cubeCords(x, y, z);
    }

    float Distance(offSetCords nuo, offSetCords iki)
    {
        var nuoCC = oddr_to_cube(nuo.x, nuo.y);
        var ikiCC = oddr_to_cube(iki.x, iki.y);
        return cube_distance(nuoCC, ikiCC);

    }

    float cube_distance(cubeCords a, cubeCords b)
    {
        return (Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y) + Mathf.Abs(a.z - b.z)) / 2;
    }
    List<offSetCords> Range(offSetCords nuo, int N)
    {
        List<offSetCords> result = new List<offSetCords>();
        /*
         for each -N ≤ x ≤ +N:
     for each -N ≤ y ≤ +N:
         for each -N ≤ z ≤ +N:
             if x + y + z = 0:
                 results.append(cube_add(center, Cube(x, y, z)))
          */
        var offSetCC = oddr_to_cube(nuo.x, nuo.y);
        for (int x = -N; x <= N; x++)
        {
            for (int y = -N; y <= N; y++)
            {
                for (int z = -N; z <= N; z++)
                {
                    if (x + y + z == 0)
                    {
                        var cc = new cubeCords(x + offSetCC.x, y + offSetCC.y, z + offSetCC.z);
                        result.Add(cube_to_oddr(cc));
                    }
                }
            }

        }
        return result;
    }


    //var results = []
    //for each -N ≤ x ≤ +N:
    // for each max(-N, -x-N) ≤ y ≤ min(+N, -x+N) :
    // var z = -x - y
    // results.append(cube_add(center, Cube(x, y, z)))


    void MouseOver_Unit(GameObject ourHitObject)
    {
        Debug.Log("Raycast hit: " + ourHitObject.name);
        if (Input.GetMouseButton(0)) // we have click on the unit
        {
            //selectedUnit = ourHitObject.GetComponent<Unit>();


        }
    }
}
