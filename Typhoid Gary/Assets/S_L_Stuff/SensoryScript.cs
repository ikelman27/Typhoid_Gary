using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensoryScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject[] sensors = GameObject.FindGameObjectsWithTag("Sensor");
        foreach(GameObject s in sensors)
        {
            s.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
