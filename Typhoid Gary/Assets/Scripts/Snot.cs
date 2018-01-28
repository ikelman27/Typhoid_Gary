using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snot : MonoBehaviour {


    #region vars
   
    Vector3 snotDir;
    public float speed;
    public float maxDist;
    float currentDist;

    // Audio
    public AudioClip[] clips;
    public AudioSource sneezingClips;

    #endregion
    // Use this for initialization
    void Start () {
        sneezingClips = GetComponent<AudioSource>();
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

        // Plays random sneezing sound
        int i = Random.Range(0, clips.Length);
        sneezingClips.PlayOneShot(clips[2]);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 0 || other.gameObject.layer == 2)
        {
            if (other.gameObject.tag == "SickPoint")
            {
                other.GetComponent<InfectScript>().infectObject();
            }
            if (other.gameObject.tag == "Player"  || other.gameObject.tag == "Sensor")
            {

            }
            else
                gameObject.SetActive(false);
            //gameObject.SetActive(false);
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
