using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    #region ContorlerVariables
    public float speed = 5;
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
    private Rigidbody rigid;
    public GameObject coughCone;
    #endregion

    #region enemyDectVars
    public GameObject box;
    public bool clicked;
    #endregion



    // Use this for initialization
    void Start()
    {
        //find the 
        player = GameObject.Find("Player");
        position = player.transform.position;
        snot.SetActive(false);
        snezeTimeStamp = snezeCooldownTime + Time.time;
        rigid = player.GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        /**
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
        **/

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
        //position = transform.position;
    }


    void movePlayer()
    {
        player.transform.rotation = Quaternion.Euler(new Vector3(0f, -angle, 0f));

        if(Input.GetKey(KeyCode.W)){
            player.transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
            //rigid.AddForce(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);


        }
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
        }

        //player.transform.Translate(position);
        //player.transform.position = new Vector3(player.transform.position.x, .1f, player.transform.position.z);
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


    // If an event happens within the trigger area, the senses are activated
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Sensor")
        {
            if (clicked)
            {
                if (collision.gameObject.GetComponent<SensoryScript>().isHearing)
                    collision.gameObject.GetComponent<SensoryScript>().Hearing = true;
                else
                    collision.gameObject.GetComponent<SensoryScript>().Seeing = true;
            }
        }
    }

    // Senses are disabled upon leaving trigger area
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Sensor")
        {
            collision.gameObject.GetComponent<SensoryScript>().Hearing = false;
            collision.gameObject.GetComponent<SensoryScript>().Seeing = false;
        }
    }
}
