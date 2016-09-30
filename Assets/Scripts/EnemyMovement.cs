using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {


    [SerializeField]
    private float height;

    // Use this for initialization
    void Start () {
        if (height <= 1)
            height = Random.Range(2,15);
        transform.localScale = Vector3.one * height;	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(new Vector3(0, (-50/height) * Time.deltaTime, 0));
	
	}
}
