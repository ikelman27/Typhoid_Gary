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
        cough.transform.position = transform.position;
        //cough.transform.rotation =Quaternion.ro

        cough.Play();

    }

    // Update is called once per frame
    void Update () {
        
        if(timeStamp < Time.time - .1)
        {
            gameObject.SetActive(false);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Object")
        {
            Debug.Log(collision.gameObject.name);
        }
    }
}
