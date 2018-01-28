using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
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
            Debug.Log("you got cought");
            SceneManager.LoadScene("YouGotCaught");
        }
        Debug.Log("boss in room: " + bossInRoom);
        Debug.Log("You in room: " + youInRoom);
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
