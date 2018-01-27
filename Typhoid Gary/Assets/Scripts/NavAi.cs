using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NavAi : MonoBehaviour {

    public List<GameObject> moveToTargets;
    private GameObject target;
    private bool reachedTarget;
    public float tarDistance;
    private float currTimer = 0;
    private float reachedTimer;
    private float randPause;
 
    
	// Use this for initialization
	void Start () {
        target = moveToTargets[0];
        reachedTarget = false;
	}
	
	// Update is called once per frame
	void Update () {
        ReachedTargetPause();
        float dist = Vector3.Distance(this.gameObject.transform.position, target.transform.position);
        //Debug.Log(dist);
        if (dist < tarDistance)
        {
            reachedTarget = true;
            GetComponent<NavMeshAgent>().destination = transform.position;
        }
        if(reachedTarget==false)
        {
            GetComponent<NavMeshAgent>().destination = target.transform.position;
            Debug.Log("target:" + target);
        }
    }

    public void ReachedTargetPause()
    {
        if (reachedTarget == true)
        {
            randPause -= 1.0f * Time.deltaTime;
            if(randPause <= 0)
            {
                reachedTarget = false;
                PickNewItem();
            }
        }
    }

    public void PickNewItem()
    {
        int rand = Random.Range(0, moveToTargets.Count);
        Debug.Log(rand);
        target = moveToTargets[rand];
        float pausingBase = 0.0f;
        pausingBase = Random.Range(1, 6);
        randPause = pausingBase;// * 10;

    }
}
