using UnityEngine;
using System.Collections;

public class SideWrap : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // IF PLAYER POSITION IS BELOW -3.4 THAN...
        if (transform.position.x <= -3.05f)
        {
            // NEW PLAYER POSITION WILL BE = X(3.4F, CURRENT Y, CURRENT Z)
            transform.position = new Vector3(3.05f,transform.position.y,transform.position.z);
        }
        else if (transform.position.x >= 3.05f)
        {
            transform.position = new Vector3(-3.05f,transform.position.y,transform.position.z);
        }
    }
}
