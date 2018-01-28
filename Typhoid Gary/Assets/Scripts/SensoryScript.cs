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

    // Audio
    public AudioClip[] clips;
    public AudioSource reactionSound;

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
        RaycastHit ray;
        float dist = (transform.position - target.transform.position).sqrMagnitude;
        if (dist < (transform.localScale.x / 2))
        {
            playerInRange = true;
        }
        else
            playerInRange = false;

        Debug.Log("RANGE: " + name + " " + playerInRange);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGERED");
        if (other.tag == "Infection")
        {
            if (playerInRange)
            {
                if (clips.Length > 0)
                {
                    int i = Random.Range(0, clips.Length);
                    reactionSound.PlayOneShot(clips[i]);
                    Debug.Log("SOUND");
                }
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
        if (playerInRange)
        {
            Debug.Log("IN RANGE");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            playerInRange = false;
    }
}
