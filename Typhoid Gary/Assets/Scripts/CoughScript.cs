using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoughScript : MonoBehaviour {


    #region vars
    float timeStamp;
    public GameObject player;
    public ParticleSystem cough;
   
    #endregion
    // Use this for initialization
    void Start () {
	    
	}

    private void OnEnable()
    {
        timeStamp = Time.time;
        cough.transform.position =player.transform.position;

        cough.transform.rotation = player.transform.rotation*Quaternion.Euler(0, -90, 90);


        cough.Play();

    }

    // Update is called once per frame
    void Update () {
        
        if(timeStamp < Time.time - .1)
        {
            gameObject.SetActive(false);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Object")
        {
            Debug.Log(other.gameObject.name);
        }
    }
}
