using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WayPointType
{
    Waypoint,
    StartEnd
    
}


[System.Serializable]

public class WayPoint
{
    public WayPointType Type = WayPointType.Waypoint;
    public int x;
    public int y;
   

}

public class way : MonoBehaviour
{
    public GameObject Instance;
    public GameObject Player;
    public List<WayPoint> WayPoints;
    public static List<string> Que = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < WayPoints.Count; i++)
        {
            Vector3 p1 = new Vector3((8 * WayPoints[i].x) + 4, 2, (8 * WayPoints[i].y));
            Vector3 p2 = new Vector3((8 * (WayPoints[i].x + 4 - 1)) + 4, 2, (8 * (WayPoints[i].y)));


            GameObject Object = Instantiate(Instance, p1, Quaternion.identity);

            Object.transform.localScale = new Vector3(Object.transform.localScale.x, Object.transform.localScale.y, Vector3.Distance(p1, p2));
            Object.transform.LookAt(p2, Vector3.forward);

            Object.transform.rotation = Quaternion.Euler(Object.transform.rotation.eulerAngles.x, Object.transform.rotation.eulerAngles.y, 0);
            Object.transform.position = (p1 + p2) / 2;
            Object.name = $"{WayPoints[i].x}, {WayPoints[i].y}";

            way.Que.Add( Object.name);
            
            if (WayPoints[i].Type == WayPointType.StartEnd)
            {
                Player.transform.position = Object.transform.position;
                Player.transform.rotation = Quaternion.Euler(Object.transform.rotation.eulerAngles.x, Object.transform.rotation.eulerAngles.y - 90, Object.transform.rotation.eulerAngles.z);
            }

        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
