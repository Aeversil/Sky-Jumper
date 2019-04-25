using UnityEngine;
using System.Collections;

public class LeftRight2D : MonoBehaviour
{
    public float PlatformSpeed = 2f;
    private bool EndPoint;

    // Update is called once per frame
    //Moves platform left and right between specific x positions
    void Update()
    {
        if (EndPoint)
        {
            transform.position += Vector3.right*PlatformSpeed*Time.deltaTime;
        }
        else
        {
            transform.position -= Vector3.right*PlatformSpeed*Time.deltaTime;
        }
        if (transform.position.x >= 3.05f)
        {
            EndPoint = false;
        }
        if (transform.position.x <= -3.05f)
        {
            EndPoint = true;
        }
    }
}
