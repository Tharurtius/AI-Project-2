using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DryadAI : AIMovement
{
    // Start is called before the first frame update
    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        index = 0;
        m_Agent.SetDestination(patrol[index].transform.position);//dryad starts off doing a ritual
    }

    // Update is called once per frame
    void Update()
    {
        if (AIDistance(gameObject, patrol[index]) <= 0.5f && GameManager.gateQuest == false)//goes back to doing ritual after quest
        {
            NextPatrol();
        }
        else if (AIDistance(gameObject, waypoints[0]) <= 0.5f)
        {
            //open city gate, remove key
            GameManager.OpenGate();
            waypoints[0].SetActive(false);
            index = 0;
            m_Agent.SetDestination(patrol[index].transform.position);//back to the forest
        }
        else if (GameManager.gateQuest == true)
        {
            m_Agent.SetDestination(waypoints[0].transform.position);//go to guard tower
        }
        CheckAnim(m_Agent);
    }
}
