using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    #region variables
    private float speed;
    private Vector2 position;
    private GameObject player;
    private float rotation;

    #endregion


    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        position = player.transform.position;
       
	}
	
    
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("a"))
        {
            position.x -= .1f;
            rotation = 270;
        }

        if (Input.GetKey("d"))
        {
            position.x += .1f;
            rotation = 90;
        }

        if (Input.GetKey("w"))
        {
            position.y += .1f;
           

            if (Input.GetKey("a"))
            {
                rotation = 315;

            }
            else if (Input.GetKey("d"))
            {
                rotation  = 45;
            }
            else
            {
                rotation = 0;
            }

        }

        

        if (Input.GetKey("s"))
        {
            position.y -= .1f;


            if (Input.GetKey("a"))
            {
                rotation = 225;

            }
            else if (Input.GetKey("d"))
            {
                rotation =  135;
            }
            else
            {
                rotation = 180;
            }
        }

        

        


        movePlayer();
	}

    void movePlayer()
    {
        player.transform.rotation = Quaternion.Euler(player.transform.rotation.x, player.transform.rotation.y, rotation);
        player.transform.position = position;
       
    }
}
