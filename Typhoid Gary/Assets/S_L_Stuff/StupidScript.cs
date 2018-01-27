using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidScript : MonoBehaviour {

    public GameObject box;
    public bool clicked;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            box.transform.position = hit.point;
        box.transform.position = new Vector3(box.transform.position.x, 1.0f, box.transform.position.z);
        if (!Input.GetMouseButton(0))
        {
            clicked = false;
        }

        Debug.Log(clicked);
	}

    private void OnMouseDown()
    {
        clicked = true;
    }
}
