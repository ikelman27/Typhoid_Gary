using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aesthetic : MonoBehaviour {

    public float amp;
    public float speed;
    private float yVal;
	// Use this for initialization
	void Start () {
        yVal = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        float tempY = yVal + amp * Mathf.Sin(speed * Time.time);
        this.transform.position = new Vector3(this.transform.position.x, tempY, this.transform.position.z);
	}
}
