using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensoryScript : MonoBehaviour {

    public bool isSight;
    public bool isHearing;

    bool hearing = false;
    bool seeing = false;

    GameObject target;

    public string findTag;

    // Use this for initialization
    void Start () {
        // Turns everything invisible upon startup
        GameObject[] sensors = GameObject.FindGameObjectsWithTag("Sensor");
        foreach(GameObject s in sensors)
        {
            s.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        }

        // Sets target to findTag's tag
        target = GameObject.FindGameObjectWithTag(findTag);
	}
	
    public bool Hearing
    {
        get { return hearing; }
        set { hearing = value; }
    }

    public bool Seeing
    {
        get { return seeing; }
        set { seeing = value; }
    }

	// Update is called once per frame
	void Update ()
    {
        if (hearing)
        {
            Debug.Log("HEARING");
            // To add: code about raising suspicion
        }
        else if (seeing)
        {
            Debug.Log("SEEING");
        }

    }
}
