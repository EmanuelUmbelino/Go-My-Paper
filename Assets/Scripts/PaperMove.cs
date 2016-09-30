using UnityEngine;
using System.Collections;

public class PaperMove : MonoBehaviour
{

	// Use this for initialization
	void Start () {
	
	}
    // Update is called once per frame
    void Update ()
    {
        int fingerCount = 0;
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
                fingerCount++;

        }
        if (fingerCount > 0)
            print("User has " + fingerCount + " finger(s) touching the screen");
        if (Input.GetButtonDown("Fire1"))
            this.GetComponent<Rigidbody>().AddForce(Vector3.up*50);
    }
}
