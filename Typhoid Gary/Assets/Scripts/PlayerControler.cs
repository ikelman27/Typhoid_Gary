using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    #region variables
    private float speed;
    private Vector3 position;
    private GameObject player;
    Vector2 cameraPos;
    Vector2 mousePos;
    float angle;
    public GameObject snot;
    Vector3 snotDir;
    public float snezeCooldownTime;
    float snezeTimeStamp;
     float coughTimeStamp;
    public float coughCooldownTime;
 
    public GameObject coughCone;
    #endregion


    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        position = player.transform.position;
        snot.SetActive(false);
        snezeTimeStamp = snezeCooldownTime + Time.time;

    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("a"))
        {
            position.x -= .1f;

        }

        if (Input.GetKey("d"))
        {
            position.x += .1f;

        }

        if (Input.GetKey("w"))
        {
            position.z += .1f;

        }
        if (Input.GetKey("s"))
        {
            position.z -= .1f;

        }


        cameraPos = Camera.main.WorldToViewportPoint(transform.position);
        mousePos = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        angle = Mathf.Atan2(cameraPos.y - mousePos.y, cameraPos.x - mousePos.x) * Mathf.Rad2Deg;

        if (Input.GetMouseButtonDown(0))
        {
            sneeze();
        }

        if (Input.GetMouseButtonDown(1))
        {
            cough();
        }


        if (coughTimeStamp > Time.time)
        {
            //coughCone.SetActive(false);
        }
            movePlayer();
    }


    void movePlayer()
    {
        player.transform.rotation = Quaternion.Euler(new Vector3(0f, -angle, 0f));
        player.transform.position = position;
    }



    void sneeze()
    {
        if (snezeTimeStamp <= Time.time)
        {
            snot.transform.position = player.transform.position;
            snot.SetActive(true);
            snot.GetComponent<Snot>().fireSnot(-player.transform.right);
            snezeTimeStamp = snezeCooldownTime + Time.time;
        }
    }

    void cough()
    {
        if(coughTimeStamp <= Time.time)
        {

            coughCone.SetActive(true);
            coughTimeStamp = coughCooldownTime + Time.time;
        }
        
    }
}
