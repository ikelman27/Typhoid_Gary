using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectScript : MonoBehaviour {
    public bool isInfected;
    public Material infectedMaterial;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void infect()
    {
        isInfected = true;
        gameObject.GetComponent<Renderer>().material.color = Color.green;
    }

     public bool getInfected()
    {
        return isInfected;
    }
}
