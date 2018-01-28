using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BossCheckScript : MonoBehaviour {

   
    bool bossInRoom;
    bool youInRoom;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if(bossInRoom && youInRoom)
        {
            SceneManager.LoadScene("YouGotCaught");
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Boss")
            bossInRoom = true;
        if (other.gameObject.name == "Player")
            youInRoom = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Boss")
            bossInRoom = false;
        if (other.gameObject.name == "Player")
            youInRoom = false;
    }
}
