using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroy : MonoBehaviour {

    public Transform cameraHeight;
    float cameraHeightY;
    private float findCamera;

    void Start () {
		
	}
	
	// Update is called once per frame
    //Destroys objects where y position is lower than camera y position
	void Update () {
        findCamera = Camera.main.transform.position.y;
        cameraHeightY = cameraHeight.position.y;

        if (transform.position.y < (cameraHeightY - 5.5) || transform.position.y < findCamera -5.5)
        {
            Destroy(this.gameObject);
        }
	}
}
