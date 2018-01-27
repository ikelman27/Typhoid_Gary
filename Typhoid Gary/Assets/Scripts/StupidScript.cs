using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidScript : MonoBehaviour {

    public GameObject box;
    public bool clicked;

	// Use this for initialization
	void Start () {
        box = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            box.transform.position = hit.point;
        box.transform.position = new Vector3(box.transform.position.x, 1.0f, box.transform.position.z);

        // Changes whether event happens - replace later with sneeze / cough / infect code
        if(Input.GetMouseButtonDown(0))
        {
            clicked = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            clicked = false;
        }

    }

    // If an event happens within the trigger area, the senses are activated
    private void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.tag == "Sensor")
        {
            if (clicked)
            {
                if (collision.gameObject.GetComponent<SensoryScript>().isHearing)
                    collision.gameObject.GetComponent<SensoryScript>().Hearing = true;
                else
                    collision.gameObject.GetComponent<SensoryScript>().Seeing = true;
            }
        }
    }

    // Senses are disabled upon leaving trigger area
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Sensor")
        {
            collision.gameObject.GetComponent<SensoryScript>().Hearing = false;
            collision.gameObject.GetComponent<SensoryScript>().Seeing = false;
        }
    }
}
