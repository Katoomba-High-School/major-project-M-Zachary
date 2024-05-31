using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WayPointType
{
    StartEnd, 
    Waypoint
}

[System.Serializable]
public class WayPoint
{
    public WayPointType Type = WayPointType.Waypoint;
    public Vector2 P0 = Vector2.zero;
    public Vector2 P1 = Vector2.zero;
    public int index = 0;

}

public class way : MonoBehaviour
{
    public GameObject Instance;
    public List<WayPoint> WayPoints;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < Len; i++)
        {

        }
        Vector3 p1 = new Vector3((8 * x) + 4, 2, (8 * y));
        Vector3 p2 = new Vector3((8 * (x + counter - 1)) + 4, 2, (8 * (y)));


        GameObject Object = Instantiate(CheckSprite, p1, Quaternion.identity);

        Object.transform.localScale = new Vector3(Object.transform.localScale.x, Object.transform.localScale.y, Vector3.Distance(p1, p2));
        Object.transform.LookAt(p2, Vector3.forward);

        Object.transform.rotation = Quaternion.Euler(Object.transform.rotation.eulerAngles.x, Object.transform.rotation.eulerAngles.y, 0);
        Object.transform.position = (p1 + p2) / 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
