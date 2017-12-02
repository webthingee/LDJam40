using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// https://answers.unity.com/questions/827225/moving-platform-help-c.html

public class PlatformCtrl : MonoBehaviour 
{
    public Transform platform;
	public Transform[] Waypoints;
    public float moveSpeed = 3;
    public float rotateSpeed = 0.5f;
    public float scaleSpeed = 0.5f;
    public int CurrentPoint = 0;

    void FixedUpdate()
    {
        if (platform.position != Waypoints[CurrentPoint].transform.position)
        {
            platform.position = Vector3.MoveTowards(platform.position, Waypoints[CurrentPoint].transform.position, moveSpeed * Time.deltaTime);
            //platform.rotation = Quaternion.Lerp(platform.rotation, Waypoints[CurrentPoint].transform.rotation, rotateSpeed * Time.deltaTime);
            //platform.localScale = Vector3.Lerp(platform.localScale, Waypoints[CurrentPoint].transform.localScale, scaleSpeed * Time.deltaTime);
        }

        if (platform.position == Waypoints[CurrentPoint].transform.position)
        {
            CurrentPoint += 1;
        }
        if (CurrentPoint >= Waypoints.Length)
        {
            CurrentPoint = 0;
        }
    }
}
