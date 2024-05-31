using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem.Android;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;


public struct Connection
{
    Point p0 {  get; set; }
    Point p1 { get; set; }
}

//16 wide
public class Map : MonoBehaviour
{

    public int[][] mapArray;

    public List<Connection> checkPoints = new List<Connection>();

    public GameObject ObjectSprite;

    


    public GameObject isle;

    int GetValue(int x, int y)
    {
        if(y > 0 && y < mapArray.Length )
        {
            if(x >= 0 && x < mapArray[y].Length) 
            {
                return mapArray[y][x];
            }
        }

        return -1;
    }

    // Start is called before the first frame update
    void Start()
    {

        
  
        mapArray = new int[][]
        {
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},

        };




        for (int y = 0; y < mapArray.Length; y++)
        {
            for (int x = 0; x < mapArray[y].Length; x++)
            {
                if (mapArray[y][x] == 1 || mapArray[y][x] == 2)
                {
                    GameObject clone = GameObject.Instantiate(isle);
                    clone.transform.position = new Vector3((8 * x), 0, (8 * y));
                    clone.transform.parent = transform;
                    clone.SetActive(true);

                    

                 

                    // check 1 cell to the right
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////
                    if (GetValue(x + 1, y) == 0 || GetValue(x + 1, y) == 2)
                    {

                        
                        if (GetValue(x, y) == 1)
                        {
                            int counter = 1;

                            // walk right untill it hits a air or out of bohnds
                            while (GetValue(x + counter, y) == 0)
                            {
                                counter++;
                            }


                            // if its air 
                            if (GetValue(x + counter, y - 2) != -1 && counter <= 4)
                            {

                                //checkPoints.Add(Connection(new Point{x,y}));

                              
                                Debug.DrawLine(new Vector3((8 * x) + 4, 2, (8 * y)), new Vector3((8 * (x + counter - 1)) + 4, 2, (8 * (y))), UnityEngine.Color.green, 100, false);

                                


                            }


                        }

                        // check 1 cell above
                        if (GetValue(x, y - 2) == 1)
                        {
                            int counter = 0;

                            // walk right untill it hits a air or out of bohnds
                            while (GetValue(x + counter, y - 2) == 1)
                            {
                                counter++;
                            }

                            // if its air 
                            if (GetValue(x + counter, y - 2) != -1)
                            {

                                Vector3 p1 = new Vector3((8 * x) + 4, 2, (8 * y));
                                Vector3 p2 = new Vector3((8 * (x + counter - 1)) + 4, 2, (8 * (y - 2)));

                                Debug.DrawLine(new Vector3((8 * x) + 4, 2, (8 * y)), new Vector3((8 * (x + counter - 1)) + 4, 2, (8 * (y - 2))), UnityEngine.Color.blue, 100, false);
                                
                                
                                GameObject Object = Instantiate(ObjectSprite, p1, Quaternion.identity);
                                Object.transform.localScale = new Vector3(Object.transform.localScale.x, Object.transform.localScale.y, Vector3.Distance(p1, p2));
                                Object.transform.LookAt(p2, Vector3.forward);

                                Object.transform.rotation = Quaternion.Euler(Object.transform.rotation.eulerAngles.x, Object.transform.rotation.eulerAngles.y, 0);
                                Object.transform.position = (p1 + p2) / 2;
                            }



                        }

                        // check 1 cell below
                        if (GetValue(x, y + 2) == 1)
                        {
                            int counter = 0;


                            while (GetValue(x + counter, y + 2) == 1)
                            {
                                counter++;
                            }

                            // if its air 
                            if (GetValue(x + counter, y + 2) != -1)
                            {

                                Vector3 p1 = new Vector3((8 * x) + 4, 2, (8 * y));
                                Vector3 p2 = new Vector3((8 * (x + counter - 1)) + 4, 2, (8 * (y + 2)));

                                Debug.DrawLine(new Vector3((8 * x) +4, 2, (8 * y)), new Vector3((8 * (x + counter - 1))+4, 2, (8 * (y + 2))), UnityEngine.Color.blue, 100, false);

                                GameObject Object = Instantiate(ObjectSprite, p1, Quaternion.identity);
                                Object.transform.localScale = new Vector3(Object.transform.localScale.x, Object.transform.localScale.y, Vector3.Distance(p1, p2));
                                Object.transform.LookAt(p2, Vector3.forward);

                                Object.transform.rotation = Quaternion.Euler(Object.transform.rotation.eulerAngles.x, Object.transform.rotation.eulerAngles.y, 0);
                                Object.transform.position = (p1 + p2) / 2;
                            }


                        }

                    }
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////
                    ///
                     // check 1 cell to the left
                    if (GetValue(x - 1, y) == 0 || GetValue(x - 1, y) == 2)
                    {

                        if (GetValue(x, y - 2) == 1)
                        {
                            int counter = 0;


                            while (GetValue(x + counter, y - 2) == 1)
                            {
                                counter--;
                            }

                            if (GetValue(x + counter, y - 2) != -1)
                            {

                                Vector3 p1 = new Vector3((8 * x) - 4, 2, (8 * y));
                                Vector3 p2 = new Vector3((8 * (x + counter + 1)) - 4, 2, (8 * (y - 2)));

                                Debug.DrawLine(new Vector3((8 * x) - 4, 2, (8 * y)), new Vector3((8 * (x + counter + 1)) - 4, 2, (8 * (y - 2))), UnityEngine.Color.red, 100, false);


                                GameObject Object = Instantiate(ObjectSprite, p1, Quaternion.identity);
                                Object.transform.localScale = new Vector3(Object.transform.localScale.x, Object.transform.localScale.y, Vector3.Distance(p1, p2));
                                Object.transform.LookAt(p2, Vector3.forward);

                                Object.transform.rotation = Quaternion.Euler(Object.transform.rotation.eulerAngles.x, Object.transform.rotation.eulerAngles.y, 0);
                                Object.transform.position = (p1 + p2) / 2;
                            }


                        }

                        if (GetValue(x, y + 2) == 1)
                        {
                            int counter = 0;


                            while (GetValue(x + counter, y + 2) == 1)
                            {
                                counter--;
                            }

                            if (GetValue(x + counter, y + 2) != -1)
                            {
                                Vector3 p1 = new Vector3((8 * x) - 4, 2, (8 * y));
                                Vector3 p2 = new Vector3((8 * (x + counter + 1)) - 4, 2, (8 * (y + 2)));

                                Debug.DrawLine(p1, p2, UnityEngine.Color.red, 100, false);

                                GameObject Object = Instantiate(ObjectSprite, p1, Quaternion.identity);
                                Object.transform.localScale = new Vector3(Object.transform.localScale.x, Object.transform.localScale.y, Vector3.Distance(p1, p2));
                                Object.transform.LookAt(p2, Vector3.forward);

                                Object.transform.rotation = Quaternion.Euler(Object.transform.rotation.eulerAngles.x, Object.transform.rotation.eulerAngles.y, 0);
                                Object.transform.position = (p1 + p2) / 2;

                            }


                        }

                    }

                }

            }




        }
    }

  
}
