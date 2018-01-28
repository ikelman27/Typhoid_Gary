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

    public float randMin;
    public float randMax;

    public bool isBoss;
    public float wanderRad;
    public float wanderTimer;
    private float timer;
    private NavMeshAgent agent;
 
    
	// Use this for initialization
	void Start () {
        target = moveToTargets[0];
        reachedTarget = false;
        agent = GetComponent<NavMeshAgent>();

    }
	
	// Update is called once per frame
	void Update () {
        ReachedTargetPause();
        float dist = Vector3.Distance(this.gameObject.transform.position, target.transform.position);
        //Debug.Log(dist);
        if (dist < tarDistance)
        {
            reachedTarget = true;
            if (isBoss)
            {
                BossWander();
            }
            if(isBoss ==false )
            {
                agent.destination = transform.position;
            }
        }
        if(reachedTarget==false)
        {
            agent.destination = target.transform.position;
            //Debug.Log("target:" + target);
        }
    }

    public void ReachedTargetPause()
    {
        if (reachedTarget == true)
        {
            if (!gameObject.GetComponent<InfectScript>().isInfected && target.GetComponent<InfectScript>() != null)
            {
                if (target.GetComponent<InfectScript>().isInfected)
                {
                    gameObject.GetComponent<InfectScript>().infectPerson();
                }
            }
            randPause -= 1.0f * Time.deltaTime;
  
            if (randPause <= 0)
            {
                reachedTarget = false;
                PickNewItem();
            }

        }
    }

    public void PickNewItem()
    {
        int rand = Random.Range(0, moveToTargets.Count);
        target = moveToTargets[rand];
        float pausingBase = 0.0f;
        pausingBase = Random.Range(randMin, randMax);
        randPause = pausingBase;// * 10;

    }
    public void BossWander()
    {
        timer += Time.deltaTime;
        if(timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRad, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }

    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDir = Random.insideUnitSphere * dist;
        randDir += origin;
        NavMeshHit agentHit;
        NavMesh.SamplePosition(randDir, out agentHit, dist, layermask);
        return agentHit.position;
        
    }
}
