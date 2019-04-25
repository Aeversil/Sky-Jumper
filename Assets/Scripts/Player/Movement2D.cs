using UnityEngine;
using System.Collections;

public class Movement2D : MonoBehaviour
{
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    public float maxVelocity = 100f;
    public Vector3 vec3;
    void Update()
    {
        //// remap device acceleration axis to game coordinates: // 1) XY plane of the device is mapped onto XZ plane // 2) rotated 90 degrees around Y axis


       vec3.x = Input.acceleration.x;  // Z is the axis which controls left and right


        //// clamp acceleration vector to unit sphere 
       if (vec3.sqrMagnitude > 1) vec3.Normalize();


        //// Make it move 10 meters per second instead of 10 meters per frame...
       vec3 *= Time.deltaTime;


        ////Move object 
       transform.Translate(vec3 * maxVelocity);
    }
    void FixedUpdate()
    {

    }

}




