using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField] public static Transform[] points;

    private void Awake()
    {
        //Get all the Waypoints in the level
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            //Get the transform of each waypoint
            points[i] = transform.GetChild(i);
        }
    }
}
