using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class CoughScript : MonoBehaviour {


    #region vars

    float timeStamp;
    public GameObject player;
    public ParticleSystem cough;

    // Audio
    public AudioClip[] clips;
    public AudioSource coughingClips;

    #endregion
    // Use this for initialization
    void Start () {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        // Plays random coughing sound
        int i = Random.Range(0, clips.Length);
        coughingClips.PlayOneShot(clips[i]);

        timeStamp = Time.time;

        cough.transform.position =player.transform.position;

        cough.transform.rotation = player.transform.rotation*Quaternion.Euler(0, -90, 90);


        

        cough.Play();
    }

    // Update is called once per frame
    void Update () {

        if (timeStamp < Time.time - .1)
        {
            gameObject.SetActive(false);
        }
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
            RaycastHit hit;

            //Debug.Log("Other: " + other.gameObject.name);

            if (other.GetComponent<CapsuleCollider>())
            {
                if (!Physics.Raycast(player.transform.position, other.transform.position - player.transform.position, out hit, Vector3.Magnitude(other.transform.position - player.transform.position) - other.GetComponent<CapsuleCollider>().radius))
                {
                    /*Debug.Log("TAG: " + other.gameObject.tag);
                    Debug.Log("NAME: " + other.gameObject.name);
                    Debug.Log("Found something with raycast");*/

                    if (other.gameObject.tag == "Enemy")
                    {
                        other.GetComponent<InfectScript>().infectPerson();
                    }
                }
                //Debug.Log("HIT: " + hit.transform.gameObject.name);
            }
        }
      
      
    }
   
}
