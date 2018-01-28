using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snot : MonoBehaviour {


    #region vars
   
    Vector3 snotDir;
    public float speed;
    public float maxDist;
    float currentDist;
    #endregion
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isActiveAndEnabled)
        {
            if (currentDist <= maxDist)
            {
                gameObject.transform.position += snotDir * speed / 10;
                currentDist += Vector3.Magnitude( snotDir) * speed / 10;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
	}

    public void fireSnot(Vector3 direction)
    {
        currentDist = 0;
        snotDir = direction;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 0 || other.gameObject.layer == 2)
        {
            if (other.gameObject.tag == "SickPoint")
            {
                other.GetComponent<InfectScript>().infectObject();
            }
        }
        else if (other.gameObject.layer == 1)
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.GetComponent<InfectScript>().infectPerson();
            }
            if (other.gameObject.tag != "Player")
                gameObject.SetActive(false);
        }
    }
}
