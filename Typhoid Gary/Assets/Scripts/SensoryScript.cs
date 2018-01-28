using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensoryScript : MonoBehaviour {

    public bool isSight;
    public bool isHearing;

    bool playerInRange;             // Bool to see if the player is within range

    GameObject target;

    public string findTag;

    GameObject manager;

    public int personType = 0;      // For determining penalties -> 0 = normal person, 1 = executive, 2+ = boss

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

        // Finds the Game Manager
        manager = GameObject.FindGameObjectWithTag("GameManager");
	}

	// Update is called once per frame
	void Update ()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Infection")
        {
            if (playerInRange)
            {
                int penalty = 0;
                // If it's sneezing
                if (other.gameObject.name == "Snot")
                {
                    if (isHearing)
                    {
                        if (personType == 0)
                            penalty = 5;
                        else if (personType == 1)
                            penalty = 10;
                        else
                            penalty = 10;
                    }
                    else
                    {
                        if (personType == 0)
                            penalty = 20;
                        else if (personType == 1)
                            penalty = 30;
                        else
                            penalty = 100;
                    }
                }
                // If it's coughing
                else
                {
                    if (isHearing)
                    {
                        if (personType == 0)
                            penalty = 2;
                        else if (personType == 1)
                            penalty = 8;
                        else
                            penalty = 10;
                    }
                    else
                    {
                        if (personType == 0)
                            penalty = 10;
                        else if (personType == 1)
                            penalty = 25;
                        else
                            penalty = 50;
                    }
                }
                manager.GetComponent<ChangingBar>().IncreaseSuspicion(penalty);
            }

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
            playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            playerInRange = false;
    }
}
