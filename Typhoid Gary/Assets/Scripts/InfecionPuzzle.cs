using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    public bool isInfected;
    public Material infectedMaterial;
    public GameObject diseaseBubbles;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void infectPerson()
    {
        isInfected = true;
        GameObject newDisease = Instantiate(diseaseBubbles, transform.position, Quaternion.identity);
        newDisease.transform.SetParent(gameObject.transform);

    }

    public void infectObject()
    {
        isInfected = true;
        gameObject.GetComponent<Renderer>().material.color = Color.green;
    }

    public bool getInfected()
    {
        return isInfected;
    }
}
