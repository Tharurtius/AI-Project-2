using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanAI : AIMovement
{
    // Start is called before the first frame update
    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        index = 0;
        m_Agent.SetDestination(waypoints[0].transform.position);//the epic journey of erica who lost her house keys
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints.Count == 0)
        {
            //do nothing
        }
        else if (!GameManager.gateQuest && AIDistance(gameObject, waypoints[0]) <= 0.5f)//follow waypoints
        {
            //check if door or key
            if (waypoints[0].tag == "Key")//get key
            {
                hasKey = true;
            }
            else if (waypoints[0].tag == "Door" && hasKey)//open door if you have key
            {
                GameManager.OpenDoor();
            }

            if (waypoints[0].tag == "GiveQuest")//give quest to dryad
            {
                GameManager.gateQuest = true;
                waypoints[0].tag = "Patrol";//change tag, will remove waypoint later
            }
            else//remove waypoints and move to next one
            {
                waypoints[0].SetActive(false);
                waypoints.Remove(waypoints[0]);
                if (waypoints.Count > 0)
                {
                    m_Agent.SetDestination(waypoints[0].transform.position);
                }
            }
        }
        CheckAnim(m_Agent);
    }
}
