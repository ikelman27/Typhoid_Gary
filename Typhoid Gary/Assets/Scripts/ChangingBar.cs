using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ChangingBar : MonoBehaviour {

    //stuff relating to the cooldownbar
    public GameObject player;
    public float totalBar;//total max value out of
    private float currVal = 0;//the current value 
    public GameObject barVal;//the actual changing bar object
    public float increaseVal;
    public GameObject[] enemies;

    //cooldown display
    //the images for the acts
    public Image sneezImg;
    public Image coughImg;
    //the cooldown value
    public float snzCD;
    public float coughCD;
    //if they are currently on cool down
    public bool coughIsCD;
    public bool sneezeIsCD;


	// Use this for initialization
	void Start () {
        sneezeIsCD = false;
        coughIsCD = false;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1) && !coughIsCD)
        {
            ActivatCoughCD();
        }
        if (Input.GetMouseButtonDown(0) && !sneezeIsCD)
            ActivateSneezeCD();
        if(coughIsCD)
        {
            coughImg.fillAmount += 1 / coughCD * Time.deltaTime;
            if (coughImg.fillAmount >= 1)
            {
         
                coughIsCD = false;
            }
        }
        if(sneezeIsCD)
        {
            sneezImg.fillAmount += 1 / snzCD * Time.deltaTime;
            if(sneezImg.fillAmount >= 1)
            {
             
                sneezeIsCD = false;
            }
        }

        if (winGame())
        {
            //SceneManager.LoadScene(1);
            Debug.Log("you win");
        }
        if(currVal >= 100)
        {
            Debug.Log("you Lose");
        }
		
	}

    public void IncreaseSuspicion(float valueIncrease)
    {
        currVal += valueIncrease;
        barVal.transform.localScale = new Vector3((currVal / totalBar), 1, 1);
    }
    public void ActivatCoughCD()
    {
        coughImg.fillAmount = 0;
        coughIsCD = true;
    }
    public void ActivateSneezeCD()
    {
        sneezImg.fillAmount = 0;
        sneezeIsCD = true;
    }

    bool winGame()
    {

        for(int i = 0; i < enemies.Length; i++)
        {
            if (!enemies[i].GetComponent<InfectScript>().isInfected)
                return false;        
        }
        return true;
    }
}

