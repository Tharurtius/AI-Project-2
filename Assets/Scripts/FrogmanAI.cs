using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FrogmanAI : AIMovement
{
    bool _goneFishing;
    // Start is called before the first frame update
    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        index = 0;
        m_Agent.SetDestination(patrol[index].transform.position);//frogman is locked out of his house
        _goneFishing = false;//tag to prevent waypoint from constantly being set
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.frogDoor.activeSelf == true && AIDistance(gameObject, patrol[index]) <= 0.5f)//frogman locked himself out of his house
        {
            NextPatrol();
        }
        else if (waypoints.Count == 0)//fishing trip is finished
        {
            //do nothing
        }
        else if (AIDistance(gameObject, waypoints[0]) <= 0.5f && _goneFishing)//fishing trip
        {
            waypoints[0].SetActive(false);
            waypoints.Remove(waypoints[0]);
            if (waypoints.Count > 0)
            {
                m_Agent.SetDestination(waypoints[0].transform.position);
            }
        }
        else if (GameManager.frogDoor.activeSelf == false && !_goneFishing)
        {
            _goneFishing = true;
            m_Agent.SetDestination(waypoints[0].transform.position);
        }
        CheckAnim(m_Agent);
        ChangeAreaSpeed();
    }
    void ChangeAreaSpeed()//swim speed boost
    {
        NavMeshHit navHit;
        m_Agent.SamplePathPosition(areaMask: -1, maxDistance: 0.0f, out navHit);
        //Debug.Log(navHit.mask);
        int SwimMask = 1 << NavMesh.GetAreaFromName("Swim");
        if ((navHit.mask & SwimMask) > 0)//if there is a swim mask
        {
            m_Agent.speed = 10f;
            m_Agent.acceleration = 24f;
        }
        else
        {
            m_Agent.speed = 3.5f;
            m_Agent.acceleration = 8;
        }
    }
}
