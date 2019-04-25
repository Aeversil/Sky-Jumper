using UnityEngine;
using System.Collections;

public class Jump2D : MonoBehaviour
{

    public bool Grounded;                   // True or false whether we are grounded
    public float JumpHeight = 500f;                // Player jump height

    public Transform GroundCheck;           // Object which will check if we are grounded

    public float GroundRadius = .2f;       // Radius around the ground check object, that will detect if we are grounded or not
    public LayerMask Ground;                // Decide which layers count as grounded

	
	// Update is called once per frame
    // Makes the player jump
	void FixedUpdate ()
	{
	    Grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundRadius, Ground);

	    float VelY = GetComponent<Rigidbody2D>().velocity.y;

	    if (Grounded && VelY <= 0)
	    {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
	        GetComponent<Rigidbody2D>().AddForce(new Vector2(0,JumpHeight));
	    }
	}
}
