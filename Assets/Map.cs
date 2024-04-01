using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PointPair 
{
    public Vector2 P0;
    public Vector2 P1;
    
    public Direction Direction;
    

    public PointPair(Vector2 p0, Vector2 p1, Direction direction)
    {
        P0 = p0;
        P1 = p1;
        Direction = direction;
    }
}
//16 wide
public class Map : MonoBehaviour
{

    public int[][] mapArray;

    public List<PointPair> connections;
    public GameObject isle;

    // Start is called before the first frame update
    void Start()
    {
        connections = new List<PointPair>();

        mapArray = new int[][]
        {  
        new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        new int[] { 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1},
        new int[] { 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1},
        new int[] { 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1},
        new int[] { 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1},
        new int[] { 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1},
        new int[] { 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1},
        new int[] { 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1},
        new int[] { 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1},
        new int[] { 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1},
        new int[] { 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1},


        };

        //MapHelper.Get<int>()

  
        for (int y = 0; y < mapArray.Length; y++)
        {
            for (int x = 0; x < mapArray[y].Length; x++)
            {
                if (mapArray[y][x] == 1)
                {
                    GameObject clone = GameObject.Instantiate(isle);
                    clone.transform.position = new Vector3(115 - (8*x), 0 , 40 - (10*y));
                    clone.transform.parent = transform;
                    clone.SetActive(true);

                    var left = mapArray.Get(x, y, Direction.West, -1);
                    var right = mapArray.Get(x, y, Direction.East, -1);
                    var up = mapArray.Get(x, y, Direction.North, -1);
                    var down = mapArray.Get(x, y, Direction.South, -1);

                    if (right == 0)
                    {
                        if (down == 1)
                        {
                         
                            int index = 0;
                            bool running = true;
                            while (running)
                            {
                                index += 1;

                                var leftConnect = mapArray.Get(x + index, y - 1, Direction.East, -1);

                                if (leftConnect <= 0 )
                                {
                                    // if there is an empty space.
                                    if (leftConnect == 0)
                                    {
                                        connections.Add(new PointPair(
                                            new Vector2(x, y),
                                            new Vector2(x + index, y - 1),
                                            Direction.East)
                                        );
                                    }
                                    running = false;
                                }
                                
                            }

                        }

                    }

                    
                }
            }
            
        }

        

        



    }

    void Update()
    {

       
        foreach (var item in connections)
        {
            if (item.Direction == Direction.East)
            {
               Debug.DrawLine(new Vector3((115 - (8 * item.P0.x)) + 4, 1, 40 - (10 * item.P0.y)), new Vector3((115 - (8 * item.P1.x)) + 4, 1, 40 - (10 * item.P1.y)), Color.red);
            }
           

        }

        

    }
}
