using UnityEngine;
using System.Collections;

public class UpDown2D : MonoBehaviour
{

    public float PlatformSpeed = 2f;
    private bool EndPoint;

    private float StartPoint;
    private float EndPointY;

    public int UnitsToMove = 2;

    // Use this for initialization
    void Start()
    {
        StartPoint = transform.position.y;
        EndPointY = StartPoint + UnitsToMove;
    }

    // Update is called once per frame
    //Moves platform between specific y positions
    void Update()
    {

        if (EndPoint)
        {
            transform.position += Vector3.up * PlatformSpeed * Time.deltaTime;
        }
        else
        {
            transform.position -= Vector3.up * PlatformSpeed * Time.deltaTime;
        }
        if (transform.position.y >= EndPointY)
        {
            EndPoint = false;
        }
        if (transform.position.y <= StartPoint)
        {
            EndPoint = true;
        }
    }
}

